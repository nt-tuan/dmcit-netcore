using System.Collections.Generic;

namespace DMCIT.Web.ApiModels
{
    public class BaseListModel<T>
    {
        public IEnumerable<T> data { get; set; }
        public int? page { get; set; }
        public int? pageSize { get; set; }
        public int totalCount { get; set; }

        public BaseListModel(IEnumerable<T> myData, int? myPage, int? myPageSize, int myCount)
        {
            data = myData;
            page = myPage;
            pageSize = myPageSize;
            totalCount = myCount;
        }

        public ResponseModel ToResponseModel()
        {
            return new ResponseModel(this);
        }
    }
}
