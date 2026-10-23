using System;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Movement.Wind
{
    // WindController supplies displacement, already multiplied by 0.1 and DeltaTime.
    // These Actor moves intentionally have no Player.OnCollideH/V callbacks.
    public sealed class PlayerWindMovement
    {
        private readonly RoomPlayerWorld world;
        private readonly global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHairAppearance appearance;
        private readonly Func<bool> justRespawned;

        public PlayerWindMovement(RoomPlayerWorld world,
            global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHairAppearance appearance,
            Func<bool> justRespawned)
        {
            this.world = world ?? throw new ArgumentNullException(nameof(world));
            this.appearance = appearance ?? throw new ArgumentNullException(nameof(appearance));
            this.justRespawned = justRespawned ?? throw new ArgumentNullException(nameof(justRespawned));
        }

        public void Move(Vector2 move)
        {
            var data = world.Data;
            int state = world.Machine.State;
            if (justRespawned() || !(data.NoWindTimer <= 0) ||
                state >= 11 && state <= 17 || state == 23 || state == 25 || state == 4 || state == 2 ||
                state == 10) return;
            var body = world.Body;
            global::Celeste.Core.Geometry.IntRect room = world.Contacts.RoomBounds;
            if (move.X != 0 && state != 1)
            {
                appearance.WindTimeout = .2f;
                appearance.WindDirection.X = Math.Sign(move.X);
                if (!body.World.SolidAt(body.BoundsAt(body.Position + Vector2.UnitX * -Math.Sign(move.X) * 3f)))
                {
                    if (data.Motion.Ducking && data.OnGround) move.X *= 0f;
                    if (move.X < 0) move.X = Math.Max(move.X, room.X - (body.ExactPosition.X + body.Hitbox.X));
                    else move.X = Math.Min(move.X, room.Right - (body.ExactPosition.X + body.Hitbox.Right));
                    world.SourcePlayer.MoveH(move.X);
                }
            }

            if (move.Y == 0) return;
            appearance.WindTimeout = .2f;
            appearance.WindDirection.Y = Math.Sign(move.Y);
            if (!(body.BoundsAt(body.Position).Bottom > room.Y) ||
                (!(data.Motion.Normal.Speed.Y < 0) && world.SourcePlayer.OnGround())) return;
            if (state == 1)
            {
                if (!(move.Y > 0) || !(data.ClimbNoMoveTimer <= 0)) return;
                move.Y *= .4f;
            }

            if (move.Y < 0) data.WindMovedUp = true;
            world.SourcePlayer.MoveV(move.Y);
        }
    }
}
