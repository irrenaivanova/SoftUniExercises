using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.VehicleExtension.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumptionPerKm { get; }

        double TankCapacity { get; }

        string Drive(double km,bool isIncreased=true);
        void Refuel(double amount);
    }
}
