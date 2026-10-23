using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Death
{
    public sealed class RoomPlayerHazards
    {
        private readonly RoomPlayerWorld world;
        private readonly Func<global::Celeste.Simulation.Gameplay.Player.Death.PlayerDeathRequest, bool> tryDie;
        private readonly Func<bool> isDead;
        public event Action<global::Celeste.Simulation.Gameplay.Player.Death.PlayerHazardEvent> Emitted;

        public RoomPlayerHazards(RoomPlayerWorld world,
            Func<global::Celeste.Simulation.Gameplay.Player.Death.PlayerDeathRequest, bool> tryDie, Func<bool> isDead)
        {
            this.world = world ?? throw new ArgumentNullException(nameof(world));
            this.tryDie = tryDie ?? throw new ArgumentNullException(nameof(tryDie));
            this.isDead = isDead ?? throw new ArgumentNullException(nameof(isDead));
        }

        public bool CheckSpike(global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeRegion spike)
        {
            if (isDead() || world.Machine.State == 21 || !spike.Collidable) return false;
            global::Celeste.Core.Geometry.Bounds hurtbox =
                world.Contacts.HurtboxBoundsAt(Vector2.Zero, world.UsesFeatherCollider);
            if (!hurtbox.Intersects(spike.Bounds)) return false;
            return OnSpikeCollision(spike);
        }

        // Spikes.OnCollide is called after PlayerCollider.Check has already tested
        // the current component geometry (which TAS may replace).
        public bool OnSpikeCollision(global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeRegion spike)
        {
            global::Celeste.Core.Geometry.Bounds hurtbox =
                world.Contacts.HurtboxBoundsAt(Vector2.Zero, world.UsesFeatherCollider);
            var direction = SpikeDirectionVector(spike.Direction);
            var request =
                new global::Celeste.Simulation.Gameplay.Player.Death.PlayerDeathRequest(direction,
                    source: spike.Source);
            Emitted?.Invoke(new global::Celeste.Simulation.Gameplay.Player.Death.PlayerHazardEvent(
                global::Celeste.Simulation.Gameplay.Player.Death.PlayerHazardEventKind.SpikeContact, world.Position,
                request));
            if (!SpikeWouldKill(spike, hurtbox, world.Data.Motion.Normal.Speed)) return false;
            return TryDie(request);
        }

        public bool TryDie(Vector2 direction, bool evenIfInvincible = false, bool registerDeathInStats = true)
            => TryDie(new global::Celeste.Simulation.Gameplay.Player.Death.PlayerDeathRequest(direction,
                evenIfInvincible, registerDeathInStats));

        public bool TryDie(global::Celeste.Simulation.Gameplay.Player.Death.PlayerDeathRequest request)
        {
            Vector2 position = world.Position;
            Emitted?.Invoke(new global::Celeste.Simulation.Gameplay.Player.Death.PlayerHazardEvent(
                global::Celeste.Simulation.Gameplay.Player.Death.PlayerHazardEventKind.DeathRequested, position,
                request));
            if (!global::Celeste.Simulation.Gameplay.Player.Death.PlayerDeathRules.CanDie(isDead(), world.Machine.State,
                    world.Settings.Invincible,
                    request.EvenIfInvincible))
            {
                Emitted?.Invoke(new global::Celeste.Simulation.Gameplay.Player.Death.PlayerHazardEvent(
                    global::Celeste.Simulation.Gameplay.Player.Death.PlayerHazardEventKind.DeathSuppressed, position,
                    request));
                return false;
            }

            bool died = tryDie(request);
            Emitted?.Invoke(new global::Celeste.Simulation.Gameplay.Player.Death.PlayerHazardEvent(
                died
                    ? global::Celeste.Simulation.Gameplay.Player.Death.PlayerHazardEventKind.Died
                    : global::Celeste.Simulation.Gameplay.Player.Death.PlayerHazardEventKind.DeathSuppressed, position,
                request));
            return died;
        }

        public static bool SpikeWouldKill(global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeRegion spike,
            global::Celeste.Core.Geometry.Bounds playerHurtbox, Vector2 playerSpeed)
        {
            switch (spike.Direction)
            {
                case global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection.Up:
                    return playerSpeed.Y >= 0 && playerHurtbox.Bottom <= spike.Bounds.Bottom;
                case global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection.Down: return playerSpeed.Y <= 0;
                case global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection.Left: return playerSpeed.X >= 0;
                case global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection.Right: return playerSpeed.X <= 0;
                default: return false;
            }
        }

        public static Vector2 SpikeDirectionVector(
            global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection direction)
        {
            switch (direction)
            {
                case global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection.Up: return -Vector2.UnitY;
                case global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection.Down: return Vector2.UnitY;
                case global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection.Left: return -Vector2.UnitX;
                case global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection.Right: return Vector2.UnitX;
                default: return Vector2.Zero;
            }
        }
    }
}
