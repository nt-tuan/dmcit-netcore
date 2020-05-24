using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Posts;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Infrastructure.Events.Posts
{
    public class OnPostAddEvent : BaseDomainEvent
    {
        public Post Entity { get; set; }
        public OnPostAddEvent(Post e, AppUser actor)
        {
            Entity = e;
            Actor = actor;
        }
    }
}
