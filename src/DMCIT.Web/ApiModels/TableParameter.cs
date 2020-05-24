using DMCIT.Core.SharedKernel;

namespace DMCIT.Web.ApiModels
{
    public class TableParameter<F, E>
        where E : new()
        where F : FilterModel<E>, new()
    {
        public const int ORDER_ASC = 0;
        public const int ORDER_DESC = 1;
        public int? pageSize { get; set; } = 30;
        public int? page { get; set; } = 0;
        public string search { get; set; } = null;
        public string orderBy { get; set; } = "id";
        public int orderDirection { get; set; } = 0;

        public F filter { get; set; } = new F();

        public GetListParams<E> ToEntityParam()
        {
            var p = new GetListParams<E>
            {
                pageRows = pageSize,
                page = page,
                search = search,
                orderDir = orderDirection
            };


            if (filter != null)
            {
                p.orderBy = filter.BuildOrder(orderBy, orderDirection);
                p.extension = u => filter.BuildQuery(u);
            }

            return p;
        }
    }

    public class TableParameter
    {
        public const int ORDER_ASC = 0;
        public const int ORDER_DESC = 1;
        public int pageSize { get; set; } = 30;
        public int page { get; set; } = 0;
        public string search { get; set; } = null;
        //public string orderBy { get; set; } = "id";
        public int orderDirection { get; set; } = 0;
        //public IDictionary<string, object> filter { get; set; }
        public TableParameter<F, E> ToFilterTableParameter<F, E>()
            where E : new()
        where F : FilterModel<E>, new()
        {
            var p = new TableParameter<F, E>();
            p.pageSize = pageSize;
            p.page = page;
            p.search = search;
            p.orderDirection = orderDirection;
            return p;
        }
        public GetListParams<T> ToEntityParam<T>()
        {
            var p = new GetListParams<T>
            {
                pageRows = this.pageSize,
                page = this.page,
                search = this.search,
                orderBy = null,
                orderDir = this.orderDirection,
                extension = null
            };
            return p;
        }
    }
}
