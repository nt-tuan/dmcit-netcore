using DMCIT.Core.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DMCIT.Web.ApiModels.CustomerAR
{
    public class CustomerARFilterModel : FilterModel<CustomerARNow>
    {
        public List<string> customerCode { get; set; }
        public List<string> distributorCode { get; set; }
        public override Expression<Func<CustomerARNow, object>> BuildOrder(string orderBy, int? orderDir)
        {
            return u => u.CustomerCode;
        }

        public override IQueryable<CustomerARNow> BuildQuery(IQueryable<CustomerARNow> query)
        {
            var rs = query;
            if (IsValidList(customerCode))
                rs = rs.Where(u => u.CustomerCode.Contains(customerCode[0]));
            if (IsValidList(distributorCode))
                rs = rs.Where(u => u.DistributorCode.Contains(distributorCode[0]));
            return rs;
        }

        public override IQueryable<CustomerARNow> BuildSearchQuery(IQueryable<CustomerARNow> q)
        {
            return q;
        }
    }
}
