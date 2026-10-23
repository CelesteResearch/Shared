using System.IO;
using System.Xml;
using Celeste.Core.Serialization.Xml;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Text;

namespace Celeste.Everest.Content.Xml
{
    public sealed class EverestXmlDocumentLoadingPolicy : ISourceXmlDocumentLoadingPolicy
    {
        private readonly EverestContentRegistry content;

        public EverestXmlDocumentLoadingPolicy(EverestContentRegistry content)
        {
            this.content = content;
        }

        public XmlDocument Load(string filename)
        {
            if (content.TryGet<AssetTypeXml>(filename.Substring(0, filename.Length - 4), out var metadata))
            {
                XmlDocument xmlDocument = new XmlDocument();
                using Stream inStream = metadata.Stream;
                xmlDocument.Load(inStream);
                return xmlDocument;
            }

            if (File.Exists(filename))
                return SourceXmlDocumentLoader.Load(filename);
            return new XmlDocument();
        }
    }
}
