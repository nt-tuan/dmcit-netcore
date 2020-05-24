using DMCIT.Core.Entities.Sales;

namespace DMCIT.Web.ApiModels.Sales
{
    public class DistributorModel : BaseModel<Distributor>
    {
        public string code { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string country { get; set; }
        public DistributorModel()
        {

        }

        public DistributorModel(Distributor entity) : base(entity)
        {
            code = entity.Code;
            name = entity.Name;
            address = entity.Address;
            phone = entity.Phone;
            country = entity.Country != null ? entity.Country.Name : "";
        }

        public Distributor ToEntity()
        {
            return new Distributor
            {
                Code = code,
                Address = address,
                Phone = phone,
                Name = name
            };
        }

    }
}
