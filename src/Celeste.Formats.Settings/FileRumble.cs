using System.Xml.Serialization;

namespace Celeste.Formats.Settings
{
    public enum FileRumble
    {
        [XmlEnum("false")] Off,
        Half,
        [XmlEnum("true")] On,
    }
}
