using DMCIT.Core.Entities.Posts;
using DMCIT.Web.ApiModels.Accounts;
using System;

namespace DMCIT.Web.ApiModels.Posts
{
    public class PostSummaryModel
    {
        public string subject { get; set; }
        public DateTime lastModifedDate { get; set; }
        public UserModel createdBy { get; set; }
        public int commentCount { get; set; }
        public int viewCount { get; set; }
        public bool isPublic { get; set; }
        public PostSummaryModel(Post post)
        {
            subject = post.Subject;
            isPublic = post.PostRestrictionType == (int)Post.PostRestriction.NONE;
            if (post.CreatedBy != null)
                createdBy = new UserModel(post.CreatedBy);
            //META
            lastModifedDate = post.LastModifiedDate;
            commentCount = post.CommentCount;
            viewCount = post.ViewCount;
        }
    }

    public class PostDetailModel : PostSummaryModel
    {
        public string content { get; set; }
        public PostDetailModel(Post post) : base(post)
        {
            content = post.Content;
        }
    }
}
