using DMCIT.Core.Entities.Core;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.Posts
{
    public class PostTag : BaseEntity
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
