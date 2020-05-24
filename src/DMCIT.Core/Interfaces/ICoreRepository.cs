using DMCIT.Core.Entities.Accounting;
using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.DataCollector;
using DMCIT.Core.SharedKernel;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Core.Interfaces
{
    public interface ICoreRepository
    {
        #region Person
        /// <summary>
        /// Update this person information if his identity existed. Otherwise, add this person to database
        /// </summary>
        /// <param name="person"></param>
        /// <param name="actor"></param>
        /// <returns></returns>
        Task<Person> UpdateOrAddPerson(Person person, AppUser actor);
        Task<Person> AddPerson(Person person, AppUser actor);
        Task UpdatePerson(Person person, AppUser actor);
        Task<Person> GetPersonById(int id, DateTime? at = null);
        Task<Person> GetPersonByIdentity(string identity, DateTime? at = null);
        #endregion

        #region Business
        /// <summary>
        /// Update this business information if it's identity existed. Otherwise, add this business to database
        /// </summary>
        /// <param name="business"></param>
        /// <param name="actor"></param>
        /// <returns></returns>
        Task<Business> UpdateOrAddBusiness(Business business, AppUser actor);
        Task<Business> AddBusiness(Business business, AppUser actor);
        Task UpdateBusiness(Business business, AppUser actor);
        Task<Business> GetBusinessById(int id, DateTime? at = null);
        Task<Business> GetBusinessByIdentity(string identity, DateTime? at = null);
        #endregion

        #region Employee
        Task UpdateAccount(Employee employee, AppUser account);
        Task<Employee> GetEmployeeByPersonId(int id);
        Task<Employee> GetEmployeeByUser(AppUser user);
        Task<ICollection<Employee>> ListEmployees(GetListParams<Employee> param);
        Task<Employee> GetEmployeeByCode(string code);
        Task<Dictionary<string, Employee>> BulkFindEmployeeByCode(IEnumerable<string> codes);
        Task<Employee> GetEmployeeById(int id, DateTime? at = null);
        Task<int> GetEmployeeCount(GetListParams<Employee> param);
        Task<Employee> AddEmployee(Employee employee, AppUser appUser);
        Task UpdateEmployee(Employee updated, AppUser appUser);
        Task UpdateOrAddEmployeeByCode(Employee employee, AppUser appUser);
        Task DeleteEmployee(int id, AppUser appUser);
        Task AddEmployeeAccount(int id, string username, AppUser appUser);
        Task RevokeEmployeeAccount(int id, AppUser appUser);
        //End employee interface
        #endregion 

        #region Department
        Task<ICollection<Department>> GetDepartments(GetListParams<Department> p);
        Task<Department> GetDepartmentById(int id, DateTime? at = null);
        Task<int> GetDepartmentCount(GetListParams<Department> p);
        Task AddDepartment(Department department, AppUser appUser);
        Task UpdateDepartment(Department department, AppUser appUser);
        Task UpdateOrAddDepartmentByCode(Department department, AppUser appUser);
        Task DeleteDepartment(int id, AppUser appUser);
        #endregion

        #region ACCOUNTS
        Task<ICollection<AppUser>> GetUserList(GetListParams<AppUser> param);
        Task<int> GetUserCount(GetListParams<AppUser> param);
        Task<ICollection<AppRole>> GetRoleList();
        #endregion

        #region DISTRIBUTOR SERVERS
        Task<DistributedServer> GetDistributedServer(string code);
        Task<List<DistributedServer>> GetDistributedServers();
        Task UpdateDistributedServer(DistributedServer server);
        Task AddDistributedServer(DistributedServer server);
        Task DeleteDistributedServer(DistributedServer server);
        #endregion
        Task<Diary131> GetLastDiary131(string code);
        Task<ICollection<Diary131>> GetDiary131(GetListParams<Diary131> p);
        #region ACCOUNTING PERIOD
        Task<AccountingPeriod> GetOpeningAccountPeriod();
        Task<AccountingPeriod> GetLastAccountingPeriod();
        Task<AccountingPeriod> GetLastClosedAccountingPeriod();
        Task<AccountingPeriod> FindLastClosedAccountingPeriod(DateTime? before);
        Task<AccountingPeriod> GetAccountingPeriodById(int id);
        Task<ICollection<AccountingPeriod>> GetAccountingPeriods();
        Task AddAccountingPeriod(AccountingPeriod entity, AppUser actor);
        Task UpdateAccountingPeriod(AccountingPeriod entity, AppUser actor);
        Task DeleteAccountingPeriod(AccountingPeriod entity, AppUser actor);
        Task CloseAccountingPeriod(AppUser actor, PerformContext context);
        Task OpenAccountingPeriod(AppUser actor);
        Task<AccountingPeriod> GetNextOpeningAccountingPeriod();
        Task RevertAccountingPeriod(AppUser actor);
        #endregion
    }
}
