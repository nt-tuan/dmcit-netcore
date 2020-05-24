using DMCIT.Core.Entities.Messaging;
using DMCIT.Web.ApiModels.Accounts;
using System;

namespace DMCIT.Web.ApiModels.Messaging
{
    public class MessageBatchModel
    {
        public int id { get; set; }
        public DateTime? sentDate { get; set; }
        public DateTime? finishDate { get; set; }
        public UserModel createdBy { get; set; }
        public int count { get; set; }
        public MessageBatchModel()
        {

        }

        public MessageBatchModel(MessageBatch entity)
        {
            id = entity.Id;
            sentDate = entity.ActionTime;
            finishDate = entity.FinishTime;
            if (entity.CreatedBy != null)
                createdBy = new UserModel(entity.CreatedBy);
        }

    }
}
