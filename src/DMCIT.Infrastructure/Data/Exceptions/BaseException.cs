using System;

namespace DMCIT.Infrastructure.Data.Exceptions
{
    public abstract class BaseExceptionInformation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public BaseExceptionInformation()
        {
            LoadDefault();
        }
        public virtual void LoadDefault()
        {
            Name = GetType().Name;
        }
        public virtual Exception ToException()
        {
            return new Exception(Name);
        }
    }
}
