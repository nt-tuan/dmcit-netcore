using System;

namespace DMCIT.Infrastructure.Providers
{
    public class SendMessageException : Exception
    {
        public SendMessageException() : base()
        {

        }

        public SendMessageException(string mes) : base(mes)
        {

        }
    }
}
