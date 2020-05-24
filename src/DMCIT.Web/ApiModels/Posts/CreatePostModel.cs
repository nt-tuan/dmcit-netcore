using DMCIT.Core.Entities.Posts;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DMCIT.Web.ApiModels.Posts
{
    public class CreatePostModel
    {
        public string subject { get; set; }
        public string content { get; set; }
        public int categoryId { get; set; }
        public List<string> tags { get; set; }
        public bool canComment { get; set; }
        public bool featureLevel { get; set; }
        public List<string> accessUsers { get; set; }
        public CreatePostModel() { }

        public Post ToEntity()
        {
            var post = new Post();
            post.Subject = subject;
            post.Content = content;
            post.CategoryId = categoryId;
            post.CanComment = canComment;
            post.PostAccessUsers = accessUsers.Select(u => new PostAccessUser { AppUserId = u }).ToList();
            return post;
        }
    }
}
