using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Feline : Mammal, IFeline
    {
        protected Feline(string name, double weight, List<string> foods, double weightMultiplyer, string livingRegion, string breed, string sound) : 
            base(name, weight, foods, weightMultiplyer, livingRegion,sound)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
//Felines - "{AnimalType} [{AnimalName}, {Breed}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"
//return ((BaseClass)this).ToString();
//return $"{((Animal)this).ToString()}{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";