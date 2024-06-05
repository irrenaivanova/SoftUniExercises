using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private static readonly List<string> Foods = new List<string>() { "Fruit", "Vegetable" };
        private const double WeightMultiplyer = 0.1;
        private const string Sound = "Squeak";
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, Foods, WeightMultiplyer, livingRegion, Sound)
        {
        }
    }
}
