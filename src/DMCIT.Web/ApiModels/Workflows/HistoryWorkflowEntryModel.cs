using DMCIT.Core.Entities.Workflow;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMCIT.Web.ApiModels.Workflows
{
    public class HistoryWorkflowEntrySummaryModel
    {
        public int id { get; set; }
        public int workflowId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public DateTime startTime { get; set; }
        public DateTime statusTime { get; set; }
        public HistoryWorkflowEntrySummaryModel()
        {
        }
        public HistoryWorkflowEntrySummaryModel(HistoryWorkflowEntry entry)
        {
            id = entry.Id;
            workflowId = entry.DefinedWorkflowId;
            name = entry.Name;
            description = entry.Description;
            status = entry.Status.ToString();
            startTime = entry.DateCreated;
            statusTime = entry.StatusDate;
        }
    }
    public class HistoryWorkflowEntryModel : HistoryWorkflowEntrySummaryModel
    {
        public List<string> files { get; set; }
        public List<string> logs { get; set; }
        public HistoryWorkflowEntryModel() : base()
        {

        }

        public HistoryWorkflowEntryModel(HistoryWorkflowEntry entry) : base(entry)
        {
            try
            {
                logs = JsonConvert.DeserializeObject<List<string>>(entry.Logs);
            }
            catch
            {
                logs = entry.Logs.Split("\r\n").ToList();
            }
            if (entry.Files != null)
                files = JsonConvert.DeserializeObject<List<string>>(entry.Files);
            else
                files = new List<string>();
        }
    }
}
