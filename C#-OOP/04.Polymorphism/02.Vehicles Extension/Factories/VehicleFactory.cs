using _02.Vehicles_Extension.Models;
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
        public IVehicle Create(string type, double fuelQuantity, double fuelConsumptionPerKm, double tankcapacity)
        {
            if (type=="Car")
            {
                return new Car(fuelQuantity, fuelConsumptionPerKm, tankcapacity);
            }
            else if (type=="Truck")
            {
                return new Truck(fuelQuantity, fuelConsumptionPerKm, tankcapacity);
            }
            else if (type == "Bus")
            {
                return new Bus(fuelQuantity, fuelConsumptionPerKm, tankcapacity);
            }

            throw new ArgumentException("Inavlid type of car");
        }

    }
}
