using DMCIT.Core.Entities.Core;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Web.ApiModels.HR
{
    public class DepartmentErrorableModel : DepartmentModel
    {
        public ICollection<MessageModel> messages { get; set; } = new List<MessageModel>();

        public DepartmentErrorableModel()
        {

        }

        public DepartmentErrorableModel(Department entity) : base(entity)
        {

        }

        public async Task UpdateDepartmentFromCell(string header, ICell cell, Func<string, Task<ICollection<Department>>> getDept)
        {
            header = header.ToLower();
            if (cell == null || cell.CellType == CellType.Blank)
            {
                return;
            }

            if (header == "code")
            {
                var curDept = await getDept(cell.ToString());
                if (curDept != null && curDept.Count > 0)
                {
                    messages.Add(MessageModel.CreateWarning("DEPARTMENT_CODE_EXISTED", header));
                }
                code = cell.ToString();
            }
            else if (header == "name")
            {
                name = cell.ToString();
            }
            else if (header == "parent")
            {
                var parentValue = cell.ToString();
                if (String.IsNullOrEmpty(parentValue))
                    return;
                var curParent = await getDept(parentValue);
                if (curParent.Count > 0)
                {
                    SetParent(curParent.First());
                }
                else
                {
                    messages.Add(MessageModel.CreateError("INVALID PARENT DEPARTMENT", header));
                }
            }
        }
    }
}
