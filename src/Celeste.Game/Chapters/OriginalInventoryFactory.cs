using System;
using System.Collections.Generic;
using Celeste.Simulation.Gameplay.Player.Inventory;

namespace Celeste.Game.Chapters
{
    public static class OriginalInventoryFactory
    {
        public static readonly RoomPlayerInventory Prologue =
            new(0, false);

        public static readonly RoomPlayerInventory Default =
            new(1);

        public static readonly RoomPlayerInventory OldSite =
            new(1, false);

        public static readonly RoomPlayerInventory CH6End = new(2);

        public static readonly RoomPlayerInventory TheSummit =
            new(2, true,
                false);

        public static readonly RoomPlayerInventory Core =
            new(2, true,
                true, true);

        public static readonly RoomPlayerInventory Farewell =
            new(1, true,
                false);

        private static readonly
            Dictionary<string, RoomPlayerInventory> Maps =
                BuildMaps();

        public static RoomPlayerInventory CreateForMap(
            string mapPackage, string checkpoint = null)
        {
            if (!Maps.TryGetValue(mapPackage, out var inventory))
                throw new ArgumentException("Unknown original map package: " + mapPackage, nameof(mapPackage));
            // AreaData.GetCheckpointInventory uses an exact room-name match and otherwise the mode inventory.
            if (mapPackage == "2-OldSite" && checkpoint == "3") return Default;
            if (mapPackage == "6-Reflection" && checkpoint == "after-00") return CH6End;
            return inventory;
        }

        private static Dictionary<string, RoomPlayerInventory>
            BuildMaps()
        {
            var maps =
                new Dictionary<string, RoomPlayerInventory>(
                    StringComparer.Ordinal)
                {
                    { "0-Intro", Prologue }, { "8-Epilogue", TheSummit }, { "LostLevels", Farewell },
                };
            AddChapter(maps, 1, "ForsakenCity", Default, Default);
            AddChapter(maps, 2, "OldSite", OldSite, Default);
            AddChapter(maps, 3, "CelestialResort", Default, Default);
            AddChapter(maps, 4, "GoldenRidge", Default, Default);
            AddChapter(maps, 5, "MirrorTemple", Default, Default);
            AddChapter(maps, 6, "Reflection", Default, Default);
            AddChapter(maps, 7, "Summit", TheSummit, TheSummit);
            AddChapter(maps, 9, "Core", Core, Core);
            return maps;
        }

        private static void AddChapter(
            Dictionary<string, RoomPlayerInventory> maps, int id,
            string name,
            RoomPlayerInventory normal,
            RoomPlayerInventory sides)
        {
            maps.Add(id + "-" + name, normal);
            maps.Add(id + "H-" + name, sides);
            maps.Add(id + "X-" + name, sides);
        }
    }
}
