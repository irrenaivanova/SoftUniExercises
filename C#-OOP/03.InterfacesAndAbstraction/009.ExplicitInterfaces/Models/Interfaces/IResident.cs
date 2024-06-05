using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009.ExplicitInterfaces.Models.Interfaces
{
    internal interface IResident
    {
        string Name { get; }
         string Country { get; }
        public string GetName();

    }
}
