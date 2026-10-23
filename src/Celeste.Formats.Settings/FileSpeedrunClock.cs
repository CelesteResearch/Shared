using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Celeste.Formats.Settings
{
    public enum FileSpeedrunClock
    {
        [XmlEnum("false")] Off,
        [XmlEnum("true")] Chapter,
        File
    }
}
