using DMCIT.Core.SharedKernel;
using System.Collections.Generic;

namespace DMCIT.Infrastructure.Events.CustomerAREvent
{
    public class CalculatePaymentEvent : BaseDomainEvent
    {
        public int Distributor { get; set; }
        public IEnumerable<int> Providers { get; set; }
    }
}
