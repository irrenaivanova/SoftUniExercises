using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("User")]
    public class User88
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;
        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;
        
        [XmlElement("age")]
        public int? Age { get; set; }
        
        [XmlElement("SoldProducts")]
        public Product8 ProductsSold { get; set; } = null!;
    }
}
