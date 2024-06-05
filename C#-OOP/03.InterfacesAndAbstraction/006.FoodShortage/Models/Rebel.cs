
using _005.BirthdayCelebrations.Models.Interfaces;
using _006.FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005.BirthdayCelebrations.Models
{
    public class Rebel : INameable,IBuyable,INameBuy
    {
        const int FoodInitial = 0;
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = FoodInitial;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 5;
        }

    }
}
