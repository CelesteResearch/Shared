using System.IO;
using System.Xml;

namespace Celeste.Core.Serialization.Xml
{
    public static class SourceXmlDocuments
    {
        public static XmlDocument LoadXml(string filename)
        {
            XmlDocument document = new XmlDocument();
            using FileStream input = File.OpenRead(filename);
            document.Load(input);
            return document;
        }
    }
}
