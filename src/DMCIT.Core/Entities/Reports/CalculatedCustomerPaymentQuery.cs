using System;

namespace DMCIT.Core.Entities.Accounting
{
    public class CalculatedCustomerPayment
    {
        public string CustomerCode { get; set; }
        public string DistributorCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime ReceiptDate { get; set; }
    }
}
