using DMCIT.Core.Entities.Reports;
using DMCIT.Core.SharedKernel;
using System.Collections.Generic;

namespace DMCIT.Infrastructure.Events.CustomerAREvent
{
    public class BuildARMessageContentEvent : BaseDomainEvent
    {
        public int Distributor { get; set; }
        public IEnumerable<CustomerAR> CustomerPayments { get; set; }
    }
}
