﻿
using System.Xml.Serialization;

namespace ProductShop.DTOs.Import;

[XmlType("User")]
public class UserDto
{
    [XmlElement("firstName")]
    public string? FirstName { get; set; } 
    [XmlElement("lastName")]
    public string? LastName { get; set; }
    
    [XmlElement("age")]
    public int? Age { get; set; }
}
