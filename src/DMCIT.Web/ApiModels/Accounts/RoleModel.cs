using DMCIT.Core.Entities.Core;

namespace DMCIT.Web.ApiModels.Accounts
{
    public class RoleModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public RoleModel(AppRole role)
        {
            id = role.Id;
            name = role.Name;
            description = role.Description;
        }
    }
}
