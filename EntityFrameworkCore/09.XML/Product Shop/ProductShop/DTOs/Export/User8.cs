using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
   // [XmlType("Users")]
    public class User8
    {
        [XmlElement("count")]
        public int Count { get; set; }
       
        [XmlArray("users")]
        public List<User88> Users { get; set; }
    }
}
