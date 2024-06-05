﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.VehicleExtension.Models
{
    public class Car : Vehicle
    {
        private const double IncreasedConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm, IncreasedConsumption)
        {
            
        }
    }
}
