using System.IO;
using System.Xml;

namespace Celeste.Core.Serialization.Xml
{
    public static class SourceXmlDocuments
    {
        public static XmlDocument LoadXml(string filename)
        {
            var document = new XmlDocument();
            using var input = File.OpenRead(filename);
            document.Load(input);
            return document;
        }
    }
}
