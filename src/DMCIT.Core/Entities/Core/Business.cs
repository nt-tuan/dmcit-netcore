using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.Core
{
    public class Business : BaseVersionControlEntity<Business>
    {
        public string BusinessIdentityNumber { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TaxNumber { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public AppUser AppUser { get; set; }

        public override void UpdateFrom(BaseEntity source)
        {
            var e = source as Business;
            FullName = e.FullName ?? FullName;
            DisplayName = e.DisplayName ?? DisplayName;
            Address = e.Address ?? Address;
            MobilePhone = e.MobilePhone ?? MobilePhone;
            Email = e.Email ?? Email;
            Phone = e.Phone ?? Phone;
            TaxNumber = e.TaxNumber ?? TaxNumber;
            CountryId = e.CountryId ?? CountryId;
        }
    }
}
