using DMCIT.Core.SharedKernel;
using System;

namespace DMCIT.Infrastructure.Events.CustomerAREvent
{
    public class UpdateAREvent : BaseDomainEvent
    {
        public DateTime EndDate { get; set; }
    }
}
