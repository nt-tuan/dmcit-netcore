using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMCIT.Web.ApiModels.Accounts
{
    public class UpdateUserModel
    {
        [Required]
        public string id { get; set; }
        public List<string> roles { get; set; }
        public int? employeeId { get; set; }
        public int? customerId { get; set; }
    }
}
