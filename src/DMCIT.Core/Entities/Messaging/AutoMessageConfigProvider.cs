using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.Messaging
{
    public class AutoMessageConfigProvider : BaseVersionControlEntity<AutoMessageConfigProvider>
    {
        public int AutoMessageConfigId { get; set; }
        public AutoMessageConfig AutoMessageConfig { get; set; }

        public int MessageServiceProviderId { get; set; }
        public MessageServiceProvider MessageServiceProvider { get; set; }
    }
}
