using DMCIT.Core.Entities.Core;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.Sales
{
    public class Distributor : BaseVersionControlEntity<Distributor>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
    }
}
