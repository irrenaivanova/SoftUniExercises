using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private static readonly List<string> Foods = new List<string>() { "Meat" };
        private const double WeightMultiplyer = 0.4;
        private const string Sound = "Woof!";
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, Foods, WeightMultiplyer, livingRegion, Sound)
        {
        }
    }
}
