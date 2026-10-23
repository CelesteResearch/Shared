using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Celeste.Game.Execution.Areas;
using Celeste.Everest.Content.Maps.Metadata;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed partial class InstalledAreaRegistryLoadSource
    {
        public EverestMapWipeProcess MapWipes => sourceStatics.Value.MapWipes;

        public void ParseName(string sid, out int? order, out OriginalAreaMode side, out string name)
            => sourceStatics.Value.ParseName(sid, out order, out side, out name);

        private int AreaComparison(OriginalAreaData left, OriginalAreaData right)
        {
            var a = (EverestArea)left;
            var b = (EverestArea)right;
            string levelSet = a.LevelSet;
            string sID = a.SID;
            EverestMapMetadata meta = a.Metadata;
            string levelSet2 = b.LevelSet;
            string sID2 = b.SID;
            EverestMapMetadata meta2 = b.Metadata;
            if (levelSet == "Celeste" && levelSet2 != "Celeste")
            {
                return -1;
            }

            if (levelSet != "Celeste" && levelSet2 == "Celeste")
            {
                return 1;
            }

            if (string.IsNullOrEmpty(levelSet) && !string.IsNullOrEmpty(levelSet2))
            {
                return 1;
            }

            if (!string.IsNullOrEmpty(levelSet) && string.IsNullOrEmpty(levelSet2))
            {
                return -1;
            }

            if (levelSet != levelSet2)
            {
                return string.Compare(levelSet, levelSet2);
            }

            if (!string.IsNullOrEmpty(meta?.Parent) && string.IsNullOrEmpty(meta2?.Parent))
            {
                return 1;
            }

            if (string.IsNullOrEmpty(meta?.Parent) && !string.IsNullOrEmpty(meta2?.Parent))
            {
                return -1;
            }

            ParseName(sID, out var order, out var side, out var name);
            ParseName(sID2, out var order2, out var side2, out var name2);
            if (order.HasValue && !order2.HasValue)
            {
                return -1;
            }

            if (!order.HasValue && order2.HasValue)
            {
                return 1;
            }

            if (order.HasValue && order2.HasValue && order.Value != order2.Value)
            {
                return order.Value - order2.Value;
            }

            if (name != name2)
            {
                return string.Compare(name, name2);
            }

            if (side != side2)
            {
                return side - side2;
            }

            return 0;
        }
    }
}
