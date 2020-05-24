using DMCIT.Core.SharedKernel;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Core
{
    public class EmployeeJob : BaseEntity
    {
        public string Name { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public ICollection<EmployeeJobRequirement> EmployeeJobRequirements { get; set; }
    }
}
