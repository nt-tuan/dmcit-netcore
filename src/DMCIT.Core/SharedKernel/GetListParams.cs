using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DMCIT.Core.SharedKernel
{
    public class GetListParams<T>
    {
        public static int ORDER_DIR_ASC = 0;
        public static int ORDER_DIR_DESC = 1;
        const string DEFAULT_ORDER_BY = "id";
        public string search { get; set; }
        public int? page { get; set; } = 0;
        public int? pageRows { get; set; } = 30;
        public Expression<Func<T, object>> orderBy { get; set; } = null;
        public int orderDir { get; set; } = ORDER_DIR_ASC;
        public DateTime at { get; set; } = DateTime.Now;
        public Func<IQueryable<T>, IQueryable<T>> extension { get; set; }
        public Func<IQueryable<T>, IQueryable<T>> preExtension { get; set; }

        //TEMPORAR ADD FOR THIS APPLICATION CAN WORK AT THIS MOMENT
        public IDictionary<string, object> filter { get; set; }
        public GetListParams() { }
        public GetListParams(int? page, int? pageRows)
        {
            this.page = page;
            this.pageRows = pageRows;
        }

        public void SetGetAllItems()
        {
            page = null;
            pageRows = null;
        }
    }
}
