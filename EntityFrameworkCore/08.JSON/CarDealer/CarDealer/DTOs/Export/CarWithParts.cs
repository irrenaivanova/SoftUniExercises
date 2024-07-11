using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Export
{
    public class CarWithParts
    {
        [JsonProperty("car")]
        public CarDto Car { get; set; }
        
        [JsonProperty("parts")]
        public ICollection<PartDto> Parts { get; set; }
    }
}
