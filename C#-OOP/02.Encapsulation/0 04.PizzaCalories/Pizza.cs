using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private readonly List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }
        public Pizza()
        {

        }
        public Dough Dough { get; set; }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public void AddTopping(Topping topping)
        {
            if (toppings.Count > 10)
            {
                throw new SystemException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
        public double Calories
        {
            get => Dough.WeightDough() + toppings.Select(x =>x.CalorieTopping).Sum();
        }

        public override string ToString()
        {
            return $"{Name} - {Calories:f2} Calories.";
        }

    }
}
