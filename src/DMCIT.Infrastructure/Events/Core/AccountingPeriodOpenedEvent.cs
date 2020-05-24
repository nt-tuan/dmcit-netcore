using DMCIT.Core.Entities.Core;

namespace DMCIT.Infrastructure.Events.Core
{
    public class AccountingPeriodOpenedEvent
    {
        public AccountingPeriod AccountingPeriod { get; set; }
        public AccountingPeriodOpenedEvent(AccountingPeriod ap)
        {
            AccountingPeriod = ap;
        }
    }
}
