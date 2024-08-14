﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Truck : Vehicle
    {
        public Truck(string model, double price) 
            : base(model, price*1.3)
        {
        }
    }
}
