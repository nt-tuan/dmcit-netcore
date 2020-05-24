using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.Interfaces;
using DMCIT.Core.Services;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Providers;
using DMCIT.Infrastructure.Services;
using Hangfire.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data
{
    public class MessagingRepository : IMessagingRepository
    {
        private readonly IRepository _rep;
        private readonly AppDbContext _db;
        private readonly ILogger _logger;
        private readonly ISendMessageService _service;
        private readonly IProcessManagerService _processService;
        private readonly ISettingRepository _setting;
        private readonly IServiceProvider _sp;
        public MessagingRepository(IServiceProvider sp, AppDbContext db, IRepository rep, ISendMessageService service, ILogger<IMessagingRepository> logger, IProcessManagerService processService, ISettingRepository setting)
        {
            _sp = sp;
            _rep = rep;
            _db = db;
            _logger = logger;
            _service = service;
            _processService = processService;
            _setting = setting;
        }

        IQueryable<MessageBatch> ApplyMessageBatchFilter(IQueryable<MessageBatch> query, dynamic filter)
        {

            if (filter != null)
            {
                var dict = filter as Dictionary<string, object>;
                if (dict.ContainsKey("start") && dict["start"] != null)
                {
                    var start = dict["start"] as DateTime?;
                    query = query.Where(u => u.DateCreated >= start.Value);
                }
                if (dict.ContainsKey("end") && dict["end"] != null)
                {
                    var end = dict["end"] as DateTime?;
                    query = query.Where(u => u.DateCreated <= end.Value);
                }
            }
            return query;
        }

        public async Task<ICollection<MessageBatch>> GetMessageBatches(GetListParams<MessageBatch> p)
        {
            var ls = await _rep.List(p);
            return ls;
        }

        public async Task UpdateMessageBatch(MessageBatch entity)
        {
            await _rep.Update(entity);
        }

        public async Task<int> GetMessageBatchesCount(GetListParams<MessageBatch> p)
        {
            var count = await _rep.Count(p);
            return count;
        }

        public async Task<int> GetMessagesCount(GetListParams<SentMessage> param)
        {
            return await _rep.Count(param);
        }

        public async Task<MessageBatch> CreateMessageBatch(AppUser actor)
        {
            var batch = new MessageBatch
            {
                AutoMessageConfigId = null,
                MessageSourceId = null,
                DateRemoved = null
            };
            var eBatch = await _rep.Add(batch, actor);
            return eBatch;
        }

        public async Task<MessageBatch> CreateMessageBatch(ICollection<SentMessage> messages, AppUser actor)
        {
            var eBatch = await CreateMessageBatch(actor);
            eBatch.SentMessages = new List<SentMessage>();
            foreach (var item in messages)
            {
                item.Status = (int)SentMessage.SentMessageStatus.WAITING;
                item.ResponseMessage = null;
                item.MessageBatchId = eBatch.Id;
                item.SentTime = null;
                item.ResponseTime = null;
                var eMessage = await _rep.Add(item, actor);
                eBatch.SentMessages.Add(eMessage);
            }
            return eBatch;
        }

        public async Task<MessageBatch> GetMessageBatch(int id)
        {
            Func<IQueryable<MessageBatch>, IQueryable<MessageBatch>> func = query => query
                .Include(u => u.SentMessages)
                    .ThenInclude(u => u.ReceiverProvider)
                        .ThenInclude(u => u.MessageServiceProvider)
                .Include(u => u.SentMessages)
                    .ThenInclude(u => u.ReceiverProvider)
                        .ThenInclude(u => u.MessageReceiver);
            return await _rep.GetById<MessageBatch>(id, func);
        }

        public async Task UpdateSentMessage(SentMessage entity)
        {
            var temp = entity.ReceiverProvider;
            entity.ReceiverProvider = null;
            await _rep.Update(entity);
            entity.ReceiverProvider = temp;
        }

        public async Task<SentMessage> GetSentMessageById(int id)
        {
            return await _rep.GetById<SentMessage>(id);
        }

        public async Task<ICollection<SentMessage>> GetSentMessages(GetListParams<SentMessage> p)
        {
            var temp = p.extension;
            if (temp == null)
                temp = u => u;

            p.extension = v => temp(v.Include(u => u.ReceiverProvider)
                .ThenInclude(u => u.MessageServiceProvider)
            .Include(u => u.ReceiverProvider)
                .ThenInclude(u => u.MessageReceiver));
            return await _rep.List<SentMessage>(p);
        }


        async Task<ICollection<SentMessage>> loadWillSendMessage(MessageBatch batch)
        {
            var param = new GetListParams<SentMessage>();
            param.filter = new Dictionary<string, object>();
            param.filter.Add("MessageBatchId", batch.Id);
            param.SetGetAllItems();
            var sentMessages = await GetSentMessages(param);

            batch.SentMessages = null;
            batch.ActionTime = DateTime.Now;
            await UpdateMessageBatch(batch);

            return sentMessages;
        }

        async Task<IMessagingProvider> checkProviderObject(SentMessage item)
        {
            MessageServiceProvider provider = item.ReceiverProvider.MessageServiceProvider;
            var pClassName = provider.Module;
            var classType = Type.GetType(pClassName + ",DMCIT.Infrastructure");
            IMessagingProvider result = null;
            if (classType != null)
            {
                result = ActivatorUtilities.CreateInstance(_sp, classType) as IMessagingProvider;
            }


            if (result == null)
            {
                item.Status = (int)SentMessage.SentMessageStatus.ERROR;
                item.ResponseTime = DateTime.Now;
                var er = $"NO IMPLEMENT {pClassName} TO PROVIDER {provider.Name} FOUND";
                item.ResponseMessage = er;
                //TODO: Create MessageProviderNotFound          
                await UpdateSentMessage(item);
            }
            return result;
        }

        async Task sendMessage(SentMessage item, IMessagingProvider provider)
        {
            item.Status = (int)SentMessage.SentMessageStatus.SENDING;
            await UpdateSentMessage(item);

            var result = await provider.SendMessage(item.Content, item.ReceiverProvider.ReceiverAddress);

            item.ResponseTime = DateTime.Now;
            item.ResponseMessage = result.ResponseMessage;
            if (result.Success)
            {
                item.Status = (int)SentMessage.SentMessageStatus.SENT;
            }
            else
            {
                item.Status = (int)SentMessage.SentMessageStatus.ERROR;
                item.ResponseMessage = result.ResponseMessage;
            }
            await UpdateSentMessage(item);
        }

        async Task<MessageBatch> sentMessageBatch(MessageBatch batch, SendMessageBatchEventCollection events)
        {
            var sentMessages = await loadWillSendMessage(batch);
            events?.OnSendMessageBatchStart?.Invoke(batch);
            foreach (var item in sentMessages)
            {
                try
                {
                    if (item.Status != (int)SentMessage.SentMessageStatus.WAITING || item.SentTime != null)
                    {
                        //TODO: create MessageSentException class
                        throw new Exception("THIS MESSAGE HAS BEEN SENT TO RECIPIENT");
                    }
                    item.SentTime = DateTime.Now;
                    //Find send message module, if no module found, mark this message is error with this reason.
                    IMessagingProvider provider = await checkProviderObject(item);
                    if (provider != null)
                    {
                        await sendMessage(item, provider);
                        //TODO: define progress data
                        events?.OnSendMessageSucceed?.Invoke(item);
                    }
                }
                catch (SendMessageException e)
                {
                    item.ResponseMessage = e.Message;
                    item.Status = (int)SentMessage.SentMessageStatus.ERROR;
                    events?.OnSendMessageFailed?.Invoke(item, e.Message);
                }
                finally
                {
                    await UpdateSentMessage(item);
                }
            }
            batch.FinishTime = DateTime.Now;
            await UpdateMessageBatch(batch);
            batch.SentMessages = sentMessages;
            return batch;
        }

        public async Task SendMessageBatchHangfire(int batchId, AppUser actor, PerformContext context)
        {
            var events = SendMessageBatchEventCollection.CreateProcessEvent(_service, actor, context);
            Func<Task> task = async () =>
            {
                await SendMessageBatch(batchId, actor, events);
            };

            var title = $"Send message batch #{batchId}";
            await _processService.StartProcess(context, title, task, actor);
        }

        public async Task<MessageBatch> SendMessageBatch(int batchId, AppUser actor, SendMessageBatchEventCollection events)
        {
            try
            {
                //Trigger event
                events?.OnSendMessageBatchInitialize?.Invoke(batchId, actor);

                //
                var batch = await GetMessageBatch(batchId);
                if (batch == null)
                {
                    //TODO: Create MessageBatchNotFoundException class
                    throw new Exception("Message batch not found");
                }
                if (batch.FinishTime != null)
                {
                    //TODO: Create InvalidMessageBatch Exception
                    throw new Exception("Message batch not found");
                }
                //Send messages
                batch = await sentMessageBatch(batch, events);
                //Has to remove batchState out of hub

                //Trigger events
                events?.OnSendMessageBatchEnd?.Invoke(batch);
                return batch;
            }
            catch (Exception e)
            {
                var temp = e;
                var mes = temp.Message;
                while (temp.InnerException != null)
                {
                    temp = temp.InnerException;
                    mes += Environment.NewLine + temp.Message;
                }
                events?.OnSendMessageBatchFailed?.Invoke(batchId, mes);
                throw;
            }
        }
    }
}
