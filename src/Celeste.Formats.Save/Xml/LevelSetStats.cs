using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    public sealed class LevelSetStats
    {
        [XmlAttribute] public string Name;
        public List<AreaStats> Areas = new List<AreaStats>();
        public List<string> Poem = new List<string>();
        public int UnlockedAreas, TotalStrawberries;
    }
}
