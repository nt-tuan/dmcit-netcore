using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.Messaging
{
    public class MessageSource : BaseVersionControlEntity<MessageSource>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
    }
}
