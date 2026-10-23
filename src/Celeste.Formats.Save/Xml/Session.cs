using System.Collections.Generic;
using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    public sealed class Session
    {
        public AreaKey Area = new();
        [XmlElement(IsNullable = true)] public Vector RespawnPoint;
        public AudioState Audio = new();
        public PlayerInventory Inventory = new();
        public List<string> Flags = [], LevelFlags = [];

        public List<EntityID> Strawberries = [],
            DoNotLoad = [],
            Keys = [];

        public List<Counter> Counters = [];
        public bool[] SummitGems = new bool[6];
        public AreaStats OldStats;
        public bool UnlockedCSide;
        public string FurthestSeenLevel;
        public bool BeatBestTime;
        [XmlAttribute] public string Level;
        [XmlAttribute] public long Time;
        [XmlAttribute] public bool StartedFromBeginning;
        [XmlAttribute] public int Deaths, Dashes, DashesAtLevelStart, DeathsInCurrentLevel;
        [XmlAttribute] public bool InArea = true;
        [XmlAttribute] public string StartCheckpoint;
        [XmlAttribute] public bool FirstLevel = true, Cassette, HeartGem, Dreaming;
        [XmlAttribute] public string ColorGrade;
        [XmlAttribute] public float LightingAlphaAdd, BloomBaseAdd, DarkRoomAlpha = .75f;
        [XmlAttribute] public CoreMode CoreMode;
        [XmlAttribute] public bool GrabbedGolden, HitCheckpoint;
        public bool RestartedFromGolden;
        public List<Slider> Sliders = [];
    }
}
