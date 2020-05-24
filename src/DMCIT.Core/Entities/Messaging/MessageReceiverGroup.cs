using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMCIT.Core.Entities.Messaging
{
    public class MessageReceiverGroup : BaseVersionControlEntity<MessageReceiverGroup>
    {
        public Boolean IsPrivate { get; set; }
        public string Name { get; set; }
        public ICollection<MessageReceiverGroupMessageReceiver> MessageReceiverGroupMessageReceivers { get; set; }
        public ICollection<MessageReceiver> GetMessageReceivers()
        {
            return MessageReceiverGroupMessageReceivers.Select(u => u.MessageReceiver).ToList();
        }


    }
}
