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
        private double fuelQuantity;
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double increasedConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.increasedConsumption = increasedConsumption;
            
        }

        public double FuelQuantity 
        {
            get { return fuelQuantity; }
            private set
            {
                if (value>TankCapacity)
                {
                     fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsumptionPerKm { get; private set; }

        public double TankCapacity { get; private set; } 
      
        public string Drive(double km, bool isIncreasedConsumption = true)
        {
            double realConsumption = isIncreasedConsumption ? FuelConsumptionPerKm + increasedConsumption : FuelConsumptionPerKm;
            double neededFuel = km * realConsumption;
            if (neededFuel > FuelQuantity)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }
            FuelQuantity -= neededFuel;
            return $"{GetType().Name} travelled {km} km";
        }

        public virtual void Refuel(double amount)
        {
            double availableSpace = TankCapacity - FuelQuantity;
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (availableSpace + amount > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }
            FuelQuantity += amount;
        }

        public override string ToString()=> $"{GetType().Name}: {FuelQuantity:f2}";
    }
}
