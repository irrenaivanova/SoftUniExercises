﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008.CollectionHierarchy.Models.Interfaces
{
    public interface IMyList:IAddRemove
    {
        public int Used { get; }
    }
}
