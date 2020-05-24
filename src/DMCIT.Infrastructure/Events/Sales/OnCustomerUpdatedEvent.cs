using DMCIT.Core.Entities.Sales;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Infrastructure.Events.Sales
{
    public class OnCustomerUpdatedEvent : BaseDomainEvent
    {
        public Customer Entity { get; set; }
    }
}
