﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007.MilitaryElite.Models.Interfaces
{
    public interface IEngineer:ISpecialedSoldier
    {
         IReadOnlyCollection<IRepair> Repairs { get;}
    }
}
