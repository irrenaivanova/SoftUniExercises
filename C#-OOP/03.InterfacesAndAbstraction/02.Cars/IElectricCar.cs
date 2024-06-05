using Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
     interface IElectricCar:ICar
    {
        public int Battery { get; set; }
    }
}
