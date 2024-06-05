using _04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Bird : Animal, IBird
    {
        public Bird(string name, double weight, List<string> foods, double weightMultiplyer, double wingSize,string sound)
            : base(name, weight, foods, weightMultiplyer,sound)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }
        public override string ToString()
            => $"{base.ToString()}{WingSize}, {Weight}, {FoodEaten}]";

    }
}
