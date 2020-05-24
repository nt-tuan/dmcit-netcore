using DMCIT.Core.Entities.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DMCIT.Web.ApiModels.Messaging
{
    public class MessageReceiverFilterModel : FilterModel<MessageReceiver>
    {
        public string type { get; set; }
        public List<int> department { get; set; }
        public List<int> distributor { get; set; }
        public override Expression<Func<MessageReceiver, object>> BuildOrder(string orderBy, int? orderDir)
        {
            return u => u.Id;
        }

        public override IQueryable<MessageReceiver> BuildQuery(IQueryable<MessageReceiver> query)
        {
            if (type == "employee")
            {
                query = query.Where(u => u.EmployeeId != null);
            }
            if (type == "customer")
            {
                query = query.Where(u => u.CustomerId != null);
            }
            if (department != null && department.Count > 0)
            {
                query = query.Where(u => department.Contains(u.Employee.DepartmentId.Value));
            }
            if (distributor != null && distributor.Count > 0)
            {
                query = query.Where(u => distributor.Contains(u.Customer.DistributorId.Value));
            }
            return BuildSearchQuery(query);
        }

        public override IQueryable<MessageReceiver> BuildSearchQuery(IQueryable<MessageReceiver> q)
        {
            if (!string.IsNullOrEmpty(Search))
            {
                q = q.Where(u => u.Employee.Person.DisplayName.Contains(Search) || u.Employee.Person.FullName.Contains(Search) || u.Employee.Code.Contains(Search) || u.Customer.Code.Contains(Search) || u.Customer.Person.FullName.Contains(Search) || u.Customer.Person.DisplayName.Contains(Search) || u.Customer.Business.FullName.Contains(Search) || u.Customer.Business.BusinessIdentityNumber.Contains(Search));
            }
            return q;
        }
    }
}
