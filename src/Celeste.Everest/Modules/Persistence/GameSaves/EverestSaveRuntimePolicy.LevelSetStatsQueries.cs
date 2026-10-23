using System.Linq;
using Celeste.Game.Save.Data;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Simulation.Save.Progress;
using Celeste.Core.Maps;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy : IInstalledLevelSetStatsQueries
    {
        public int GetCompletionPercent(OriginalLevelSetStats stats) => stats.CompletionPercent;

        public int GetTotalGoldenStrawberries(OriginalLevelSetStats stats)
        {
            int areaOffset = stats.AreaOffset;
            int num = 0;
            for (int i = 0; i <= stats.MaxArea; i++)
            {
                ChapterAreaProgress areaStats =
                    ((!(stats.Name == "Celeste")) ? stats.Areas[i] : stats.SaveData.Areas[i]);
                IOriginalAreaData areaData = registry.Areas[areaOffset + i];
                for (int j = 0; j < areaData.Mode.Length && j < areaStats.Modes.Length; j++)
                {
                    ChapterModeProgress areaModeStats = areaStats.Modes[j];
                    OriginalAreaModeData modeProperties = areaData.Mode[j];
                    if (areaModeStats == null || modeProperties == null)
                    {
                        continue;
                    }

                    foreach (MapEntityId strawb in areaModeStats.Strawberries)
                    {
                        if (modeProperties.MapData.Goldenberries.Any((OriginalLevelEntityData berry) =>
                                berry.ID == strawb.ID && berry.Level.Name == strawb.Level))
                        {
                            num++;
                        }

                        if (modeProperties.MapData.DashlessGoldenberries.Any((OriginalLevelEntityData berry) =>
                                berry.ID == strawb.ID && berry.Level.Name == strawb.Level))
                        {
                            num++;
                        }
                    }
                }
            }

            return num;
        }

        public int GetMaxStrawberries(OriginalLevelSetStats stats)
        {
            if (stats.Name == "Celeste")
            {
                return 175;
            }

            int areaOffset = stats.AreaOffset;
            int num = 0;
            for (int i = 0; i <= stats.MaxArea; i++)
            {
                OriginalAreaModeData[] mode = registry.Areas[areaOffset + i].Mode;
                foreach (OriginalAreaModeData modeProperties in mode)
                {
                    if (modeProperties?.MapData != null && modeProperties.MapData.Area.Mode <= 2)
                    {
                        num += modeProperties.MapData.DetectedStrawberries;
                    }
                }
            }

            return num;
        }

        public int GetMaxStrawberriesIncludingUntracked(OriginalLevelSetStats stats)
        {
            if (stats.Name == "Celeste")
            {
                return 202;
            }

            int areaOffset = stats.AreaOffset;
            int num = 0;
            for (int i = 0; i <= stats.MaxArea; i++)
            {
                OriginalAreaModeData[] mode = registry.Areas[areaOffset + i].Mode;
                foreach (OriginalAreaModeData modeProperties in mode)
                {
                    if (modeProperties != null)
                    {
                        num += modeProperties.MapData.DetectedStrawberriesIncludingUntracked;
                    }
                }
            }

            return num;
        }

        public int GetMaxGoldenStrawberries(OriginalLevelSetStats stats)
        {
            if (stats.Name == "Celeste")
            {
                return 25;
            }

            int areaOffset = stats.AreaOffset;
            int num = 0;
            for (int i = 0; i <= stats.MaxArea; i++)
            {
                OriginalAreaModeData[] mode = registry.Areas[areaOffset + i].Mode;
                foreach (OriginalAreaModeData modeProperties in mode)
                {
                    if (modeProperties != null)
                    {
                        num += modeProperties.MapData.Goldenberries.Count;
                        num += modeProperties.MapData.DashlessGoldenberries.Count;
                    }
                }
            }

            return num;
        }

        public int GetMaxCassettes(OriginalLevelSetStats stats)
        {
            if (stats.Name == "Celeste")
            {
                return 8;
            }

            int areaOffset = stats.AreaOffset;
            int num = 0;
            for (int i = 0; i <= stats.MaxArea; i++)
            {
                OriginalAreaModeData[] mode = registry.Areas[areaOffset + i].Mode;
                foreach (OriginalAreaModeData modeProperties in mode)
                {
                    if (modeProperties != null && modeProperties.MapData.DetectedCassette)
                    {
                        num++;
                    }
                }
            }

            return num;
        }

        public int GetTotalHeartGems(OriginalLevelSetStats stats) => stats.TotalHeartGems;

        public int GetMaxHeartGems(OriginalLevelSetStats stats)
        {
            if (stats.Name == "Celeste")
            {
                return 24;
            }

            int areaOffset = stats.AreaOffset;
            int num = 0;
            for (int i = 0; i <= stats.MaxArea; i++)
            {
                OriginalAreaModeData[] mode = registry.Areas[areaOffset + i].Mode;
                foreach (OriginalAreaModeData modeProperties in mode)
                {
                    if (modeProperties?.MapData != null && modeProperties.MapData.Area.Mode <= 2)
                    {
                        num += (modeProperties.MapData.DetectedHeartGem ? 1 : 0);
                    }
                }
            }

            return num;
        }

        public int GetMaxHeartGemsExcludingCSides(OriginalLevelSetStats stats)
        {
            if (stats.Name == "Celeste")
            {
                return 16;
            }

            int areaOffset = stats.AreaOffset;
            int num = 0;
            for (int i = 0; i <= stats.MaxArea; i++)
            {
                IOriginalAreaData areaData = registry.Areas[areaOffset + i];
                for (int j = 0; j < 2 && j < areaData.Mode.Length; j++)
                {
                    OriginalAreaModeData obj = areaData.Mode[j];
                    if (obj != null && obj.MapData.DetectedHeartGem)
                    {
                        num++;
                    }
                }
            }

            return num;
        }

        public int GetMaxCompletions(OriginalLevelSetStats stats)
        {
            if (stats.Name == "Celeste")
            {
                return 9;
            }

            return registry.Areas.Count((IOriginalAreaData area) => area.LevelSet == stats.Name && !IsInterlude(area));
        }

        public int GetTotalCassettes(OriginalLevelSetStats stats)
        {
            int areaOffset = stats.AreaOffset;
            int num = 0;
            for (int i = 0; i <= stats.MaxArea; i++)
            {
                if (!IsInterlude(registry.Areas[areaOffset + i]) && stats.AreasIncludingCeleste[i].Cassette)
                {
                    num++;
                }
            }

            return num;
        }

        public int GetTotalCompletions(OriginalLevelSetStats stats)
        {
            int areaOffset = stats.AreaOffset;
            int num = 0;
            for (int i = 0; i <= stats.MaxArea; i++)
            {
                if (!IsInterlude(registry.Areas[areaOffset + i]) && stats.AreasIncludingCeleste[i].Modes[0].Completed)
                {
                    num++;
                }
            }

            return num;
        }
    }
}
