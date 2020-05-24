using DMCIT.Core.Entities.Messaging;
using System;

namespace DMCIT.Infrastructure.Data.Exceptions.Messages
{
    class InvalidReceiverAddressException : Exception
    {
        public InvalidReceiverAddressException(string address, MessageServiceProvider provider) : base(String.Format("{0} IS NOT A VALID {1}", address, provider.AddressLabel))
        {

        }
    }
}
