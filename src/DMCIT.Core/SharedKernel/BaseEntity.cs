using DMCIT.Core.Entities.Core;
using System;
using System.Collections.Generic;

namespace DMCIT.Core.SharedKernel
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity : Base, IEqualityComparer<BaseEntity>, IComparable<BaseEntity>
    {
        public enum ListOrder { ASC = 1, DESC = 0 }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public AppUser CreatedBy { get; set; }

        public DateTime? DateRemoved { get; set; }
        public AppUser RemovedBy { get; set; }
        public string RemovedById { get; set; }
        public string CreatedById { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public AppUser LastModifiedBy { get; set; }
        public string LastModifiedById { get; set; }

        public virtual bool Equals(BaseEntity x, BaseEntity y)
        {
            return x.Id == y.Id;
        }

        public virtual int GetHashCode(BaseEntity obj)
        {
            return obj.GetHashCode();
        }

        public virtual int CompareTo(BaseEntity obj)
        {
            return Comparer<int>.Default.Compare(Id, obj.Id);
        }

        public virtual void UpdateFrom(BaseEntity entity)
        {

        }
    }
}