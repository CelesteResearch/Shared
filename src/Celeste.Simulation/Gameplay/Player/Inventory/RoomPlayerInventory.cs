using Celeste.Simulation.Gameplay.Player.Configuration;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Inventory
{
    // PlayerInventory is a value type in the original. Keep the session's copy across room transitions;
    [DataContract]
    public struct RoomPlayerInventory
    {
        public static readonly RoomPlayerInventory Prologue = new RoomPlayerInventory(0, dreamDash: false);
        public static readonly RoomPlayerInventory Default = new RoomPlayerInventory(1, true, true, false);
        public static readonly RoomPlayerInventory OldSite = new RoomPlayerInventory(1, dreamDash: false);
        public static readonly RoomPlayerInventory CH6End = new RoomPlayerInventory(2);

        public static readonly RoomPlayerInventory TheSummit =
            new RoomPlayerInventory(2, dreamDash: true, backpack: false);

        public static readonly RoomPlayerInventory Core =
            new RoomPlayerInventory(2, dreamDash: true, backpack: true, noRefills: true);

        public static readonly RoomPlayerInventory Farewell =
            new RoomPlayerInventory(1, dreamDash: true, backpack: false);

        [DataMember] public int Dashes;
        [DataMember] public bool DreamDash, Backpack, NoRefills;

        public RoomPlayerInventory(int dashes = 1, bool dreamDash = true, bool backpack = true, bool noRefills = false)
        {
            Dashes = dashes;
            DreamDash = dreamDash;
            Backpack = backpack;
            NoRefills = noRefills;
        }

        // Level.LoadLevel selects this mode; Player's constructor saves it before applying PlayAsBadeline.
        public global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode DefaultSpriteMode =>
            Backpack
                ? global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode.Madeline
                : global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode.MadelineNoBackpack;

        public global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode GetSpriteMode(
            bool playAsBadeline) =>
            playAsBadeline
                ? global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode.MadelineAsBadeline
                : DefaultSpriteMode;

        public int MaxDashes(global::Celeste.Simulation.Gameplay.Player.Configuration.DashMode dashMode,
            bool inCutscene = false) =>
            dashMode != global::Celeste.Simulation.Gameplay.Player.Configuration.DashMode.Normal && !inCutscene
                ? 2
                : Dashes;

        // Changing inventory does not itself refill the player. Player.Added sets Dashes = MaxDashes at spawn.
        public void ApplyTo(RoomPlayerWorld world)
        {
            if (world == null) throw new ArgumentNullException(nameof(world));
            world.InventoryDashes = Dashes;
            world.InventoryDreamDash = DreamDash;
            world.NoRefills = NoRefills;
        }
    }
}
