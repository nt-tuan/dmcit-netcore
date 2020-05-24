using DMCIT.Core.SharedKernel;

namespace DMCIT.Infrastructure.Events.SendMessageEvent
{
    public class SendMessageBatchFaildEvent : BaseDomainEvent
    {
        public int BatchId { get; set; }
        public string Reason { get; set; }
    }
}
