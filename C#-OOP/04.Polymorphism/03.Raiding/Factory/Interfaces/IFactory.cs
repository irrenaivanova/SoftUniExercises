using _03.Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding.Factory.Interfaces
{
    public interface IFactory
    {
        IBaseHero Create(string type, string name);
    }
}
