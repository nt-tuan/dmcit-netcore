using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Sales;
using DMCIT.Web.ApiModels.Core;

namespace DMCIT.Web.ApiModels.Sales
{
    public class CustomerModel : BaseModel<Customer>
    {
        public PersonModel person { get; set; }
        public BusinessModel business { get; set; }
        public string code { get; set; }
        public float? coordinateX { get; set; }
        public float? coordinateY { get; set; }
        public DistributorModel distributor { get; set; }
        public CustomerModel()
        {

        }

        public CustomerModel(Customer entity) : base(entity)
        {
            if (entity.BusinessId != null && entity.Business == null)
            {
                entity.Business = entity.RetreiveCache<Business>();
            }
            if (entity.PersonId != null)
            {
                entity.Person = entity.RetreiveCache<Person>();
            }

            code = entity.Code;
            coordinateX = entity.CoordinateX;
            coordinateY = entity.CoordinateY;
            if (entity.Person != null)
                person = new PersonModel(entity.Person);
            if (entity.Business != null)
                business = new BusinessModel(entity.Business);
            if (entity.Distributor != null)
                distributor = new DistributorModel(entity.Distributor);
        }

        public Customer ToEntity()
        {

            var entity = new Customer
            {
                Id = id,
                Code = code,
                DistributorId = distributor?.id,
                Person = person?.ToEntity(),
                Business = business?.ToEntity()
            };

            if (distributor != null)
            {
                entity.Distributor = distributor.ToEntity();
            }

            return entity;
        }
    }
}
