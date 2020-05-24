using DMCIT.Core.Entities.Reports;
using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace DMCIT.Infrastructure.Events.CustomerAREvent
{
    public class EndCalculatedCustomerAREvent : BaseDomainEvent
    {
        public IEnumerable<CustomerAR> ARs { get; set; }
        public DateTime At { get; set; }
    }
}
