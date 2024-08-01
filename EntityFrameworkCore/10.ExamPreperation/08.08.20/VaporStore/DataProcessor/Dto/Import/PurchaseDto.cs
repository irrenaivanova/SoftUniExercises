using System;
using System.Collections.Generic;
using System.Text;
using VaporStore.Data.Models.Enums;
using VaporStore.Data.Models;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchaseDto
    {
        [XmlAttribute("title")]
        public string GameName { get; set; }

        [Required]
        [XmlElement("Type")]
        public PurchaseType? Type { get; set; }

        [Required]
        [XmlElement("Key")]
        [RegularExpression(@"[A-Z\d]{4}-[A-Z\d]{4}-[A-Z\d]{4}")]
        public string ProductKey { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }
        
        [XmlElement("Card")]
        public string  CardNumber { get; set; }
   
       
    }
}
