using DMCIT.Core.SharedKernel;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Core
{
    public class JobRequirement : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<EmployeeJobRequirement> EmployeeJobRequirements { get; set; }
    }
}
