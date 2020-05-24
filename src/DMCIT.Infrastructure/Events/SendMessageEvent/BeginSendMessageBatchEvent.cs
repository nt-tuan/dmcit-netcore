using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.SharedKernel;
using System.Collections.Generic;

namespace DMCIT.Infrastructure.Events.SendMessageEvent
{
    public class BeginSendMessageBatchEvent : BaseDomainEvent
    {
        public MessageBatch Batch { get; set; }
        public IEnumerable<SentMessage> Mesasges { get; set; }
        public AppUser Actor { get; set; }
    }
}
