using DMCIT.Core.Entities.Core;
using DMCIT.Core.SharedKernel;
using System;

namespace DMCIT.Core.Entities.Sales
{
    public class Customer : BaseVersionControlEntity<Customer>
    {
        public Person Person { get; set; }
        public int? PersonId { get; set; }

        #region Person property
        public string CachePersonIdentityNumber { get; set; }
        public string CachePersonFullName { get; set; }
        public string CachePersonFirstName { get; set; }
        public string CachePersonLastName { get; set; }
        public string CachePersonDisplayName { get; set; }
        public string CachePersonAddress { get; set; }
        public string CachePersonPhone { get; set; }
        public string CachePersonEmail { get; set; }
        public DateTime? CachePersonBirthday { get; set; }
        public int CachePersonGender { get; set; }
        #endregion

        public Business Business { get; set; }
        public int? BusinessId { get; set; }

        #region Business propery
        public string CacheBusinessIdentityNumber { get; set; }
        public string CacheBusinessFullName { get; set; }
        public string CacheBusinessDisplayName { get; set; }
        public string CacheBusinessAddress { get; set; }
        public string CacheBusinessMobilePhone { get; set; }
        public string CacheBusinessEmail { get; set; }
        public string CacheBusinessPhone { get; set; }
        public string CacheBusinessTaxNumber { get; set; }
        #endregion

        public string Code { get; set; }

        public int? DistributorId { get; set; }
        public Distributor Distributor { get; set; }

        public float? CoordinateX { get; set; }
        public float? CoordinateY { get; set; }

        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }

        public string GetFullName()
        {
            if (!string.IsNullOrEmpty(CacheBusinessFullName))
                return CacheBusinessFullName;
            return CachePersonFullName;
        }

        public string GetDisplayName()
        {
            if (!string.IsNullOrEmpty(CacheBusinessDisplayName))
            {
                return CacheBusinessDisplayName;
            }
            return CachePersonDisplayName;
        }

        public void RemoveCache()
        {
        }

        public void SetBusinessCache(Business business)
        {

        }

        public void SetPersonCache(Person person)
        {
        }

        public void Copy(Customer source)
        {
            BusinessId = source.BusinessId;
            Business = source.Business;
            PersonId = source.PersonId;
            Person = source.Person;
            Code = source.Code;
            DistributorId = source.DistributorId;
            Distributor = source.Distributor;
            CoordinateX = source.CoordinateX;
            CoordinateY = source.CoordinateY;
        }
    }
}
