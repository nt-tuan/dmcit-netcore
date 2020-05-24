using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Posts;
using DMCIT.Core.Interfaces;
using DMCIT.Web.ApiModels;
using DMCIT.Web.ApiModels.Posts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DMCIT.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly UserManager<AppUser> _user;
        private readonly IPostRepository _post;
        private readonly ICoreRepository _core;
        public PostController(IPostRepository post, ICoreRepository core, UserManager<AppUser> user)
        {
            _user = user;
            _post = post;
            _core = core;
        }
        // GET: api/<controller>
        [HttpPost]
        public async Task<BaseListModel<PostSummaryModel>> Get(TableParameter model)
        {
            var user = await _user.GetUserAsync(User);
            var param = model.ToEntityParam<Post>();
            var posts = await _post.GetPosts(param, user);
            var postModels = posts.Select(u => new PostSummaryModel(u));
            var postCount = await _post.GetPostsCount(param, user);
            var r = new BaseListModel<PostSummaryModel>(postModels, model.page, model.pageSize, postCount);
            return r;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDetailModel>> Get(int id)
        {
            var post = await _post.GetPostById(id);
            if (post == null) return NotFound();
            return new PostDetailModel(post);
        }

        [HttpPost]
        [Route("{id}/comments")]
        public async Task<ActionResult<BaseListModel<CommentModel>>> GetComments(int id, TableParameter parameter)
        {
            var user = await _user.GetUserAsync(User);
            var p = parameter.ToEntityParam<PostComment>();
            p.extension = query => p.extension(query).Where(u => u.PostId == id);
            var count = await _post.GetPostCommentsCount(id, p, user);
            var data = (await _post.GetPostComments(id, p, user)).Select(u => new CommentModel(u));
            var rs = new BaseListModel<CommentModel>(data, parameter.page, parameter.pageSize, count);
            return rs;
        }

        [HttpPost]
        [Route("comment/{id}/comments")]
        public async Task<ActionResult<BaseListModel<CommentModel>>> GetCommentLevel2s(int id, TableParameter parameter)
        {
            var user = await _user.GetUserAsync(User);
            var p = parameter.ToEntityParam<PostComment>();
            var count = await _post.GetSubPostCommentCount(id, p, user);
            var data = (await _post.GetSubPostComment(id, p, user)).Select(u => new CommentModel(u));
            var rs = new BaseListModel<CommentModel>(data, parameter.page, parameter.pageSize, count);
            return rs;
        }


        // POST api/<controller>
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<int>> Post(CreatePostModel model)
        {
            var user = await _user.GetUserAsync(User);
            var entity = model.ToEntity();
            var newPost = await _post.CreatePost(entity, user);
            return newPost.GetId();
        }

        //Add comment for a post
        [HttpPost]
        [Route("{id}/createComment")]
        public async Task<ActionResult<int>> CreateComment(int id, string content)
        {
            var user = await _user.GetUserAsync(User);
            var entity = new PostComment();
            entity.Content = content;
            entity.PostId = id;
            var comment = await _post.AddPostComment(entity, user);
            return comment.GetId();
        }

        //Add comment for a comment
        [HttpPost]
        [Route("comment/{id}/create")]
        public async Task<ActionResult<int>> CreateCommentLevel2(int id, string content)
        {
            var user = await _user.GetUserAsync(User);
            var entity = new PostComment();
            entity.Content = content;
            entity.ParentId = id;
            var comment = await _post.AddPostComment(entity, user);
            return comment.GetId();
        }
    }
}
