using System.Collections.Generic;

namespace DMCIT.Web.ApiModels.Messaging
{
    public class ReviewReceiversModel
    {
        public List<int> receivers { get; set; }
        public List<int> groups { get; set; }
        public List<int> providers { get; set; }
    }
}
