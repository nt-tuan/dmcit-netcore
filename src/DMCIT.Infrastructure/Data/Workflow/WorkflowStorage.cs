using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Workflow;
using DMCIT.Core.Interfaces;
using DMCIT.Infrastructure.Services;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMCIT.Infrastructure.Data.Workflow
{
    /// <summary>
    /// Wexflow engine.
    /// </summary>
    public class WorkflowStorage
    {
        public static string WORKFLOW_ADMIN_ROLE = "workflow.admin";
        public static string WORKFLOW_EXECUTOR_ROLE = "workflow.executor";
        ILogger Logger;

        /// <summary>
        /// List of the Workflows loaded by Wexflow engine.
        /// </summary>
        public IList<Workflow> Workflows { get; private set; }


        /// <summary>
        /// Global variables.
        /// </summary>
        public List<Variable> GlobalVariables { get; set; } = new List<Variable>();
        /// <summary>
        /// Database
        /// </summary>
        readonly IWorkflowRepository _rep;
        readonly IWorkflowService _service;
        readonly WorkflowSetting _setting;
        readonly IServiceProvider _serviceProvider;
        /// <summary>
        /// Creates a new instance of Wexflow engine.
        /// </summary>
        /// <param name="settingsFile">Settings file path.</param>
        public WorkflowStorage(ISettingRepository setting, IWorkflowRepository database, IWorkflowService service, ILogger<IWorkflowRepository> logger, IServiceProvider sp)
        {
            _serviceProvider = sp;
            _service = service;
            var settingStore = setting.GetSettingStore();
            _setting = settingStore.GetSetting<WorkflowSetting>();
            Workflows = new List<Workflow>();
            Logger = logger;
            Logger.LogInformation("");
            Logger.LogInformation("Starting Wexflow Engine");

            _rep = database;

            if (_rep != null)
            {
                _rep.Init().Wait();
            }

            LoadGlobalVariables();

            LoadWorkflows();
        }

        /// <summary>
        /// Checks whether a cron expression is valid or not.
        /// </summary>
        /// <param name="expression">Cron expression</param>
        /// <returns></returns>
        public static bool IsCronExpressionValid(string expression)
        {
            bool res = CronExpression.IsValidExpression(expression);
            return res;
        }

        private void LoadGlobalVariables()
        {
            XDocument xdoc = XDocument.Load(_setting.GlobalVariablesFile);

            foreach (var xvariable in xdoc.Descendants("Variable"))
            {
                Variable variable = new Variable
                {
                    Key = xvariable.Attribute("name").Value,
                    Value = xvariable.Attribute("value").Value
                };
                GlobalVariables.Add(variable);
            }
        }

        private void LoadWorkflows()
        {
            var workflows = _rep.GetWorkflows().Result;

            foreach (var workflow in workflows)
            {
                var wf = LoadWorkflowFromDatabase(workflow);
                Workflows.Add(wf);
            }
        }

        public Workflow LoadWorkflowFromDatabase(DefinedWorkflow workflow)
        {
            try
            {
                var wf = new Workflow(
                    _setting,
                    new ConcurrentDictionary<Guid, WorkingWorkflow>(),
                    workflow,
                    GlobalVariables.ToArray());

                Logger.LogInformation("Workflow loaded: {0}", wf);
                return wf;
            }
            catch (Exception e)
            {
                Logger.LogError("An error occured while loading the workflow : {0} Please check the workflow configuration. Error: {1}", workflow.Id, e.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets a workflow.
        /// </summary>
        /// <param name="workflowId">Workflow Id.</param>
        /// <returns></returns>
        public Workflow GetWorkflow(int workflowId)
        {
            return Workflows.FirstOrDefault(wf => wf.Id == workflowId);
        }
        public IEnumerable<Workflow> GetWorkflows()
        {
            return Workflows;
        }
        public async Task<Guid> InitializeWorkflow(Workflow wf, Dictionary<string, string> parameters)
        {
            //wf.Parameters = parameters;
            if (wf.Jobs.Count > 0 && !wf.EnableParallelJobs)
            {
                return Guid.Empty;
            }

            var workingWf = Activator.CreateInstance(typeof(WorkingWorkflow), wf, parameters) as WorkingWorkflow;
            wf.ReadyJobs.TryAdd(workingWf.InstanceId, workingWf);

            await _rep.IncrementRunningCount();

            var entry = await _rep.GetEntry(workingWf.Root.Id);
            if (entry == null)
            {
                var newEntry = new WorkflowEntry(workingWf.Root.DbEntity, parameters);
                await _rep.InsertEntry(newEntry);
            }
            else
            {
                entry.Status = Status.Running;
                entry.StatusDate = DateTime.Now;
                await _rep.UpdateEntry(entry);
            }
            return workingWf.InstanceId;
        }
        public async Task<Guid> PrepareStartingWorkflow(int workflowId, Dictionary<string, string> parameters)
        {
            var wf = GetWorkflow(workflowId);
            if (wf == null)
            {
                Logger.LogError("Workflow {0} not found.", workflowId);
            }
            else
            {
                if (wf.IsEnabled)
                {
                    var instanceId = await InitializeWorkflow(wf, parameters);
                    //var instanceId = await wf.Start(parameters);
                    return instanceId;
                }
            }
            return Guid.Empty;
        }
        public async Task StartWorkflow(int id, string instanceId)
        {
            var wf = GetWorkflow(id);
            wf.ReadyJobs.TryGetValue(Guid.Parse(instanceId), out WorkingWorkflow wwf);
            if (wwf != null)
            {
                var running = ActivatorUtilities.CreateInstance<WorkingWorkflow>(_serviceProvider, wwf);
                _ = wf.ReadyJobs.TryRemove(Guid.Parse(instanceId), out var _);
                _ = wf.Jobs.TryAdd(running.InstanceId, running);

                running.LoadTasks(_serviceProvider);
                await running.Start();
            }
        }

        public async Task UpdateWorkflow(DefinedWorkflow dw, AppUser actor)
        {
            await _rep.UpdateWorkflow(dw, actor);
            var updateWf = await _rep.GetWorkflow(dw.Id);

            var changedWorkflow = Workflows.SingleOrDefault(wf => wf.DbEntity.Id == updateWf.Id);

            if (changedWorkflow == null)
                throw new Exception($"Workflow {updateWf.Id} not found");

            StopCronJobs(changedWorkflow);
            Workflows.Remove(changedWorkflow);
            Logger.LogInformation("A change in the workflow {0} has been detected. The workflow will be reloaded.", changedWorkflow.Name);

            var updatedWorkflow = LoadWorkflowFromDatabase(updateWf);
            Workflows.Add(updatedWorkflow);
            await ScheduleWorkflow(updatedWorkflow);
        }

        public async Task<bool> StopWorkflow(int workflowId, string instanceId)
        {
            var wf = GetWorkflow(workflowId);
            if (wf == null)
            {
                Logger.LogError("Workflow {0} not found.", workflowId);
            }
            else
            {
                if (wf.IsEnabled)
                {
                    var innerWf = wf.Jobs.Where(kvp => kvp.Key.Equals(instanceId)).Select(kvp => kvp.Value).FirstOrDefault();

                    if (innerWf == null)
                    {
                        Logger.LogError("Instance {0} not found.", instanceId);
                    }
                    else
                    {
                        var rs = BackgroundJob.Delete(innerWf.JobId);
                        _ = wf.Jobs.TryRemove(new Guid(instanceId), out var _);
                        return rs;
                    }
                }
            }
            return false;
        }
        public async Task StopWorkflow(Workflow wf)
        {

        }

        public async Task<bool> ApproveWorkflow(int workflowId, string instanceIdStr)
        {
            try
            {
                Guid instanceId = Guid.Parse(instanceIdStr);
                var wf = GetWorkflow(workflowId);

                if (wf == null)
                {
                    Logger.LogError("Workflow {0} not found.", workflowId);
                    return false;
                }

                if (wf.IsApproval && wf.IsEnabled)
                {
                    wf.Jobs.TryGetValue(instanceId, out var innerWf);
                    if (innerWf == null)
                    {
                        Logger.LogError("Instance {0} not found.", instanceId);
                    }
                    else
                    {
                        lock (innerWf)
                        {
                            var rs = innerWf.Approve();
                            return rs;
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Logger.LogError("An error occured while approving the workflow {0}.", e, workflowId);
                return false;
            }
        }

        public async Task ContinueWorkflow(int id, string instanceIdStr)
        {
            var wf = GetWorkflow(id);
            var instanceId = Guid.Parse(instanceIdStr);
            wf.Jobs.TryGetValue(instanceId, out var running);

            if (running != null)
            {
                await running.Continue();
            }
        }

        public async Task<bool> DisapproveWorkflow(int workflowId, string instanceIdStr)
        {
            try
            {
                Guid instanceId = Guid.Parse(instanceIdStr);
                var wf = GetWorkflow(workflowId);

                if (wf == null)
                {
                    Logger.LogError("Workflow {0} not found.", workflowId);
                    return false;
                }

                if (wf.IsApproval && wf.IsEnabled)
                {
                    wf.Jobs.TryGetValue(instanceId, out var innerWf);
                    if (innerWf == null)
                    {
                        Logger.LogError("Instance {0} not found.", instanceId);
                    }
                    else
                    {
                        await innerWf.Disapprove();
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Logger.LogError("An error occured while approving the workflow {0}.", e, workflowId);
                return false;
            }
        }

        public async Task<DefinedWorkflow> AddWorkflow(DefinedWorkflow dw, AppUser actor)
        {
            int dbId = await _rep.InsertWorkflow(dw, actor);
            var wfFromDb = await _rep.GetWorkflow(dbId);
            var newWorkflow = LoadWorkflowFromDatabase(wfFromDb);
            Logger.LogInformation("New workflow {0} has been created. The workflow will be loaded.", newWorkflow.Name);
            Workflows.Add(newWorkflow);
            await ScheduleWorkflow(newWorkflow);
            return wfFromDb;
        }
        public async Task InsertUserWorkflowRelation(string userId, int workflowId)
        {
            try
            {
                await _rep.InsertUserWorkflowRelation(new UserWorkflow { AppUserId = userId, DefinedWorkflowId = workflowId });
            }
            catch (Exception e)
            {
                Logger.LogError("Error while inserting user workflow relation: {0}", e.Message);
            }
        }

        private void StopCronJobs(Workflow wf)
        {
            if (wf == null || wf.Jobs == null)
                return;
            foreach (var job in wf.Jobs.Values)
            {
                var jobId = job.JobId;
                RecurringJob.RemoveIfExists(jobId);
            }
        }

        private async Task ScheduleWorkflow(Workflow wf)
        {
            try
            {
                if (wf.IsEnabled)
                {
                    if (wf.LaunchType == (LaunchType.Startup))
                    {
                        foreach (var job in wf.Jobs.Values)
                        {
                            await job.Start();
                        }
                    }
                    else if (wf.LaunchType == LaunchType.Periodic)
                    {
                        foreach (var job in wf.Jobs.Values)
                        {
                            IDictionary<string, object> map = new Dictionary<string, object>();
                            map.Add("workflow", wf);
                            BackgroundJob.Schedule<WorkflowStorage>(u => u.StartWorkflow(wf.Id, job.InstanceId.ToString()), wf.Period);
                        }
                    }
                    else if (wf.LaunchType == LaunchType.Cron)
                    {
                        foreach (var job in wf.Jobs.Values)
                        {
                            IDictionary<string, object> map = new Dictionary<string, object>();
                            map.Add("workflow", wf);

                            string jobIdentity = "Workflow Job " + wf.Id;
                            //Start cron
                            RecurringJob.AddOrUpdate<WorkflowStorage>(u => u.StartWorkflow(wf.Id, job.InstanceId.ToString()), wf.CronExpression);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logger.LogError("An error occured while scheduling the workflow {0}: ", e, wf);
            }
        }

        /// <summary>
        /// Deletes a workflow from the database.
        /// </summary>
        /// <param name="dbId">DB ID.</param>
        public async Task DeleteWorkflow(int dbId)
        {
            try
            {
                await _rep.DeleteWorkflow(dbId);
                await _rep.DeleteUserWorkflowRelationsByWorkflowId(dbId);

                var removedWorkflow = Workflows.SingleOrDefault(wf => wf.DbEntity.Id == dbId);
                if (removedWorkflow != null)
                {
                    Logger.LogInformation("Workflow {0} is stopped and removed.", removedWorkflow.Name);
                    await StopWorkflow(removedWorkflow);

                    StopCronJobs(removedWorkflow);
                    Workflows.Remove(removedWorkflow);
                }

            }
            catch (Exception e)
            {
                Logger.LogError("Error while deleting a workflow: {0}", e.Message);
            }
        }

        /// <summary>
        /// Deletes workflows from the database.
        /// </summary>
        /// <param name="dbIds">DB IDs</param>
        public async Task<bool> DeleteWorkflows(int[] dbIds)
        {
            try
            {
                await _rep.DeleteWorkflows(dbIds);

                foreach (var dbId in dbIds)
                {
                    var removedWorkflow = Workflows.SingleOrDefault(wf => wf.DbEntity.Id == dbId);
                    if (removedWorkflow != null)
                    {
                        Logger.LogInformation("Workflow {0} is stopped and removed.", removedWorkflow.Name);
                        await StopWorkflow(removedWorkflow);

                        StopCronJobs(removedWorkflow);
                        Workflows.Remove(removedWorkflow);
                        await _rep.DeleteUserWorkflowRelationsByWorkflowId(removedWorkflow.DbEntity.Id);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Logger.LogError("Error while deleting workflows: {0}", e.Message);
                return false;
            }
        }

        /// <summary>
        /// Deletes user workflow relations.
        /// </summary>
        /// <param name="userId">User DB ID.</param>
        public void DeleteUserWorkflowRelations(string userId)
        {
            try
            {
                _rep.DeleteUserWorkflowRelationsByUserId(userId);
            }
            catch (Exception e)
            {
                Logger.LogError("Error while deleting user workflow relations of user {0}: {1}", userId, e.Message);
            }
        }

        /// <summary>
        /// Returns user workflows.
        /// </summary>
        /// <param name="userId">User DB ID.</param>
        /// <returns>User worklofws.</returns>
        public async Task<List<Workflow>> GetUserWorkflows(string userId)
        {
            try
            {
                var userWorkflows = (await _rep.GetUserWorkflows(userId)).ToArray();
                var workflows = Workflows.Where(w => userWorkflows.Contains(w.DbEntity.Id)).ToList();
                return workflows;
            }
            catch (Exception e)
            {
                Logger.LogError("Error while retrieving user workflows of user {0}: {1}", userId, e.Message);
                return new List<Workflow>();
            }
        }

        /// <summary>
        /// Checks whether a user have access to a workflow.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="workflowId">Workflow db id.</param>
        /// <returns>true/false.</returns>
        public async Task<bool> CheckUserWorkflow(string userId, int workflowId)
        {
            try
            {
                return await _rep.CheckUserWorkflow(userId, workflowId);
            }
            catch (Exception e)
            {
                Logger.LogError("Error while checking user workflows of user {0}: {1}", userId, e.Message);
                return false;
            }
        }
    }
}
