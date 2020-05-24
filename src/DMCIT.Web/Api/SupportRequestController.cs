using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.SupportRequests;
using DMCIT.Core.Interfaces;
using DMCIT.Web.ApiModels;
using DMCIT.Web.ApiModels.SupportRequests;
using DMCIT.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Web.Api
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    [ValidateModel]
    public class SupportRequestController : ControllerBase
    {
        private readonly ISupportRequestRepository _rep;
        private readonly ICoreRepository _core;
        private readonly UserManager<AppUser> _user;
        public SupportRequestController(ISupportRequestRepository rep, UserManager<AppUser> user, ICoreRepository core)
        {
            _rep = rep;
            _user = user;
            _core = core;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupportRequestDetailModel>> GetSupportRequest(int id)
        {
            var sr = await _rep.GetRequestById(id);
            if (sr == null)
                return NotFound();

            return new SupportRequestDetailModel(sr);
        }

        [HttpPost]
        [Route("unassigned")]
        public async Task<ActionResult<BaseListModel<SupportRequestSummaryModel>>> GetSupportRequests(TableParameter parameter)
        {
            var p = parameter.ToEntityParam<SupportRequest>();
            p.extension = query => query.Where(u => u.RequestStatusNumber == (int)SupportRequest.RequestStatus.ASSIGNING);

            var srs = (await _rep.GetSupportRequests(p)).Select(u => new SupportRequestSummaryModel(u));
            var count = await _rep.GetSupportRequestsCount(p);
            return new BaseListModel<SupportRequestSummaryModel>(srs, null, null, count);
        }

        [HttpPost]
        [Route("all")]
        public async Task<ActionResult<BaseListModel<SupportRequestSummaryModel>>> GetSupportRequests(TableParameter<SupportRequestFilterModel, SupportRequest> parameter)
        {
            var p = parameter.ToEntityParam();
            var srs = (await _rep.GetSupportRequests(p)).Select(u => new SupportRequestSummaryModel(u));
            var count = await _rep.GetSupportRequestsCount(p);
            return new BaseListModel<SupportRequestSummaryModel>(srs, null, null, count);
        }

        [HttpPost]
        [Route("my")]
        public async Task<ActionResult<List<SupportRequestSummaryModel>>> GetMySupportRequests(TableParameter<SupportRequestFilterModel, SupportRequest> parameter)
        {
            var user = await _user.GetUserAsync(User);
            var emp = await _core.GetEmployeeByUser(user);
            if (emp == null)
                throw new Exception("INVALID EMPLOYEE ACCOUNT");
            parameter.filter.requesters = new ListModel<int>(emp.GetId());
            var p = parameter.ToEntityParam();
            var srs = await _rep.GetSupportRequests(p);
            return srs.Select(u => new SupportRequestSummaryModel(u)).ToList();
        }

        [HttpPost]
        [Route("handling")]
        public async Task<ActionResult<BaseListModel<SupportRequestSummaryModel>>> GetMyHandlingSupportRequests(TableParameter parameter)
        {
            var p = parameter.ToFilterTableParameter<SupportRequestFilterModel, SupportRequest>();
            p.filter.statuses = new ListModel<int>((int)SupportRequest.RequestStatus.PENDING, (int)SupportRequest.RequestStatus.HANDLING);
            var pe = p.ToEntityParam();
            var srs = (await _rep.GetSupportRequests(pe)).Select(u => new SupportRequestSummaryModel(u));
            var count = await _rep.GetSupportRequestsCount(pe);
            return new BaseListModel<SupportRequestSummaryModel>(srs, null, null, count);
        }



        [HttpPost]
        [Route("anonymousCreate")]
        public async Task<int> CreateSupportRequestFor(CreateSupportRequestModelFor model)
        {
            var emp = await _core.GetEmployeeById(model.employeeId);
            var sr = model.CreateNewSupportRequest();
            sr.RequesterId = emp.GetId();
            var user = await _user.GetUserAsync(User);
            var newSr = await _rep.CreateRequestFor(sr, emp, user);
            return newSr.GetId();
        }

        [HttpPost]
        [Route("create")]
        public async Task<int> CreateSupportRequest(CreateSupportRequestModel model)
        {
            var user = await _user.GetUserAsync(User);
            var emp = await _core.GetEmployeeById(user.EmployeeId.Value);
            var sr = model.CreateNewSupportRequest();
            sr.RequesterId = emp.GetId();
            var newSr = await _rep.CreateRequest(sr, user);
            return newSr.GetId();
        }

        [HttpPost]
        [Route("{id}/assign")]
        public async Task<ActionResult<bool>> AssignedSupporter(int id, int employeeId)
        {
            var user = await _user.GetUserAsync(User);

            var employee = await _core.GetEmployeeById(employeeId);
            if (employee == null)
                throw new Exception("Invalid employee");

            var request = await _rep.GetRequestById(id);
            await _rep.AssignRequest(request, user, employee);
            return true;
        }

        [HttpGet]
        [Route("{id}/assistants")]
        public async Task<ActionResult<List<int>>> GetAssistants(int id)
        {
            var sr = await _rep.GetRequestById(id);
            var assistants = await _rep.GetAssistants(sr);
            return assistants.Select(u => u.AssistantId).ToList();
        }

        [HttpPost]
        [Route("{id}/assignAssistant")]
        public async Task<ActionResult<bool>> AssignAssistant([FromRoute] SREmployeeActionModel model)
        {
            var user = await _user.GetUserAsync(User);
            await _rep.AssignAssistant(model.id, model.employeeId, user);
            return true;
        }

        [HttpPost]
        [Route("{id}/unassignAssistant")]
        public async Task<ActionResult<bool>> UnassignAssistant([FromRoute] SREmployeeActionModel model)
        {
            var user = await _user.GetUserAsync(User);
            await _rep.UnassignAssistant(model.id, model.employeeId, user);
            return true;
        }

        [HttpPost]
        [Route("{id}/handle")]
        public async Task<ActionResult<bool>> HandlerSupportRequest(int id)
        {
            var user = await _user.GetUserAsync(User);
            var sr = await _rep.GetRequestById(id);
            await _rep.StartHandlingRequest(sr, user);
            return true;
        }

        [HttpPost]
        [Route("{id}/stop")]
        public async Task<ActionResult<bool>> StopHandlingSupportRequest(int id)
        {
            var user = await _user.GetUserAsync(User);
            var sr = await _rep.GetRequestById(id);
            await _rep.StopHandlingRequest(sr, user);
            return true;
        }

        [HttpPost]
        [Route("{id}/cancel")]
        public async Task<ActionResult<bool>> StopHandlingSupportRequest(int id, string reason)
        {
            var user = await _user.GetUserAsync(User);
            var sr = await _rep.GetRequestById(id);
            await _rep.CancelRequest(sr, reason, user);
            return true;
        }

        [HttpPost]
        [Route("{id}/finish")]
        public async Task<ActionResult<bool>> FinishSupportRequest(int id, string solution)
        {
            var user = await _user.GetUserAsync(User);
            var sr = await _rep.GetRequestById(id);
            await _rep.FinishHandlingRequest(sr, solution, user);
            return true;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("confirm/{token}")]
        public async Task<ActionResult<bool>> ConfirmSupportRequest(string token)
        {
            await _rep.ConfirmFinishRequest(token);
            return true;
        }

        [HttpPost]
        [Route("{id}/unassign")]
        public async Task<ActionResult<bool>> UnassignSupportRequest(int id, string reason)
        {
            var user = await _user.GetUserAsync(User);
            var sr = await _rep.GetRequestById(id);
            await _rep.UnassignRequest(sr, reason, user);
            return true;
        }



        [HttpPost]
        [Route("myroles/{id}")]
        public async Task<ActionResult<List<string>>> GetMyRoles(int id)
        {
            var request = await _rep.GetRequestById(id);
            var user = await _user.GetUserAsync(User);
            var roles = await _rep.GetSupportRequestRoles(request, user);
            return roles.Select(u => u.ToString()).ToList();
        }
    }
}
