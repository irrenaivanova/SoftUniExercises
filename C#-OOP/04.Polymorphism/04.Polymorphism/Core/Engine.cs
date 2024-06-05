using _04.VehicleExtension.Core.Interfaces;
using _04.VehicleExtension.Factories;
using _04.VehicleExtension.IO;
using _04.VehicleExtension.IO.Interfaces;
using _04.VehicleExtension.Models;
using _04.VehicleExtension.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.VehicleExtension.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly VehicleFactory vehicleFactory;
        private readonly ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, VehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
            this.vehicles = new List<IVehicle>();
        }

        public void Run()
        {
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());

            int numbersOfCommands = int.Parse(reader.ReadLine());
            for (int i = 0; i < numbersOfCommands; i++)
            {
                try
                {
                    CommandProcess();
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }

        private void CommandProcess()
        {
            string[] commands = reader.ReadLine().Split();
            string command = commands[0];
            string typeVehicle = commands[1];
            IVehicle vehicle = vehicles.FirstOrDefault(x=>x.GetType().Name == typeVehicle);
          
            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }
            if (command == "Drive")
            {
                double distance = double.Parse(commands[2]);
                writer.WriteLine(vehicle.Drive(distance));

            }
            if (command == "Refuel")
            {
                double fuel = double.Parse(commands[2]);
                vehicle.Refuel(fuel);
            }
        }

        private IVehicle CreateVehicle()
        {
            string[] input = reader.ReadLine().Split();
            return vehicleFactory.Create(input[0], double.Parse(input[1]), double.Parse(input[2]));
        }
    }
}
//Drive Car 9