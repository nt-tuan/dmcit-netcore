using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Events.ProcessEvent;
using DMCIT.Infrastructure.Services;
using MediatR;

using System.Collections.Concurrent;
using System.Collections.Generic;

using System.Threading;
using System.Threading.Tasks;

namespace DMCIT.Web.EventHandlers
{
    public class ProgressHandler : INotificationHandler<ProgressChangeEvent>,
        INotificationHandler<ProgressBeginEvent>,
        INotificationHandler<ProgressEndEvent>,
        INotificationHandler<ProgressErrorEvent>
    {
        private readonly IProcessManagerService _processService;
        private static ConcurrentDictionary<string, BaseProgress> Progresses { get; set; } = new ConcurrentDictionary<string, BaseProgress>();

        private static readonly ConcurrentDictionary<string, List<string>> Map = new ConcurrentDictionary<string, List<string>>();

        public ProgressHandler(IProcessManagerService progress)
        {
            _processService = progress;
        }

        public async Task Handle(ProgressChangeEvent notification, CancellationToken cancellationToken)
        {
            var progress = notification.Progress;
            await _processService.UpdateProgress(notification.Context.BackgroundJob.Id, progress.Description);
        }

        public async Task Handle(ProgressBeginEvent notification, CancellationToken cancellationToken)
        {
            var rs = await _processService.BeginProgress(notification.Context.BackgroundJob.Id, notification.Progress);
        }

        public async Task Handle(ProgressEndEvent notification, CancellationToken cancellationToken)
        {
            await _processService.AddSuccessMessage(notification.Context.BackgroundJob.Id, notification.Message);
            await _processService.EndProgress(notification.Context.BackgroundJob.Id);
        }

        public async Task Handle(ProgressErrorEvent notification, CancellationToken cancellationToken)
        {
            await _processService.AddErrorMessage(notification.Context.BackgroundJob.Id, notification.Reason);
        }
    }
}
