using System;
using System.Collections.Generic;
using Celeste.Simulation;

namespace Celeste.Game.Chapters
{
    public static class OriginalInventoryFactory
    {
        public static readonly global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory Prologue =
            new global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory(0, dreamDash: false);

        public static readonly global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory Default =
            new global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory(1, true, true, false);

        public static readonly global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory OldSite =
            new global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory(1, dreamDash: false);

        public static readonly global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory CH6End =
            new global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory(2);

        public static readonly global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory TheSummit =
            new global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory(2, dreamDash: true,
                backpack: false);

        public static readonly global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory Core =
            new global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory(2, dreamDash: true,
                backpack: true, noRefills: true);

        public static readonly global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory Farewell =
            new global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory(1, dreamDash: true,
                backpack: false);

        private static readonly
            Dictionary<string, global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory> Maps =
                BuildMaps();

        public static global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory CreateForMap(
            string mapPackage, string checkpoint = null)
        {
            if (!Maps.TryGetValue(mapPackage, out var inventory))
                throw new ArgumentException("Unknown original map package: " + mapPackage, nameof(mapPackage));
            // AreaData.GetCheckpointInventory uses an exact room-name match and otherwise the mode inventory.
            if (mapPackage == "2-OldSite" && checkpoint == "3") return Default;
            if (mapPackage == "6-Reflection" && checkpoint == "after-00") return CH6End;
            return inventory;
        }

        private static Dictionary<string, global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory>
            BuildMaps()
        {
            var maps =
                new Dictionary<string, global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory>(
                    StringComparer.Ordinal)
                {
                    { "0-Intro", Prologue }, { "8-Epilogue", TheSummit }, { "LostLevels", Farewell }
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
            Dictionary<string, global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory> maps, int id,
            string name,
            global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory normal,
            global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory sides)
        {
            maps.Add(id + "-" + name, normal);
            maps.Add(id + "H-" + name, sides);
            maps.Add(id + "X-" + name, sides);
        }
    }
}
