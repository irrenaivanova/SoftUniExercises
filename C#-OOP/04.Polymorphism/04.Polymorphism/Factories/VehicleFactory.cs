using _04.VehicleExtension.Factories.Interfaces;
using _04.VehicleExtension.Models;
using _04.VehicleExtension.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.VehicleExtension.Factories
{
    public class VehicleFactory : IVehicleFactory
    { 
        public IVehicle Create(string type, double FuelQuantity, double FuelConsumptionPerKm)
        {
            if (type=="Car")
            {
                return new Car(FuelQuantity, FuelConsumptionPerKm);
            }
            else if (type=="Truck")
            {
                return new Truck(FuelQuantity, FuelConsumptionPerKm);
            }

            throw new ArgumentException("Inavlid type of car");
        }

    }
}
