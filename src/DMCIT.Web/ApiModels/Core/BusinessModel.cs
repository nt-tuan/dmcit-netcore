using DMCIT.Core.Entities.Core;

namespace DMCIT.Web.ApiModels.Core
{
    public class BusinessModel : BaseModel<Business>
    {
        public string fullname { get; set; }
        public string displayname { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string taxNumber { get; set; }
        public string country { get; set; }
        public string code { get; set; }
        public BusinessModel()
        {

        }

        public BusinessModel(Business entity) : base(entity)
        {
            fullname = entity.FullName;
            displayname = entity.DisplayName;
            address = entity.Address;
            email = entity.Email;
            phone = entity.Phone;
            taxNumber = entity.TaxNumber;
            code = entity.BusinessIdentityNumber;
        }

        public Business ToEntity()
        {
            var entity = new Business
            {
                FullName = fullname,
                DisplayName = displayname,
                Address = address,
                Email = email,
                Phone = phone,
                TaxNumber = taxNumber,
                BusinessIdentityNumber = code,
                Id = id
            };
            return entity;
        }
    }
}
