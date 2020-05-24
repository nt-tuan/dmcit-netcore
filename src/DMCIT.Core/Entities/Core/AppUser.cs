using DMCIT.Core.Entities.Sales;
using Microsoft.AspNetCore.Identity;

namespace DMCIT.Core.Entities.Core
{
    public class AppUser : IdentityUser
    {
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
