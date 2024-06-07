using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Core.Exceptions
{
    public class EmptyPropertyException:Exception
    {
        private const string defaultException = "The value of the field cannot be null or whitespace!";
        public EmptyPropertyException(string message) : base(message)
        {

        }

        public EmptyPropertyException() : base(defaultException)
        {
        }
    }
}
