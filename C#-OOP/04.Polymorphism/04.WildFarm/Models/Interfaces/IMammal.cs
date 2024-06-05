using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Interfaces
{
    public interface IMammal:IAnimal
    {
        string LivingRegion { get;}
    }
}
