using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Posts;
using DMCIT.Core.Entities.SupportRequests;
using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DMCIT.Core.Entities.SupportRequests.SupportRequest;

namespace DMCIT.Infrastructure.Data
{
    public class RequestRepository : ISupportRequestRepository
    {
        private readonly AppDbContext _context;
        private readonly IRepository _rep;
        private readonly ICoreRepository _core;
        private readonly IPostRepository _post;
        private readonly ISupportRequestService _service;
        private readonly RoleManager<AppRole> _rolesManager;
        private readonly UserManager<AppUser> _usersManager;
        public RequestRepository(AppDbContext context, IRepository rep, IPostRepository post, ISupportRequestService service, ICoreRepository core, RoleManager<AppRole> rolesManager, UserManager<AppUser> usersManager)
        {
            _rep = rep;
            _context = context;
            _core = core;
            _rolesManager = rolesManager;
            _usersManager = usersManager;
            _service = service;
            _post = post;
        }


        //Create a support
        public async Task<SupportRequest> CreateRequest(SupportRequest sp, AppUser actor)
        {
            //TODO: Get employee
            var emp = await _core.GetEmployeeById(actor.EmployeeId.Value);
            sp.ToNewSupportRequest(emp);
            var rs = await _rep.AddDetail(sp, DateTime.Now, actor);
            return rs;
        }

        //Create a request support, then assign it to a supporter
        public async Task<SupportRequest> CreateRequestFor(SupportRequest sp, Employee requester, AppUser actor)
        {
            sp.ToNewSupportRequest(requester);
            var rs = await _rep.AddDetail(sp, DateTime.Now, actor);
            return rs;
        }

        public async Task<SupportRequest> AssignRequest(SupportRequest sp, AppUser assignBy, Employee assignTo)
        {
            if (sp.Status == RequestStatus.DONE || sp.Status == RequestStatus.CLOSE)
                //Create this type of exception
                throw new Exception();
            var assignByEmp = await _core.GetEmployeeByUser(assignBy);
            if (assignByEmp == null)
                throw new Exception($"User {assignBy.UserName} chưa được gán với nhân viên.");
            var oldStatus = sp.Status;
            sp.Status = RequestStatus.PENDING;
            sp.AssignedBy = null;
            sp.AssignedTo = null;
            sp.Post = null;
            sp.Requester = null;
            sp.AssignedById = assignByEmp.GetId();
            sp.AssignedToId = assignTo.GetId();
            await _rep.Update(sp, assignBy);
            await _service.OnStatusChange(sp, oldStatus, assignBy);
            return sp;
        }

        //Decline a request that has been received and has not been done
        public async Task<SupportRequest> UnassignRequest(SupportRequest sr, string reason, AppUser actor)
        {
            if (sr.RequestStatusNumber != (int)SupportRequest.RequestStatus.PENDING || sr.RequestStatusNumber != (int)SupportRequest.RequestStatus.HANDLING)
                //TODO: create this type if exception
                throw new Exception();

            sr.AssignedById = null;
            sr.AssignedToId = null;
            var oldStatus = sr.Status;
            sr.Status = SupportRequest.RequestStatus.ASSIGNING;
            sr.ConfirmFinishCode = null;

            await _rep.Update(sr, actor);
            await _service.OnStatusChange(sr, oldStatus, actor);
            return sr;
        }

        //Cancel a support request with a specific reason
        public async Task<SupportRequest> CancelRequest(SupportRequest sp, string reason, AppUser actor)
        {
            if (sp.RequestStatusNumber == (int)SupportRequest.RequestStatus.DONE)
            {
                //TODO: create this type of exception
                throw new Exception("CAN NOT CANCEL A SUPPORT REQUEST HAS BEEN DONE");
            }
            sp.Conlusion = reason;
            var oldStatus = sp.Status;
            sp.Status = SupportRequest.RequestStatus.CLOSE;
            await _rep.Update(sp, actor);
            await _service.OnStatusChange(sp, oldStatus, actor);
            return sp;
        }

        //Begin process a request
        //If an employee is processing a request, he has to stop process that request, then he starts processsing a new request
        public async Task<SupportRequest> StartHandlingRequest(SupportRequest sr, AppUser actor)
        {
            if (sr.RequestStatusNumber != (int)SupportRequest.RequestStatus.PENDING)
                //TODO: create this type of exception
                throw new Exception();
            var oldStatus = sr.Status;
            sr.Status = SupportRequest.RequestStatus.HANDLING;
            await _rep.Update(sr, actor);
            await _service.OnStatusChange(sr, oldStatus, actor);
            return sr;
        }

        public async Task<SupportRequest> StopHandlingRequest(SupportRequest sr, AppUser actor)
        {
            if (sr.Status != SupportRequest.RequestStatus.HANDLING)
                //TODO: create this type of exception
                throw new Exception();
            var oldStatus = sr.Status;
            sr.Status = SupportRequest.RequestStatus.PENDING;
            await _rep.Update(sr, actor);
            await _service.OnStatusChange(sr, oldStatus, actor);
            return sr;
        }

        public async Task<SupportRequest> FinishHandlingRequest(SupportRequest sr, string solution, AppUser actor)
        {
            if (sr.Status != SupportRequest.RequestStatus.HANDLING)
                //TODO: add this type of exception
                throw new Exception();

            //generate code
            bool exist = false;
            do
            {
                var str = Guid.NewGuid().ToString();
                exist = await _context.Set<SupportRequest>().Where(u => u.ConfirmFinishCode == str).AnyAsync();
                sr.ConfirmFinishCode = str;
            } while (exist);

            sr.Conlusion = solution;
            sr.Status = SupportRequest.RequestStatus.CONFIRMING;
            await _rep.Update(sr, actor);
            await _service.OnStatusChange(sr, SupportRequest.RequestStatus.HANDLING, actor);
            return sr;
        }

