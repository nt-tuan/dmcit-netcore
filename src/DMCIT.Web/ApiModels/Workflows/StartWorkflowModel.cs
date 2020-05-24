using System.Collections.Generic;

namespace DMCIT.Web.ApiModels.Workflows
{
    public class StartWorkflowModel
    {
        public int id { get; set; }
        public Dictionary<string, string> parameters { get; set; }
    }
}
