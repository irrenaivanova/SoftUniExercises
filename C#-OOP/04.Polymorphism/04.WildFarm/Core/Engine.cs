using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.WildFarm.Core.Interfaces;
using _04.WildFarm.Factories.Interfaces;
using _04.WildFarm.IO.Interfaces;
using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IFactoryAnimal factoryAnimal;
        private readonly IFactoryFood factoryFood;
        private readonly ICollection<IAnimal> animals;

        public Engine(IWriter writer, IReader reader, IFactoryAnimal factoryAnimal, IFactoryFood factoryFood)
         
        {
            this.writer = writer;
            this.reader = reader;
            this.factoryAnimal = factoryAnimal;
            this.factoryFood = factoryFood;
            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            while(true)
            {
                string command = reader.ReadLine();
                if (command == "End")
                    break;
                
                try
                {
                    CreateAnimal(command);
                    command = reader.ReadLine();    
                    ProcessWithFood(command);
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
            foreach (var animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }
        private void CreateAnimal(string command)
        {
            string[] tokens = command.Split();
            animals.Add(factoryAnimal.Create(tokens));
        }

        private void ProcessWithFood(string command)
        {
            string[] tokens = command.Split();
            IFood currentFood = factoryFood.Create(tokens[0], int.Parse(tokens[1]));
            IAnimal currentAnimal = animals.LastOrDefault();
            writer.WriteLine(currentAnimal.AskForFood());
            currentAnimal.Eat(currentFood);
        }

    }
}
