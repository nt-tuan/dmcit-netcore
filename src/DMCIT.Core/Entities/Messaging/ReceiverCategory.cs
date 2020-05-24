using DMCIT.Core.SharedKernel;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Messaging
{
    public class ReceiverCategory : BaseVersionControlEntity<ReceiverCategory>
    {
        public string Code { get; set; }
        public ICollection<MessageReceiver> MessageReceivers { get; set; }
        public string Name { get; set; }
    }
}
