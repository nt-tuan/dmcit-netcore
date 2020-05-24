using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Sales;
using DMCIT.Core.SharedKernel;
using System;
using System.Collections;

namespace DMCIT.Core.Entities.Reports
{
    public class CalculatedCustomerLiabilityQuery : Base, IEqualityComparer
    {
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string CustomerCode { get; set; }
        public Distributor Distributor { get; set; }
        public int? DistributorId { get; set; }
        public string DistributorCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime At { get; set; }

        public new bool Equals(object x, object y)
        {
            var cX = (CalculatedCustomerLiabilityQuery)x;
            var cY = (CalculatedCustomerLiabilityQuery)y;
            return cX.CustomerCode == cY.CustomerCode && cX.DistributorCode == cY.DistributorCode && cX.Amount == cY.Amount;
        }

        public int GetHashCode(object obj)
        {
            return 0;
        }
    }

    //This report is calculated at its AccountingPeriod End Time
    public class CustomerAR : CustomerAccounting
    {
        public DateTime? CreatedDate { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public AccountingPeriod DispatchAccountingPeriod { get; set; }
        public int DispatchAccountingPeriodId { get; set; }

        public CustomerAR() { }

        public CustomerAR(CalculatedCustomerLiabilityQuery ar) : base(ar)
        {
            CreatedDate = DateTime.Now;
        }

        public CustomerAR(CalculatedCustomerLiabilityQuery ar, int apId) : this(ar)
        {
            DispatchAccountingPeriodId = apId;
        }

        public bool Equals(CustomerAR x, CustomerAR y)
        {
            return x.CustomerId == y.CustomerId && x.DistributorCode == y.DistributorCode && Amount == Amount;
        }

        public int GetHashCode(CustomerAR obj)
        {
            return obj.CustomerId.Value;
        }
    }
}
