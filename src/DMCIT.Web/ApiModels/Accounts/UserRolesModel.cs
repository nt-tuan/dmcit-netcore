using DMCIT.Core.Entities.Core;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DmcSupport.Models.Accounts
{
    public class UserRolesModel
    {
        public AppUser User { get; set; }
        public List<bool> RolesAssigned { get; set; }
        public List<string> RolesNewAssigned { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}