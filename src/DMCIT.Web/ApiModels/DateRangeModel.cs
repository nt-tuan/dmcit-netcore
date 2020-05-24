using System;
using System.Linq;

namespace DMCIT.Web.ApiModels
{
    public class DateRangeModel
    {
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }

        public IQueryable<T> BuildQuery<T>(IQueryable<T> query, Func<T, DateTime?> func)
        {
            if (startDate != null)
                query = query.Where(u => func(u) >= startDate);
            if (endDate != null)
                query = query.Where(u => func(u) <= startDate);
            return query;
        }
    }
}
