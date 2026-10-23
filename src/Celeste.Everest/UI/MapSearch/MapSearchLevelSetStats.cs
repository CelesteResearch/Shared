using System;
using System.Collections.Generic;
using System.Linq;

namespace Celeste.Everest.UI.MapSearch
{
    public struct MapSearchLevelSetStats
    {
        public int AreaOffset, UnlockedAreas;

        public MapSearchLevelSetStats(int areaOffset, int unlockedAreas)
        {
            AreaOffset = areaOffset;
            UnlockedAreas = unlockedAreas;
        }
    }
}
