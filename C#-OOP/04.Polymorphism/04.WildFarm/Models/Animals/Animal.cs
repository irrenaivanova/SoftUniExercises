using _04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private string sound;
        private List<string> foods;
        private double weightMultiplyer;
        protected Animal(string name, double weight, List<string> foods, double weightMultiplyer,string sound)
        {
            Name = name;
            Weight = weight;
            this.foods = foods;
            this.weightMultiplyer = weightMultiplyer;
            this.sound = sound;
        }

        public string Name {get; private set;}

        public double Weight { get; private set; }

        public int FoodEaten { get; set; }
        
        public string AskForFood()
        {
            return sound;
        }

        public void Eat(IFood food)
        {
            if (!foods.Contains(food.GetType().Name))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            Weight += weightMultiplyer * food.Quantity;
            FoodEaten+= food.Quantity;
        }

        public override string ToString() 
        {
            return $"{GetType().Name} [{Name}, "; 
        }
    }
}


