using DMCIT.Core.Entities.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DMCIT.Web.ApiModels.Messaging
{
    public class MessageBatchFilterModel : FilterModel<MessageBatch>
    {
        const string SENT_TIME = "senttime";
        const string FINISH_TIME = "finishtime";
        const string ID = "id";
        public List<DateRangeModel> SentDate { get; set; }
        public override Expression<Func<MessageBatch, object>> BuildOrder(string orderBy, int? orderDir)
        {
            //throw new NotImplementedException();
            if (orderBy == SENT_TIME)
                return u => u.ActionTime;
            if (orderBy == FINISH_TIME)
                return u => u.FinishTime;
            if (orderBy == ID)
                return u => u.Id;
            return u => u.ActionTime;
        }

        public override IQueryable<MessageBatch> BuildQuery(IQueryable<MessageBatch> query)
        {
            if (IsValidList(SentDate))
            {
                var item = SentDate[0];
                var endDate = item.endDate;
                var startDate = item.startDate;
                if (endDate != null)
                {
                    query = query.Where(u => u.ActionTime < endDate);
                }
                if (startDate != null)
                {
                    query = query.Where(u => u.ActionTime >= startDate);
                }
            }
            return query;
        }

        public override IQueryable<MessageBatch> BuildSearchQuery(IQueryable<MessageBatch> q)
        {
            return q;
        }
    }
}
