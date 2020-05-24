using DMCIT.Core.Entities.Core;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.Workflow
{
    public class UserWorkflow : BaseEntity
    {
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public int DefinedWorkflowId { get; set; }
        public DefinedWorkflow DefinedWorkflow { get; set; }
    }
}
