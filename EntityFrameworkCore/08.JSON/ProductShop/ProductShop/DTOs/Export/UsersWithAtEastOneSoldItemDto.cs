using Newtonsoft.Json;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductShop.DTOs.Export
{
    public class UsersWithAtEastOneSoldItemDto
    {
        public string? FirstName { get; set; }

        public string LastName { get; set; } = null!;
        
        [JsonProperty("soldProducts")]
        public virtual ICollection<SoldProductDto> ProductsSold { get; set; }
    }
}
