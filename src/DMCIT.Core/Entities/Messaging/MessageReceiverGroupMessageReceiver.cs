using DMCIT.Core.SharedKernel;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Messaging
{
    public class MessageReceiverGroupMessageReceiver : BaseVersionControlEntity<MessageReceiverGroupMessageReceiver>
    {
        public int MessageReceiverId { get; set; }
        public MessageReceiver MessageReceiver { get; set; }

        public int MessageReceiverGroupId { get; set; }
        public MessageReceiverGroup MessageReceiverGroup { get; set; }

        public override bool Equals(BaseEntity x, BaseEntity y)
        {
            var mx = x as MessageReceiverGroupMessageReceiver;
            var my = y as MessageReceiverGroupMessageReceiver;
            return mx.MessageReceiverId == my.MessageReceiverId && mx.MessageReceiverGroupId == my.MessageReceiverGroupId;
        }

        public override int GetHashCode(BaseEntity obj)
        {
            return obj.GetHashCode();
        }

        public override int CompareTo(BaseEntity obj)
        {
            var mObj = obj as MessageReceiverGroupMessageReceiver;
            if (MessageReceiverGroupId == mObj.MessageReceiverGroupId && MessageReceiverId == mObj.MessageReceiverId)
                return 0;
            return Comparer<int>.Default.Compare(Id, obj.Id);
        }
    }
}
