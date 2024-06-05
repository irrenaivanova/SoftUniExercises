using _03.Raiding.Factory.Interfaces;
using _03.Raiding.Models;
using _03.Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding.Factory
{
    public class Factory : IFactory
    {
        public IBaseHero Create(string type, string name)
        {
            switch (type) 
            {
                case "Druid": return new Druid(name);
                case "Paladin": return new Paladin(name);
                case "Rogue": return new Rogue(name);
                case "Warrior": return new Warrior(name);
                default: throw new ArgumentException("Invalid hero");
            }
        }
    }
}
