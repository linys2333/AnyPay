using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace AnyPay.Common
{
    public static class SerializeExt
    {
        public static string ToXml(this IDictionary<string, string> dict)
        {
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            var xmlBuilder = new StringBuilder();
            using (var writer = XmlWriter.Create(xmlBuilder, settings))
            {
                writer.WriteStartElement("xml");
                foreach (var item in dict)
                {
                    writer.WriteElementString(item.Key, item.Value);
                }
                writer.WriteEndElement();
                writer.Flush();
            }

            return xmlBuilder.ToString();
        }

        public static SortedDictionary<string, string> ToSortDict(this string xml)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);

            var result = new SortedDictionary<string, string>();
            if (xmlDocument.FirstChild != null)
            {
                foreach (XmlNode item in xmlDocument.FirstChild.ChildNodes)
                {
                    result.Add(item.Name, item.InnerText);
                }
            }

            return result;
        }
    }
}
