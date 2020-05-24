using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Posts;
using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<Post> CreatePost(Post post, AppUser actor);
        Task<PostComment> AddPostComment(PostComment comment, AppUser actor);
        Task<List<Post>> GetPostsByTags(GetListParams<Post> param, List<string> tags);
        Task<List<Post>> GetPosts(GetListParams<Post> param, AppUser user);
        Task<List<PostComment>> GetPostComments(int id, GetListParams<PostComment> param, AppUser user);
        Task<int> GetPostCommentsCount(int id, GetListParams<PostComment> param, AppUser user);
        Task<List<PostComment>> GetSubPostComment(int commentId, GetListParams<PostComment> param, AppUser user);
        Task<int> GetSubPostCommentCount(int id, GetListParams<PostComment> param, AppUser user);
        Task<Post> GetPostById(int id);
        Task UpdatePostTags(Post post, List<PostTag> tags, AppUser actor);

        Task<int> GetPostsCount(GetListParams<Post> param, AppUser user);

        //Updates
        Task UpdatePost(Post entity, DateTime at, AppUser actor);
        Task AddAccessedUser(int postId, string userId, AppUser actor);
        Task RemoveAccessedUser(int postId, string userId, AppUser actor);
    }
}
