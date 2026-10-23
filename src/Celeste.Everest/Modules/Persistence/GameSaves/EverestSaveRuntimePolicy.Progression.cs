using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public int GetUnlockedModes(OriginalSaveDataState save)
        {
            if (save.DebugMode || save.CheatMode) return 3;
            return GetLevelSetUnlockedModes(GetLevelSetStats(save));
        }

        public int GetLevelSetUnlockedModes(OriginalLevelSetStats set)
        {
            int offset = set.AreaOffset;
            bool allComplete = true;
            for (int i = 0; i <= set.MaxArea; i++)
            {
                var area = registry.Areas[offset + i];
                if (area.HasMode(1))
                {
                    var mode = set.AreasIncludingCeleste[i].Modes[1];
                    bool interlude = IsInterlude(area);
                    bool detectedHeart = area.GetOriginalMode(1).MapData.DetectedHeartGem;
                    bool heart = mode.HeartGem;
                    bool completed = mode.Completed;
                    if (!interlude && !(detectedHeart ? heart : completed)) allComplete = false;
                }
            }

            if (allComplete) return 3;
            for (int i = 0; i <= set.MaxArea; i++)
                if (!IsInterlude(registry.Areas[offset + i]) && set.AreasIncludingCeleste[i].Cassette)
                    return 2;
            return 1;
        }

        public int GetMaxArea(OriginalSaveDataState save)
        {
            var set = GetLevelSetStats(save);
            return unchecked(set.AreaOffset + set.MaxArea);
        }

        public int GetUnlockedAreasSafe(OriginalSaveDataState save)
        {
            if (GetLevelSetStats(save).Name == "Celeste") return save.UnlockedAreas;
            var set = GetLevelSetStats(save);
            return unchecked(set.AreaOffset + set.UnlockedAreas);
        }

        public void SetUnlockedAreasSafe(OriginalSaveDataState save, int value)
        {
            if (save.LevelSets == null || GetLevelSetStats(save).Name == "Celeste")
            {
                save.UnlockedAreas = value;
                return;
            }

            var set = GetLevelSetStats(save);
            set.UnlockedAreas = unchecked(value - set.AreaOffset);
        }
    }
}
