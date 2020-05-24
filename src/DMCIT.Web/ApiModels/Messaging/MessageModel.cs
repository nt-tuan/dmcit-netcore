using DMCIT.Core.Entities.Messaging;
using System;

namespace DMCIT.Web.ApiModels.Messaging
{
    public class SentMessageModel
    {
        public int id { get; set; }
        public string content { get; set; }
        public string addressee { get; set; }
        public string provider { get; set; }
        public DateTime? sentTime { get; set; }
        public DateTime? responseTime { get; set; }
        public string responseMessage { get; set; }
        public int status { get; set; }
        public int messageBatchId { get; set; }
        public SentMessageModel()
        {

        }

        public SentMessageModel(SentMessage entity)
        {
            content = entity.Content;
            id = entity.Id;
            addressee = entity.ReceiverProvider != null ? entity.ReceiverProvider.ReceiverAddress : null;
            provider = entity.ReceiverProvider != null && entity.ReceiverProvider.MessageServiceProvider != null ? entity.ReceiverProvider.MessageServiceProvider.Name : null;
            sentTime = entity.SentTime;
            responseTime = entity.ResponseTime;
            responseMessage = entity.ResponseMessage;
            status = entity.Status;
            messageBatchId = entity.MessageBatchId;
        }
    }
}
