using DMCIT.Core.Entities.Core;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DMCIT.Web.ApiModels.HR
{
    public class EmployeeFilterModel : FilterModel<Employee>
    {
        public Func<IQueryable<Employee>, IQueryable<Employee>> extendQuery { get; set; }
        public Expression<Func<Employee, object>> order;
        public string code { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public int? departmentId { get; set; }
        public override IQueryable<Employee> BuildQuery(IQueryable<Employee> q)
        {
            q = BuildSearchQuery(q);
            if (departmentId != null)
                q = q.Where(u => u.DepartmentId == departmentId);

            if (!string.IsNullOrEmpty(code))
            {
                q = q.Where(u => u.Code == code);
            }

            if (!string.IsNullOrEmpty(name))
            {
                q = q.Where(u => u.Person.DisplayName.Contains(name) || u.Person.FullName.Contains(name));
            }

            if (!string.IsNullOrEmpty(department))
            {
                q = q.Where(u => u.Department.Code == department || u.Department.FullName.Contains(department));
            }

            return q;
        }

        public override Expression<Func<Employee, object>> BuildOrder(string orderBy, int? orderDir)
        {
            if (orderBy == nameof(name))
            {
                return u => u.Person.DisplayName;
            }
            else if (orderBy == nameof(department))
            {
                return u => u.Department.Code;
            }
            else if (orderBy == nameof(departmentId))
                return u => u.DepartmentId;
            return u => u.Code;
        }

        public override IQueryable<Employee> BuildSearchQuery(IQueryable<Employee> q)
        {
            if (!string.IsNullOrEmpty(Search))
            {
                return q.Where(u => u.Code == Search || u.Person.FullName.Contains(Search) || u.Person.DisplayName.Contains(Search));
            }
            return q;
        }
    }
}
