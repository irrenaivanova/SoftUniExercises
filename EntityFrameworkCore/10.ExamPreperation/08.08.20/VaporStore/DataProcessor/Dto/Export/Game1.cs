using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType ("Game")]
    public class Game1
    {
        [XmlAttribute("title")]
        public string GameName { get; set; }
        
        [XmlElement("Genre")]
        public string GenreName { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
