using Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private  const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50;
        public Coffee(string name, decimal price, double milliliters) : base(name, price, milliliters)
        {
        }
        
    }
}
Coffee and Tea are hot beverages. The Coffee class must have the following additional members:
//•	double CoffeeMilliliters = 50
//•	decimal CoffeePrice = 3.50
//•	Caffeine – double