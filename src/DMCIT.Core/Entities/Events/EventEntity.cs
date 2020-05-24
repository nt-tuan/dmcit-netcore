using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.Events
{
    public class EventEntity : BaseEntity
    {
        public string ModelName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
