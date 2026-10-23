using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Story.Farewell.Travel
{
    // The EventTrigger owns its once-only OnEnter guard. These callbacks retain
    // the original player identity and execute their mutations at end of frame.
    public sealed class FarewellTravelEvent
    {
        readonly global::Celeste.Simulation.Story.Farewell.Travel.IFarewellTravelWorld world;
        public string Event;

        public FarewellTravelEvent(global::Celeste.Simulation.Story.Farewell.Travel.IFarewellTravelWorld world,
            string eventName)
        {
            this.world = world;
            Event = eventName;
        }

        public static bool Handles(string name) =>
            name == "ch9_goto_the_future" || name == "ch9_goto_the_past" || name == "ch9_end_golden";

        public void Enter(global::Celeste.Simulation.Story.Farewell.Travel.IFarewellTravelPlayer player)
        {
            if (Event == "ch9_goto_the_future" || Event == "ch9_goto_the_past")
                world.QueueEndOfFrame(() => Travel(player));
            else if (Event == "ch9_end_golden")
            {
                world.WipeColor = Vector4.One;
                world.StartFadeOut(1f, () => world.QueueEndOfFrame(() =>
                {
                    world.TeleportTransition(player, "end-granny");
                    player.Speed = Vector2.Zero;
                }));
            }
            else throw new ArgumentException("Unsupported original travel event", nameof(Event));
        }

        void Travel(global::Celeste.Simulation.Story.Farewell.Travel.IFarewellTravelPlayer player)
        {
            // Original evaluates this unused expression before taking snapshots.
            _ = new Vector2(world.LevelOffset.X + world.Bounds.Width - player.Position.X,
                player.Position.Y - world.LevelOffset.Y);
            Vector2 oldOffset = world.LevelOffset;
            Vector2 relativePlayer = player.Position - world.LevelOffset;
            Vector2 relativeCamera = world.CameraPosition - world.LevelOffset;
            int facing = player.Facing;
            world.RemovePlayer(player);
            world.UnloadLevel();
            world.Dreaming = true;
            world.SessionLevel = Event == "ch9_goto_the_future" ? "intro-01-future" : "intro-00-past";
            global::Celeste.Core.Geometry.Bounds bounds = world.Bounds;
            world.RespawnPoint = world.GetSpawnPoint(new Vector2(bounds.X, bounds.Y));
            world.FirstLevel = false;
            world.LoadTransition();
            world.CameraPosition = world.LevelOffset + relativeCamera;
            world.InventoryDashes = 1;
            player.Dashes = Math.Min(player.Dashes, 1);
            world.AddPlayer(player);
            player.Position = world.LevelOffset + relativePlayer;
            player.Facing = facing;
            player.MoveHairBy(world.LevelOffset - oldOffset);
            if (world.HasWipe) world.CancelWipe();
            world.FlashWhite();
            world.Shake();
            world.AddLightningStrike(new Vector2(player.Position.X + 60, world.Bounds.Bottom - 180), 10, 200, 0);
            world.AddLightningStrike(new Vector2(player.Position.X + 220, world.Bounds.Bottom - 180), 40, 200, .25f);
            world.PlaySound("event:/new_content/game/10_farewell/lightning_strike");
        }
    }
}
