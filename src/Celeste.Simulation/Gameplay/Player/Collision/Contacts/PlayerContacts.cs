using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Geometry;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Collision.Blockers;
using Celeste.Simulation.Gameplay.Environment.Water;
using Celeste.Simulation.Gameplay.Hazards.Spikes;
using Celeste.Simulation.Gameplay.Interaction.WallBooster;
using Celeste.Simulation.Gameplay.Player.State;
using JetBrains.Annotations;

namespace Celeste.Simulation.Gameplay.Player.Collision.Contacts
{
    public sealed partial class PlayerContacts
    {
        public readonly PixelActor Body;
        public readonly PlayerState State;

        private SimulationStateMachine machine =>
            ((RoomPlayerSession)actualOwner).Machine;

        public readonly HitboxColliderGeometry NormalHitbox = new(8, 11, -4, -11);
        public readonly HitboxColliderGeometry DuckHitbox = new(8, 6, -4, -6);
        public readonly HitboxColliderGeometry FeatherHitbox = new(8, 8, -4, -10);
        public readonly HitboxColliderGeometry NormalHurtbox = new(8, 9, -4, -11);
        public readonly HitboxColliderGeometry DuckHurtbox = new(8, 4, -4, -6);
        public readonly HitboxColliderGeometry FeatherHurtbox = new(6, 6, -3, -9);

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private ISourceEntityCollider actualOwner;

        public ISourceEntityCollider ActualOwner => actualOwner;
        public ColliderGeometry Collider => actualOwner.Collider;
        public ColliderGeometry Hurtbox;
        public bool PlayerColliderPass { get; private set; }
        public bool Ducking => ReferenceEquals(Collider, DuckHitbox) || ReferenceEquals(Collider, DuckHurtbox);

        public bool UsesFeatherCollider
        {
            get => ReferenceEquals(Collider, FeatherHitbox) || ReferenceEquals(Collider, FeatherHurtbox);
            set
            {
                if (value)
                {
                    SetCollider(FeatherHitbox);
                    Hurtbox = FeatherHurtbox;
                }
                else
                {
                    SetDucking(Ducking);
                }
            }
        }

        public void BindActualOwner(ISourceEntityCollider owner)
        {
            actualOwner = owner;

            Body.SourceColliderOwner = owner;
        }

        public void SetDucking(bool value)
        {
            SetCollider(value ? DuckHitbox : NormalHitbox);
            Hurtbox = value ? DuckHurtbox : NormalHurtbox;
        }

        public IntRect RoomBounds =>
            ((ISourceSceneBounds)((RoomPlayerSession)actualOwner).Scene).Bounds;

        public PlayerContacts(PixelActor body, PlayerState state,
            RoomPlayerSession actualPlayer)
        {
            Body = body;
            State = state;
            actualOwner = actualPlayer;
            Hurtbox = NormalHurtbox;
            BindActualOwner(actualPlayer);
        }

        public void SetCollider(ColliderGeometry collider)
        {
            ((RoomPlayerSession)actualOwner).Collider = collider;
        }

        public ColliderGeometry BeginPlayerColliderPass()
        {
            var saved = Collider;
            SetCollider(Hurtbox);
            PlayerColliderPass = true;
            return saved;
        }

        public void EndPlayerColliderPass(ColliderGeometry saved, bool dead)
        {
            if (dead || ReferenceEquals(Collider, Hurtbox)) SetCollider(saved);
            PlayerColliderPass = false;
        }

        private Bounds ShapeBoundsAt(ColliderGeometry shape, Vector2 position)
        {
            var origin = !ReferenceEquals(shape, Collider) || ReferenceEquals(shape.Entity, actualOwner)
                ? position
                : shape.Entity?.Position ?? Vector2.Zero;
            return new(shape.Left + origin.X, shape.Top + origin.Y,
                shape.Width, shape.Height, shape.Right + origin.X, shape.Bottom + origin.Y);
        }

