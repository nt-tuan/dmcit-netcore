using DMCIT.Infrastructure.Data.Workflow;
using DMCIT.Infrastructure.Services;
using DMCIT.Web.ApiModels.Workflows;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Web.Hubs.WorkflowHub
{
    public class WorkflowHub : Hub
    {
        static string WORKFLOW_GROUP_NAME = "WORKFLOW_";
        static string WORKFLOW_INSTANCE_GROUP_NAME = "INSTANCE_";
        private readonly WorkflowStorage _engine;
        private readonly IWorkflowService _service;
        public WorkflowHub(WorkflowStorage engine, IWorkflowService service)
        {
            _engine = engine;
            _service = service;
        }

        public static string GetWorkflowGroup(int id)
        {
            return WORKFLOW_GROUP_NAME + id;
        }

        public static string GetWorkflowInstanceGroup(string instanceId)
        {
            return WORKFLOW_INSTANCE_GROUP_NAME + instanceId;
        }
        public static string GetWorkflowInstanceGroup(Guid instanceId)
        {
            return GetWorkflowInstanceGroup(instanceId.ToString());
        }

        public void throwWorkflowInstanceNotFound(int id, string instanceId)
        {
            throw new Exception($"Instance {instanceId} of workflow {id} not found");
        }

        public async Task<WorkflowInstanceModel> WatchWorkflowInstance(int id, string instanceId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, GetWorkflowInstanceGroup(instanceId));
            var wf = _engine.GetWorkflow(id);
            wf.Jobs.TryGetValue(Guid.Parse(instanceId), out WorkingWorkflow instance);
            if (instance == null)
                return null;
            return new WorkflowInstanceModel(instance);
        }

        public async Task<dynamic> WatchWorkflow(int id)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, GetWorkflowGroup(id));
            var e = _engine.GetWorkflow(id);
            var workflow = new WorkflowModel(e.DbEntity);
            var jobs = e.Jobs.Values.Select(u => new { id, instanceId = u.InstanceId });
            return new { workflow, jobs };
        }

        public async Task<WorkflowInstanceModel> GetWorkflowInstance(int id, string instanceId)
        {
            return await Task.Run(() =>
            {
                var wf = _engine.GetWorkflow(id);
                wf.Jobs.TryGetValue(Guid.Parse(instanceId), out WorkingWorkflow instance);
                if (instance == null)
                    throwWorkflowInstanceNotFound(id, instanceId);
                return new WorkflowInstanceModel(instance);
            });
        }

        public async Task<bool> StopWorkflow(int id, string instanceId)
        {
            var wf = _engine.GetWorkflow(id);
            wf.Jobs.TryGetValue(Guid.Parse(instanceId), out WorkingWorkflow instance);
            if (instance == null)
                throwWorkflowInstanceNotFound(id, instanceId);
            var rs = await _engine.StopWorkflow(id, instanceId);
            return rs;
        }

        public async Task ForgetWorkflow(int id, string instanceId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, GetWorkflowInstanceGroup(instanceId));
        }
    }
}
