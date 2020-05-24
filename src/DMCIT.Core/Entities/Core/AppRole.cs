using Microsoft.AspNetCore.Identity;

namespace DMCIT.Core.Entities.Core
{
    public class AppRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
