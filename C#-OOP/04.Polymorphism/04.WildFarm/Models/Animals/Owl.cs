using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private static readonly List<string> Foods = new List<string>() {"Meat"};
        private const double WeightMultiplyer = 0.25;
        private const string Sound = "Hoot Hoot";
        public Owl(string name, double weight, double wingSize) : 
            base(name, weight, Foods, WeightMultiplyer, wingSize, Sound )
        {

        }
    }
}
