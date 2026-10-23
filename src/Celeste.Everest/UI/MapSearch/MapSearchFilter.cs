using System;
using System.Collections.Generic;
using System.Linq;

namespace Celeste.Everest.UI.MapSearch
{
    // The installed Everest OuiMapSearch.ReloadItems projection. Callers provide
    // the active dialog strings and SaveData LevelSetStats; no engine APIs live here.
    public static class MapSearchFilter
    {
        public static MapSearchResults Build(IReadOnlyList<MapSearchArea> areas, string search,
            bool debugMode, Func<string, MapSearchLevelSetStats> levelSetStats,
            MapSearchOrigin origin = MapSearchOrigin.ChapterSelect,
            string perfectMatchTitle = null)
        {
            if (areas == null) throw new ArgumentNullException(nameof(areas));
            if (search == null) throw new ArgumentNullException(nameof(search));
            if (levelSetStats == null) throw new ArgumentNullException(nameof(levelSetStats));
            var result = new MapSearchResults { Search = search, Origin = origin };
            var loweredSearch = search.ToLower();
            var hunks = search.Split(' ').Select(hunk => hunk.ToLower()).ToArray();
            for (var i = 0; i < areas.Count; i++)
                if (areas[i].DisplayName.ToLower() == loweredSearch)
                    result.MatchCount++;

            string currentSet = null;
            int offset = 0, unlocked = int.MaxValue;
            var hasExact = false;
            for (var i = 0; i < areas.Count; i++)
            {
                var area = areas[i];
                if (area == null || !area.HasNormalMode || (!debugMode && !string.IsNullOrEmpty(area.Parent))) continue;
                var levelSet = area.LevelSet;
                if (levelSet == "Celeste" && i > unchecked(offset + unlocked)) continue;
                string[] fields =
                [
                    area.Name.ToLower(), area.DisplayName.ToLower(),
                    levelSet.ToLower(), area.DisplayLevelSet.ToLower(),
                ];
                if (hunks.Any(hunk => !fields.Any(field => field.Contains(hunk)))) continue;

                result.ItemCount++;
                var button = new MapSearchItem
                {
                    Kind = MapSearchItemKind.Area,
                    AreaID = area.ID, LevelSet = levelSet, Title = area.DisplayName,
                    Icon = area.Icon == "areas/null" ? null : area.Icon,
                };
                // The source's second lock branch is unreachable: the same test
                // above already continued before this button was made.
                if (area.DisplayName.ToLower() == loweredSearch)
                {
                    if (!hasExact)
                    {
                        result.Items.Insert(0, new()
                        {
                            Kind = MapSearchItemKind.PerfectMatchHeader, Title = perfectMatchTitle,
                        });
                        result.ResultHeaderIndex++;
                        hasExact = true;
                    }

                    result.Items.Insert(1, button);
                    result.ResultHeaderIndex++;
                    if (result.MatchCount > 1)
                    {
                        currentSet = levelSet;
                        var stats = levelSetStats(levelSet);
                        offset = stats.AreaOffset;
                        unlocked = stats.UnlockedAreas;
                        result.Items.Insert(1, new()
                        {
                            Kind = MapSearchItemKind.LevelSetHeader,
                            LevelSet = levelSet, Title = area.DisplayLevelSet,
                        });
                        result.ResultHeaderIndex++;
                    }
                }
                else
                {
                    if (currentSet != levelSet)
                    {
                        currentSet = levelSet;
                        var stats = levelSetStats(levelSet);
                        offset = stats.AreaOffset;
                        unlocked = stats.UnlockedAreas;
                        result.Items.Add(new()
                        {
                            Kind = MapSearchItemKind.LevelSetHeader,
                            LevelSet = levelSet, Title = area.DisplayLevelSet,
                        });
                    }

                    result.Items.Add(button);
                }
            }

            result.QuickMatched = hasExact;
            return result;
        }
    }
}
