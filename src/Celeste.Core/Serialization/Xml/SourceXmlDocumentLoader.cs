using System.IO;
using System.Xml;

namespace Celeste.Core.Serialization.Xml
{
    public static class SourceXmlDocumentLoader
    {
        public static XmlDocument Load(string filename)
        {
            var xmlDocument = new XmlDocument();
            using var inStream = File.OpenRead(filename);
            xmlDocument.Load(inStream);
            return xmlDocument;
        }
    }
}
