using System.Xml.Serialization;

namespace Celeste.Formats.Settings
{
    public enum FileScreenShake
    {
        [XmlEnum("false")] Off,
        [XmlEnum("true")] Half,
        On,
    }
}
