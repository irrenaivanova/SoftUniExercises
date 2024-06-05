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
        private const double IncreasedConsumption = 1.4;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm,double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm, IncreasedConsumption, tankCapacity)
        {
        }

        public override void Refuel(double amount)
        {
            double availableSpace = TankCapacity - FuelQuantity;
        
            if (availableSpace + amount > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }
           
            base.Refuel(amount*0.95);
        }

    }
}
