using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    public sealed class PlayerInventory
    {
        public int Dashes;
        public bool DreamDash, Backpack, NoRefills;
    }
}
