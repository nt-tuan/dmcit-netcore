using DMCIT.Core.SharedKernel;
using System;

namespace DMCIT.Core.Entities.Messaging
{
    public class SentMessage : BaseEntity
    {
        public enum SentMessageStatus { WAITING = 2, SENDING = 1, SENT = 3, ERROR = -1 }
        public string Content { get; set; }
        public int Status { get; set; }
        public ReceiverProvider ReceiverProvider { get; set; }
        public int ReceiverProviderId { get; set; }
        public string ResponseMessage { get; set; }
        public DateTime? ResponseTime { get; set; }
        public DateTime? SentTime { get; set; }

        public MessageBatch MessageBatch { get; set; }
        public int MessageBatchId { get; set; }
        public SentMessage()
        {
            Status = (int)SentMessageStatus.WAITING;
        }
        public SentMessage(string content, int receiverProviderId) : this()
        {
            Content = content;
            ReceiverProviderId = receiverProviderId;

        }
    }
}
