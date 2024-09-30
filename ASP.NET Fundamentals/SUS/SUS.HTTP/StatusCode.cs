using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public enum StatusCode
    {
        OK=200,
        MovedPernamently = 301,
        NotFound = 404,
        ServerError = 500,
    }
}
