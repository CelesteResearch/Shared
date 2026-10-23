using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    public sealed class EntityID
    {
        [XmlAttribute] public string Key;
    }
}
