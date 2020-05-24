using DMCIT.Core.Entities.Core;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Infrastructure.Events.Core
{
    public class OnPersonUpdatedEvent : BaseDomainEvent
    {
        public Person Entity { get; set; }
    }
}
