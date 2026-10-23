using System.Xml.Serialization;

namespace Celeste.Game.Controls.Source
{
    public enum RumbleAmount
    {
        [XmlEnum("false")] Off,
        Half,
        [XmlEnum("true")] On
    }
}
