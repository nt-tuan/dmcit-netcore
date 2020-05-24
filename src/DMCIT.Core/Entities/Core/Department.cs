using DMCIT.Core.SharedKernel;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Core
{
    public class Department : VSTreeNodeEntity<Department, DepartmentRelation>
    {
        public string Code { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }

        public string Location { get; set; }
        public string Location2 { get; set; }
        public string Location3 { get; set; }

        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public override void UpdateFrom(BaseEntity e)
        {
            var entity = e as Department;
            Code = entity.Code;
            FullName = entity.FullName;
            ShortName = entity.ShortName;
            ManagerId = entity.ManagerId;
        }
    }
}
