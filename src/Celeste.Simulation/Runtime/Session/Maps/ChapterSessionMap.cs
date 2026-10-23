using Celeste.Core.Campaigns;
using Celeste.Core.Maps;
using Celeste.Simulation.Audio;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Inventory;

namespace Celeste.Simulation.Runtime.Session.Maps
{
    public sealed class ChapterSessionMap
    {
        public CampaignAreaKey Area;
        public MapDocument Map;
        public IChapterSessionMapData SourceData;
        public IChapterSessionAreaData Data => SourceData.Data;
        public IChapterSessionModeData ModeData => SourceData.ModeData;
        public string ColorGrade;
        public bool Dreaming;
        public RoomCoreMode CoreMode;
        public RoomPlayerInventory Inventory;
        public RoomAudioState Audio;
        public int DetectedStrawberries;
        public int DetectedStrawberriesIncludingUntracked;
        public bool DetectedCassette;
        public ChapterSessionCheckpoint[] Checkpoints;

        public ChapterSessionCheckpoint GetCheckpoint(string level)
        {
            if (level != null && Checkpoints != null)
                foreach (var checkpoint in Checkpoints)
                    if (checkpoint.Level.Equals(level))
                        return checkpoint;
            return null;
        }

        public IChapterSessionLevelData Get(string level)
        {
            return SourceData.GetLevel(level);
        }

        public IChapterSessionLevelData StartLevel()
        {
            return SourceData.StartLevel();
        }
    }
}
