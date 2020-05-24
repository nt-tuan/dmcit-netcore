using DMCIT.Core.Entities.Reports;
using DMCIT.Core.Interfaces;
using DMCIT.Infrastructure.Data;
using DMCIT.Infrastructure.Events.Core;
using DMCIT.Infrastructure.Events.Diary131Event;
using DMCIT.Infrastructure.Services;
using EFCore.BulkExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.DomainEvents.Handlers
{
    public class LoadDiary131Handler : INotificationHandler<AccountingPeriodClosedEvent>,
        INotificationHandler<EndDownloadAllDiary131Event>
    {

        private readonly AppDbContext _db;
        private readonly IDataCollectorRepository _collector;
        private readonly ICustomerARRepository _customerAR;
        private readonly ICoreRepository _core;
        private readonly ISaleRepository _sale;
        private readonly ILogger<LoadDiary131Handler> _logger;
        private readonly IProcessManagerService _processService;
        public LoadDiary131Handler(AppDbContext db, IDataCollectorRepository collector, ICoreRepository core, ISaleRepository sale, ICustomerARRepository customerAR, IProcessManagerService service, ILogger<LoadDiary131Handler> logger)
        {
            _core = core;
            _collector = collector;
            _sale = sale;
            _customerAR = customerAR;
            _logger = logger;
            _processService = service;
            _db = db;
        }
        public async Task Handle(AccountingPeriodClosedEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                var ap = notification.AccountingPeriod;
                //TODO: disable below line because i dont want to download diary131. Just update ar.
                await _collector.LoadDiary131s(ap.AccountingStartTime ?? new DateTime(1900, 1, 1), ap.AccountingEndTime, ap.CreatedBy, notification.Context);
                await _customerAR.UpdateCustomerARs(ap, ap.CreatedBy, notification.Context);

            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
                await _processService.AddErrorMessage(notification.Context.BackgroundJob.Id, e.Message + Environment.NewLine + e.StackTrace);
            }
        }

        public async Task Handle(EndDownloadAllDiary131Event notification, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            var calculatedAR = await _customerAR.CalculateCustomerARs(DateTime.Now);
            var ar = calculatedAR.Select(u => new CustomerARNow(u));

            var temp = await _db.CustomerARNows.ToListAsync();
            await _db.BulkDeleteAsync(await _db.CustomerARNows.ToListAsync());
            await _db.BulkInsertAsync(ar.ToList());
        }
    }
}