        public Bounds BoundsAt(Vector2 offset, bool standing = false)
        {
            return ShapeBoundsAt(standing ? NormalHitbox : Collider, Body.Position + offset);
        }

        public Bounds HurtboxBoundsAt(Vector2 offset, bool? featherOverride = null)
        {
            return ShapeBoundsAt(PlayerColliderPass ? Collider : Hurtbox, Body.Position + offset);
        }

        public void SyncCollider()
        {
            if (actualOwner == null) SetDucking(State.Motion.Ducking);
        }

        public bool SolidAt(Vector2 offset)
        {
            return Body.CollideSolidAt(Body.Position + offset);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool DuckFreeAt(Vector2 offset)
        {
            var from = Body.Position;
            var previous = Collider;
            Body.Position += offset;
            SetCollider(DuckHitbox);
            var result = !Body.CollideSolidAt(Body.Position);
            Body.Position = from;
            SetCollider(previous);
            return result;
        }

        public bool GroundAt(Vector2 offset)
        {
            return ((RoomPlayerSession)actualOwner).OnGround(Body.Position + offset);
        }

        public bool JumpThruAt(Vector2 offset)
        {
            return Body.CollideJumpThruAt(Body.Position + offset);
        }

        public bool JumpThruOutsideAt(Vector2 offset)
        {
            return Body.CollideJumpThruOutside(Body.Position + offset);
        }

        public ISourceWater FirstWaterAt(Vector2 offset)
        {
            return SourceTrackedEntityCollision
                .FirstAt<ISourceWater>(
                    ((ISourceScene)((RoomPlayerSession)actualOwner).Scene).SourceScene
                    .Entities,
                    "Celeste.Water", actualOwner, Body.Position + offset);
        }

        public bool WaterAt(Vector2 offset)
        {
            return FirstWaterAt(offset) != null;
        }

        public bool SwimCheck()
        {
            return WaterAt(-Vector2.UnitY * 8f) && WaterAt(Vector2.Zero);
        }

        public bool SwimUnderwaterCheck()
        {
            return WaterAt(-Vector2.UnitY * 9f);
        }

        public bool SwimJumpCheck()
        {
            return !WaterAt(-Vector2.UnitY * 14f);
        }

        public bool SwimRiseCheck()
        {
            return !WaterAt(-Vector2.UnitY * 18f);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool UnderwaterMusicCheck()
        {
            return WaterAt(Vector2.Zero) && WaterAt(-Vector2.UnitY * 12f);
        }

        public bool JumpThruBoostBlocked()
        {
            var player = (RoomPlayerSession)actualOwner;
            var scene = (ISourceScene)player.Scene;
            foreach (var component in scene.SourceScene.Components.GetTrackedComponents("Celeste.LedgeBlocker"))
                if (((LedgeBlockerState)component)
                    .JumpThruBoostCheck(player))
                    return true;
            return false;
        }

        public bool DashCorrectBlocked(Vector2 offset)
        {
            var previous = Body.Position;
            var saved = Collider;
            Body.Position += offset;
            SetCollider(Hurtbox);
            var player = (RoomPlayerSession)actualOwner;
            var scene = (ISourceScene)player.Scene;
            foreach (var component in scene.SourceScene.Components.GetTrackedComponents("Celeste.LedgeBlocker"))
                if (((LedgeBlockerState)component)
                    .DashCorrectCheck(player))
                {
                    Body.Position = previous;
                    SetCollider(saved);
                    return true;
                }

            Body.Position = previous;
            SetCollider(saved);
            return false;
        }

        public bool CanUnDuck
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get => CanUnDuckAtCore(Vector2.Zero, true);
        }

        public bool CanUnDuckAt(Vector2 offset)
        {
            var position = Body.Position;
            Body.Position = position + offset;
            var result = CanUnDuck;
            Body.Position = position;
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool StandingUnduckBlockedAt(Vector2 offset)
        {
            return SolidAt(offset);
        }

        private bool CanUnDuckAtCore(Vector2 offset, bool currentContacts)
        {
            if (!State.Motion.Ducking) return true;
            var saved = Collider;
            SetCollider(NormalHitbox);
            var free = !(currentContacts ? StandingUnduckBlockedAt(offset) : SolidAt(offset));
            SetCollider(saved);
            return free;
        }

        [MethodImpl(MethodImplOptions
            .NoInlining)]
        public bool ClimbBoundsCheck(int direction)
        {
            var bounds = BoundsAt(Vector2.Zero);
            return bounds.X + direction * 2 >= RoomBounds.X && bounds.Right + direction * 2 < RoomBounds.Right;
        }

        public bool ClimbBlocked(Vector2 offset, bool edgeOnly = false)
        {
            var player = (RoomPlayerSession)actualOwner;
            return edgeOnly
                ? ClimbBlockerState.EdgeCheckOffset(
                    player.Scene, player, offset)
                : ClimbBlockerState.Check(
                    player.Scene, player, player.Position + offset);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool ClimbCheck(int direction, int yOffset = 0)
        {
            return ClimbBoundsCheck(direction) &&
                   !ClimbBlocked(new(2 * State.Facing,
                       yOffset)) && SolidAt(new(
                       2 * direction,
                       yOffset));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool SlipCheck(float addY = 0f)
        {
            var bounds = BoundsAt(Vector2.Zero);
            var point = new Vector2(State.Facing == 1 ? bounds.Right : bounds.X - 1, bounds.Y + 4f + addY);
            return !Body.World.SolidAt(point) && !Body.World.SolidAt(point + Vector2.UnitY * (-4f + addY));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool ClimbHopBlocked(bool hasStrawberrySeedFollower)
        {
            if (hasStrawberrySeedFollower) return true;
            var player = (RoomPlayerSession)actualOwner;
            var scene = (ISourceScene)player.Scene;
            foreach (var component in scene.SourceScene.Components.GetTrackedComponents("Celeste.LedgeBlocker"))
                if (((LedgeBlockerState)component)
                    .HopBlockCheck(player))
                    return true;
            return SolidAt(-Vector2.UnitY * 6f);
        }

        public bool WallBoosterCheck()
        {
            if (ClimbBlocked(Vector2.UnitX * State.Facing)) return false;
            var player = (RoomPlayerSession)actualOwner;
            var entities =
                ((ISourceScene)player.Scene).SourceScene.Entities.GetTrackedEntities(
                    "Celeste.WallBooster");
            foreach (var actual in entities)
            {
                var booster = (ISourceWallBooster)actual;
                if (booster.Facing == State.Facing && booster.Collidable &&
                    SourceEntityCollision.Check(player, booster)) return true;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool WallJumpCheck(int direction)
        {
            var reach = 3;
            var extended = ((RoomPlayerSession)actualOwner).DashAttacking && State.Direction.X == 0f &&
                           State.Direction.Y == -1f;
            if (extended)
            {
                var dangerousSide = direction > 0
                    ? SpikeDirection.Left
                    : SpikeDirection.Right;
                var player = (RoomPlayerSession)actualOwner;
                var scene = (ISourceScene)player.Scene;
                foreach (var entity in scene.SourceScene.Entities.GetTrackedEntities("Celeste.Spikes"))
                {
                    var spike = (SpikesState)entity;
                    if (spike.Direction == dangerousSide &&
                        SourceEntityCollision.CheckAt(player, spike, player.Position + Vector2.UnitX * direction * 5f))
                    {
                        extended = false;
                        break;
                    }
                }
            }

            if (extended) reach = 5;
            return ClimbBoundsCheck(direction) && !ClimbBlocked(Vector2.UnitX * direction * reach, true) &&
                   SolidAt(Vector2.UnitX * direction * reach);
        }

        public void MoveH(float amount)
        {
            SyncCollider();
            ((RoomPlayerSession)actualOwner).MoveH(amount);
        }

        public void MoveVExact(int amount)
        {
            SyncCollider();
            ((RoomPlayerSession)actualOwner).MoveVExact(amount);
        }
    }
}
