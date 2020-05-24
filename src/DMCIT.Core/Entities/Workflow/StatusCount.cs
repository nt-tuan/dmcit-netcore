using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.Workflow
{
    public class StatusCount : BaseEntity
    {
        public int PendingCount { get; set; }
        public int RunningCount { get; set; }
        public int DoneCount { get; set; }
        public int FailedCount { get; set; }
        public int WarningCount { get; set; }
        public int DisabledCount { get; set; }
        public int StoppedCount { get; set; }
        public int DisapprovedCount { get; set; }
    }
}