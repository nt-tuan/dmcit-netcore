using DMCIT.Core.Entities.Core;
using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Posts
{
    public class Post : BaseVersionControlEntity<Post>
    {
        public enum PostRestriction { NONE, ALLOW_USERS }
        public int FeatureLevel { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        //META DATA
        public DateTime LastModifiedDate { get; set; }
        public int ViewCount { get; set; }
        public int CommentCount { get; set; }

        //REFERENCES
        public int? CategoryId { get; set; }
        public PostCategory Category { get; set; }
        public bool CanComment { get; set; }
        public ICollection<PostComment> Comments { get; set; }
        public int PostRestrictionType { get; set; }
        public ICollection<PostAccessUser> PostAccessUsers { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
    }

    public class PostAccessUser : BaseEntity
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
