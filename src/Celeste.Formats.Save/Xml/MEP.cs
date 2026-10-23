using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    public sealed class MEP
    {
        [XmlAttribute] public string Key;
        [XmlAttribute] public float Value;
    }
}
