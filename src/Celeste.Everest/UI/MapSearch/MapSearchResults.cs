using System;
using System.Collections.Generic;
using System.Linq;

namespace Celeste.Everest.UI.MapSearch
{
    public sealed class MapSearchResults
    {
        public string Search;
        public MapSearchOrigin Origin;

        public readonly List<MapSearchItem> Items = new List<MapSearchItem>();

        // ItemCount counts buttons; MatchCount counts exact cleaned names before
        // the mode/parent/unlock filters. Items also contains subheaders.
        public int ItemCount, MatchCount;

        public bool QuickMatched;

        // The result-count subheader starts at right-menu index 0. Exact matches
        // use Insert(0/1), moving that persistent subheader behind the prefix.
        public int ResultHeaderIndex;
        public bool FromChapterSelect => Origin == MapSearchOrigin.ChapterSelect;
        public int InitialSelection => ItemCount > 0 ? 1 : 0;
        public int ResultsPaneSelection => QuickMatched ? 1 : 2;
        public bool CanSwitchToResults => Items.Count > 1;
        public bool EnterMayInspectFirst => Items.Count == 2 || MatchCount == 1;
    }
}
