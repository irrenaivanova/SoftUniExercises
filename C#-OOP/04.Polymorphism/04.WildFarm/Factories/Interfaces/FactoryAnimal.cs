using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.Food;
using _04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Factories.Interfaces
{
    public class FactoryAnimal : IFactoryAnimal
    {
        public IAnimal Create(string[] tokens)
        {
            string type = tokens[0];
            switch (type)
            {
                case "Owl": return new Owl(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                case "Hen": return new Hen(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                case "Tiger": return new Tiger(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                case "Cat": return new Cat(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                case "Mouse": return new Mouse(tokens[1], double.Parse(tokens[2]), tokens[3]);
                case "Dog": return new Dog(tokens[1], double.Parse(tokens[2]), tokens[3]);
                default: throw new ArgumentException("Invalid input");
            }

        }
    }
}
