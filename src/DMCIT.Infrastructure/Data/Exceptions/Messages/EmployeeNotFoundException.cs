using System;

namespace DMCIT.Infrastructure.Data.Exceptions.Messages
{
    class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException(int id) : base("EMPLOYEE NOT FOUND")
        {

        }
    }
}
