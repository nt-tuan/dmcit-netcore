using DMCIT.Core.Entities.Sales;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Infrastructure.Events.Sales
{
    public class OnCustomerCreatedEvent : BaseDomainEvent
    {
        public Customer Entity { get; set; }
    }
}
