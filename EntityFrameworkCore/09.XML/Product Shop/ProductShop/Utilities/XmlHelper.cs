using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop.Utilities
{
    public class XmlHelper
    {
        public T[] Deserialize<T> (string inputxml)
        {
            var doc = XDocument.Parse(inputxml);
            var root = doc.Root.Name.LocalName.ToString();
            var xml = new XmlSerializer(typeof(T[]), new XmlRootAttribute(root));
            using var reader = new StringReader(inputxml);
            return (T[])xml.Deserialize(reader);
        }

        public string Serialize<T>(T[] obj, string root)
        
        { 
            StringBuilder sb = new StringBuilder();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            var xml = new XmlSerializer(typeof(T[]), new XmlRootAttribute(root));
            using var writer = new StringWriter(sb);
            xml.Serialize(writer, obj, ns);

            return sb.ToString();
        }


        public string Serialize<T>(T obj, string root)

        {
            StringBuilder sb = new StringBuilder();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            var xml = new XmlSerializer(typeof(T), new XmlRootAttribute(root));
            using var writer = new StringWriter(sb);
            xml.Serialize(writer, obj, ns);

            return sb.ToString();
        }
    }
}
