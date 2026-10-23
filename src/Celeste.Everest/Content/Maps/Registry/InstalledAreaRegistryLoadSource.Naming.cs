using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed partial class InstalledAreaRegistryLoadSource
    {
        public EverestMapWipeProcess MapWipes => sourceStatics.Value.MapWipes;

        public void ParseName(string sid, out int? order, out OriginalAreaMode side, out string name)
        {
            sourceStatics.Value.ParseName(sid, out order, out side, out name);
        }

        private int AreaComparison(OriginalAreaData left, OriginalAreaData right)
        {
            var a = (EverestArea)left;
            var b = (EverestArea)right;
            var levelSet = a.LevelSet;
            var sId = a.SID;
            var meta = a.Metadata;
            var levelSet2 = b.LevelSet;
            var sId2 = b.SID;
            var meta2 = b.Metadata;
            if (levelSet == "Celeste" && levelSet2 != "Celeste") return -1;

            if (levelSet != "Celeste" && levelSet2 == "Celeste") return 1;

            if (string.IsNullOrEmpty(levelSet) && !string.IsNullOrEmpty(levelSet2)) return 1;

            if (!string.IsNullOrEmpty(levelSet) && string.IsNullOrEmpty(levelSet2)) return -1;

            if (levelSet != levelSet2) return string.Compare(levelSet, levelSet2);

            if (!string.IsNullOrEmpty(meta?.Parent) && string.IsNullOrEmpty(meta2?.Parent)) return 1;

            if (string.IsNullOrEmpty(meta?.Parent) && !string.IsNullOrEmpty(meta2?.Parent)) return -1;

            ParseName(sId, out var order, out var side, out var name);
            ParseName(sId2, out var order2, out var side2, out var name2);
            if (order.HasValue && !order2.HasValue) return -1;

            if (!order.HasValue && order2.HasValue) return 1;

            if (order.HasValue && order2.HasValue && order.Value != order2.Value) return order.Value - order2.Value;

            if (name != name2) return string.Compare(name, name2);

            if (side != side2) return side - side2;

            return 0;
        }
    }
}
