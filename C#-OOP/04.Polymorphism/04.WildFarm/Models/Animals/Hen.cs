using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private static readonly List<string> Foods = new List<string>() { "Fruit", "Meat", "Seeds", "Vegetable" };
        private const double WeightMultiplyer = 0.35;
        private const string Sound = "Cluck";
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, Foods, WeightMultiplyer, wingSize, Sound)
        {
        }
    }
}
