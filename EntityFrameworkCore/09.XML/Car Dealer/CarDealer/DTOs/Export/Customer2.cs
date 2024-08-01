
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("customer")]
    public class Customer2
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; }
        [XmlAttribute("bought-cars")]
        public int BoughtCar { get; set; }

        [XmlAttribute("spent-money")]
        public string SpentMoney { get; set; }

    }
}
