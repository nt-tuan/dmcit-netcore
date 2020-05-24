using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace DMCIT.Infrastructure.Events.CustomerAREvent
{
    public class UpdateCustomerPaymentMessageEvent : BaseDomainEvent
    {
        public int Distributor { get; set; }
        public IEnumerable<int> Providers { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
