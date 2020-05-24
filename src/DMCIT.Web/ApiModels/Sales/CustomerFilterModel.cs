using DMCIT.Core.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DMCIT.Web.ApiModels.Sales
{
    public class CustomerFilterModel : FilterModel<Customer>
    {
        public string name { get; set; }
        public string code { get; set; }
        public List<int?> distributor { get; set; }

        public override Expression<Func<Customer, object>> BuildOrder(string orderBy, int? orderDir)
        {
            if (orderBy == nameof(distributor))
                return u => u.DistributorId;
            return u => u.Code;
        }

        public override IQueryable<Customer> BuildQuery(IQueryable<Customer> query)
        {
            if (distributor != null && distributor.Count > 0)
            {
                query = query.Where(u => distributor.Contains(u.DistributorId));
            }
            return BuildSearchQuery(query);
        }

        public override IQueryable<Customer> BuildSearchQuery(IQueryable<Customer> q)
        {
            if (!string.IsNullOrEmpty(Search))
            {
                q = q.Where(u => u.Code.Contains(Search) || u.Person.DisplayName.Contains(Search) || u.Business.FullName.Contains(Search));
            }
            return q;
        }
    }
}
