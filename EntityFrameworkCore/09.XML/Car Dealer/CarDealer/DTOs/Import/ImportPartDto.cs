using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Part")]
    public class ImportPartDto
    { 
        public string name { get; set; } = null!;

        public decimal price { get; set; }

        public int quantity { get; set; }

        public int supplierId { get; set; }

    }
}
