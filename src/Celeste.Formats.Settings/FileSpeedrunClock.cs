using System.Xml.Serialization;

namespace Celeste.Formats.Settings
{
    public enum FileSpeedrunClock
    {
        [XmlEnum("false")] Off,
        [XmlEnum("true")] Chapter,
        File,
    }
}
