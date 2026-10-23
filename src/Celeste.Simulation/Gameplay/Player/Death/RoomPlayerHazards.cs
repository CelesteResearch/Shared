using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Simulation.Gameplay.Hazards.Spikes;

namespace Celeste.Simulation.Gameplay.Player.Death
{
    public sealed class RoomPlayerHazards
    {
        private readonly RoomPlayerWorld world;
        private readonly Func<PlayerDeathRequest, bool> tryDie;
        private readonly Func<bool> isDead;
        public event Action<PlayerHazardEvent> Emitted;

        public RoomPlayerHazards(RoomPlayerWorld world,
            Func<PlayerDeathRequest, bool> tryDie, Func<bool> isDead)
        {
            this.world = world ?? throw new ArgumentNullException(nameof(world));
            this.tryDie = tryDie ?? throw new ArgumentNullException(nameof(tryDie));
            this.isDead = isDead ?? throw new ArgumentNullException(nameof(isDead));
        }

        public bool CheckSpike(SpikeRegion spike)
        {
            if (isDead() || world.Machine.State == 21 || !spike.Collidable) return false;
            var hurtbox =
                world.Contacts.HurtboxBoundsAt(Vector2.Zero, world.UsesFeatherCollider);
            if (!hurtbox.Intersects(spike.Bounds)) return false;
            return OnSpikeCollision(spike);
        }

        // Spikes.OnCollide is called after PlayerCollider.Check has already tested
        // the current component geometry (which TAS may replace).
        public bool OnSpikeCollision(SpikeRegion spike)
        {
            var hurtbox =
                world.Contacts.HurtboxBoundsAt(Vector2.Zero, world.UsesFeatherCollider);
            var direction = SpikeDirectionVector(spike.Direction);
            var request =
                new PlayerDeathRequest(direction,
                    source: spike.Source);
            Emitted?.Invoke(new(
                PlayerHazardEventKind.SpikeContact, world.Position,
                request));
            if (!SpikeWouldKill(spike, hurtbox, world.Data.Motion.Normal.Speed)) return false;
            return TryDie(request);
        }

        public bool TryDie(Vector2 direction, bool evenIfInvincible = false, bool registerDeathInStats = true)
        {
            return TryDie(new(direction,
                evenIfInvincible, registerDeathInStats));
        }

        public bool TryDie(PlayerDeathRequest request)
        {
            var position = world.Position;
            Emitted?.Invoke(new(
                PlayerHazardEventKind.DeathRequested, position,
                request));
            if (!PlayerDeathRules.CanDie(isDead(), world.Machine.State,
                    world.Settings.Invincible,
                    request.EvenIfInvincible))
            {
                Emitted?.Invoke(new(
                    PlayerHazardEventKind.DeathSuppressed, position,
                    request));
                return false;
            }

            var died = tryDie(request);
            Emitted?.Invoke(new(
                died
                    ? PlayerHazardEventKind.Died
                    : PlayerHazardEventKind.DeathSuppressed, position,
                request));
            return died;
        }

        public static bool SpikeWouldKill(SpikeRegion spike,
            Bounds playerHurtbox, Vector2 playerSpeed)
        {
            switch (spike.Direction)
            {
                case SpikeDirection.Up:
                    return playerSpeed.Y >= 0 && playerHurtbox.Bottom <= spike.Bounds.Bottom;
                case SpikeDirection.Down: return playerSpeed.Y <= 0;
                case SpikeDirection.Left: return playerSpeed.X >= 0;
                case SpikeDirection.Right: return playerSpeed.X <= 0;
                default: return false;
            }
        }

        public static Vector2 SpikeDirectionVector(
            SpikeDirection direction)
        {
            switch (direction)
            {
                case SpikeDirection.Up: return -Vector2.UnitY;
                case SpikeDirection.Down: return Vector2.UnitY;
                case SpikeDirection.Left: return -Vector2.UnitX;
                case SpikeDirection.Right: return Vector2.UnitX;
                default: return Vector2.Zero;
            }
        }
    }
}
