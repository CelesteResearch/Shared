using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Save.Data
{
// Same actual object owns inherited plain serialization fields and source runtime fields.
    public class OriginalLevelSetStats : ChapterLevelSetStats
    {
        [IgnoreDataMember] public OriginalSaveDataState SaveData;
        [IgnoreDataMember] public int MaxArea;
        [IgnoreDataMember] public int MaxAssistArea => MaxArea;

        public new int TotalStrawberries
        {
            get
            {
                if (Name == "Celeste" && SaveData != null) return SaveData.TotalStrawberries;
                return base.TotalStrawberries;
            }
            set
            {
                if (Name == "Celeste" && SaveData != null) SaveData.TotalStrawberries = value;
                else base.TotalStrawberries = value;
            }
        }

        public new int UnlockedAreas
        {
            get
            {
                if (Name == "Celeste" && SaveData != null) return SaveData.UnlockedAreas;
                if (string.IsNullOrEmpty(Name)) return MaxArea;
                int value = base.UnlockedAreas;
                int count = AreasIncludingCeleste?.Count ?? 0;
                if (value < 0) value = 0;
                if (value > count) value = count;
                return value;
            }
            set
            {
                if (Name == "Celeste" && SaveData != null) SaveData.UnlockedAreas = value;
                else base.UnlockedAreas = value;
            }
        }

        public List<ChapterAreaProgress> AreasIncludingCeleste => Name == "Celeste" ? SaveData.Areas : Areas;

        // The save owns the same installed policy that reads the canonical area registry.
        // These accessors never create a second stats store or recalculate from a port mirror.
        [IgnoreDataMember]
        public int TotalGoldenStrawberries => SaveData.LevelSetStatsQueries.GetTotalGoldenStrawberries(this);

        [IgnoreDataMember]
        public int MaxStrawberries => Name == "Celeste" ? 175 : SaveData.LevelSetStatsQueries.GetMaxStrawberries(this);

        [IgnoreDataMember]
        public int MaxGoldenStrawberries =>
            Name == "Celeste" ? 25 : SaveData.LevelSetStatsQueries.GetMaxGoldenStrawberries(this);

        [IgnoreDataMember]
        public int MaxStrawberriesIncludingUntracked => Name == "Celeste"
            ? 202
            : SaveData.LevelSetStatsQueries.GetMaxStrawberriesIncludingUntracked(this);

        [IgnoreDataMember]
        public int MaxCassettes => Name == "Celeste" ? 8 : SaveData.LevelSetStatsQueries.GetMaxCassettes(this);

        [IgnoreDataMember]
        public int MaxHeartGems => Name == "Celeste" ? 24 : SaveData.LevelSetStatsQueries.GetMaxHeartGems(this);

        [IgnoreDataMember]
        public int MaxHeartGemsExcludingCSides =>
            Name == "Celeste" ? 16 : SaveData.LevelSetStatsQueries.GetMaxHeartGemsExcludingCSides(this);

        [IgnoreDataMember]
        public int MaxCompletions => Name == "Celeste" ? 9 : SaveData.LevelSetStatsQueries.GetMaxCompletions(this);

        [IgnoreDataMember] public int TotalCassettes => SaveData.LevelSetStatsQueries.GetTotalCassettes(this);

        [IgnoreDataMember]
        public int TotalHeartGems =>
            AreasIncludingCeleste.Sum(area => area.Modes.Count(mode => mode?.HeartGem ?? false));

        [IgnoreDataMember] public int TotalCompletions => SaveData.LevelSetStatsQueries.GetTotalCompletions(this);

        [IgnoreDataMember]
        public int CompletionPercent => (int)(0f +
                                              ((MaxHeartGems == 0)
                                                  ? 1f
                                                  : ((float)TotalHeartGems / (float)MaxHeartGems)) *
                                              24f + ((MaxStrawberries == 0)
                                                  ? 1f
                                                  : ((float)TotalStrawberries / (float)MaxStrawberries)) * 55f +
                                              ((MaxCassettes == 0)
                                                  ? 1f
                                                  : ((float)TotalCassettes / (float)MaxCassettes)) *
                                              7f + ((MaxCompletions == 0)
                                                  ? 1f
                                                  : ((float)TotalCompletions / (float)MaxCompletions)) * 14f);

        [IgnoreDataMember] public int UnlockedModes => SaveData.LevelSetStatsQueries.GetLevelSetUnlockedModes(this);

        [IgnoreDataMember]
        public int MaxAreaMode => Name == "Celeste" ? 2 : SaveData.LevelSetStatsQueries.GetMaxAreaMode(this);

        internal void ComputeBounds() => SaveData.LevelSetStatsQueries.ComputeBounds(this);
    }
}
