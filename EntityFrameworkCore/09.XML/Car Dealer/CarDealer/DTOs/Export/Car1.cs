﻿
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("car")]
    public class Car1
    {
        [XmlAttribute("make")]
        public string Make { get; set; } = null!;
        [XmlAttribute("model")]
        public string Model { get; set; } = null!;
        [XmlAttribute("traveled-distance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public List<Part1> Parts { get; set;}

    }
}
