using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public int GetUnlockedModes(OriginalSaveDataState save)
        {
            if (save.DebugMode || save.CheatMode) return 3;
            if (TotalHeartGems(save) >= 16) return 3;
            for (int i = 1; i <= GetMaxArea(save); i++)
                if (save.Areas[i].Cassette)
                    return 2;
            return 1;
        }

        public int GetMaxArea(OriginalSaveDataState save) =>
            environment.EventMode ? 2 : unchecked(areas.Areas.Count - 1);

        public int GetUnlockedAreasSafe(OriginalSaveDataState save) => save.UnlockedAreas;
        public void SetUnlockedAreasSafe(OriginalSaveDataState save, int value) => save.UnlockedAreas = value;
    }
}
