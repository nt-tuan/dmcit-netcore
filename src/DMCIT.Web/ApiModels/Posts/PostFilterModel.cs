using DMCIT.Core.Entities.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DMCIT.Web.ApiModels.Posts
{
    public class PostFilterModel : FilterModel<Post>
    {
        public int? categoryId { get; set; }
        public string createdId { get; set; }
        public List<string> tags { get; set; }
        public string orderBy { get; set; }
        public override Expression<Func<Post, object>> BuildOrder(string orderBy, int? orderDir)
        {
            return u => new { u.FeatureLevel, u.LastModifiedDate };
        }

        public override IQueryable<Post> BuildQuery(IQueryable<Post> query)
        {
            var q = query;
            if (categoryId != null)
                q = query.Where(u => u.CategoryId == categoryId);
            if (createdId != null)
                q = query.Where(u => u.CreatedById == createdId);
            if (tags != null && tags.Count > 0)
            {
                q = query.Where(u => u.PostTags.Where(v => tags.Contains(v.Tag.Value)).Any());
            }
            return q;
        }

        public override IQueryable<Post> BuildSearchQuery(IQueryable<Post> q)
        {
            var words = Search.Split(' ').Where(u => !string.IsNullOrEmpty(u));
            if (words.Count() > 0)
            {
                return q.Where(u => u.PostTags.Where(v => tags.Contains(v.Tag.Value)).Any());
            }
            return q;
        }
    }
}
