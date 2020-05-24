using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.Posts
{
    public class PostComment : VSTreeNodeEntity<PostComment, PostCommentRelation>
    {
        public string Content { get; set; }
        public int? PageId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }

    public class PostCommentRelation : VSTreeRelationEntity<PostComment, PostCommentRelation>
    {
    }
}
