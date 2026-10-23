using System.Collections.Generic;
using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    public sealed class AudioTrackState
    {
        [XmlAttribute] public string Event;
        public List<MEP> Parameters = [];
    }
}
