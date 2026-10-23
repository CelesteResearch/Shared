using Celeste.Simulation.Audio;
using Celeste.Core.Maps;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;
using Celeste.Simulation;

namespace Celeste.Simulation.Runtime.Session.Maps
{
    public sealed class ChapterSessionMap
    {
        public global::Celeste.Core.Campaigns.CampaignAreaKey Area;
        public MapDocument Map;
        public IChapterSessionMapData SourceData;
        public IChapterSessionAreaData Data => SourceData.Data;
        public IChapterSessionModeData ModeData => SourceData.ModeData;
        public string ColorGrade;
        public bool Dreaming;
        public global::Celeste.Simulation.Gameplay.Environment.Core.RoomCoreMode CoreMode;
        public global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory Inventory;
        public RoomAudioState Audio;
        public int DetectedStrawberries;
        public int DetectedStrawberriesIncludingUntracked;
        public bool DetectedCassette;
        public global::Celeste.Simulation.Runtime.Session.Maps.ChapterSessionCheckpoint[] Checkpoints;

        public global::Celeste.Simulation.Runtime.Session.Maps.ChapterSessionCheckpoint GetCheckpoint(string level)
        {
            if (level != null && Checkpoints != null)
                foreach (var checkpoint in Checkpoints)
                    if (checkpoint.Level.Equals(level))
                        return checkpoint;
            return null;
        }

        public IChapterSessionLevelData Get(string level) => SourceData.GetLevel(level);
        public IChapterSessionLevelData StartLevel() => SourceData.StartLevel();
    }
}
