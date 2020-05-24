using DMCIT.Core.Entities.Posts;
using DMCIT.Web.ApiModels.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMCIT.Web.ApiModels.Posts
{
    public class CommentModel
    {
        public string content { get; set; }
        public DateTime createdTime { get; set; }
        public UserModel createdBy { get; set; }
        public List<CommentModel> subComments { get; set; }
        public CommentModel(PostComment c)
        {
            content = c.Content;
            createdBy = new UserModel(c.CreatedBy);
            createdTime = c.DateCreated;
            subComments = c.Children.Select(u => new CommentModel(u)).ToList();
        }
    }
}
