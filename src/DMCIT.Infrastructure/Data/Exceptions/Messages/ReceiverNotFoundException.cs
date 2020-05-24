using System;

namespace DMCIT.Infrastructure.Data.Exceptions.Messages
{
    class ReceiverNotFoundException : Exception
    {
        public ReceiverNotFoundException() : base("MESSAGE RECEIVER NOT FOUND")
        {

        }
    }
}
