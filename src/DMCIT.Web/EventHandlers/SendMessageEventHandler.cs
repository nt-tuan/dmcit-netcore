using DMCIT.Core.Entities.Processes;
using DMCIT.Infrastructure.Events.SendMessageEvent;
using DMCIT.Infrastructure.Services;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DMCIT.Web.EventHandlers
{
    public class SendMessageEventHandler : INotificationHandler<BeginSendMessageBatchEvent>,
        INotificationHandler<EndSendMessageBatchEvent>,
        INotificationHandler<InitializeMessageBatchEvent>,
        INotificationHandler<SendMessageBatchFaildEvent>,
        INotificationHandler<SendMessageFailedEvent>,
        INotificationHandler<SendMessageSuccessEvent>
    {
        IProcessManagerService _processService { get; set; }
        public SendMessageEventHandler(IProcessManagerService processService)
        {
            _processService = processService;
        }

        public async Task Handle(SendMessageBatchFaildEvent notification, CancellationToken cancellationToken)
        {
            var job = notification.Context.BackgroundJob.Id;
            await _processService.AddErrorMessage(job, notification.Reason);
            await _processService.EndProgress(job);
        }

        public async Task Handle(BeginSendMessageBatchEvent notification, CancellationToken cancellationToken)
        {
            var job = notification.Context.BackgroundJob.Id;
            await _processService.UpdateProgress(job, "BEGIN TO SEND MESSAGES");
            await _processService.InitCounting(job, notification.Mesasges.Count());
        }

        public async Task Handle(EndSendMessageBatchEvent notification, CancellationToken cancellationToken)
        {
            var job = notification.Context.BackgroundJob.Id;
            await _processService.EndProgress(job);
        }

        public async Task Handle(InitializeMessageBatchEvent notification, CancellationToken cancellationToken)
        {
            var jobId = notification.Context.BackgroundJob.Id;
            var progress = new SendMessageProgress();
            //TODO: create static class to store this fix string
            progress.Title = $"SEND MESSAGES {notification.BatchId}";
            progress.Description = "PREPARING TO SEND MESSAGE";
            await _processService.BeginProgress(jobId, progress);
        }

        public async Task Handle(SendMessageFailedEvent notification, CancellationToken cancellationToken)
        {
            //progress.SetError($"Send message #{notification.Message.Id} failed");   
            var job = notification.Context.BackgroundJob.Id;
            await _processService.AddErrorMessage(job, notification.Reason);
            await _processService.Increase(job, 1);
        }

        public async Task Handle(SendMessageSuccessEvent notification, CancellationToken cancellationToken)
        {
            var job = notification.Context.BackgroundJob.Id;
            await _processService.Increase(job, 1);
        }
    }
}
