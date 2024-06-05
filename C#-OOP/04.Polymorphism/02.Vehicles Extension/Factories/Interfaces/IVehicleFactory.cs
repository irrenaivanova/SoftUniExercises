using _04.VehicleExtension.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.VehicleExtension.Factories.Interfaces
{
    internal interface IVehicleFactory
    {
        IVehicle Create(string type, double FuelQuantity, double FuelConsumptionPerKm, double TankCapacity);
    }
}
