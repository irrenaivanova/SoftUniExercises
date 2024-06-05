using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006.FoodShortage.Models.Interfaces
{
    public interface IBuyable
    {
        public void BuyFood();
        public int Food { get; set; }
    }
}
