using DMCIT.Core.Entities.Workflow;
using Newtonsoft.Json;
using System.Linq;

namespace DMCIT.Web.ApiModels.Workflows
{
    public class UpdateWorkflowModel : WorkflowModel
    {
        public void UpdateEntity(DefinedWorkflow dw)
        {
            dw.Name = Name;
            dw.Description = Description;
            dw.LauchType = LaunchType;
            dw.Period = Period;
            dw.CronExpression = CronExpression;
            dw.IsEnabled = Enabled;
            dw.IsApproval = Approval;
            dw.StopWhenError = StopWhenError;
            dw.EnableParallelJobs = EnableParallelJobs;
            dw.LocalVariablesJSON = JsonConvert.SerializeObject(LocalVariables);
            var taskEntities = Tasks.ToDictionary(u => u.Key, u => u.Value.ToEntity());
            dw.TasksJSON = JsonConvert.SerializeObject(taskEntities);
            dw.ParametersJSON = JsonConvert.SerializeObject(Parameters);
            dw.UserWorkflows = Executors.Select(u => new UserWorkflow
            {
                DefinedWorkflowId = dw.Id,
                AppUserId = u
            }).ToList();
        }
    }
}
