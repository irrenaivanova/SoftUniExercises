using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class User1
    {
        [XmlAttribute("username")]
        public string UserName { get; set; }

        [XmlArray("Purchases")]
        public Purchase1[] Purchases { get; set; }
        
        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }

    }
}
