using System;

namespace DMCIT.Infrastructure.Data
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message) : base(message)
        {

        }
    }
}
