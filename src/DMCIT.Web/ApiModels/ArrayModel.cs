using System;
using System.Collections.Generic;
using System.Linq;

namespace DMCIT.Web.ApiModels
{
    public class IntCollectionModel
    {
        public List<int> collection { get; set; } = new List<int>();
    }

    public class ListModel<T> : List<T>
    {
        public ListModel() : base() { }
        public ListModel(params T[] items) : this()
        {
            foreach (var item in items)
                Add(item);
        }

        public IQueryable<V> BuildQuery<V>(IQueryable<V> query, Func<V, T> func)
        {
            if (Count > 0)
                return query.Where(u => Contains(func(u)));
            return query;
        }
    }
}
