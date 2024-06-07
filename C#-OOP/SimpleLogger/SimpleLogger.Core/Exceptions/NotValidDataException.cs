using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Core.Exceptions
{
    public class NotValidDataException : Exception
    {
        private const string defaultMessage = "Invalid data format";
        public NotValidDataException(string message):base(message) 
        { 

        }

        public NotValidDataException() : base(defaultMessage)
        {
        }
    }
}
