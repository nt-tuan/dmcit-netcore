using DMCIT.Core.SharedKernel;
using System;

namespace DMCIT.Infrastructure.Events.CustomerAREvent
{
    public class SendPaymentProcessEnd : BaseDomainEvent
    {
        public int Distributor { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
