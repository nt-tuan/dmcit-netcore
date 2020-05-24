using DMCIT.Core.Entities.DataCollector;
using DMCIT.Core.Entities.Workflow;
using DMCIT.Core.Events;
using DMCIT.Core.Interfaces;
using DMCIT.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data.Workflow.WorkflowTasks.LoadDiary131Task
{
    public class LoadDiary131Task : WorkflowTask
    {
        private readonly IDataCollectorRepository _collector;

        public LoadDiary131Task(int id, DefinedWorkflowTask xe, WorkingWorkflow wf) : base(id, xe, wf)
        {
        }

        [ActivatorUtilitiesConstructor]
        public LoadDiary131Task(IWorkflowService service, IDataCollectorRepository collector, int id, DefinedWorkflowTask xe, WorkingWorkflow wf) : base(service, id, xe, wf)
        {
            _collector = collector;
        }

        public void OnStart(DistributedServer sv, DateTime from, DateTime to)
        {
            lock (Workflow)
            {
                Progress = new LoadingDiary131Progress(sv, from, to);
                Progress.Id = Id;
                Progress.SetBegin();
            }
            Info(Progress.Description);
            _service.OnWorkflowTaskChange(this);
        }
        public void OnDownload()
        {
            lock (Workflow)
            {
                ((LoadingDiary131Progress)Progress)?.SetDownLoad();
            }
            Info(Progress.Description);
            _service.OnWorkflowTaskChange(this);
        }
        public void OnUpdate()
        {
            lock (Workflow)
            {
                ((LoadingDiary131Progress)Progress)?.SetUpdate();
            }
            Info(Progress.Description);
            _service.OnWorkflowTaskChange(this);
        }

        public void OnEnd()
        {
            lock (Workflow)
            {
                Progress?.SetEnd();
            }
            Info(Progress.Description);
            _service.OnWorkflowTaskChange(this);
        }

        protected override async Task<TaskStatus> _run()
        {
            await _collector.LoadDiary131s(null, new LoadDiary131EventCollection
            {
                OnBeginDownloadDiary131FromServer = OnStart,
                OnDownloadingDiary131FromServer = OnDownload,
                OnEndDownloadDiaryFromServer = OnEnd,
                OnUpdatingDiary131FromServer = OnUpdate
            }); ;
            return new TaskStatus(Status.Done, false);

        }
    }
}
