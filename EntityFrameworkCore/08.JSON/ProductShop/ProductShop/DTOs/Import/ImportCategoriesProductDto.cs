﻿using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.DTOs.Import
{
    public class ImportCategoriesProductDto
    {
        public int CategoryId { get; set; }
      
        public int ProductId { get; set; }
    }
}
