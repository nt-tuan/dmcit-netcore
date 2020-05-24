using DMCIT.Core.Entities.SupportRequests;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DMCIT.Web.ApiModels.SupportRequests
{
    public class SupportRequestFilterModel : FilterModel<SupportRequest>
    {
        public DateRangeModel requestTime { get; set; }
        public DateRangeModel finishTime { get; set; }
        public ListModel<int> requesters { get; set; }
        public ListModel<int?> requesterDepartments { get; set; }
        public ListModel<int?> assignees { get; set; }
        public ListModel<int?> categories { get; set; }
        public ListModel<string> tags { get; set; }
        public ListModel<int> statuses { get; set; }
        public override Expression<Func<SupportRequest, object>> BuildOrder(string orderBy, int? orderDir)
        {
            switch (orderBy)
            {
                case "requester":
                    return u => u.Requester.Code;
                case "requestTime":
                    return u => u.DateCreated;
                case "supporter":
                    return u => u.AssignedTo.Code;
                case "category":
                    return u => u.Post.Category.Name;
                case "status":
                    return u => u.RequestStatusNumber;
                default:
                    return u => u.Id;
            }
        }

        public override IQueryable<SupportRequest> BuildQuery(IQueryable<SupportRequest> query)
        {
            query = BuildQuery(query, requestTime, u => u.DateCreated);
            query = BuildQuery(query, finishTime, u => u.FinishTime);
            query = BuildQuery(query, requesters, u => u.RequesterId);
            query = BuildQuery(query, requesterDepartments, u => u.Requester.DepartmentId);
            query = BuildQuery(query, assignees, u => u.AssignedToId);
            query = BuildQuery(query, categories, u => u.Post.CategoryId);
            query = BuildQuery(query, statuses, u => u.RequestStatusNumber);
            if (IsValidList(tags))
            {
                query = query.Where(u => u.Post.PostTags.Where(pt => tags.Contains(pt.Tag.Value)).Count() > 0);
            }
            return query;
        }

        public override IQueryable<SupportRequest> BuildSearchQuery(IQueryable<SupportRequest> q)
        {
            if (!string.IsNullOrEmpty(Search))
                return q.Where(u => u.Subject.Contains(Search));
            return q;
        }
    }
}
