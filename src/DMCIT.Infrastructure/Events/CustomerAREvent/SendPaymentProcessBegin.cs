using DMCIT.Core.SharedKernel;
using System;

namespace DMCIT.Infrastructure.Events.CustomerAREvent
{
    public class SendPaymentProcessBegin : BaseDomainEvent
    {
        public int Disitributor { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
