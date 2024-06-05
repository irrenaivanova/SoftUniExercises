using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagProducts = new List<Product>();
        }
     
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public void Buying(Product product)
        {
            if (Money>=product.Cost)
            {
                bagProducts.Add(product);
                Money -= product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
        public override string ToString()
        {
            if (bagProducts.Count==0)
            {
                return $"{Name} - Nothing bought";
            }
            return $"{Name} - {string.Join(", ", bagProducts)}";
        }
    }
}
