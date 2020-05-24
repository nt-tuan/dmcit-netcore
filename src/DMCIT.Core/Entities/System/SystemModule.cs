using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.System
{
    public class SystemModule : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
