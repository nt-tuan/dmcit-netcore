using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Sales;
using DMCIT.Core.SharedKernel;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Messaging
{
    public class MessageReceiver : BaseVersionControlEntity<MessageReceiver>
    {
        public ICollection<MessageReceiverGroupMessageReceiver> MessageReceiverGroupMessageReceivers { get; set; }
        public ICollection<ReceiverProvider> ReceiverProviders { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public int? ReceiverCategoryId { get; set; }
        public ReceiverCategory ReceiverCategory { get; set; }

        public void Copy(MessageReceiver source)
        {
            ReceiverProviders = source.ReceiverProviders;
            CustomerId = source.CustomerId;
            Customer = source.Customer;
            EmployeeId = source.EmployeeId;
            Employee = source.Employee;
            FullName = source.FullName;
            ShortName = source.ShortName;
            ReceiverCategoryId = source.ReceiverCategoryId;
            ReceiverCategory = source.ReceiverCategory;
        }
    }
}
