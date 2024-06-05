using _04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Mammal : Animal, IMammal
    {
        public Mammal(string name, double weight, List<string> foods, double weightMultiplyer, string livingRegion, string sound) 
            : base(name, weight, foods, weightMultiplyer, sound)
        {
            LivingRegion = livingRegion;
        }
        public string LivingRegion { get; private set; }
        public override string ToString()
        {
            return $"{base.ToString()}{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
