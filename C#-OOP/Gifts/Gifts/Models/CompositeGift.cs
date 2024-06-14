using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gifts.Models
{
    public class CompositeGift : IGiftBase
    {
        private List<IGiftBase> gifts;
        private decimal price; 
        
        public CompositeGift(string name ,decimal price )
        {
            Name = name;
            Price = price;
            gifts = new List<IGiftBase> ();
        }

        public string Name {get; private set;}

        public decimal Price { get; private set; }
       
        public decimal CalculateTotalPrice()
        {
            Console.WriteLine($"{Name} contains the following products with prices: ");
            foreach (var gift in gifts)
            {
                gift.CalculateTotalPrice();
                Price += gift.Price;
            }
            return Price;
        }
        public void Add(IGiftBase gift) 
        {
            gifts.Add( gift );
        }
    }
}
