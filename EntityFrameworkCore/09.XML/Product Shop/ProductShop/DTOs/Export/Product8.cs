using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("SoldProducts")]
    public class Product8
    {
        [XmlElement("count")]
        public int Count { get; set; }
       
        [XmlArray("products")]
        public List<Product88> Products {get;set;}
    }
}
