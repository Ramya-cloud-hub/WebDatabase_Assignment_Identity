using System;

namespace WebAppAssignmentDATABASE_5.Data.Exceptions
{
    internal class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }

       
    }
}