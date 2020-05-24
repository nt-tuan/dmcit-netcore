using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Posts;
using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly IRepository _rep;
        private readonly AppDbContext _db;
        private readonly IPostService _service;
        public PostRepository(IRepository rep, AppDbContext db, IPostService service)
        {
            _rep = rep;
            _db = db;
            _service = service;
        }
        public async Task<PostComment> AddPostComment(PostComment comment, AppUser actor)
        {
            var e = await _rep.AddDetail(comment, DateTime.Now, actor);
            await _service.OnAddComment(e, actor);
            return e;
        }

        public async Task<Post> CreatePost(Post post, AppUser actor)
        {
            var e = await _rep.AddDetail(post, DateTime.Now, actor);
            await _service.OnAddPost(post, actor);
            return e;
        }

        public async Task<Post> GetPostById(int id)
        {
            var post = await _rep.GetById<Post>(id);
            return post;
        }

        public async Task<List<PostComment>> GetSubPostComment(int commentId, GetListParams<PostComment> param, AppUser user)
        {
            param.extension = query => query.Where(u => u.ParentId == commentId);
            return await _rep.ListVersionControl(param);
        }

        public async Task<int> GetSubPostCommentCount(int commentId, GetListParams<PostComment> param, AppUser user)
        {
            param.extension = query => query.Where(u => u.ParentId == commentId);
            return await _rep.CountDetail(param);
        }

        public async Task<bool> IsAccessiblePost(int id, AppUser user)
        {
            var p = new GetListParams<Post>();
            p.extension = query => query.Where(u => u.PostRestrictionType == (int)Post.PostRestriction.NONE || (u.PostRestrictionType == (int)Post.PostRestriction.ALLOW_USERS && u.PostAccessUsers.Where(v => v.AppUserId == user.Id).Any()));
            var count = await _rep.CountDetail(p);
            return count > 0;
        }

        public async Task<List<PostComment>> GetPostComments(int postId, GetListParams<PostComment> param, AppUser user)
        {
            param.extension = query => query.Where(u => u.PostId == postId);
            return await _rep.ListVersionControl(param);
        }

        public async Task<int> GetPostCommentsCount(int postId, GetListParams<PostComment> param, AppUser user)
        {
            param.extension = query => query.Where(u => u.PostId == postId);
            return await _rep.CountDetail(param);
        }

        IQueryable<Post> GetAccessUserQuery(IQueryable<Post> query, AppUser user)
        {
            return query.Where(u => u.PostRestrictionType == (int)Post.PostRestriction.NONE || (u.PostRestrictionType == (int)Post.PostRestriction.ALLOW_USERS && u.PostAccessUsers.Where(v => v.AppUserId == user.Id).Any()));
        }

        public async Task<List<Post>> GetPosts(GetListParams<Post> param, AppUser user)
        {
            param.extension = query => _rep.IncludeCreated(query);
            var posts = await _rep.ListVersionControl(param);
            return posts;
        }

        public Task<List<Post>> GetPostsByTags(GetListParams<Post> param, List<string> tags)
        {
            param.extension = query =>
            {
                var q = query;
                q = q.Include(u => u.PostTags).ThenInclude(u => u.Tag);
                q = q.Where(u => u.PostTags.Where(v => tags.Contains(v.Tag.Value)).Any());
                return q;
            };
            return _rep.ListVersionControl(param);
        }

        public async Task<int> GetPostsCount(GetListParams<Post> param, AppUser user)
        {
            param.extension = query => param.extension(GetAccessUserQuery(query, user));
            return await _rep.CountDetail(param);
        }

        public async Task UpdatePostTags(Post post, List<PostTag> tags, AppUser actor)
        {
            //throw new NotImplementedException();
            await _db.Entry(post).Reference(u => u.PostTags).LoadAsync();
            foreach (var pt in post.PostTags)
            {
                _db.Remove(pt);
            }
            await _db.SaveChangesAsync();
            foreach (var tag in tags)
            {
                await _rep.Add(tag, actor);
            }
        }

        async Task<PostAccessUser> GetAccessUser(int postId, string userId)
        {
            Func<IQueryable<PostAccessUser>, IQueryable<PostAccessUser>> query = q => q.Where(u => u.PostId == postId && u.AppUserId == userId);
            return await _rep.First(query);
        }

        public async Task UpdatePost(Post entity, DateTime at, AppUser actor)
        {
            await _rep.UpdateDetail(entity, at, actor);
        }

        public async Task AddAccessedUser(int postId, string userId, AppUser actor)
        {
            var accessUsers = await GetAccessUser(postId, userId);
            if (accessUsers == null)
            {
                var add = new PostAccessUser
                {
                    PostId = postId,
                    AppUserId = userId
                };
                await _rep.Add(add, actor);
            }
        }

        public async Task RemoveAccessedUser(int postId, string userId, AppUser actor)
        {
            var accessUser = await GetAccessUser(postId, userId);
            if (accessUser == null)
                return;
            await _rep.Delete(accessUser);
        }
    }
}
