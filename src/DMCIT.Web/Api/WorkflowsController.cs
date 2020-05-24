using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Workflow;
using DMCIT.Core.Interfaces;
using DMCIT.Infrastructure.Data;
using DMCIT.Infrastructure.Data.Workflow;
using DMCIT.Infrastructure.Data.Workflow.ExecutionGraph.Flowchart;
using DMCIT.Infrastructure.Services;
using DMCIT.Web.ApiModels;
using DMCIT.Web.ApiModels.Accounts;
using DMCIT.Web.ApiModels.Workflows;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DMCIT.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WorkflowsController : ControllerBase
    {
        private readonly WorkflowStorage _w;
        private readonly IWorkflowRepository _rep;
        private readonly UserManager<AppUser> _userManager;
        private readonly WorkflowSetting _setting;
        public WorkflowsController(WorkflowStorage wexflowEngine, UserManager<AppUser> userManager, IWorkflowRepository rep,  ISettingRepository settingRep)
        {
            _w = wexflowEngine;
            _userManager = userManager;
            _rep = rep;
            _setting = settingRep.GetSettingStore().GetSetting<WorkflowSetting>();
        }

        //Get workflow has been defined
        // GET: api/<controller>
        [HttpGet]
        public async Task<List<WorkflowItemModel>> Get()
        {
            //var user = await _userManager.GetUserAsync(User);
            return await Task.Run<List<WorkflowItemModel>>(() =>
            {
                var wfs = _w.GetWorkflows();
                return wfs.Select(u => new WorkflowItemModel(u.DbEntity)).ToList();
            });
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkflowModel>> Get(int id)
        {
            return await Task.Run<ActionResult<WorkflowModel>>(() =>
            {
                var wf = _w.GetWorkflow(id);
                if (wf != null)
                    return new WorkflowModel(wf.DbEntity);
                return NotFound();
            });
        }

        // POST api/<controller>
        // Create new workflow
        [HttpPost]
        public async Task<int> Post(WorkflowModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var entity = model.ToEntity();
            var newWf = await _w.AddWorkflow(entity, user);
            await _rep.SetUserWorkflows(newWf.Id, model.Executors);
            return newWf.Id;
        }

        // PUT api/<controller>/5
        //Update existed workflow
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, UpdateWorkflowModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var wf = await _rep.GetWorkflow(id);
            model.UpdateEntity(wf);
            await _w.UpdateWorkflow(wf, user);
            return true;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var wf = _w.GetWorkflow(id);

            if (wf != null)
            {
                //var user = _userManager.GetUserAsync(User);
                await _w.DeleteWorkflow(wf.Id);
            }
            return true;
        }

        [HttpGet]
        [Route("graph/{id}")]
        public async Task<IList<NodeModel>> GetGraph(int id)
        {
            IList<NodeModel> nodes = new List<NodeModel>();
            var wf = _w.GetWorkflow(id);
            foreach (var node in wf.ExecutionGraph.Nodes)
            {
                wf.Tasks.TryGetValue(node.Id, out var task);
                string nodeName = "Task " + node.Id + (task != null ? ": " + task.Description : "");

                if (node is If)
                {
                    nodeName = "If...EndIf";
                }
                else if (node is While)
                {
                    nodeName = "While...EndWhile";
                }
                else if (node is Switch)
                {
                    nodeName = "Switch...EndSwitch";
                }

                string nodeId = "n" + node.Id;
                string parentId = "n" + node.ParentId;

                nodes.Add(new NodeModel(nodeId, nodeName, parentId));
            }
            return nodes;
        }

        [HttpGet]
        [Route("status/{id}")]
        public ActionResult<List<WorkflowStatusModel>> GetWorkflowStatus(int id)
        {
            var wf = _w.GetWorkflow(id);
            if (wf == null)
                return NotFound();
            var jobs = wf.Jobs.Select(u => new WorkflowStatusModel(u.Value));
            return jobs.ToList();
        }

        [HttpPost]
        [Route("start")]
        public async Task<ActionResult<bool>> StartWorkflow(StartWorkflowModel model)
        {
            //var user = await _userManager.GetUserAsync(User);
            var instanceId = await _w.PrepareStartingWorkflow(model.id, model.parameters);
            if (instanceId == Guid.Empty)
                return false;
            BackgroundJob.Enqueue<WorkflowStorage>(u => u.StartWorkflow(model.id, instanceId.ToString()));
            return Ok(true);
        }

        [HttpPost("approve")]
        public async Task<ActionResult<bool>> ApproveWorkflow(WorkflowInstanceRequestModel model)
        {
            var rs = await _w.ApproveWorkflow(model.workflowId, model.instanceId);

            if (rs)
            {
                BackgroundJob.Enqueue<WorkflowStorage>(u => u.ContinueWorkflow(model.workflowId, model.instanceId));
            }
            return rs;
        }

        [HttpPost("disapprove")]
        public async Task<ActionResult<bool>> DisapproveWorkflow(WorkflowInstanceRequestModel model)
        {
            var rs = await _w.DisapproveWorkflow(model.workflowId, model.instanceId);
            return rs;
        }

        [HttpGet]
        [Route("setting")]
        public async Task<ActionResult<WorkflowSetting>> GetSetting()
        {
            return _setting;
        }

        [HttpPost]
        [Route("history")]
        public async Task<ActionResult<BaseListModel<HistoryWorkflowEntrySummaryModel>>> GetHistory(TableParameter param)
        {
            var eP = param.ToEntityParam<HistoryWorkflowEntry>();
            eP.orderBy = u => u.DateCreated;
            var entries = (await _rep.GetHistoryEntries(eP)).Select(u => new HistoryWorkflowEntrySummaryModel(u));
            var count = await _rep.GetHistoryEntriesCount(eP);
            return new BaseListModel<HistoryWorkflowEntrySummaryModel>(entries, param.page, param.pageSize, count);
        }

        [HttpGet]
        [Route("history/{id}")]
        public async Task<ActionResult<HistoryWorkflowEntryModel>> GetHistory(int id)
        {
            var e = await _rep.GetHistoryWorkflowEntry(id);
            return new HistoryWorkflowEntryModel(e);
        }

        [HttpGet]
        [Route("tasks")]
        public async Task<ActionResult<List<string>>> GetTasks()
        {
            var tasks = new List<WorkflowTask>();
            var infAssembly = Assembly.GetAssembly(typeof(EfRepository));
            var webAssembly = Assembly.GetCallingAssembly();
            //var coreAssembly = Assembly.GetAssembly(typeof(BaseEntity));
            var allTypes = new List<Type>();
            allTypes.AddRange(webAssembly.GetTypes());
            allTypes.AddRange(infAssembly.GetTypes());
            //allTypes.AddRange(coreAssembly.GetTypes());
            var allTasks = allTypes.Where(u => typeof(WorkflowTask).IsAssignableFrom(u));
            return allTasks.Select(u => u.Name).ToList();
        }

        [HttpGet]
        [Route("executors")]
        public async Task<List<UserModel>> GetUserInRoles()
        {
            var user = await _userManager.GetUsersInRoleAsync(WorkflowStorage.WORKFLOW_EXECUTOR_ROLE);
            return user.Select(u => new UserModel(u)).ToList();
        }
    }
}
