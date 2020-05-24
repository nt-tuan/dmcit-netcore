using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.Entities.Sales;
using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Core.Interfaces
{
    public interface IMessageReceiverRepository
    {
        //Usecase 1.1
        Task<ICollection<ReceiverCategory>> GetCategories(DateTime? at);
        //Usecase 1.2
        Task<ReceiverCategory> AddCategory(ReceiverCategory cate, AppUser appUser);
        //Usecase 1.3
        Task UpdateCategory(ReceiverCategory cate, AppUser appUser);
        //Usecase 1.4
        Task DeleteCategory(ReceiverCategory cate, AppUser appUser);

        //Usecase 2.1
        Task<ICollection<MessageReceiverGroup>> GetGroups(GetListParams<MessageReceiverGroup> param);

        Task<int> GetGroupMemberCount(int id, DateTime? at);
        //Usecase 2.2
        Task<MessageReceiverGroup> GetGroupById(int id, DateTime? at);
        Task<ICollection<MessageReceiverGroupMessageReceiver>> GetGroupMembers(int id, DateTime? at);
        Task<int> GetGroupsCount(GetListParams<MessageReceiverGroup> p);
        //Usecase 2.3
        Task<MessageReceiverGroup> AddGroup(MessageReceiverGroup group, AppUser actor, DateTime? at);
        //Usecase 2.4
        Task UpdateGroup(MessageReceiverGroup group, AppUser actor, DateTime? at);
        //Usecase 2.5
        Task DeleteGroup(int id, AppUser actor, DateTime? at);

        //Usecase  3.1
        Task<ICollection<MessageReceiver>> GetReceivers(GetListParams<MessageReceiver> p);
        Task<MessageReceiver> GetCustomerReceiver(int customerId);
        Task<MessageReceiver> GetEmployeeReceiver(int employeeId);
        Task<ICollection<ReceiverProvider>> GetReceiverProviders(int receiverId, IEnumerable<int> providerIds);

        Task<int> GetReceiversCount(GetListParams<MessageReceiver> param);

        //Usecase 3.2
        Task<MessageReceiver> GetReceiverById(int id, DateTime? at);
        //Usecase 3.3.1
        Task<MessageReceiver> AddCustomerReceiver(Customer customer, AppUser actor, DateTime? at);
        //Usecase 3.3.2
        Task<MessageReceiver> AddEmployeeReceiver(Employee employee, AppUser actor, DateTime? at);
        //Usecase 3.3.3
        Task<MessageReceiver> AddReceiver(MessageReceiver receiver, AppUser actor, DateTime? at);
        //Usecase 3.4
        Task UpdateReceiver(MessageReceiver receiver, AppUser actor, DateTime? at);
        //Usecase 3.5
        Task DeleteReceiver(int id, AppUser actor, DateTime? at);
        //Usecase 3.4.1
        Task<ReceiverProvider> AddReceiverProvider(ReceiverProvider provider, AppUser actor, DateTime? at);
        Task DeleteReceiverProvider(int id, AppUser actor, DateTime? at);
        //Usecase 3.6
        Task<List<MessageServiceProvider>> GetProviders(DateTime? at = null);
        //Usecase 3.7
        Task<MessageServiceProvider> GetProviderById(int id, bool throwException);
        Task<ICollection<ReceiverProvider>> GetReceiverProvider(int receiverId, DateTime? at = null);

        //Quality of live
        Task<ICollection<ReceiverProvider>> GetReceiverProviders(IEnumerable<int> receivers, IEnumerable<int> groups, IEnumerable<int> providers);

        //Extense module
        Task<MessageReceiver> UpdateOrAddReceiver(MessageReceiver entity, AppUser actor);

        Task<IEnumerable<EntityReviewResult<MessageReceiver>>> ReviewReceiver(IEnumerable<MessageReceiver> data);
    }
}
