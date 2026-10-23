using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    public sealed class AreaStats
    {
        [XmlAttribute] public int ID;
        [XmlAttribute] public bool Cassette;
        public AreaModeStats[] Modes;
        [XmlAttribute] public string SID;
    }
}
