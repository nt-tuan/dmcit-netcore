using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.DataCollector;
using DMCIT.Core.Entities.Processes;
using DMCIT.Core.Entities.Reports;
using DMCIT.Core.Events;
using DMCIT.Infrastructure.Events.CustomerAREvent;
using DMCIT.Infrastructure.Events.Diary131Event;
using DMCIT.Infrastructure.Events.ProcessEvent;
using DMCIT.Infrastructure.Services;
using Hangfire.Server;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Core.Services
{
    public interface IDiary131Service
    {
        Task Begin(DistributedServer server, DateTime startTime, DateTime endTime, PerformContext context);
        Task Begin(IEnumerable<DistributedServer> servers, DateTime startTime, DateTime endTime, PerformContext context);
        Task Download(PerformContext context);
        Task Delete(PerformContext context);
        Task Update(PerformContext context);
        Task End(PerformContext context);
        Task EndDownloadAllDiary131(PerformContext context);
        Task Error(string reason, PerformContext context);
        Task CalculateAR(DateTime to, AppUser actor, PerformContext context);
        Task EndCalculateAR(List<CustomerAR> entities, DateTime to, PerformContext context);

    }
    public class Diary131Service : IDiary131Service
    {
        private readonly IMediator _mediator;
        private readonly IProcessManagerService _processService;
        public Diary131Service(IMediator mediator, IProcessManagerService processService)
        {
            _mediator = mediator;
            _processService = processService;
        }

        public async Task Begin(DistributedServer server, DateTime startTime, DateTime endTime, PerformContext context)
        {
            var progress = new LoadingDiary131Progress
                (server, startTime, endTime);
            await _mediator.Publish(new ProgressBeginEvent
            (progress, context));
        }

        public async Task Begin(IEnumerable<DistributedServer> servers, DateTime startTime, DateTime endTime, PerformContext context)
        {
            //Do nothing
        }

        public async Task CalculateAR(DateTime to, AppUser actor, PerformContext context)
        {
            var progress = new BackgroundProgress();
            progress.Title = $"Calculate AR at {to}";
            await _mediator.Publish(new ProgressBeginEvent(progress, context));
        }

        public async Task Delete(PerformContext context)
        {
            var progress = _processService.GetCurrentProgress(context.BackgroundJob.Id) as LoadingDiary131Progress;
            progress.SetDelete();
            await _mediator.Publish(new ProgressChangeEvent(progress, context));
        }

        public async Task Download(PerformContext context)
        {
            var progress = _processService.GetCurrentProgress(context.BackgroundJob.Id) as LoadingDiary131Progress;
            progress.SetDownLoad();
            await _mediator.Publish(new ProgressChangeEvent(progress, context));
        }

        public async Task End(PerformContext context)
        {
            var progress = _processService.GetCurrentProgress(context.BackgroundJob.Id) as LoadingDiary131Progress;
            progress.SetEnd();

            var message = $"Succeeded to  {progress.ToString()}";
            await _mediator.Publish(new ProgressEndEvent(progress, message, context));
        }

        public async Task EndDownloadAllDiary131(PerformContext context)
        {
            //TODO: here
            await _mediator.Publish(new EndDownloadAllDiary131Event
            {
                Context = context
            });
        }

        public async Task EndCalculateAR(List<CustomerAR> entities, DateTime to, PerformContext context)
        {
            var progress = _processService.GetCurrentProgress(context.BackgroundJob.Id) as LoadingDiary131Progress;
            await _mediator.Publish(new EndCalculatedCustomerAREvent
            {
                ARs = entities,
                At = to
            });
            await _mediator.Publish(new ProgressEndEvent(progress, $"Successed to calculate AR at {to}", context));
        }

        public async Task Error(string reason, PerformContext context)
        {
            var progress = _processService.GetCurrentProgress(context.BackgroundJob.Id) as LoadingDiary131Progress;
            progress.SetDelete();
            await _mediator.Publish(new ProgressErrorEvent(progress, context, reason));
        }

        public async Task Update(PerformContext context)
        {
            var progress = _processService.GetCurrentProgress(context.BackgroundJob.Id) as LoadingDiary131Progress;
            progress.SetUpdate();
            await _mediator.Publish(new ProgressChangeEvent(progress, context));
        }
    }
}
