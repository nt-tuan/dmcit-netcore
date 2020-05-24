using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Sales;
using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _db;
        private readonly IRepository _res;
        private readonly ICoreRepository _core;
        private readonly ISaleService _service;
        public SaleRepository(AppDbContext db, IRepository res, ICoreRepository core, ISaleService service)
        {
            _db = db;
            _res = res;
            _core = core;
            _service = service;
        }

        /*async Task LoadCustomerInfo(Customer item, DateTime? at)
        {
            if (item.BusinessId != null)
            {
                item.Business = await _core.GetBusinessById(item.BusinessId.Value, at);
            }

            if (item.PersonId != null)
            {
                item.Person = await _core.GetPersonById(item.PersonId.Value, at);
            }
        }*/

        public async Task<Customer> AddCustomer(Customer customer, AppUser actor)
        {
            var d = customer.Distributor;
            customer.Distributor = null;
            var entity = await _res.AddDetail(customer, DateTime.Now, actor);
            entity.Distributor = d;
            await _service.OnCustomerAdded(entity);
            return entity;
        }

        public async Task<Distributor> AddDistributor(Distributor entity, AppUser actor)
        {
            return await _res.Add(entity, actor);
        }

        public async Task DeleteCustomer(Customer customer, AppUser actor)
        {
            await _res.Delete(customer, actor);
        }

        public async Task DeleteDistributor(Distributor entity, AppUser actor)
        {
            await _res.Delete(entity, actor);
        }

        public async Task EditCustomer(Customer customer, AppUser actor)
        {
            if (customer.PersonId != null)
                customer.Person = null;
            if (customer.BusinessId != null)
                customer.Business = null;
            var d = customer.Distributor;
            customer.Distributor = null;
            await _res.UpdateDetail(customer, DateTime.Now, actor);
            customer.Distributor = d;
            await _service.OnCustomerUpdated(customer);
        }

        public async Task EditDistributor(Distributor entity, AppUser actor)
        {
            await _res.Update(entity, actor);
        }

        public async Task<Customer> GetCustomerByCode(string code, int distributorId, DateTime? at = null)
        {
            var p = new GetListParams<Customer>();
            p.extension = query => query.Where(u => u.Code == code && u.DistributorId == distributorId);
            p.at = at ?? DateTime.Now;
            var lst = await _res.ListVersionControl(p);
            return lst.Count > 0 ? lst[0] : null;
        }

        public async Task<Customer> GetCustomerById(int id, DateTime? at = null)
        {
            var query = _db.Customers;
            var customer = await _res.GetById(query, id, at);
            return customer;
        }

        public async Task<ICollection<Customer>> GetCustomers(GetListParams<Customer> model)
        {
            var ls = await _res.ListVersionControl(model);
            return ls;
        }

        public async Task<int> GetCustomersCount(GetListParams<Customer> model)
        {
            return await _res.Count(model);
        }

        public async Task<Distributor> GetDistributorByCode(string code, DateTime? at = null)
        {
            var p = new GetListParams<Distributor>();
            p.extension = query => query.Where(u => u.Code == code);
            p.at = at ?? DateTime.Now;
            var lst = await _res.ListVersionControl<Distributor>(p);
            return lst.Count > 0 ? lst[0] : null;
        }

        public async Task<Distributor> GetDistributorById(int id, DateTime? at = null)
        {
            return await _res.GetById<Distributor>(id, at);
        }

        public async Task<ICollection<Distributor>> GetDistributors()
        {
            return await _res.ListVersionControl(new GetListParams<Distributor>());
        }

        public async Task<ICollection<Distributor>> GetDistributors(GetListParams<Distributor> model)
        {
            return await _res.ListVersionControl<Distributor>(model);
        }

        public async Task<Customer> GetSimplyCustomerByCode(string code)
        {
            var p = new GetListParams<Customer>();
            p.extension = query => query.Where(u => u.Code == code);
            p.at = DateTime.Now;
            var lst = await _res.ListVersionControl<Customer>(p);
            return lst.FirstOrDefault();
        }

        public async Task<Dictionary<string, Customer>> BulkFindCustomerByCode(IEnumerable<string> codes, int distributorId)
        {
            var set = codes.ToHashSet();
            var rs = new Dictionary<string, Customer>();
            foreach (var item in set)
            {
                var customer = await GetCustomerByCode(item, distributorId);
                rs.Add(item, customer);
            }
            return rs;
        }

        public async Task AddCustomers(IEnumerable<Customer> customers, AppUser actor)
        {
            var distributors = (await GetDistributors()).ToDictionary(u => u.Code);

            foreach (var item in customers)
            {
                if (item.Distributor != null && distributors.ContainsKey(item.Distributor.Code))
                {
                    item.DistributorId = distributors[item.Distributor.Code].GetId();
                }

                item.Distributor = null;
                await AddCustomer(item, actor);
            }
        }

        async Task<Customer> ReviewCustomer(Customer item)
        {
            if (item?.Distributor?.GetId() == null)
                return item;
            var cusDis = item?.Distributor?.GetId();
            Customer cus = await GetCustomerByCode(item.Code, cusDis.Value);
            if (cus != null)
            {
                cus.Copy(item);
                return cus;
            }

            return item;
        }
        void reviewDistributor(Customer customer, IDictionary<string, Distributor> dict)
        {
            dict.TryGetValue(customer?.Distributor?.Code, out Distributor distributor);
            customer.Distributor = distributor;
            customer.DistributorId = distributor?.GetId();
        }
        async Task reviewBusiness(Customer customer)
        {
            var identity = customer?.Business?.BusinessIdentityNumber;
            if (customer.BusinessId != null)
            {
                var business = await _core.GetBusinessById(customer.BusinessId.Value);
                customer.Business = business;
                customer.BusinessId = business?.GetId();
            }
            else if (!string.IsNullOrEmpty(identity))
            {
                var business = await _core.GetBusinessByIdentity(identity);
                customer.Business = business;
                customer.BusinessId = business?.GetId();
            }
            else
            {
                customer.BusinessId = null;
            }
        }
        async Task reviewPerson(Customer customer)
        {
            var identity = customer?.Person?.IdentityNumber;
            if (customer.PersonId != null)
            {
                var person = await _core.GetPersonById(customer.PersonId.Value);
                customer.Person = person;
                customer.PersonId = person?.GetId();
            }
            else if (!string.IsNullOrEmpty(identity))
            {
                var person = await _core.GetPersonByIdentity(identity);
                customer.Person = person;
                customer.PersonId = person?.GetId();
            }
            else
            {
                customer.PersonId = null;
            }
        }

        public async Task<IEnumerable<Customer>> ReviewImportCustomer(IEnumerable<Customer> customers)
        {
            var distributors = (await GetDistributors()).ToDictionary(u => u.Code);
            var rs = new List<Customer>();
            foreach (var item in customers)
            {
                reviewDistributor(item, distributors);
                var entity = await ReviewCustomer(item);
                await reviewBusiness(entity);
                await reviewPerson(entity);
                rs.Add(entity);
            }
            return rs;
        }
    }
}
