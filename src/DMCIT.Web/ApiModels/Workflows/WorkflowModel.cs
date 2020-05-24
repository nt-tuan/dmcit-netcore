using DMCIT.Core.Entities.Workflow;
using DMCIT.Infrastructure.Data.Workflow;
using Hangfire;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMCIT.Web.ApiModels.Workflows
{
    public class WorkflowModel
    {
        public int? Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int LaunchType { get; set; } = (int)Infrastructure.Data.Workflow.LaunchType.Trigger;
        public string Period { get; set; } = "";
        public string CronExpression { get; set; } = "";
        public bool Enabled { get; set; } = true;
        public bool Approval { get; set; } = false;
        public bool StopWhenError { get; set; } = false;
        public bool EnableParallelJobs { get; set; } = false;
        public HashSet<string> Executors { get; set; }
        public Dictionary<string, string> LocalVariables { get; set; } = new Dictionary<string, string>();
        public Dictionary<int, WorkflowTaskModel> Tasks { get; set; } = new Dictionary<int, WorkflowTaskModel>();
        public Dictionary<string, WorkflowParameter> Parameters { get; set; }
        public WorkflowModel() { }
        public WorkflowModel(DefinedWorkflow w)
        {
            Id = w.Id;
            Name = w.Name;
            Description = w.Description;
            LaunchType = (int)w.LauchType;
            Period = w.Period.ToString();
            CronExpression = w.CronExpression;
            Enabled = w.IsEnabled;
            Approval = w.IsApproval;
            StopWhenError = w.StopWhenError;

            LocalVariables = w.GetLocalVariables();
            Parameters = w.GetParameters();

            EnableParallelJobs = w.EnableParallelJobs;
            Tasks = w.GetWorkflowTasks().ToDictionary(u => u.Key, u => new WorkflowTaskModel(u.Value));
            Executors = new HashSet<string>();
            if (w.UserWorkflows != null)
            {
                foreach (var item in w.UserWorkflows)
                {
                    Executors.Add(item.AppUserId);
                }
            }
        }

        public DefinedWorkflow ToEntity()
        {
            DefinedWorkflow dw = new DefinedWorkflow
            {
                Name = Name,
                Description = Description,
                LauchType = LaunchType
            };
            TimeSpan.TryParse(Period, out TimeSpan timeSpan);
            dw.Period = timeSpan.ToString();
            try
            {
                var cron = NCrontab.CrontabSchedule.TryParse(CronExpression);
                dw.CronExpression = cron.ToString();
            }
            catch
            {
                dw.CronExpression = Cron.Never();
            }
            dw.IsEnabled = Enabled;
            dw.IsApproval = Approval;
            dw.StopWhenError = StopWhenError;
            dw.EnableParallelJobs = EnableParallelJobs;
            dw.LocalVariablesJSON = JsonConvert.SerializeObject(LocalVariables);
            var taskEntities = Tasks.ToDictionary(u => u.Key, u => u.Value.ToEntity());
            dw.TasksJSON = JsonConvert.SerializeObject(taskEntities);
            dw.ParametersJSON = JsonConvert.SerializeObject(Parameters);
            if (Executors != null)
                dw.UserWorkflows = Executors.Select(u => new UserWorkflow
                {
                    AppUserId = u
                }).ToList();
            else
                dw.UserWorkflows = new List<UserWorkflow>();
            return dw;
        }
    }

    public class WorkflowInstanceModel
    {
        public int Id { get; set; }
        public string InstanceId { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public List<WorkingWorkflowTaskModel> Tasks { get; set; }
        public WorkflowInstanceModel() { }
        public WorkflowInstanceModel(WorkingWorkflow wf)
        {
            Id = wf.Root.Id;
            InstanceId = wf.InstanceId.ToString();
            Parameters = wf.Parameters;
            Tasks = wf.Tasks.Select(u => new WorkingWorkflowTaskModel(u)).ToList();
        }
    }
}
