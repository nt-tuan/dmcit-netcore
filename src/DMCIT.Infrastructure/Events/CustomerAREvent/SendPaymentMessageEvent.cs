using DMCIT.Core.Entities.Messaging.TemplateMessage;
using DMCIT.Core.SharedKernel;
using System.Collections.Generic;

namespace DMCIT.Infrastructure.Events.CustomerAREvent
{
    public class SendPaymentMessageEvent : BaseDomainEvent
    {
        public int Distributor { get; set; }
        public IEnumerable<CustomerPaymentMessage> PMsg { get; set; }
    }
}
