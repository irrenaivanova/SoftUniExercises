using _04.VehicleExtension.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.VehicleExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increasedConsumption;
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double increasedConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.increasedConsumption = increasedConsumption;
        }

        public double FuelQuantity {get; private set;}

        public double FuelConsumptionPerKm { get; private set; }

        public string Drive(double km)
        {
            double neededFuel = km * (FuelConsumptionPerKm+increasedConsumption);
            if (neededFuel > FuelQuantity)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }
            FuelQuantity -= neededFuel;
            return $"{GetType().Name} travelled {km} km";
        }

        public virtual void Refuel(double amount)
        {
           FuelQuantity += amount;
        }

        public override string ToString()=> $"{GetType().Name}: {FuelQuantity:f2}";
    }
}
