using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private static readonly List<string> Foods = new List<string>() { "Meat" };
        private const double WeightMultiplyer = 1;
        private const string Sound = "ROAR!!!";
        public Tiger(string name, double weight, string livingRegion, string breed) :
            base(name, weight, Foods, WeightMultiplyer, livingRegion, breed, Sound)
        {
        }
    
    }
}
