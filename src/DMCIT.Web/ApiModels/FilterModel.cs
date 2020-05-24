using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DMCIT.Web.ApiModels
{
    public abstract class FilterModel<T>
    {
        public string Search { get; set; }
        public abstract IQueryable<T> BuildQuery(IQueryable<T> query);
        public abstract Expression<Func<T, object>> BuildOrder(string orderBy, int? orderDir);

        public virtual IQueryable<T> BuildSearchQuery(IQueryable<T> q)
        {
            return q;
        }

        public static IQueryable<T> BuildQuery(IQueryable<T> q, DateRangeModel model, Func<T, DateTime?> func)
        {
            return model?.BuildQuery(q, func) ?? q;
        }
        public static IQueryable<T> BuildQuery<V>(IQueryable<T> q, ListModel<V> filter, Func<T, V> func)
        {
            return filter?.BuildQuery(q, func) ?? q;
        }

        public bool IsValidList(List<string> l)
        {
            return l != null && l.Count > 0 && !string.IsNullOrEmpty(l[0]);
        }

        public bool IsValidList<E>(List<E> l)
        {
            return l != null && l.Count > 0 && l[0] != null;
        }
    }
}
