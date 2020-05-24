using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Messaging;
using Hangfire.Server;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Core.Services
{
    public interface ISendMessageService
    {
        Task InitializeSendMessageBatch(int batchId, PerformContext context);
        Task BeginSendMessageBatch(MessageBatch batch, IEnumerable<SentMessage> messages, AppUser actor, PerformContext context);
        Task SendMessageSuccess(SentMessage msg, PerformContext context);
        Task SendMessageFailed(SentMessage msg, string reason, PerformContext context);
        Task EndSendMessageBatch(MessageBatch batch, AppUser actor, PerformContext context);
        Task SendMessageBatchFailed(int batchId, string reason, AppUser actor, PerformContext context);
    }
}
