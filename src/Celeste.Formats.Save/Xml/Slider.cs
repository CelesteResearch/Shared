using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    public sealed class Slider
    {
        [XmlAttribute] public string Name;
        [XmlAttribute] public float Value;
    }
}
