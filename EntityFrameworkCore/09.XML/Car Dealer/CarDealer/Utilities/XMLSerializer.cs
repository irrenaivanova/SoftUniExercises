using CarDealer.DTOs.Import;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarDealer.Utilities
{
    public class XMLSerializer
    {

        public T[] Deserialise<T>(string inputXml)
        {
            XDocument doc = XDocument.Parse(inputXml);
            var rootAttribute = doc?.Root?.Name.LocalName;
            var serializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(rootAttribute));
            using StringReader reader = new StringReader(inputXml);
            return (T[])serializer.Deserialize(reader);
        }

}
}
