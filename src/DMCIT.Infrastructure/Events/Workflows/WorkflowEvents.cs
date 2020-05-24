using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Data.Workflow;

namespace DMCIT.Infrastructure.Events.Workflows
{
    public class OnWorkflowStartEvent : BaseDomainEvent
    {
        public WorkingWorkflow Entity { get; set; }
    }
    public class OnWorkflowTaskStartEvent : BaseDomainEvent
    {
        public WorkflowTask Entity { get; set; }
    }
    public class OnWorkflowTaskChangeEvent : BaseDomainEvent
    {
        public WorkflowTask Entity { get; set; }
    }
    public class OnWorkflowTaskEndEvent : BaseDomainEvent
    {
        public WorkflowTask Entity { get; set; }
    }

    public class OnWorkflowEndEvent : BaseDomainEvent
    {
        public WorkingWorkflow Entity { get; set; }
    }
}
