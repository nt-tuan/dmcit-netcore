using DMCIT.Core.Entities.Sales;
using DMCIT.Infrastructure.Events.Sales;
using MediatR;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Services
{
    public interface ISaleService
    {
        Task OnCustomerUpdated(Customer entity);
        Task OnCustomerAdded(Customer entity);
    }
    public class SaleService : ISaleService
    {
        private IMediator _mediator;
        public SaleService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnCustomerAdded(Customer entity)
        {
            await _mediator.Publish(new OnCustomerCreatedEvent
            {
                Entity = entity
            });
        }

        public async Task OnCustomerUpdated(Customer entity)
        {
            await _mediator.Publish(new OnCustomerUpdatedEvent
            {
                Entity = entity
            });
        }
    }
}
