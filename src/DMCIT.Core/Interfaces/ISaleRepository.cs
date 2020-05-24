using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Sales;
using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Core.Interfaces
{
    public interface ISaleRepository
    {
        #region CUSTOMER
        Task<Customer> GetCustomerById(int id, DateTime? at = null);
        Task<Customer> GetCustomerByCode(string customerCode, int distributorId, DateTime? at = null);
        Task<Customer> GetSimplyCustomerByCode(string code);
        Task<ICollection<Customer>> GetCustomers(GetListParams<Customer> model);
        Task<int> GetCustomersCount(GetListParams<Customer> model);
        Task<Customer> AddCustomer(Customer customer, AppUser actor);
        Task AddCustomers(IEnumerable<Customer> customer, AppUser actor);
        Task EditCustomer(Customer customer, AppUser actor);
        Task DeleteCustomer(Customer customer, AppUser actor);
        #endregion
        Task<IEnumerable<Customer>> ReviewImportCustomer(IEnumerable<Customer> customers);
        #region DISTRIBUTOR
        Task<ICollection<Distributor>> GetDistributors();
        Task<ICollection<Distributor>> GetDistributors(GetListParams<Distributor> p);
        Task<Distributor> GetDistributorById(int id, DateTime? at = null);
        Task<Distributor> GetDistributorByCode(string code, DateTime? at = null);
        Task<Distributor> AddDistributor(Distributor entity, AppUser actor);
        Task EditDistributor(Distributor entity, AppUser actor);
        Task DeleteDistributor(Distributor entity, AppUser actor);
        #endregion

        //interface other database server
    }
}
