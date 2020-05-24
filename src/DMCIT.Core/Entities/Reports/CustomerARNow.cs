using DMCIT.Core.Entities.Sales;
using System;

namespace DMCIT.Core.Entities.Reports
{
    public class CustomerARNow : CustomerAccounting
    {
        public DateTime? CreatedDate { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public CustomerARNow() { }

        public CustomerARNow(CalculatedCustomerLiabilityQuery item) : base(item)
        {
            CreatedDate = DateTime.Now;
            CustomerId = item.CustomerId;
        }
    }
}
