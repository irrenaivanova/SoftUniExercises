using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_04.PizzaCalories
{
    public class Topping
    {
        private readonly Dictionary<string, double> modifiers;
        private const double BaseToppingCaloriesPerGram = 2;
        private const int MinWeight = 1;
        private const int MaxWeight = 50;
       
        private string name;
        private double weight;

        public Topping(string name, double weight)
        {
            modifiers = new Dictionary<string, double>()
            {
                { "meat", 1.2 },
                { "veggies", 0.8 },
                { "cheese", 1.1 },
                { "sauce", 0.9 },
            };
            Name = name;
            Weight = weight;
            
        }
        public string Name
        {
            get => name;
            private set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                name = value;
            }
        }
        public double Weight
        {
            get => weight;
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException
                        (string.Format(Exceptions.WeightException, Name, MinWeight, MaxWeight));
                }
                weight = value;
            }
        }
       

        public double CalorieTopping
        {
            get
            {
                return Weight * BaseToppingCaloriesPerGram * modifiers[Name.ToLower()];
            }
        }
    }
}
