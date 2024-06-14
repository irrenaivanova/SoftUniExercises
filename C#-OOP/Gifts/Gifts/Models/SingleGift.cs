using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gifts.Models
{
    public class SingleGift : IGiftBase
    {
        public SingleGift(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public decimal CalculateTotalPrice()
        {
            Console.WriteLine($"{Name} with the price {Price}");
            return Price;
        }
    }
}
