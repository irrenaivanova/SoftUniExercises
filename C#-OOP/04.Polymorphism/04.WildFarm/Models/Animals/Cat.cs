using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private static readonly List<string> Foods = new List<string>() { "Vegetable","Meat" };
        private const double WeightMultiplyer = 0.3;
        private const string Sound = "Meow";
        public Cat(string name, double weight, string livingRegion, string breed) : 
            base(name, weight, Foods, WeightMultiplyer, livingRegion, breed, Sound)
        {
        }
    }
}
