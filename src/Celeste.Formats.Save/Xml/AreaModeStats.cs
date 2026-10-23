using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    public sealed class AreaModeStats
    {
        [XmlAttribute] public int TotalStrawberries;
        [XmlAttribute] public bool Completed, SingleRunCompleted, FullClear;
        [XmlAttribute] public int Deaths;
        [XmlAttribute] public long TimePlayed, BestTime, BestFullClearTime;
        [XmlAttribute] public int BestDashes, BestDeaths;
        [XmlAttribute] public bool HeartGem;
        public List<EntityID> Strawberries = new List<EntityID>();
        public List<string> Checkpoints = new List<string>();
    }
}
