using DMCIT.Core.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DMCIT.Web.ApiModels.CustomerAR
{
    public class CustomerPaymentFilterModel : FilterModel<CustomerPayment>
    {
        public List<string> CustomerCode { get; set; }
        public List<string> DistributorCode { get; set; }
        public List<string> CustomerName { get; set; }
        public List<DateRangeModel> CreatedDate { get; set; }
        static readonly string ORDERBY_DISTRIBUTOR = "distributor";
        static readonly string ORDERBY_CUSTOMER_CODE = "customerCode";
        public override Expression<Func<CustomerPayment, object>> BuildOrder(string orderBy, int? orderDir)
        {
            if (orderBy == ORDERBY_DISTRIBUTOR)
                return u => u.DistributorCode;
            if (orderBy == ORDERBY_CUSTOMER_CODE)
                return u => u.CustomerCode;
            return u => u.ReceiptDate;
        }

        public override IQueryable<CustomerPayment> BuildQuery(IQueryable<CustomerPayment> query)
        {
            var rs = query;
            if (IsValidList(CustomerCode))
                rs = rs.Where(u => u.CustomerCode.Contains(CustomerCode[0]));
            if (IsValidList(CustomerName))
                rs = rs.Where(u => u.Customer.CacheBusinessDisplayName.Contains(CustomerName[0]) || u.Customer.CachePersonDisplayName.Contains(CustomerName[0]));
            if (IsValidList(DistributorCode))
                rs = rs.Where(u => u.DistributorCode.Contains(DistributorCode[0]));

            if (IsValidList(CreatedDate) && CreatedDate[0]?.startDate != null)
                rs = rs.Where(u => u.ReceiptDate >= CreatedDate[0].startDate);
            if (IsValidList(CreatedDate) && CreatedDate[0]?.endDate != null)
                rs = rs.Where(u => u.ReceiptDate <= CreatedDate[0].endDate);
            return rs;
        }

        public override IQueryable<CustomerPayment> BuildSearchQuery(IQueryable<CustomerPayment> q)
        {
            return q;
        }
    }
}
