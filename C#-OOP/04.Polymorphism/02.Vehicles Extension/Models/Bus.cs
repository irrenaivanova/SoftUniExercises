using _04.VehicleExtension.Models;
using _04.VehicleExtension.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Vehicles_Extension.Models
{
    public class Bus : Vehicle
    {
        private const double IncreasedConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm, IncreasedConsumption, tankCapacity)
        {
        }
    }
}
