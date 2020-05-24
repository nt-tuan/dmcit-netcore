using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Infrastructure.Events.SendMessageEvent
{
    public class SendMessageSuccessEvent : BaseDomainEvent
    {
        public SentMessage Message { get; set; }
    }
}
