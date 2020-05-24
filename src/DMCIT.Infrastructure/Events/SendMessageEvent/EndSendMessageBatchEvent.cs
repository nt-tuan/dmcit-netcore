using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Infrastructure.Events.SendMessageEvent
{
    public class EndSendMessageBatchEvent : BaseDomainEvent
    {
        public MessageBatch Batch { get; set; }
        public AppUser Actor { get; set; }
    }
}
