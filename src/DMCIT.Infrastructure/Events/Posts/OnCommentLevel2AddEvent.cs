using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Posts;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Infrastructure.Events.Posts
{
    public class OnCommentLevel2AddEvent : BaseDomainEvent
    {
        public PostComment Entity { get; set; }
        public OnCommentLevel2AddEvent(PostComment e, AppUser actor)
        {
            Entity = e;
            Actor = actor;
        }
    }
}
