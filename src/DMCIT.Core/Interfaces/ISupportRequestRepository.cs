using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Posts;
using DMCIT.Core.Entities.SupportRequests;
using DMCIT.Core.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DMCIT.Core.Interfaces
{
    public interface ISupportRequestRepository
    {
        Task<SupportRequest> CreateRequest(SupportRequest model, AppUser actor);
        Task<SupportRequest> CreateRequestFor(SupportRequest model, Employee employee, AppUser actor);
        Task<SupportRequest> AssignRequest(SupportRequest request, AppUser assignedBy, Employee assignedTo);

        Task<SupportRequest> UnassignRequest(SupportRequest request, string reason, AppUser actor);
        //Task<SupportRequest> ForceCancelRequest(int employeeid, int supportid, string note);
        Task<SupportRequest> CancelRequest(SupportRequest request, string reason, AppUser actor);
        Task<SupportRequest> StartHandlingRequest(SupportRequest request, AppUser actor);
        Task<SupportRequest> StopHandlingRequest(SupportRequest request, AppUser actor);
        Task<SupportRequest> FinishHandlingRequest(SupportRequest request, string solution, AppUser actor);
        Task<SupportRequest> ConfirmFinishRequest(string token);
        Task<List<SupportRequest>> GetSupportRequests(GetListParams<SupportRequest> p);

        Task<int> GetSupportRequestsCount(GetListParams<SupportRequest> p);
        Task<SupportRequest> GetRequestById(int id);
        Task UpdateCategory(SupportRequest request, PostCategory cate, AppUser actor);
        Task UpdateTags(SupportRequest request, List<PostTag> tags, AppUser actor);

        Task<HashSet<SupportRequest.SupportRequestRoles>> GetSupportRequestRoles(SupportRequest request, AppUser actor);
        Task<List<SupportAssistant>> GetAssistants(SupportRequest sr);
        Task AssignAssistant(int srId, int employeeId, AppUser actor);
        Task UnassignAssistant(int srId, int employeeId, AppUser actor);
    }
}
