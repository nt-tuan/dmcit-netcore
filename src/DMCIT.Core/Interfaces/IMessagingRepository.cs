using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.Services;
using DMCIT.Core.SharedKernel;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Core.Interfaces
{
    public class SendMessageBatchEventCollection
    {
        public Action<int, AppUser> OnSendMessageBatchInitialize { get; set; }
        public Action<MessageBatch> OnSendMessageBatchStart { get; set; }
        public Action<SentMessage> OnSendMessageSucceed { get; set; }
        public Action<SentMessage, string> OnSendMessageFailed { get; set; }
        public Action<MessageBatch> OnSendMessageBatchEnd { get; set; }
        public Action<int, string> OnSendMessageBatchFailed { get; set; }

        public static SendMessageBatchEventCollection CreateProcessEvent(ISendMessageService _service, AppUser actor, PerformContext context)
        {
            var events = new SendMessageBatchEventCollection
            {
                OnSendMessageBatchInitialize = async (_batchId, a) => await _service.InitializeSendMessageBatch(_batchId, context),
                OnSendMessageBatchStart = async (batch) => await _service.BeginSendMessageBatch(batch, null, actor, context),
                OnSendMessageBatchFailed = async (bId, reason) => await _service.SendMessageBatchFailed(bId, reason, actor, context),
                OnSendMessageSucceed = async (m) => await _service.SendMessageSuccess(m, context),
                OnSendMessageFailed = async (m, reason) => await _service.SendMessageFailed(m, reason, context)
            };
            return events;
        }
    }
    public interface IMessagingRepository
    {
        Task<ICollection<MessageBatch>> GetMessageBatches(GetListParams<MessageBatch> param);

        Task<MessageBatch> GetMessageBatch(int id);

        Task<int> GetMessageBatchesCount(GetListParams<MessageBatch> param);

        Task<int> GetMessagesCount(GetListParams<SentMessage> param);

        Task<MessageBatch> CreateMessageBatch(ICollection<SentMessage> messages, AppUser actor = null);
        Task UpdateSentMessage(SentMessage entity);
        Task UpdateMessageBatch(MessageBatch entity);
        Task<SentMessage> GetSentMessageById(int id);
        Task<ICollection<SentMessage>> GetSentMessages(GetListParams<SentMessage> p);
        Task<MessageBatch> CreateMessageBatch(AppUser actor);
        Task<MessageBatch> SendMessageBatch(int batchId, AppUser actor, SendMessageBatchEventCollection events);
        Task SendMessageBatchHangfire(int batchId, AppUser actor, PerformContext context);
    }
}
