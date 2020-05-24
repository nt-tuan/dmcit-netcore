using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.Messaging
{
    public class AutoMessageConfigMessageReceiverGroup : BaseVersionControlEntity<AutoMessageConfigMessageReceiverGroup>
    {
        public int AutoMessageConfigId { get; set; }
        public AutoMessageConfig AutoMessageConfig { get; set; }

        public int MessageReceiverGroupId { get; set; }
        public MessageReceiverGroup MessageReceiverGroup { get; set; }
    }
}
