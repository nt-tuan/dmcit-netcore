using DMCIT.Core.Entities.Core;
using DMCIT.Web.ApiModels.Core;

namespace DMCIT.Web.ApiModels.HR
{
    public class EmployeeModel : BaseModel<Employee>
    {
        public string code { get; set; }
        public DepartmentModel dept { get; set; }

        public PersonModel person { get; set; }
        public EmployeeModel()
        {

        }

        public EmployeeModel(Employee entity) : base(entity)
        {
            code = entity.Code;
            if (entity.Person != null)
            {
                person = new PersonModel(entity.Person);
            }
            if (entity.Department != null)
                dept = new DepartmentModel(entity.Department);
        }

        public Employee ToEmployee()
        {
            var entity = new Employee
            {
                Id = id,
                Code = code
            };

            if (dept != null)
            {
                entity.DepartmentId = dept.id;
            }

            if (person != null)
            {
                entity.Person = person.ToEntity();
                entity.PersonId = person.id;
            }

            return entity;
        }
    }
}
