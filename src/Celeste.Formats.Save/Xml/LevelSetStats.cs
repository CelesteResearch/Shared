using System.Collections.Generic;
using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    public sealed class LevelSetStats
    {
        [XmlAttribute] public string Name;
        public List<AreaStats> Areas = [];
        public List<string> Poem = [];
        public int UnlockedAreas, TotalStrawberries;
    }
}
