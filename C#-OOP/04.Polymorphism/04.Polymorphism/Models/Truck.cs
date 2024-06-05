using _04.VehicleExtension.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.VehicleExtension.Models
{
    public class Truck : Vehicle
    {
        private const double IncreasedConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumptionPerKm) : 
            base(fuelQuantity, fuelConsumptionPerKm, IncreasedConsumption)
        {
        }
        public override void Refuel(double amount)
        {
           base.Refuel(amount*0.95);
        }
    }
}
