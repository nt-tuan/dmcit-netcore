using DMCIT.Core.SharedKernel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Workflow
{
    public class HistoryWorkflowEntry : BaseEntity
    {
        public DefinedWorkflow DefinedWorkflow { get; set; }
        public int DefinedWorkflowId { get; set; }
        public string Name { get; set; }
        public LaunchType LaunchType { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime StatusDate { get; set; }
        public string Logs { get; set; }
        public string Files { get; set; }
        public HistoryWorkflowEntry() { }
        public HistoryWorkflowEntry(DefinedWorkflow e)
        {
            DefinedWorkflowId = e.Id;
            Name = e.Name;
            LaunchType = (LaunchType)e.LauchType;
            Description = e.Description;
        }
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
    }
}
