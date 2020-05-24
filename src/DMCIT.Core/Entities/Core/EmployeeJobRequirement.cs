namespace DMCIT.Core.Entities.Core
{
    public class EmployeeJobRequirement
    {
        public int EmployeeJobId { get; set; }
        public EmployeeJob EmployeeJob { get; set; }
        public int JobRequirementId { get; set; }
        public JobRequirement JobRequirement { get; set; }
    }
}
