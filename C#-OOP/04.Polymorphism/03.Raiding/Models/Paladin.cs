using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding.Models
{
    public class Paladin:BaseHero
    {
        private const int powerConst = 100;
        public Paladin(string name) : base(name, powerConst)
        {
        }
    }
}
