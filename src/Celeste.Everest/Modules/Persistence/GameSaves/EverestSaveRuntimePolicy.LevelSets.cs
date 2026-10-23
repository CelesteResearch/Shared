using Celeste.Game.Save.Data;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public string GetLevelSet(OriginalSaveDataState save)
        {
            return GetLevelSetStats(save).Name;
        }

        public int GetMaxAreaMode(OriginalLevelSetStats actualLevelSet)
        {
            if (actualLevelSet.Name == "Celeste") return 2;
            var offset = actualLevelSet.AreaOffset;
            var maxMode = 0;
            for (var i = 0; i <= actualLevelSet.MaxArea; i++)
            {
                var modes = registry.Areas[unchecked(offset + i)].Mode;
                for (var mode = 0; mode < modes.Length; mode++)
                {
                    var data = modes[mode];
                    if (data != null && data.MapData.Area.Mode > maxMode)
                        maxMode = data.MapData.Area.Mode;
                }
            }

            return maxMode;
        }
    }
}
