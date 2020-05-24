using DMCIT.Core.Entities.Accounting;
using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.DataCollector;
using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Data.Exceptions;
using DMCIT.Infrastructure.Data.Exceptions.Accounting;
using DMCIT.Infrastructure.Services;
using Hangfire;
using Hangfire.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data
{
    public class CoreRepository : ICoreRepository
    {
        readonly IRepository _repos;
        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<AppRole> _roleManager;
        readonly AppDbContext _db;
        readonly IAccountingPeriodService _apService;
        readonly IProcessManagerService _processService;
        readonly ICoreService _service;
        public CoreRepository(IRepository repos, UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            AppDbContext db, ICoreService service,
IAccountingPeriodService apService,
            IProcessManagerService processService)
        {
            _repos = repos;
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
            _apService = apService;
            _processService = processService;
            _service = service;
        }

        #region Departments
        public async Task AddDepartment(Department department, AppUser appUser)
        {
            await _repos.AddDetail(department, DateTime.Now, appUser);
        }

        public async Task DeleteDepartment(int id, AppUser appUser)
        {
            var department = await GetDepartment(id);
            if (department != null)
            {
                await _repos.DeleteDetail<Department>(department, DateTime.Now, appUser);
            }
        }

        public async Task<Department> GetDepartment(int id)
        {
            var dept = await _repos.GetById<Department>(id, DateTime.Now);
            return dept;
        }

        public async Task<int> GetDepartmentCount(GetListParams<Department> param)
        {
            var count = await _repos.CountDetail<Department>(param);
            return count;
        }

        public async Task<ICollection<Department>> GetDepartments(GetListParams<Department> p)
        {
            var list = await _repos.ListVersionControl(p);
            return list;
        }

        public async Task UpdateDepartment(Department department, AppUser appUser)
        {
            var entity = await _repos.GetById<Department>(department.Id);
            entity.UpdateFrom(department);
            await _repos.UpdateDetail(entity, DateTime.Now, appUser);
        }

        public async Task<IDictionary<int, Department>> GetDepartmentsTree()
        {
            var dict = new Dictionary<int, Department>();
            var p = new GetListParams<Department>();
            var list = await _repos.ListVersionControl<Department>(p);
            foreach (var item in list)
            {
                dict.Add(item.Id, item);
            }

            foreach (var item in dict)
            {
                if (item.Value.ParentId != null && dict.ContainsKey(item.Value.ParentId.Value))
                    item.Value.Parent = dict[item.Value.ParentId.Value];
            }
            return dict;
        }

        public async Task<Department> GetDepartmentById(int id, DateTime? at)
        {
            return await _repos.GetById<Department>(id, at);
        }

        public async Task<Department> GetDepartmentTreeById(int id)
        {
            var set = new HashSet<int>();
            var dept = await _repos.GetById<Department>(id);
            var temp = dept;
            while (!set.Contains(temp.Id))
            {
                set.Add(temp.Id);
                if (temp.ParentId != null)
                {
                    var parent = await _repos.GetById<Department>(temp.ParentId.Value);
                    temp.Parent = parent;
                    temp = parent;
                }
            }
            return dept;
        }

        public async Task UpdateOrAddDepartmentByCode(Department department, AppUser appUser)
        {
            var p = new GetListParams<Department>();
            p.extension = query => query.Where(u => u.Code == department.Code);

            var deptCount = await GetDepartments(p);
            if (deptCount.Count > 0)
            {
                department.Id = deptCount.First().Id;
                department.OriginId = deptCount.First().OriginId;
                await UpdateDepartment(department, appUser);
            }
            else
            {
                await AddDepartment(department, appUser);
            }
        }
        public async Task<Dictionary<string, Employee>> BulkFindEmployeeByCode(IEnumerable<string> codes)
        {
            var set = codes.ToHashSet();
            var rs = new Dictionary<string, Employee>();
            foreach (var c in set)
            {
                var emp = await GetEmployeeByCode(c);
                rs.Add(c, emp);
            }
            return rs;
        }
        #endregion

        #region Employees
        public async Task<Employee> AddEmployee(Employee employee, AppUser appUser)
        {
            var time = DateTime.Now;
            Person person = null;
            if (employee.Person != null && !string.IsNullOrEmpty(employee.Person.IdentityNumber))
            {
                var personP = new GetListParams<Person>();
                personP.extension = query => query.Where(u => u.IdentityNumber == employee.Person.IdentityNumber);
                personP.at = time;
                person = (await _repos.ListVersionControl<Person>(personP)).FirstOrDefault();
                if (person != null)
                {
                    employee.Person.OriginId = person.OriginId ?? person.Id;
                    await _repos.UpdateDetail(employee.Person);
                }
            }
            else
            {
                person = await _repos.GetById<Person>(employee.PersonId, time);
            }

            if (person == null)
            {
                person = await _repos.AddDetail(employee.Person, time, appUser);
            }

            employee.PersonId = person.OriginId ?? person.Id;
            employee.Person = null;
            employee.CreatedById = appUser == null ? null : appUser.Id;
            await _repos.AddDetail(employee, time, appUser);
            employee.Person = person;
            return employee;
        }

        public async Task AddEmployeeAccount(int id, string username, AppUser appUser)
        {
            await Task.Run(() => { });
            //var emp = await GetEmployee(id);
        }

        public async Task<Employee> GetEmployeeByCode(string code)
        {
            var p = new GetListParams<Employee>();
            p.extension = query => query.Where(u => u.Code == code);
            p.at = DateTime.Now;
            var employee = await _repos.ListVersionControl(p);
            return employee.FirstOrDefault();
        }

        public async Task<Employee> GetEmployeeById(int id, DateTime? at = null)
        {
            var emp = await _repos.GetById<Employee>(_db.Employees.Include(u => u.Person).Include(u => u.Department), id, at);
            return emp;
        }

        public async Task<int> GetEmployeeCount(GetListParams<Employee> filter)
        {
            return await _repos.CountDetail<Employee>(filter);
        }

        public async Task<ICollection<Employee>> ListEmployees(GetListParams<Employee> p)
        {
            //throw new NotImplementedException()
            p.preExtension = query => query.Include(u => u.Person).Include(u => u.Department);
            var list = await _repos.ListVersionControl(p);
            return list;
        }

        public async Task DeleteEmployee(int id, AppUser appUser)
        {
            var emp = await _repos.GetById<Employee>(id, DateTime.Now);
            if (emp != null)
                await _repos.DeleteDetail(emp, DateTime.Now, appUser);
            else
                throw new EntityNotFound(typeof(Employee), emp);
        }

        public Task RevokeEmployeeAccount(int id, AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEmployee(Employee updated, AppUser appUser)
        {
            await _repos.UpdateDetail(updated.Person, DateTime.Now, appUser);
            var temp = updated.Person;
            updated.Person = null;
            await _repos.UpdateDetail(updated, DateTime.Now, appUser);
            updated.Person = temp;
        }
        public async Task UpdateOrAddEmployeeByCode(Employee employee, AppUser appUser)
        {
            var p = new GetListParams<Employee>();
            p.extension = query => query.Where(u => u.Code == employee.Code);

            var currentEmp = (await _repos.ListVersionControl(p)).FirstOrDefault();

            if (currentEmp == null)
            {
                await AddEmployee(employee, appUser);
            }
            else
            {
                currentEmp.Person = await GetPersonById(currentEmp.PersonId);

                employee.OriginId = currentEmp.OriginId;
                employee.Id = currentEmp.Id;

                employee.PersonId = currentEmp.PersonId;
                employee.Person.Id = currentEmp.Person.Id;
                employee.Person.OriginId = currentEmp.Person.OriginId;
                employee.Id = currentEmp.Id;
                await UpdateEmployee(employee, appUser);
            }
        }
        #endregion

        public async Task<ICollection<AppUser>> GetUserList(GetListParams<AppUser> param)
        {
            var query = _userManager.Users.AsNoTracking().AsQueryable();
            query = query.Include(u => u.Employee).Include(u => u.Customer);
            query = _repos.ApplyFitlerToQuery(param.filter, query);
            query = _repos.ApplyDefaultPaging(query, param.page, param.pageRows, param.orderBy, param.orderDir);
            var users = await query.ToListAsync();
            return users;
        }

        public async Task<int> GetUserCount(GetListParams<AppUser> param)
        {
            var query = _userManager.Users.AsNoTracking().AsQueryable();
            query = _repos.ApplyFitlerToQuery(param.filter, query);
            return await query.CountAsync();
        }

        public async Task<ICollection<AppRole>> GetRoleList()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        #region Distributed servers
        public async Task<List<DistributedServer>> GetDistributedServers()
        {
            var entity = await _db.DistributedServers.ToListAsync();
            return entity;
        }

        public async Task<DistributedServer> GetDistributedServer(string code)
        {
            var entity = await _repos.RawSqlQuery<DistributedServer>(_db, "execute GetServerInfo @code", new[] {
                new SqlParameter("@code", code)
            });
            return entity.FirstOrDefault();
        }

        public async Task UpdateDistributedServer(DistributedServer server)
        {
            var result = _db.DistributedServers.Update(server);
            await _db.SaveChangesAsync();
        }

        public async Task AddDistributedServer(DistributedServer server)
        {
            _db.DistributedServers.Add(server);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteDistributedServer(DistributedServer server)
        {
            await _db.Database.ExecuteSqlCommandAsync("execute DeleteServerInfo", new[] {
                new SqlParameter("@code", server.DistributorCode)
            });
        }
        #endregion

        #region ACCOUNTING PERIOD
        public async Task<AccountingPeriod> GetOpeningAccountPeriod()
        {
            var param = new GetListParams<AccountingPeriod>();
            param.extension = query => query.Where(u => u.OpenTime != null && u.CloseTime == null);
            var entities = await _repos.ListVersionControl(param);
            return entities.FirstOrDefault();
        }

        public async Task<AccountingPeriod> GetLastClosedAccountingPeriod()
        {
            var param = new GetListParams<AccountingPeriod>();
            param.orderBy = u => u.CloseTime;
            param.orderDir = (int)BaseEntity.ListOrder.DESC;
            param.extension = query => query.Where(u => u.CloseTime != null);
            var lst = await _repos.ListVersionControl(param);
            return lst.FirstOrDefault();
        }

        public async Task<AccountingPeriod> GetAccountingPeriodById(int id)
        {
            return await _repos.GetById<AccountingPeriod>(id, DateTime.Now);
        }

        public async Task<ICollection<AccountingPeriod>> GetAccountingPeriods()
        {
            var param = new GetListParams<AccountingPeriod>();
            param.orderBy = u => u.AccountingStartTime;
            param.orderDir = (int)BaseEntity.ListOrder.ASC;
            return await _repos.ListVersionControl(param);
        }

        public async Task AddAccountingPeriod(AccountingPeriod entity, AppUser actor)
        {
            var last = await GetLastAccountingPeriod();
            if (last != null)
            {
                entity.AccountingStartTime = last.AccountingEndTime;
            }
            else
            {
                entity.AccountingStartTime = null;
            }
            entity.OpenTime = null;
            entity.CloseTime = null;
            await _repos.AddDetail(entity);
        }

        public async Task UpdateAccountingPeriod(AccountingPeriod entity, AppUser actor)
        {
            await _repos.UpdateDetail(entity, DateTime.Now, actor);
        }

        public async Task DeleteAccountingPeriod(AccountingPeriod entity, AppUser actor)
        {
            await _repos.DeleteDetail(entity, DateTime.Now, actor);
        }

        [AutomaticRetry(Attempts = 0)]
        public async Task CloseAccountingPeriod(AppUser actor, PerformContext context)
        {
            Func<Task> task = async () =>
            {
                using (var trans = await _db.Database.BeginTransactionAsync())
                {
                    var current = await GetOpeningAccountPeriod();
                    if (current == null)
                    {
                        throw new OpeningAccountingPeriodNotFound().ToException();
                    }
                    //var process = await _process.GetRunningJob<BackgroundProcess>(processId);
                    current.CloseTime = DateTime.Now;
                    await _apService.OnAccountingClosed(current, context);
                    await _repos.UpdateDetail(current, DateTime.Now, actor);
                    trans.Commit();
                }
            };

            await _processService.StartProcess(context, "CLOSE ACCOUNTING PERIOD", task, actor);
        }

        public async Task RevertAccountingPeriod(AppUser actor)
        {
            using (var scope = await _db.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable))
            {
                var last = await GetLastClosedAccountingPeriod();
                var opening = await GetOpeningAccountPeriod();
                if (opening != null)
                {
                    throw new OpeningAccountingPeriodExisted().ToException();
                }


                if (last == null)
                {
                    throw new ClosedAccountingPeriodNotFound().ToException();
                }

                last.OpenTime = null;
                last.CloseTime = null;
                await _repos.UpdateDetail(last, DateTime.Now, actor);
                scope.Commit();
            }
        }

        public async Task<Diary131> GetLastDiary131(string code)
        {
            return await _db.Diary131s.Where(u => u.DistributorCode == code).OrderByDescending(u => u.ReceiptDate).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Diary131>> GetDiary131(GetListParams<Diary131> p)
        {
            return await _repos.List(p);
        }

        public async Task<AccountingPeriod> GetNextOpeningAccountingPeriod()
        {
            var param = new GetListParams<AccountingPeriod>();
            param.orderBy = u => u.AccountingStartTime;
            param.orderDir = (int)BaseEntity.ListOrder.ASC;
            param.page = 0;
            param.pageRows = 1;
            param.extension = query => query.Where(u => u.OpenTime == null);
            param.at = DateTime.Now;
            var lst = await _repos.ListVersionControl(param);
            return lst.FirstOrDefault();
        }

        public async Task OpenAccountingPeriod(AppUser actor)
        {
            var opening = await GetOpeningAccountPeriod();
            if (opening != null)
            {
                throw (new ExistOpeningAccountingPeriod()).ToException();
            }

            var next = await GetNextOpeningAccountingPeriod();
            if (next == null)
            {
                throw new NextOpeningAccountingPeriodNotFound().ToException();
            }
            var now = DateTime.Now;
            next.OpenTime = now;
            await _repos.UpdateDetail(next, now, actor);
        }

        public async Task<AccountingPeriod> GetLastAccountingPeriod()
        {
            var param = new GetListParams<AccountingPeriod>();
            param.orderBy = u => u.AccountingStartTime;
            param.orderDir = (int)BaseEntity.ListOrder.DESC;
            param.page = 0;
            param.pageRows = 1;
            var lst = await _repos.ListVersionControl(param);
            return lst.FirstOrDefault();
        }

        public async Task<AccountingPeriod> FindLastClosedAccountingPeriod(DateTime? before)
        {
            var param = new GetListParams<AccountingPeriod>();
            param.orderBy = u => u.AccountingStartTime;
            param.orderDir = (int)BaseEntity.ListOrder.DESC;
            param.page = 0;
            param.pageRows = 1;
            param.extension = query => query.Where(u => u.CloseTime != null && u.AccountingEndTime <= before);
            var lst = await _repos.ListVersionControl(param);
            return lst.FirstOrDefault();
        }

        #endregion

        #region Persons
        public async Task<Person> AddPerson(Person person, AppUser actor)
        {
            var rs = await _repos.AddDetail(person, DateTime.Now, actor);
            return rs;
        }

        public async Task UpdatePerson(Person person, AppUser actor)
        {
            await _repos.UpdateDetail(person, DateTime.Now, actor);
            await _service.OnPersonUpdated(person);
        }

        public async Task<Person> UpdateOrAddPerson(Person person, AppUser actor)
        {
            //If this person does has an identity number, lookup this person, then update his information
            if (!string.IsNullOrEmpty(person.IdentityNumber))
            {
                //Look up this person
                var tper = await _db.People.AsNoTracking().Where(u => u.IdentityNumber == person.IdentityNumber).FirstOrDefaultAsync();
                if (tper != null)
                {
                    tper.UpdateFrom(person);
                    await _repos.UpdateDetail(tper, DateTime.Now, actor);
                    return tper;
                }
                else
                {
                    return await AddPerson(person, actor);
                }
            }
            else
            {
                return await AddPerson(person, actor);
            }
        }
        #endregion

        #region Business
        public async Task<Business> UpdateOrAddBusiness(Business business, AppUser actor)
        {
            if (!string.IsNullOrEmpty(business.BusinessIdentityNumber))
            {
                var tper = await _db.Businesses.AsNoTracking().Where(u => u.BusinessIdentityNumber == business.BusinessIdentityNumber).FirstOrDefaultAsync();
                if (tper != null)
                {
                    tper.UpdateFrom(business);
                    await _repos.UpdateDetail(tper, DateTime.Now, actor);
                    return tper;
                }
                else
                {
                    return await _repos.AddDetail(business, DateTime.Now, actor);
                }
            }
            else
            {
                return await _repos.AddDetail(business, DateTime.Now, actor);
            }
        }

        public async Task<Person> GetPersonById(int id, DateTime? at = null)
        {
            return await _repos.GetById<Person>(id, at);
        }

        public async Task<Business> GetBusinessById(int id, DateTime? at = null)
        {
            return await _repos.GetById<Business>(id, at);
        }

        public async Task<Business> AddBusiness(Business business, AppUser actor)
        {
            var rs = await _repos.AddDetail(business, DateTime.Now, actor);
            return rs;
        }

        public async Task UpdateBusiness(Business business, AppUser actor)
        {
            await _repos.UpdateDetail(business, DateTime.Now, actor);
            await _service.OnBusinessUpdated(business);
        }

        public async Task<Person> GetPersonByIdentity(string identity, DateTime? at = null)
        {
            var p = new GetListParams<Person>();
            p.extension = q => q.Where(u => u.IdentityNumber == identity);
            var persons = await _repos.ListVersionControl(p);
            return persons.FirstOrDefault();
        }

        public async Task<Business> GetBusinessByIdentity(string identity, DateTime? at = null)
        {
            var p = new GetListParams<Business>();
            p.extension = q => q.Where(u => u.BusinessIdentityNumber == identity);
            var bs = await _repos.ListVersionControl(p);
            return bs.FirstOrDefault();
        }

        public async Task<Employee> GetEmployeeByPersonId(int id)
        {
            var query = _db.Employees.Where(u => u.PersonId == id);
            query = _repos.ApplyDefaultWhere(query, DateTime.Now);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Employee> GetEmployeeByUser(AppUser user)
        {
            if (user.EmployeeId == null) return null;
            return await GetEmployeeById(user.EmployeeId.Value);
        }

        public async Task UpdateAccount(Employee entity, AppUser account)
        {
            entity.AppUserId = account.Id;
            await _repos.Update(entity);
        }
        #endregion
    }
}
