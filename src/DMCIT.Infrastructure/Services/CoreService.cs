using DMCIT.Core.Entities.Core;
using DMCIT.Infrastructure.Events.Core;
using MediatR;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Services
{
    public interface ICoreService
    {
        Task OnPersonUpdated(Person entity);
        Task OnBusinessUpdated(Business entity);
    }
    public class CoreService : ICoreService
    {
        private IMediator _mediator;
        public CoreService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task OnBusinessUpdated(Business entity)
        {
            await _mediator.Publish(new OnBusinessUpdatedEvent
            {
                Entity = entity
            });
        }

        public async Task OnPersonUpdated(Person entity)
        {
            await _mediator.Publish(new OnPersonUpdatedEvent
            {
                Entity = entity
            });
        }
    }
}
