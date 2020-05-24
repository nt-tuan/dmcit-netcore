using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Infrastructure.Events.SendMessageEvent
{
    public class SendMessageFailedEvent : BaseDomainEvent
    {
        public SentMessage Message { get; set; }
        public string Reason { get; set; }
    }
}
