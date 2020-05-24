using DMCIT.Core.Entities.Core;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Web.ApiModels.HR
{
    public class EmployeeErrorableModel : EmployeeModel
    {
        public EmployeeErrorableModel()
        {

        }
        public EmployeeErrorableModel(Employee entity) : base(entity)
        {

        }
        public ICollection<MessageModel> messages { get; set; } = new List<MessageModel>();

        public async Task UpdateEmployeeFromCell(string header, ICell cell, Func<dynamic, Task<List<Employee>>> getEmp, Func<dynamic, Task<List<Department>>> getDept)
        {
            if (cell == null && cell.CellType == CellType.Blank)
            {
                return;
            }

            header = header.ToLower();
            if (header == "code")
            {
                var code = cell.ToString();
                var filter = new Dictionary<string, object>();
                filter.Add("Code", code);
                var emp = await getEmp(filter);
                if (emp.Count > 0)
                {
                    messages.Add(MessageModel.CreateWarning("EMPLOYEE_CODE_EXISTED", header));
                }
                this.code = code;
            }
            else if (header == "firstname")
            {
                person.firstname = cell.ToString();
            }
            else if (header == "lastname")
            {
                person.lastname = cell.ToString();
            }
            else if (header == "email")
            {
                person.email = cell.ToString();
            }
            else if (header == "birthday")
            {
                person.birthday = cell.DateCellValue;
            }
            else if (header == "id-number")
            {
                person.identityNumber = cell.ToString();
            }
            else if (header == "department")
            {
                var parentCode = cell.ToString();
                var filter = new Dictionary<string, object>();
                filter.Add("Code", parentCode);
                var dept = await getDept(filter);
                if (dept.Count > 0)
                {
                    var curDept = dept.First();
                    this.dept = new DepartmentModel(curDept);
                }
                else
                    messages.Add(MessageModel.CreateError("INVALID DEPARMENT", header));
            }
        }
    }
}
