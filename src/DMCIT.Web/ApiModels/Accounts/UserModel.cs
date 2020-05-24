using DMCIT.Core.Entities.Core;
using DMCIT.Web.ApiModels.HR;
using DMCIT.Web.ApiModels.Sales;
using System;
using System.Collections.Generic;

namespace DMCIT.Web.ApiModels.Accounts
{
    public class UserModel
    {
        public string id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public bool isLock { get; set; }
        public string lastActiveTime { get; set; }
        public EmployeeModel employee { get; set; }
        public CustomerModel customer { get; set; }
        public int? employeeId { get; set; }
        public int? customerId { get; set; }
        public ICollection<string> roles { get; set; }

        public string token { get; set; }
        public UserModel()
        {

        }

        public UserModel(AppUser user, string token) : this(user)
        {
            this.token = token;
        }

        public UserModel(AppUser user)
        {
            id = user.Id;
            username = user.UserName;
            email = user.Email;
            isLock = user.LockoutEnabled && user.LockoutEnd > DateTime.Now;

            if (user.Employee != null)
            {
                employee = new EmployeeModel(user.Employee);
            }

            if (user.Customer != null)
            {
                customer = new CustomerModel(user.Customer);
            }
        }

        public void SetRoles(ICollection<string> roles)
        {
            this.roles = roles;
        }
    }
}