        public async Task<SupportRequest> ConfirmFinishRequest(string code)
        {
            var sr = await _context.Set<SupportRequest>().Where(u => u.ConfirmFinishCode == code).SingleAsync();

            if (sr.Status != SupportRequest.RequestStatus.CONFIRMING)
                //TODO: create this type of exception
                throw new Exception("");

            sr.Status = SupportRequest.RequestStatus.DONE;
            await _rep.Update(sr, null);
            await _service.OnStatusChange(sr, SupportRequest.RequestStatus.CONFIRMING, null);

            return sr;
        }

        public async Task<List<SupportRequest>> GetSupportRequests(GetListParams<SupportRequest> p)
        {
            p.extension = getSupportRequestHeader(p.extension);
            return await _rep.ListVersionControl(p);
        }

        public async Task<int> GetSupportRequestsCount(GetListParams<SupportRequest> p)
        {
            return await _rep.CountDetail(p);
        }

        public Func<IQueryable<SupportRequest>, IQueryable<SupportRequest>> getSupportRequestHeader(Func<IQueryable<SupportRequest>, IQueryable<SupportRequest>> root)
        {
            Func<IQueryable<SupportRequest>, IQueryable<SupportRequest>> include = query => query
            .Include(u => u.CreatedBy)
            .Include(u => u.AssignedBy)
            .Include(u => u.AssignedTo)
            .Include(u => u.Post).AsNoTracking();
            if (root != null)
                return query => include(root(query));
            return include;
        }

        public async Task<SupportRequest> GetRequestById(int id)
        {
            var getIncludeFunc = getSupportRequestHeader(null);
            var query = getIncludeFunc(_context.Set<SupportRequest>());
            var sr = await _rep.GetById(query, id, DateTime.Now);
            return sr;
        }

        public async Task UpdateCategory(SupportRequest sr, PostCategory cate, AppUser actor)
        {
            var post = await _post.GetPostById(sr.PostId);
            post.CategoryId = cate.Id;
            await _post.UpdatePost(post, DateTime.Now, actor);
        }

        public async Task UpdateTags(SupportRequest request, List<PostTag> tags, AppUser actor)
        {
            await _context.Entry(request).Reference(u => u.Post).LoadAsync();
            await _post.UpdatePostTags(request.Post, tags, actor);
        }

        public async Task<List<SupportAssistant>> GetAssistants(SupportRequest sr)
        {
            var p = new GetListParams<SupportAssistant>(null, null);
            p.extension = query => query.Where(u => u.SupportRequestId == sr.GetId());

            return await _rep.List(p);
        }

        public async Task<HashSet<SupportRequestRoles>> GetSupportRequestRoles(SupportRequest request, AppUser actor)
        {
            var rs = new HashSet<SupportRequestRoles>();
            if (actor == null)
                return rs;
            Employee employee = await _core.GetEmployeeByUser(actor);
            if (employee != null)
            {
                var employeeId = employee.GetId();
                if (request.AssignedById == employeeId)
                    rs.Add(SupportRequestRoles.ASSIGNER);
                if (request.CreatedById == actor.Id)
                    rs.Add(SupportRequestRoles.CREATOR);
                if (request.AssignedToId == employeeId)
                    rs.Add(SupportRequestRoles.PIC);
            }

            var assistants = await GetAssistants(request);
            if (assistants.Select(u => u.AssistantId).Contains(employee.GetId()))
            {
                rs.Add(SupportRequestRoles.SPECIALIST);
            }

            if (await _usersManager.IsInRoleAsync(actor, MANAGER_ROLE))
            {
                rs.Add(SupportRequestRoles.MANAGER);
            }

            return rs;
        }

        public async Task<List<SupportAssistant>> GetSupportAssistants(int srId, int employeeId)
        {
            var p = new GetListParams<SupportAssistant>(null, null);
            p.extension = query => query.Where(u => u.SupportRequestId == srId && u.AssistantId == employeeId).Take(1);
            return await _rep.ListVersionControl(p);
        }

        public async Task AssignAssistant(int sr, int employee, AppUser actor)
        {
            var srE = await GetRequestById(sr);
            var employeeE = await _core.GetEmployeeById(employee);
            if (srE == null)
                //TODO: add this kind of exception
                throw new Exception("Invalid support request");
            if (employeeE == null)
                //TODO: add this kind of employee
                throw new Exception("Invalid employee");
            if (string.IsNullOrEmpty(employeeE.AppUserId))
                throw new Exception("This Employee requires an account");

            await UnassignAssistant(sr, employee, actor);
            var first = new SupportAssistant(sr, employee);
            await _rep.AddDetail(first, null, actor);
            await _post.AddAccessedUser(srE.PostId, employeeE.AppUserId, actor);
        }

        public async Task UnassignAssistant(int srId, int employeeId, AppUser actor)
        {
            var srE = await GetRequestById(srId);
            var employeeE = await _core.GetEmployeeById(employeeId);
            var srA = await GetSupportAssistants(srId, employeeId);
            foreach (var item in srA)
            {
                await _rep.DeleteDetail(item, null, actor);
                var employee = await _core.GetEmployeeById(item.AssistantId);
            }
            await _post.RemoveAccessedUser(srE.PostId, employeeE.AppUserId, actor);
        }
    }
}
