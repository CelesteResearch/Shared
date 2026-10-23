using System.Linq;
using Celeste.Game.Save.Data;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy : IInstalledLevelSetStatsQueries
    {
        public int GetCompletionPercent(OriginalLevelSetStats stats)
        {
            return stats.CompletionPercent;
        }

        public int GetTotalGoldenStrawberries(OriginalLevelSetStats stats)
        {
            var areaOffset = stats.AreaOffset;
            var num = 0;
            for (var i = 0; i <= stats.MaxArea; i++)
            {
                var areaStats =
                    !(stats.Name == "Celeste") ? stats.Areas[i] : stats.SaveData.Areas[i];
                var areaData = registry.Areas[areaOffset + i];
                for (var j = 0; j < areaData.Mode.Length && j < areaStats.Modes.Length; j++)
                {
                    var areaModeStats = areaStats.Modes[j];
                    var modeProperties = areaData.Mode[j];
                    if (areaModeStats == null || modeProperties == null) continue;

                    foreach (var strawb in areaModeStats.Strawberries)
                    {
                        if (modeProperties.MapData.Goldenberries.Any(berry =>
                                berry.ID == strawb.ID && berry.Level.Name == strawb.Level))
                            num++;

                        if (modeProperties.MapData.DashlessGoldenberries.Any(berry =>
                                berry.ID == strawb.ID && berry.Level.Name == strawb.Level))
                            num++;
                    }
                }
            }

            return num;
        }

        public int GetMaxStrawberries(OriginalLevelSetStats stats)
        {
            if (stats.Name == "Celeste") return 175;

            var areaOffset = stats.AreaOffset;
            var num = 0;
            for (var i = 0; i <= stats.MaxArea; i++)
            {
                var mode = registry.Areas[areaOffset + i].Mode;
                foreach (var modeProperties in mode)
                    if (modeProperties?.MapData != null && modeProperties.MapData.Area.Mode <= 2)
                        num += modeProperties.MapData.DetectedStrawberries;
            }

            return num;
        }

        public int GetMaxStrawberriesIncludingUntracked(OriginalLevelSetStats stats)
        {
            if (stats.Name == "Celeste") return 202;

            var areaOffset = stats.AreaOffset;
            var num = 0;
            for (var i = 0; i <= stats.MaxArea; i++)
            {
                var mode = registry.Areas[areaOffset + i].Mode;
                foreach (var modeProperties in mode)
                    if (modeProperties != null)
                        num += modeProperties.MapData.DetectedStrawberriesIncludingUntracked;
            }

            return num;
        }

        public int GetMaxGoldenStrawberries(OriginalLevelSetStats stats)
        {
            if (stats.Name == "Celeste") return 25;

            var areaOffset = stats.AreaOffset;
            var num = 0;
            for (var i = 0; i <= stats.MaxArea; i++)
            {
                var mode = registry.Areas[areaOffset + i].Mode;
                foreach (var modeProperties in mode)
                    if (modeProperties != null)
                    {
                        num += modeProperties.MapData.Goldenberries.Count;
                        num += modeProperties.MapData.DashlessGoldenberries.Count;
                    }
            }

            return num;
        }

        public int GetMaxCassettes(OriginalLevelSetStats stats)
        {
            if (stats.Name == "Celeste") return 8;

            var areaOffset = stats.AreaOffset;
            var num = 0;
            for (var i = 0; i <= stats.MaxArea; i++)
            {
                var mode = registry.Areas[areaOffset + i].Mode;
                foreach (var modeProperties in mode)
                    if (modeProperties != null && modeProperties.MapData.DetectedCassette)
                        num++;
            }

            return num;
        }

        public int GetTotalHeartGems(OriginalLevelSetStats stats)
        {
            return stats.TotalHeartGems;
        }

        public int GetMaxHeartGems(OriginalLevelSetStats stats)
        {
            if (stats.Name == "Celeste") return 24;

            var areaOffset = stats.AreaOffset;
            var num = 0;
            for (var i = 0; i <= stats.MaxArea; i++)
            {
                var mode = registry.Areas[areaOffset + i].Mode;
                foreach (var modeProperties in mode)
                    if (modeProperties?.MapData != null && modeProperties.MapData.Area.Mode <= 2)
                        num += modeProperties.MapData.DetectedHeartGem ? 1 : 0;
            }

            return num;
        }

        public int GetMaxHeartGemsExcludingCSides(OriginalLevelSetStats stats)
        {
            if (stats.Name == "Celeste") return 16;

            var areaOffset = stats.AreaOffset;
            var num = 0;
            for (var i = 0; i <= stats.MaxArea; i++)
            {
                var areaData = registry.Areas[areaOffset + i];
                for (var j = 0; j < 2 && j < areaData.Mode.Length; j++)
                {
                    var obj = areaData.Mode[j];
                    if (obj != null && obj.MapData.DetectedHeartGem) num++;
                }
            }

            return num;
        }

        public int GetMaxCompletions(OriginalLevelSetStats stats)
        {
            return stats.Name == "Celeste"
                ? 9
                : registry.Areas.Count(area => area.LevelSet == stats.Name && !IsInterlude(area));
        }

        public int GetTotalCassettes(OriginalLevelSetStats stats)
        {
            var areaOffset = stats.AreaOffset;
            var num = 0;
            for (var i = 0; i <= stats.MaxArea; i++)
                if (!IsInterlude(registry.Areas[areaOffset + i]) && stats.AreasIncludingCeleste[i].Cassette)
                    num++;

            return num;
        }

        public int GetTotalCompletions(OriginalLevelSetStats stats)
        {
            var areaOffset = stats.AreaOffset;
            var num = 0;
            for (var i = 0; i <= stats.MaxArea; i++)
                if (!IsInterlude(registry.Areas[areaOffset + i]) && stats.AreasIncludingCeleste[i].Modes[0].Completed)
                    num++;

            return num;
        }
    }
}
