using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class ExceptionDuplicate : Exception
    {
        public ExceptionDuplicate(string? message) : base(message)
        {
        }
    }
}
