using DMCIT.Core.Entities.Reports;
using DMCIT.Core.Entities.Templates.TextParser;
using DMCIT.Core.SharedKernel;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Messaging.TemplateMessage
{
    public class CustomerPaymentMessageContentModel : SerializedObject
    {
        public string Customer { get; set; }
        public string PaymentAmount { get; set; }
        public string ReceiptDate { get; set; }
        public string ARAmount { get; set; }
    }
    public class CustomerPaymentMessage : Base
    {
        public CustomerPayment CustomerPayment { get; set; }
        public ReceiverProvider ReceiverProvider { get; set; }
        public string MessageContent { get; set; }
    }
    public class CustomerPaymentMessageBatch
    {
        public MessageBatch Batch { get; set; }
        public List<CustomerPaymentMessage> Entities { get; set; }
    }

}
