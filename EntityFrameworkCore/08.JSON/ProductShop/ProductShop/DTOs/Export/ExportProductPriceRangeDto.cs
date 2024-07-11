using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.DTOs.Export
{
    public class ExportProductPriceRangeDto
    {
       
        public string Name { get; set; } = null!;
        
        public decimal Price { get; set; }
        [JsonProperty("seller")]
        public string FullName { get; set; } = null!;
    }
}
