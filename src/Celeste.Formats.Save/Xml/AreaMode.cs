using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    // These are wire models: XML names/order follow Celeste SaveData, not CLR gameplay ownership.
    public enum AreaMode
    {
        Normal,
        BSide,
        CSide
    }
}
