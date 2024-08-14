using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ClientImportDto
    {
        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        public string Name { get; set; }
       
        [Required]
        [MinLength(10)]
        [MaxLength(15)]
        public string NumberVat { get; set; }

        [XmlArray]
        public List<AddressImportDto> Addresses { get; set; }
    }
}
