using DMCIT.Infrastructure.Data.Workflow;
using DMCIT.Infrastructure.Events.Workflows;
using MediatR;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Services
{
    public interface IWorkflowService
    {
        Task OnWorkflowStart(WorkingWorkflow wf);
        Task OnWorkflowTaskStart(WorkflowTask wf);
        Task OnWorkflowTaskChange(WorkflowTask wf);
        Task OnWorkflowTaskEnd(WorkflowTask wf);
        Task OnWorkflowEnd(WorkingWorkflow wf);
        //Task StartWorkflow(int id, string instanceId);        
    }
    public class WorkflowService : IWorkflowService
    {
        IMediator _mediator;

        public WorkflowService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task OnWorkflowEnd(WorkingWorkflow wf)
        {
            await _mediator.Publish(new OnWorkflowEndEvent
            {
                Entity = wf
            });
        }

        public async Task OnWorkflowStart(WorkingWorkflow wf)
        {
            await _mediator.Publish(new OnWorkflowStartEvent
            {
                Entity = wf
            });
        }

        public async Task OnWorkflowTaskStart(WorkflowTask task)
        {
            await _mediator.Publish(new OnWorkflowTaskStartEvent
            {
                Entity = task
            });
        }

        public async Task OnWorkflowTaskChange(WorkflowTask task)
        {
            await _mediator.Publish(new OnWorkflowTaskChangeEvent
            {
                Entity = task
            });
        }

        public async Task OnWorkflowTaskEnd(WorkflowTask task)
        {
            await _mediator.Publish(new OnWorkflowTaskEndEvent
            {
                Entity = task
            });
        }



        //public async Task StartWorkflow(int id, string instanceId)
        //{
        //    var wf = _engine.GetWorkflow(id);
        //    wf.ReadyJobs.TryGetValue(Guid.Parse(instanceId), out WorkingWorkflow wwf);
        //    if (wwf != null)
        //    {
        //        var running = ActivatorUtilities.CreateInstance<WorkingWorkflow>(_sp, wwf);
        //        wf.ReadyJobs.Remove(Guid.Parse(instanceId));
        //        wf.Jobs.Add(running.InstanceId, running);

        //        running.LoadTasks(_sp);
        //        await OnWorkflowStart(running);
        //        await running.Start();
        //        await OnWorkflowEnd(running);
        //    }
        //}

        /// <summary>
        /// Stops a workflow.
        /// </summary>
        /// <param name="workflowId">Workflow Id.</param>
        /// <param name="instanceId">Job instance Id.</param>

        /// <summary>
        /// Resumes a workflow.
        /// </summary>
        /// <param name="workflowId">Workflow Id.</param>
        /// <param name="instanceId">Job instance Id.</param>








    }
}
