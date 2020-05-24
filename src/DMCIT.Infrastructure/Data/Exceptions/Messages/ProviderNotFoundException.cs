using System;

namespace DMCIT.Infrastructure.Data.Exceptions.Messages
{
    class ProviderNotFoundException : Exception
    {
        public ProviderNotFoundException() : base("MESSAGE SERVICE PROVIDER NOT FOUND")
        {

        }
    }
}
