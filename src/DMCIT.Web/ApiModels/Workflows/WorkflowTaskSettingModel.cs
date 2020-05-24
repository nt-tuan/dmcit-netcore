using DMCIT.Core.Entities.Workflow;
using System.Collections.Generic;
using System.Linq;

namespace DMCIT.Web.ApiModels.Workflows
{
    public class WorkflowTaskSettingModel
    {
        public string name { get; set; }
        public string value { get; set; }
        public Dictionary<string, string> attributes { get; set; } = new Dictionary<string, string>();

        public WorkflowTaskSettingModel() { }
        public WorkflowTaskSettingModel(WorkflowTaskSetting setting)
        {
            name = setting.Name;
            value = setting.Value;
            attributes = setting.Attributes.ToDictionary(u => u.Key, u => u.Value);
        }

        public WorkflowTaskSetting ToEntity()
        {
            var wts = new WorkflowTaskSetting();
            wts.Name = name;
            wts.Value = value;
            wts.Attributes = attributes;
            return wts;
        }
    }
}
