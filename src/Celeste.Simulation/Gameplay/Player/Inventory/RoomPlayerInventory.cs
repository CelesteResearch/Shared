using System;
using System.Runtime.Serialization;
using Celeste.Simulation.Gameplay.Player.Configuration;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Simulation.Gameplay.Player.Inventory
{
    // PlayerInventory is a value type in the original. Keep the session's copy across room transitions;
    [DataContract]
    public struct RoomPlayerInventory
    {
        public static readonly RoomPlayerInventory Prologue = new(0, false);
        public static readonly RoomPlayerInventory Default = new(1);
        public static readonly RoomPlayerInventory OldSite = new(1, false);

        public static readonly RoomPlayerInventory CH6End = new(2);

        public static readonly RoomPlayerInventory TheSummit = new(2, true, false);

        public static readonly RoomPlayerInventory Core = new(2, true, true, true);

        public static readonly RoomPlayerInventory Farewell = new(1, true, false);

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
        public PlayerSpriteMode DefaultSpriteMode =>
            Backpack
                ? PlayerSpriteMode.Madeline
                : PlayerSpriteMode.MadelineNoBackpack;

        public PlayerSpriteMode GetSpriteMode(
            bool playAsBadeline)
        {
            return playAsBadeline
                ? PlayerSpriteMode.MadelineAsBadeline
                : DefaultSpriteMode;
        }

        public int MaxDashes(DashMode dashMode,
            bool inCutscene = false)
        {
            return dashMode != DashMode.Normal && !inCutscene
                ? 2
                : Dashes;
        }

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
