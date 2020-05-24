using DMCIT.Core.Entities.Core;
using Hangfire.Server;
using MediatR;

namespace DMCIT.Infrastructure.Events.Core
{
    public class AccountingPeriodClosedEvent : INotification
    {
        public AccountingPeriod AccountingPeriod;
        public PerformContext Context;
        public AccountingPeriodClosedEvent(AccountingPeriod ap, PerformContext context)
        {
            AccountingPeriod = ap;
            Context = context;
        }
    }
}
