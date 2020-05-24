using DMCIT.Core.Entities.Workflow;
using DMCIT.Infrastructure.Data.Workflow;
using DMCIT.Web.ApiModels.Progress;
using System.Collections.Generic;
using System.Linq;

namespace DMCIT.Web.ApiModels.Workflows
{
    public class WorkflowTaskModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public bool enabled { get; set; }
        public bool isWaitingForApproval { get; set; }
        public bool approval { get; set; }
        public List<WorkflowTaskSettingModel> settings { get; set; } = new List<WorkflowTaskSettingModel>();

        public WorkflowTaskModel() { }
        public WorkflowTaskModel(DefinedWorkflowTask task)
        {
            name = task.Name;
            description = task.Description;
            enabled = task.IsEnabled;
            approval = task.Approval;
            isWaitingForApproval = task.Approval;
            settings = task.Settings.Select(u => new WorkflowTaskSettingModel(u)).ToList();
        }
        public DefinedWorkflowTask ToEntity()
        {
            var wt = new DefinedWorkflowTask();
            wt.Approval = approval;
            wt.IsEnabled = enabled;
            wt.Name = name;
            wt.Description = description;
            wt.Settings = settings.Select(u => u.ToEntity()).ToList();
            return wt;
        }
    }

    public class WorkingWorkflowTaskModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public bool enabled { get; set; }
        public bool isWaitingForApproval { get; set; }
        public bool approval { get; set; }
        public int id { get; set; }
        public List<string> logs = new List<string>();
        public List<FileInfoModel> files = new List<FileInfoModel>();
        public ProgressModel progress { get; set; }

        public WorkingWorkflowTaskModel() { }
        public WorkingWorkflowTaskModel(WorkflowTask task)
        {
            id = task.Id;
            name = task.Name;
            description = task.Description;
            enabled = task.IsEnabled;
            approval = task.IsWaitingForApproval;
            isWaitingForApproval = task.IsWaitingForApproval;
            if (task.Progress != null)
                progress = new ProgressModel(task.Progress);
            if (task.Logs != null)
                logs = task.Logs.Select(u => u).ToList();
            files = task.Files.Select(u => new FileInfoModel(u)).ToList();
        }
    }
}
