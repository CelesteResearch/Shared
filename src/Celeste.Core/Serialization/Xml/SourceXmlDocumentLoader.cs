using System.IO;
using System.Xml;

namespace Celeste.Core.Serialization.Xml
{
    public static class SourceXmlDocumentLoader
    {
        public static XmlDocument Load(string filename)
        {
            XmlDocument xmlDocument = new XmlDocument();
            using FileStream inStream = File.OpenRead(filename);
            xmlDocument.Load(inStream);
            return xmlDocument;
        }
    }
}
