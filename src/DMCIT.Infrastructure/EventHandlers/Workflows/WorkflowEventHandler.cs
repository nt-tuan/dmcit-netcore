using DMCIT.Infrastructure.Events.Workflows;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.DomainEvents.Handlers.Workflows
{
    public class WorkflowEventHandler : INotificationHandler<OnWorkflowStartEvent>
    {
        public async Task Handle(OnWorkflowStartEvent notification, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
        }
    }
}
