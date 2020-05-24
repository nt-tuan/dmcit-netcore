using DMCIT.Core.Entities.Core;
using DMCIT.Infrastructure.Events.Core;
using Hangfire.Server;
using MediatR;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Services
{
    public interface IAccountingPeriodService
    {
        Task OnAccountingClosed(AccountingPeriod period, PerformContext context);
        Task OnAccountingOpened(AccountingPeriod period);
    }

    public class AccountingPeriodService : IAccountingPeriodService
    {
        private readonly IMediator _mediator;
        public AccountingPeriodService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task OnAccountingClosed(AccountingPeriod period, PerformContext context)
        {
            await _mediator.Publish(new AccountingPeriodClosedEvent(period, context));
        }

        public async Task OnAccountingOpened(AccountingPeriod period)
        {
            await _mediator.Publish(new AccountingPeriodOpenedEvent(period));
        }
    }
}
