using DMCIT.Core.Entities.Core;

namespace DmcSupport.Models.Accounts
{
    public class CreateAccountSuccessfulModel
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        //public Employee employee { get; set; }
        public CreateAccountSuccessfulModel()
        {

        }
        public CreateAccountSuccessfulModel(AppUser user, string password)
        {
            username = user.UserName;
            email = user.Email;
            this.password = password;
        }
    }
}
