﻿using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("User")]
    public class User6
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;
        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;
        
        [XmlArray("soldProducts")]
        public List<Product6> ProductsSold { get; set; } = null!;
    }
}
