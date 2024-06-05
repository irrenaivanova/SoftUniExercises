using _04.WildFarm.Models.Food;
using _04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Factories.Interfaces
{
    public class FactoryFood : IFactoryFood
    {
        public IFood Create(string type, int quantity)
        {
            switch(type)
            {
                case "Fruit": return new Fruit(quantity);
                case "Meat": return new Meat(quantity);
                case "Seeds": return new Seeds(quantity);
                case "Vegetable": return new Vegetable(quantity);
                default: throw new ArgumentException("Invalid input");
            }
        }
      
    }
}
