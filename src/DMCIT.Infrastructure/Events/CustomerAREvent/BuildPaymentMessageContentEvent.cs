using DMCIT.Core.Entities.Reports;
using DMCIT.Core.SharedKernel;
using System.Collections.Generic;

namespace DMCIT.Infrastructure.Events.CustomerAREvent
{
    public class BuildPaymentMessageContentEvent : BaseDomainEvent
    {
        public int Distributor { get; set; }
        public IEnumerable<CustomerPayment> CustomerPayments { get; set; }
    }
}
