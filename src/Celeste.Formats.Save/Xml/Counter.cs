using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    public sealed class Counter
    {
        [XmlAttribute("key")] public string Key;
        [XmlAttribute("value")] public int Value;
    }
}
