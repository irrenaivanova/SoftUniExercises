﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Export
{
    public class ExportCostumerDtoByMoneySPend
    { 
        public string FullName { get; set; }
        public int BoughtCars { get; set; }

        public decimal SpentMoney { get; set; }

    }
}
