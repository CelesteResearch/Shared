using System.Xml;

namespace Celeste.Core.Serialization.Xml
{
    public interface ISourceXmlDocumentLoadingPolicy
    {
        XmlDocument Load(string filename);
    }
}
