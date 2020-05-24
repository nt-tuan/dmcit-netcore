using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.Core
{
    public class Employee : BaseVersionControlEntity<Employee>
    {
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public string Code { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? EmployeeTitleId { get; set; }
        public EmployeeTitle EmployeeTitle { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public bool HasAccount()
        {
            return string.IsNullOrEmpty(AppUserId);
        }
    }
}
