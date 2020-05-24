using DMCIT.Core.SharedKernel;
using System;

namespace DMCIT.Core.Entities.Core
{
    public class Person : BaseVersionControlEntity<Person>
    {
        public enum PersonGender { MALE = 0, FEMALE = 1 }
        public string IdentityNumber { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public int Gender { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }

        public AppUser AppUser { get; set; }

        public override void UpdateFrom(BaseEntity entity)
        {
            base.UpdateFrom(entity);
            var e = entity as Person;
            if (e == null) return;
            FullName = e.FullName ?? FullName;
            FirstName = e.FirstName ?? FirstName;
            LastName = e.LastName ?? LastName;
            DisplayName = e.DisplayName ?? DisplayName;
            Address = e.Address ?? Address;
            Phone = e.Phone ?? Phone;
            Email = e.Email ?? Email;
            Birthday = e.Birthday ?? Birthday;
            Gender = e.Gender;
            CountryId = e.CountryId ?? CountryId;
        }
    }
}
