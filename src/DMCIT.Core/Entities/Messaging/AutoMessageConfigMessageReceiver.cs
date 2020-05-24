using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.Messaging
{
    public class AutoMessageConfigMessageReceiver : BaseVersionControlEntity<AutoMessageConfigMessageReceiver>
    {
        public int MessageReceiverId { get; set; }
        public MessageReceiver MessageReceiver { get; set; }

        public int AutoMessageConfigId { get; set; }
        public AutoMessageConfig AutoMessageConfig { get; set; }
    }
}
