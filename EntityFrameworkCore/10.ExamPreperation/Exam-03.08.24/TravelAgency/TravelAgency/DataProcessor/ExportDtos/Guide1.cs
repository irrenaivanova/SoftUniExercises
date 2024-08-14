using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType("Guide")]
    public class Guide1
    {
        public string FullName { get; set; }
       
        [XmlArray]
        public TourPackage1[] TourPackages { get; set; }
    }
}
