using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.Services;
using DMCIT.Infrastructure.Events.SendMessageEvent;
using Hangfire.Server;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Services
{
    public class SendMessageService : ISendMessageService
    {
        private readonly IMediator _mediator;
        public SendMessageService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task BeginSendMessageBatch(MessageBatch batch, IEnumerable<SentMessage> messages, AppUser actor, PerformContext context)
        {
            await _mediator.Publish(new BeginSendMessageBatchEvent
            {
                Batch = batch,
                Actor = actor,
                Context = context,
                Mesasges = messages
            });
        }

        public async Task EndSendMessageBatch(MessageBatch batch, AppUser actor, PerformContext context)
        {
            await _mediator.Publish(new EndSendMessageBatchEvent
            {
                Batch = batch,
                Actor = actor,
                Context = context
            });
        }

        public async Task InitializeSendMessageBatch(int batchId, PerformContext context)
        {
            await _mediator.Publish(new InitializeMessageBatchEvent
            {
                BatchId = batchId,
                Context = context
            });
        }

        public async Task SendMessageBatchFailed(int batchId, string reason, AppUser actor, PerformContext context)
        {
            await _mediator.Publish(new SendMessageBatchFaildEvent
            {
                BatchId = batchId,
                Reason = reason,
                Context = context
            });
        }

        public async Task SendMessageFailed(SentMessage msg, string reason, PerformContext context)
        {
            await _mediator.Publish(new SendMessageFailedEvent
            {
                Message = msg,
                Reason = reason,
                Context = context
            });
        }

        public async Task SendMessageSuccess(SentMessage msg, PerformContext context)
        {
            await _mediator.Publish(new SendMessageSuccessEvent
            {
                Message = msg,
                Context = context
            });
        }
    }
}
