using DMCIT.Core.Entities.Workflow;

namespace DMCIT.Web.ApiModels.Workflows
{
    public class WorkflowItemModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public WorkflowItemModel() { }
        public WorkflowItemModel(DefinedWorkflow wf)
        {
            id = wf.Id;
            name = wf.Name;
            description = wf.Description;
        }
    }
}
