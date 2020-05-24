using DMCIT.Infrastructure.Events.Workflows;
using DMCIT.Web.ApiModels.Workflows;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace DMCIT.Web.Hubs.WorkflowHub
{
    public class WorkflowHubHandler :
        INotificationHandler<OnWorkflowStartEvent>,
        INotificationHandler<OnWorkflowEndEvent>,
        INotificationHandler<OnWorkflowTaskStartEvent>,
        INotificationHandler<OnWorkflowTaskEndEvent>,
        INotificationHandler<OnWorkflowTaskChangeEvent>
    {
        static readonly string WORKFLOW_START_METHOD = "WorkflowStart";
        static readonly string WORKFLOW_END_METHOD = "WorkflowEnd";
        static readonly string WORKFLOW_TASK_START_METHOD = "WorkflowTaskStart";
        static readonly string WORKFLOW_TASK_CHANGE_METHOD = "WorkflowTaskChange";
        static readonly string WORKFLOW_TASK_END_METHOD = "WorkflowTaskEnd";
        private readonly IHubContext<WorkflowHub> _hub;
        public WorkflowHubHandler(IHubContext<WorkflowHub> hub)
        {
            _hub = hub;
        }

        public async Task Handle(OnWorkflowStartEvent notification, CancellationToken cancellationToken)
        {
            var wf = notification.Entity;
            cancellationToken.ThrowIfCancellationRequested();
            await _hub.Clients.Groups(WorkflowHub.GetWorkflowGroup(wf.Root.Id), WorkflowHub.GetWorkflowInstanceGroup(wf.InstanceId)).SendAsync(WORKFLOW_START_METHOD, new WorkflowInstanceModel(wf), cancellationToken);
        }

        public async Task Handle(OnWorkflowEndEvent notification, CancellationToken cancellationToken)
        {
            var wf = notification.Entity;
            cancellationToken.ThrowIfCancellationRequested();

            await _hub.Clients.Groups(WorkflowHub.GetWorkflowGroup(wf.Root.Id), WorkflowHub.GetWorkflowInstanceGroup(wf.InstanceId)).SendAsync(WORKFLOW_END_METHOD, new WorkflowInstanceModel(wf), cancellationToken);
        }

        public async Task Handle(OnWorkflowTaskStartEvent notification, CancellationToken cancellationToken)
        {
            var task = notification.Entity;
            cancellationToken.ThrowIfCancellationRequested();
            await _hub.Clients.Groups(WorkflowHub.GetWorkflowInstanceGroup(task.Workflow.InstanceId)).SendAsync(WORKFLOW_TASK_START_METHOD, new WorkingWorkflowTaskModel(task), cancellationToken);
        }

        public async Task Handle(OnWorkflowTaskChangeEvent notification, CancellationToken cancellationToken)
        {
            var task = notification.Entity;
            cancellationToken.ThrowIfCancellationRequested();
            await _hub.Clients.Groups(WorkflowHub.GetWorkflowInstanceGroup(task.Workflow.InstanceId)).SendAsync(WORKFLOW_TASK_CHANGE_METHOD, new WorkingWorkflowTaskModel(task), cancellationToken);
        }

        public async Task Handle(OnWorkflowTaskEndEvent notification, CancellationToken cancellationToken)
        {
            var task = notification.Entity;
            cancellationToken.ThrowIfCancellationRequested();
            await _hub.Clients.Groups(WorkflowHub.GetWorkflowInstanceGroup(task.Workflow.InstanceId)).SendAsync(WORKFLOW_TASK_END_METHOD, new WorkingWorkflowTaskModel(task), cancellationToken);
        }
    }
}
