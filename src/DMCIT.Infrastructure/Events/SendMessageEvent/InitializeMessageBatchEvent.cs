using DMCIT.Core.Entities.Core;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Infrastructure.Events.SendMessageEvent
{
    public class InitializeMessageBatchEvent : BaseDomainEvent
    {
        public int BatchId { get; set; }
        public AppUser Actor { get; set; }
    }
}
