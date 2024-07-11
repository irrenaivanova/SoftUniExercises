using CarDealer.DTOs.Export;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.Utilities
{
    public class XMLHelper
    {

        public string Serialize<T> (T obj, string rootAtt)
        {
            StringBuilder sb = new StringBuilder();
            var ser = new XmlSerializer(typeof(T), new XmlRootAttribute(rootAtt));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            ser.Serialize(writer, obj, ns);

            return sb.ToString().TrimEnd();
        }

    }
}
