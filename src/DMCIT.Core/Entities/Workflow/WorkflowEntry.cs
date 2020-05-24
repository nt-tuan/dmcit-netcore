using DMCIT.Core.SharedKernel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Workflow
{
    public enum Status
    {
        Pending,
        Running,
        Done,
        Failed,
        Warning,
        Disabled,
        Stopped,
        Disapproved
    }

    public enum LaunchType
    {
        Startup,
        Trigger,
        Periodic,
        Cron
    }

    public class WorkflowEntry : BaseEntity
    {
        public int DefinedWorkflowId { get; set; }
        public DefinedWorkflow DefinedWorkflow { get; set; }
        public string Name { get; set; }
        public string Parameters { get; set; }
        public LaunchType LaunchType { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime StatusDate { get; set; }
        public string Logs { get; set; }
        public void SetLog(List<string> logs)
        {
            try
            {
                Logs = JsonConvert.SerializeObject(logs);
            }
            catch
            {
                Logs = "[]";
            }
        }
        public List<string> GetLogs()
        {
            try
            {
                return JsonConvert.DeserializeObject<List<string>>(Logs);
            }
            catch
            {
                return new List<string>();
            }
        }
        public virtual string GetDbId()
        {
            return "-1";
        }
        public WorkflowEntry() { }
        public WorkflowEntry(DefinedWorkflow e, Dictionary<string, string> parameters)
        {
            DefinedWorkflowId = e.Id;
            Description = e.Description;
            Name = e.Name;
            LaunchType = (LaunchType)e.LauchType;
            Parameters = e.ParametersJSON;
            Status = Status.Running;
            StatusDate = DateTime.Now;
            Parameters = parameters == null ? null : JsonConvert.SerializeObject(parameters);
        }
    }
}
