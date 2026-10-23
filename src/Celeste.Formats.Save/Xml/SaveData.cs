using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    [XmlRoot("SaveData")]
    public sealed class SaveData
    {
        public string Version, Name = "Madeline";
        public long Time;
        public DateTime LastSave;
        public bool CheatMode, AssistMode, VariantMode;
        public Assists Assists = new();
        public string TheoSisterName;

        public int UnlockedAreas,
            TotalDeaths,
            TotalStrawberries,
            TotalGoldenStrawberries,
            TotalJumps,
            TotalWallJumps,
            TotalDashes;

        public List<string> Flags = [], Poem = [];
        public bool[] SummitGems;
        public bool RevealedChapter9;
        public AreaKey LastArea;
        public Session CurrentSession;
        public List<AreaStats> Areas = [];

        public List<LevelSetStats> LevelSets = [],
            LevelSetRecycleBin = [];

        public bool HasModdedSaveData;
        public AreaKey LastArea_Safe;
        public Session CurrentSession_Safe;
    }
}
