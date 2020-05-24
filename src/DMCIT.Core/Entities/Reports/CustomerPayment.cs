using DMCIT.Core.Entities.Accounting;
using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.Entities.Sales;
using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Reports
{
    //This report is not depend on Accouting Period
    public class CustomerPayment : Base, IEqualityComparer<CustomerPayment>
    {
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? DistributorId { get; set; }
        public Distributor Distributor { get; set; }
        public string CustomerCode { get; set; }
        public string DistributorCode { get; set; }
        public decimal Amount { get; set; }
        public decimal? ARAmount { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? SentMessageId { get; set; }
        public SentMessage SentMessage { get; set; }
        public bool Equals(CustomerPayment x, CustomerPayment y)
        {
            return x.CustomerCode == y.CustomerCode && x.DistributorCode == y.DistributorCode &&
                x.Amount == y.Amount &&
                x.ReceiptDate == y.ReceiptDate;
        }

        public int GetHashCode(CustomerPayment obj)
        {
            return obj.CustomerCode.Length ^ obj.DistributorCode.Length;
        }

        public CustomerPayment()
        {

        }

        public CustomerPayment(CalculatedCustomerPayment e)
        {
            Amount = e.Amount;
            CustomerCode = e.CustomerCode;
            DistributorCode = e.DistributorCode;
            ReceiptDate = e.ReceiptDate;
        }
    }
}
