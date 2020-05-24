using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.Entities.Sales;
using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data
{
    public class MessageReceiverRepository : IMessageReceiverRepository, IEqualityComparer<MessageReceiverGroupMessageReceiver>
    {
        readonly AppDbContext _context;
        readonly ICoreRepository _core;
        readonly IRepository _res;
        readonly ISaleRepository _sale;
        readonly ISettingRepository _setting;
        public MessageReceiverRepository(AppDbContext context, ICoreRepository icore, IRepository res, ISaleRepository sale, ISettingRepository setting)
        {
            _context = context;
            _core = icore;
            _res = res;
            _sale = sale;
            _setting = setting;
        }

        public async Task<ReceiverCategory> AddCategory(ReceiverCategory cate, AppUser appUser)
        {
            var entity = await _res.AddDetail(cate, DateTime.Now, appUser);
            return entity;
        }

        async Task<bool> checkCustomerReceiverExist(int customerId)
        {
            var p = new GetListParams<MessageReceiver>();
            p.extension = q => q.Where(u => u.CustomerId == customerId);
            var cusReceiver = await _res.CountDetail(p);
            return cusReceiver > 0;
        }

        public async Task<MessageReceiver> AddCustomerReceiver(Customer customer, AppUser actor, DateTime? at)
        {
            //Get customer
            if (customer == null)
            {
                throw new EntityNotFound(typeof(Customer), customer.Id);
            }
            using (var trans = await _context.Database.BeginTransactionAsync())
            {
                if (await checkCustomerReceiverExist(customer.GetId()))
                {
                    //TODO: add customer receiver existed
                    throw new Exception($"Customer {customer.GetFullName()} #{customer.Code} has already been declared as a recipient");
                }

                var receiver = new MessageReceiver();
                receiver.FullName = customer.GetFullName();
                receiver.ShortName = customer.GetDisplayName();
                receiver.CustomerId = customer.GetId();

                var entity = await _res.AddDetail(receiver, DateTime.Now, actor);
                trans.Commit();
                return entity;
            }
        }

        public async Task<MessageReceiver> AddEmployeeReceiver(Employee employee, AppUser actor, DateTime? at)
        {
            var emp = await _core.GetEmployeeById(employee.Id);
            if (emp == null)
            {
                throw new EntityNotFound(typeof(Employee), employee.Id);
            }
            var receiver = new MessageReceiver();
            receiver.FullName = emp.Person.FullName;
            receiver.ShortName = emp.Person.DisplayName;
            receiver.EmployeeId = emp.Id;
            var entity = await _res.AddDetail(receiver, DateTime.Now, actor);
            return entity;
        }

        public async Task<MessageReceiverGroup> AddGroup(MessageReceiverGroup group, AppUser actor, DateTime? at)
        {
            var members = group.MessageReceiverGroupMessageReceivers;
            group.MessageReceiverGroupMessageReceivers = null;
            var entity = await _res.AddDetail(group, DateTime.Now, actor);
            if (members != null)
            {
                var nMembers = new List<MessageReceiverGroupMessageReceiver>();
                foreach (var item in members)
                {
                    item.MessageReceiverGroupId = entity.Id;
                    var nItem = await _res.AddDetail(item);
                    nMembers.Add(nItem);
                }
                entity.MessageReceiverGroupMessageReceivers = nMembers;
            }
            return entity;
        }

        public async Task<MessageReceiver> AddReceiver(MessageReceiver receiver, AppUser actor, DateTime? at)
        {
            var entity = await _res.AddDetail(receiver, at, actor);
            return entity;
        }

        public async Task<ReceiverProvider> AddReceiverProvider(ReceiverProvider provider, AppUser actor, DateTime? at)
        {
            return await _res.AddDetail(provider, at, actor);
        }

        public async Task DeleteCategory(ReceiverCategory cate, AppUser appUser)
        {
            //throw new NotImplementedException();
            await _res.DeleteDetail(cate, DateTime.Now, appUser);
        }

        public async Task DeleteGroup(int id, AppUser actor, DateTime? at)
        {
            var group = await _res.GetById<MessageReceiverGroup>(id, DateTime.Now);
            await _res.DeleteDetail(group, at, actor);
        }

        public async Task DeleteReceiver(int id, AppUser user, DateTime? at)
        {
            var receiver = await _res.GetById<MessageReceiver>(id, at);
            await _res.DeleteDetail(receiver);
        }

        public async Task DeleteReceiverProvider(int id, AppUser actor, DateTime? at)
        {
            var entity = await _res.GetById<ReceiverProvider>(id, DateTime.Now);
            await _res.DeleteDetail(entity, DateTime.Now, actor);
        }

        public async Task<ICollection<ReceiverCategory>> GetCategories(DateTime? at)
        {
            var p = new GetListParams<ReceiverCategory>();
            p.at = at ?? DateTime.Now;
            var list = await _res.ListVersionControl<ReceiverCategory>(p);
            return list;
        }

        public async Task<MessageReceiverGroup> GetGroupById(int id, DateTime? at)
        {
            var group = await _res.GetById<MessageReceiverGroup>(id, at);
            return group;
        }

        public async Task<int> GetGroupMemberCount(int id, DateTime? at)
        {
            var count = await _res.Count(query: _context.MessageReceiverGroupMessageReceivers.Where(u => u.MessageReceiverGroupId == id), null, time: DateTime.Now);
            return count;
        }

        public async Task<ICollection<MessageReceiverGroupMessageReceiver>> GetGroupMembers(int id, DateTime? at)
        {
            var origin = await _res.GetOrigin<MessageReceiverGroup>(id, at);

            var p = new GetListParams<MessageReceiverGroupMessageReceiver>();
            p.extension = query => query.Where(u => u.MessageReceiverGroupId == origin.Id);

            var r = await _res.ListVersionControl(p);
            foreach (var item in r)
            {
                Func<IQueryable<MessageReceiver>, IQueryable<MessageReceiver>> func = query => query.Include(u => u.ReceiverProviders).ThenInclude(u => u.MessageServiceProvider);

                item.MessageReceiver = await _res.GetById<MessageReceiver>(item.MessageReceiverId, func);

                item.MessageReceiverGroup = await GetGroupById(item.MessageReceiverGroupId, at);
            }

            return r;
        }

        public async Task<ICollection<MessageReceiverGroup>> GetGroups(GetListParams<MessageReceiverGroup> param)
        {
            var groups = await _res.ListVersionControl<MessageReceiverGroup>(param);
            return groups;
        }

        public async Task<MessageServiceProvider> GetProviderById(int id, bool throwException)
        {
            return await _res.GetById<MessageServiceProvider>(id, DateTime.Now);
        }

        public async Task<List<MessageServiceProvider>> GetProviders(DateTime? at)
        {
            var p = new GetListParams<MessageServiceProvider>();
            p.at = at ?? DateTime.Now;
            return await _res.ListVersionControl<MessageServiceProvider>(p);
        }

        public async Task<MessageReceiver> GetReceiverById(int id, DateTime? at = null)
        {
            return await _res.GetById<MessageReceiver>(id, at);
        }

        public async Task<MessageReceiver> GetReceiverById(IQueryable<MessageReceiver> query, int id, DateTime? at = null)
        {
            return await _res.GetById<MessageReceiver>(query, id, at);
        }

        public async Task<ICollection<ReceiverProvider>> GetReceiverProvider(int receiverId, DateTime? at = null)
        {
            var p = new GetListParams<ReceiverProvider>();
            p.extension = query => query.Where(u => u.MessageReceiverId == receiverId);

            var receiverproviders = await _res.ListVersionControl(p);

            foreach (var item in receiverproviders)
            {
                item.MessageServiceProvider = await _res.GetById<MessageServiceProvider>(item.MessageServiceProviderId);
            }
            return receiverproviders;
        }

        public async Task<ICollection<MessageReceiver>> GetReceivers(GetListParams<MessageReceiver> param)
        {
            if (param.extension == null)
                param.extension = u => u;

            var search = param.search;

            var r = await _res.ListVersionControl<MessageReceiver>(param);
            foreach (var item in r)
            {
                //Load customer
                if (item.CustomerId != null)
                {
                    item.Customer = await _sale.GetCustomerById(item.CustomerId.Value);
                }

                //Load Employee
                if (item.EmployeeId != null)
                {
                    item.Employee = await _core.GetEmployeeById(item.EmployeeId.Value);
                }

                //Load provider
                var receiverproviders = await GetReceiverProvider(item.GetId());
                item.ReceiverProviders = receiverproviders;
            }
            return r;
        }

        public async Task<ICollection<MessageReceiver>> GetReceivers(GetListParams<MessageReceiver> param, bool include)
        {
            if (param.extension == null)
                param.extension = u => u;

            var search = param.search;

            var r = await _res.ListVersionControl<MessageReceiver>(param);

            if (!include)
            {
                return r;
            }

            foreach (var item in r)
            {
                //Load customer
                if (item.CustomerId != null)
                {
                    item.Customer = await _sale.GetCustomerById(item.CustomerId.Value);
                }

                //Load Employee
                if (item.EmployeeId != null)
                {
                    item.Employee = await _core.GetEmployeeById(item.EmployeeId.Value);
                }

                //Load provider
                var receiverproviders = await GetReceiverProvider(item.GetId());
                item.ReceiverProviders = receiverproviders;
            }
            return r;
        }

        public async Task<int> GetReceiversCount(GetListParams<MessageReceiver> param)
        {
            return await _res.Count<MessageReceiver>(param);
        }

        public async Task<int> GetGroupsCount(GetListParams<MessageReceiverGroup> p)
        {
            return await _res.Count<MessageReceiverGroup>(p.filter);
        }

        public async Task UpdateCategory(ReceiverCategory cate, AppUser appUser)
        {
            await _res.UpdateDetail<ReceiverCategory>(cate, DateTime.Now, appUser);
        }

        public async Task UpdateGroup(MessageReceiverGroup group, AppUser actor, DateTime? at)
        {
            var eGroup = await GetGroupById(group.Id, at);
            eGroup.Name = group.Name;
            var eMembers = await GetGroupMembers(eGroup.OriginId ?? eGroup.Id, at);

            //Update group name
            eGroup.Name = group.Name;
            await _res.UpdateDetail(eGroup, at, actor);

            //Update group members
            var removeItems = eMembers.Except(group.MessageReceiverGroupMessageReceivers, this);

            var addItems = group.MessageReceiverGroupMessageReceivers.Except(eMembers, this);

            //remove members
            foreach (var item in removeItems)
            {
                await _res.DeleteDetail(item, at, actor);
            }

            //add new members
            foreach (var item in addItems)
            {
                await _res.AddDetail(item);
            }
        }

        public async Task UpdateReceiver(MessageReceiver receiver, AppUser actor, DateTime? at)
        {
            await _res.UpdateDetail(receiver, at, actor);
        }

        public bool Equals(MessageReceiverGroupMessageReceiver mx, MessageReceiverGroupMessageReceiver my)
        {
            return mx.MessageReceiverId == my.MessageReceiverId && mx.MessageReceiverGroupId == my.MessageReceiverGroupId;
        }

        public int GetHashCode(MessageReceiverGroupMessageReceiver obj)
        {
            return obj.MessageReceiverId ^ obj.MessageReceiverGroupId;
        }

        public async Task<ICollection<ReceiverProvider>> GetReceiverProviders(int receiverId, IEnumerable<int> providerIds)
        {
            var p = new GetListParams<ReceiverProvider>();
            p.extension = query =>
            query
                .Where(u => u.MessageReceiverId == receiverId && providerIds.ToList().Contains(u.MessageServiceProviderId));

            var rs = await _res.ListVersionControl(p);
            foreach (var item in rs)
            {
                item.MessageReceiver = await GetReceiverById(item.MessageReceiverId);
                item.MessageServiceProvider = await _res.GetById<MessageServiceProvider>(item.MessageServiceProviderId);

            }
            return rs;
        }



        public async Task<ICollection<ReceiverProvider>> GetReceiverProviders(IEnumerable<int> receivers, IEnumerable<int> groups, IEnumerable<int> providers)
        {
            var ids = new List<int>();
            if (receivers != null)
            {
                ids.AddRange(receivers);
            }
            if (groups != null)
            {
                foreach (var item in groups)
                {
                    var members = await GetGroupMembers(item, DateTime.Now);
                    if (members != null)
                    {
                        ids.AddRange(members.Select(u => u.MessageReceiverId));
                    }
                }
            }
            var rp = new List<ReceiverProvider>();
            foreach (var item in ids)
            {
                var temp = await GetReceiverProviders(item, providers);
                rp.AddRange(temp);
            }
            return rp;
        }


        public async Task<ReceiverProvider> GetReceiverProvider(int receiverId, int providerId)
        {
            var p = new GetListParams<ReceiverProvider>();
            p.extension = query => query.Where(u => u.MessageReceiverId == receiverId && u.MessageServiceProviderId == providerId);

            var ls = await _res.ListVersionControl(p);
            return ls.FirstOrDefault();
        }

        public async Task UpdateOrAddReceiverProvider(ReceiverProvider item)
        {
            var rpe = await GetReceiverProvider(item.MessageReceiverId, item.MessageServiceProviderId);
            if (rpe != null)
            {
                var temp = item.MessageServiceProvider;
                rpe.ReceiverAddress = item.ReceiverAddress;
                await _res.UpdateDetail(rpe);
                item.MessageServiceProvider = temp;
            }
            else
            {
                var temp = item.MessageServiceProvider;
                item.MessageServiceProvider = null;
                await _res.AddDetail(item);
                item.MessageServiceProvider = temp;
            }
        }

        public async Task<MessageReceiver> UpdateOrAddReceiver(MessageReceiver entity, AppUser actor)
        {
            if (entity.EmployeeId == null && entity.CustomerId == null)
            {
                throw new Exception("This receiver is not neither a customer or employee");
            }
            var rp = entity.ReceiverProviders;
            var employee = entity.Employee;
            var customer = entity.Customer;
            entity.ReceiverProviders = null;
            entity.Employee = null;
            entity.Customer = null;

            if (entity.Id != default)
            {
                //TODO: update receiver
                await _res.UpdateDetail(entity, DateTime.Now, actor);
            }
            else
            {
                //TODO: add receiver
                entity = await _res.AddDetail(entity, DateTime.Now, actor);
            }

            if (rp != null)
            {
                foreach (var item in rp)
                {
                    item.MessageReceiverId = entity.GetId();
                    await UpdateOrAddReceiverProvider(item);
                }
            }

            entity.ReceiverProviders = rp;
            entity.Customer = customer;
            entity.Employee = employee;
            return entity;
        }

        public async Task<MessageReceiver> GetCustomerReceiver(int customerId)
        {
            var query = _context.MessageReceivers.AsNoTracking().Where(u => u.CustomerId == customerId);
            query = _res.ApplyDefaultWhere(query, DateTime.Now);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<MessageReceiver> GetEmployeeReceiver(int employeeId)
        {
            var query = _context.MessageReceivers.AsNoTracking().Where(u => u.EmployeeId == employeeId);
            query = _res.ApplyDefaultWhere(query, DateTime.Now);
            return await query.FirstOrDefaultAsync();
        }

        void reviewProvider(MessageReceiver receiver, IDictionary<string, MessageServiceProvider> dict)
        {
            foreach (var item in receiver.ReceiverProviders)
            {
                dict.TryGetValue(item.MessageServiceProvider?.Code, out MessageServiceProvider provider);
                item.MessageServiceProvider = provider;
                item.MessageServiceProviderId = provider.GetId();
            }
        }

        async Task reviewCustomer(MessageReceiver receiver, IDictionary<string, Distributor> dict)
        {
            dict.TryGetValue(receiver.Customer?.Distributor?.Code, out Distributor distributor);
            if (distributor != null)
            {
                var customer = await _sale.GetCustomerByCode(receiver?.Customer?.Code, distributor.GetId());
                receiver.Customer = customer;
                receiver.CustomerId = customer?.GetId();
                if (customer != null)
                {
                    receiver.Customer.Distributor = distributor;
                    receiver.Customer.DistributorId = distributor?.GetId();
                }
            }
            else
            {
                receiver.Customer = null;
                receiver.CustomerId = null;
            }

        }

        async Task reviewEmployee(MessageReceiver receiver)
        {
            var employeeCode = receiver?.Employee?.Code;
            if (!string.IsNullOrEmpty(employeeCode))
            {
                var emp = await _core.GetEmployeeByCode(employeeCode);
                receiver.Employee = emp;
                receiver.EmployeeId = emp?.GetId();
            }
            else
            {
                receiver.Employee = null;
                receiver.EmployeeId = null;
            }
        }

        public async Task<IEnumerable<EntityReviewResult<MessageReceiver>>> ReviewReceiver(IEnumerable<MessageReceiver> data)
        {
            var proDict = (await GetProviders(DateTime.Now)).ToDictionary(u => u.Code);
            var distributors = (await _sale.GetDistributors()).ToDictionary(u => u.Code);
            var returnItems = new List<EntityReviewResult<MessageReceiver>>();
            foreach (var rec in data)
            {
                MessageReceiver receiver = rec;
                var message = new EntityReviewResult();
                await reviewCustomer(rec, distributors);
                if (rec.Customer != null)
                {
                    message.AddInfo("", "This recipient is a customer");
                    receiver = await GetCustomerReceiver(rec.Customer.GetId());
                    if (receiver != null)
                    {
                        message.AddWarning("", "This recipent has existed");
                    }
                    else
                    {
                        receiver = rec;
                    }
                }
                else
                {
                    await reviewEmployee(rec);
                    if (rec.Employee != null)
                    {
                        message.AddInfo("", "This recipient is an employee");
                        receiver = await GetEmployeeReceiver(rec.Employee.GetId());
                        if (receiver != null)
                        {
                            message.AddWarning("", "This recipent has existed");
                        }
                        else
                        {
                            receiver = rec;
                        }
                    }
                }

                if (receiver.Employee == null && receiver.Customer == null)
                {
                    message.AddInfo("", "This recipient is neither a customer nor a employee");
                }

                reviewProvider(rec, proDict);

                receiver.Copy(rec);

                returnItems.Add(new EntityReviewResult<MessageReceiver>(receiver, message));
            }

            return returnItems;
        }
    }
}
