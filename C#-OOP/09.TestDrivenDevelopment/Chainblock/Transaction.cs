﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chainblock
{
    public class Transaction : ICloneable
    {
        public object Clone()
        {
           return this.MemberwiseClone();
        }
    }
}
