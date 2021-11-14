using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentDATABASE_5.Data.Exceptions
{
    public class CreationException : Exception
    {

        public CreationException(string msg) : base(msg)
        {

        }
    }
}
