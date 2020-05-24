using System.Collections.Generic;

namespace DMCIT.Web.ApiModels.HR
{
    public class EmployeeCollectionModel
    {
        public ICollection<EmployeeModel> employees { get; set; } = new List<EmployeeModel>();
    }
}
