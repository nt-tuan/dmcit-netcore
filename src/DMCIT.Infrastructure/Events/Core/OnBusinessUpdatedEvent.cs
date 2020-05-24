using DMCIT.Core.Entities.Core;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Infrastructure.Events.Core
{
    public class OnBusinessUpdatedEvent : BaseDomainEvent
    {
        public Business Entity { get; set; }
    }
}
