using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Celeste.Formats.Settings
{
    public enum FileRumble
    {
        [XmlEnum("false")] Off,
        Half,
        [XmlEnum("true")] On
    }
}
