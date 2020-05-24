using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Posts;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Infrastructure.Events.Posts
{
    public class OnCommentAddEvent : BaseDomainEvent
    {
        public PostComment Entity { get; set; }
        public OnCommentAddEvent(PostComment e, AppUser a)
        {
            Entity = e;
            Actor = a;
        }
    }
}
