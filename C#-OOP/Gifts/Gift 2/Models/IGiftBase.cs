using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gifts.Models
{
    public interface IGiftBase
    {
        string Name { get; }
        decimal Price { get; }
        public decimal CalculateTotalPrice();

    }
}
