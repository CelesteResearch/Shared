using System.Xml;

namespace Celeste.Core.Serialization.Xml
{
    public interface ISourceOriginalContentXmlEnvironment
    {
        XmlDocument LoadOriginalContentXml(string filename);
    }
}
