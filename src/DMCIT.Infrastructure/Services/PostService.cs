using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Posts;
using DMCIT.Infrastructure.Events.Posts;
using MediatR;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Services
{
    public interface IPostService
    {
        Task OnAddComment(PostComment comment, AppUser actor);
        Task OnAddSubComment(PostComment comment, AppUser actor);
        Task OnAddPost(Post post, AppUser actor);
        Task OnViewPost(Post post, AppUser actor);
    }

    public class PostService : IPostService
    {
        private readonly IMediator _mediator;
        public PostService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnAddComment(PostComment comment, AppUser actor)
        {
            await _mediator.Publish(new OnCommentAddEvent(comment, actor));
        }

        public async Task OnAddSubComment(PostComment comment, AppUser actor)
        {
            await _mediator.Publish(new OnCommentLevel2AddEvent(comment, actor));
        }

        public async Task OnAddPost(Post post, AppUser actor)
        {
            await _mediator.Publish(new OnPostAddEvent(post, actor));
        }

        public async Task OnViewPost(Post post, AppUser actor)
        {
            await _mediator.Publish(new OnViewPostEvent(post, actor));
        }
    }
}
