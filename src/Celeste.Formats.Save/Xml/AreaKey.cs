using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    public sealed class AreaKey
    {
        [XmlAttribute] public int ID;
        [XmlAttribute] public AreaMode Mode;
        [XmlAttribute] public string SID;
    }
}
