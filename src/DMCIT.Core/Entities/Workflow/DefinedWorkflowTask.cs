using System.Collections.Generic;

namespace DMCIT.Core.Entities.Workflow
{
    public class DefinedWorkflowTask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Approval { get; set; }
        public bool IsEnabled { get; set; }
        public List<WorkflowTaskSetting> Settings { get; set; }
    }
    public class WorkflowTaskSetting
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
    }
}
