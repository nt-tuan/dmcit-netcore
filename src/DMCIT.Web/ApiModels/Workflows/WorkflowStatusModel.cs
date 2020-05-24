using DMCIT.Infrastructure.Data.Workflow;

namespace DMCIT.Web.ApiModels.Workflows
{
    public class WorkflowStatusModel
    {
        public bool isRunning { get; set; }
        public bool isWaitingForApproving { get; set; }
        public WorkflowStatusModel() { }
        public WorkflowStatusModel(WorkingWorkflow wf)
        {
            isRunning = wf.IsRunning;
            isWaitingForApproving = wf.IsWaitingForApproval;
        }
    }
}
