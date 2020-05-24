using DMCIT.Core.SharedKernel;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Reports
{
    public class CustomerAccounting : Base, IEqualityComparer<CustomerAccounting>
    {
        public string CustomerCode { get; set; }
        public string DistributorCode { get; set; }
        public decimal Amount { get; set; }

        public CustomerAccounting() { }

        public CustomerAccounting(CalculatedCustomerLiabilityQuery item)
        {
            CustomerCode = item.CustomerCode;
            DistributorCode = item.DistributorCode;
            Amount = item.Amount;
        }

        public bool Equals(CustomerAccounting x, CustomerAccounting y)
        {
            return x.CustomerCode == y.CustomerCode && x.DistributorCode == y.DistributorCode;
        }

        public int GetHashCode(CustomerAccounting obj)
        {
            return 0;
        }
    }
}
