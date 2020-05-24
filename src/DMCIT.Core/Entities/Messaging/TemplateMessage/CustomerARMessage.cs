using DMCIT.Core.Entities.Reports;
using DMCIT.Core.Entities.Sales;
using DMCIT.Core.Entities.Templates.TextParser;
using DMCIT.Core.SharedKernel;
using System;

namespace DMCIT.Core.Entities.Messaging.TemplateMessage
{
    public class CustomerARMessageContentModel : SerializedObject
    {
        public string Customer { get; set; }
        public string ReceiptDate { get; set; }
        public string Amount { get; set; }
    }
    public class CustomerARMessage : Base
    {
        public string CustomerCode { get; set; }
        public string DistributorCode { get; set; }
        public Customer Customer { get; set; }
        public Distributor Distributor { get; set; }
        public decimal Amount { get; set; }
        public ReceiverProvider ReceiverProvider { get; set; }
        public DateTime At { get; set; }

        public CustomerARMessage() { }

        public CustomerARMessage(CalculatedCustomerLiabilityQuery ar)
        {
            CustomerCode = ar.CustomerCode;
            DistributorCode = ar.DistributorCode;
            Customer = ar.Customer;
            Distributor = ar.Distributor;
            Amount = ar.Amount;
            At = ar.At;
        }
    }
}
