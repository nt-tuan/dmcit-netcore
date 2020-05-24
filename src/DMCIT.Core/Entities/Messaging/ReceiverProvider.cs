using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.Messaging
{
    public class ReceiverProvider : BaseVersionControlEntity<ReceiverProvider>
    {
        public int MessageReceiverId { get; set; }
        public MessageReceiver MessageReceiver { get; set; }
        public int MessageServiceProviderId { get; set; }
        public MessageServiceProvider MessageServiceProvider { get; set; }
        public string ReceiverAddress { get; set; }
    }
}
