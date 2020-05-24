using System.Collections.Generic;

namespace DMCIT.Web.ApiModels.HR
{
    public class DepartmentCollectionModel
    {
        public ICollection<DepartmentModel> depts { get; set; } = new List<DepartmentModel>();
    }
}
