using DMCIT.Core.Entities.Messaging;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DMCIT.Web.ApiModels.Messaging
{
    public class SentMessageFilterModel : FilterModel<SentMessage>
    {
        public int? messageBatch { get; set; }
        public override Expression<Func<SentMessage, object>> BuildOrder(string orderBy, int? orderDir)
        {
            return u => u.Id;
        }

        public override IQueryable<SentMessage> BuildQuery(IQueryable<SentMessage> query)
        {
            if (messageBatch != null)
            {
                query = query.Where(u => u.MessageBatchId == messageBatch);
            }
            return query;
        }

        public override IQueryable<SentMessage> BuildSearchQuery(IQueryable<SentMessage> q)
        {
            return q;
        }
    }
}
