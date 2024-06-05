using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.DefiningClasses
{
     public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make { get { return make; } set { this.make = value; } }
        public string Model { get { return model; } set { this.model = value; } }

        public int Year { get { return year; } set { this.year = value; } }
        public double FuelQuantity { get { return fuelQuantity; } set { this.fuelQuantity = value; } }
        public double FuelConsumption { get { return fuelConsumption; } set { this.fuelConsumption = value; } }

        public void Drive(double distance)
        {
            if (fuelQuantity-distance*fuelConsumption>=0)
            {
                fuelQuantity -= distance*fuelConsumption;
            }   
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: { this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"Fuel: {this.FuelQuantity:f2}");

            return sb.ToString();
        }


    }

}

