using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Client")]
    public class Client1
    {
        [XmlAttribute]
        public int InvoiceCount { get; set; }
        public string ClientName { get; set; }
        public string VatNumber { get; set; }

        public List<Invoice1> Invoices { get; set; }
    }
}
