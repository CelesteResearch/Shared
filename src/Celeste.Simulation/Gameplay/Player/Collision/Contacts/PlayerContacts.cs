using Celeste.Physics.Collision.Shapes;
using Celeste.Physics.Collision;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Collision.Contacts
{
    public sealed partial class PlayerContacts
    {
        public readonly PixelActor Body;
        public readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState State;

        private global::Celeste.Core.Scheduling.SimulationStateMachine machine =>
            ((RoomPlayerSession)actualOwner).Machine;

        public readonly HitboxColliderGeometry NormalHitbox = new HitboxColliderGeometry(8, 11, -4, -11);
        public readonly HitboxColliderGeometry DuckHitbox = new HitboxColliderGeometry(8, 6, -4, -6);
        public readonly HitboxColliderGeometry FeatherHitbox = new HitboxColliderGeometry(8, 8, -4, -10);
        public readonly HitboxColliderGeometry NormalHurtbox = new HitboxColliderGeometry(8, 9, -4, -11);
        public readonly HitboxColliderGeometry DuckHurtbox = new HitboxColliderGeometry(8, 4, -4, -6);
        public readonly HitboxColliderGeometry FeatherHurtbox = new HitboxColliderGeometry(6, 6, -3, -9);
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
                else SetDucking(Ducking);
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

        public global::Celeste.Core.Geometry.IntRect RoomBounds =>
            ((global::Celeste.Scene.Geometry.ISourceSceneBounds)((RoomPlayerSession)actualOwner).Scene).Bounds;

        public PlayerContacts(PixelActor body, global::Celeste.Simulation.Gameplay.Player.State.PlayerState state,
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

        private global::Celeste.Core.Geometry.Bounds ShapeBoundsAt(ColliderGeometry shape, Vector2 position)
        {
            Vector2 origin = !ReferenceEquals(shape, Collider) || ReferenceEquals(shape.Entity, actualOwner)
                ? position
                : shape.Entity?.Position ?? Vector2.Zero;
            return new global::Celeste.Core.Geometry.Bounds(shape.Left + origin.X, shape.Top + origin.Y,
                shape.Width, shape.Height, shape.Right + origin.X, shape.Bottom + origin.Y);
        }

        public global::Celeste.Core.Geometry.Bounds BoundsAt(Vector2 offset, bool standing = false)
            => ShapeBoundsAt(standing ? NormalHitbox : Collider, Body.Position + offset);

        public global::Celeste.Core.Geometry.Bounds HurtboxBoundsAt(Vector2 offset, bool? featherOverride = null)
            => ShapeBoundsAt(PlayerColliderPass ? Collider : Hurtbox, Body.Position + offset);

        public void SyncCollider()
        {
            if (actualOwner == null) SetDucking(State.Motion.Ducking);
        }

        public bool SolidAt(Vector2 offset) => Body.CollideSolidAt(Body.Position + offset);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool DuckFreeAt(Vector2 offset)
        {
            Vector2 from = Body.Position;
            ColliderGeometry previous = Collider;
            Body.Position += offset;
            SetCollider(DuckHitbox);
            bool result = !Body.CollideSolidAt(Body.Position);
            Body.Position = from;
            SetCollider(previous);
            return result;
        }

        public bool GroundAt(Vector2 offset) => ((RoomPlayerSession)actualOwner).OnGround(Body.Position + offset);

        public bool JumpThruAt(Vector2 offset) => Body.CollideJumpThruAt(Body.Position + offset);

        public bool JumpThruOutsideAt(Vector2 offset) =>
            Body.CollideJumpThruOutside(Body.Position + offset);

        public global::Celeste.Simulation.Gameplay.Environment.Water.ISourceWater FirstWaterAt(Vector2 offset)
            => global::Celeste.Scene.Entities.SourceTrackedEntityCollision
                .FirstAt<global::Celeste.Simulation.Gameplay.Environment.Water.ISourceWater>(
                    ((global::Celeste.Scene.Tracking.ISourceScene)((RoomPlayerSession)actualOwner).Scene).SourceScene
                    .Entities,
                    "Celeste.Water", actualOwner, Body.Position + offset);

        public bool WaterAt(Vector2 offset) => FirstWaterAt(offset) != null;
        public bool SwimCheck() => WaterAt(-Vector2.UnitY * 8f) && WaterAt(Vector2.Zero);
        public bool SwimUnderwaterCheck() => WaterAt(-Vector2.UnitY * 9f);
        public bool SwimJumpCheck() => !WaterAt(-Vector2.UnitY * 14f);
        public bool SwimRiseCheck() => !WaterAt(-Vector2.UnitY * 18f);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool UnderwaterMusicCheck() => WaterAt(Vector2.Zero) && WaterAt(-Vector2.UnitY * 12f);

        public bool JumpThruBoostBlocked()
        {
            var player = (RoomPlayerSession)actualOwner;
            var scene = (global::Celeste.Scene.Tracking.ISourceScene)player.Scene;
            foreach (var component in scene.SourceScene.Components.GetTrackedComponents("Celeste.LedgeBlocker"))
                if (((global::Celeste.Simulation.Gameplay.Collision.Blockers.LedgeBlockerState)component)
                    .JumpThruBoostCheck(player))
                    return true;
            return false;
        }

        public bool DashCorrectBlocked(Vector2 offset)
        {
            Vector2 previous = Body.Position;
            ColliderGeometry saved = Collider;
            Body.Position += offset;
            SetCollider(Hurtbox);
            var player = (RoomPlayerSession)actualOwner;
            var scene = (global::Celeste.Scene.Tracking.ISourceScene)player.Scene;
            foreach (var component in scene.SourceScene.Components.GetTrackedComponents("Celeste.LedgeBlocker"))
                if (((global::Celeste.Simulation.Gameplay.Collision.Blockers.LedgeBlockerState)component)
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
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get => CanUnDuckAtCore(Vector2.Zero, true);
        }

        public bool CanUnDuckAt(Vector2 offset)
        {
            Vector2 position = Body.Position;
            Body.Position = position + offset;
            bool result = CanUnDuck;
            Body.Position = position;
            return result;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool StandingUnduckBlockedAt(Vector2 offset) => SolidAt(offset);

        private bool CanUnDuckAtCore(Vector2 offset, bool currentContacts)
        {
            if (!State.Motion.Ducking) return true;
            ColliderGeometry saved = Collider;
            SetCollider(NormalHitbox);
            bool free = !(currentContacts ? StandingUnduckBlockedAt(offset) : SolidAt(offset));
            SetCollider(saved);
            return free;
        }

        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions
            .NoInlining)]
        public bool ClimbBoundsCheck(int direction)
        {
            global::Celeste.Core.Geometry.Bounds bounds = BoundsAt(Vector2.Zero);
            return bounds.X + direction * 2 >= RoomBounds.X && bounds.Right + direction * 2 < RoomBounds.Right;
        }

        public bool ClimbBlocked(Vector2 offset, bool edgeOnly = false)
        {
            var player = (RoomPlayerSession)actualOwner;
            return edgeOnly
                ? global::Celeste.Simulation.Gameplay.Collision.Blockers.ClimbBlockerState.EdgeCheckOffset(
                    player.Scene, player, offset)
                : global::Celeste.Simulation.Gameplay.Collision.Blockers.ClimbBlockerState.Check(
                    player.Scene, player, player.Position + offset);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool ClimbCheck(int direction, int yOffset = 0) => ClimbBoundsCheck(direction) &&
                                                                  !ClimbBlocked(new Vector2(2 * State.Facing,
                                                                      yOffset)) && SolidAt(new Vector2(
                                                                      2 * direction,
                                                                      yOffset));

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool SlipCheck(float addY = 0f)
        {
            global::Celeste.Core.Geometry.Bounds bounds = BoundsAt(Vector2.Zero);
            var point = new Vector2(State.Facing == 1 ? bounds.Right : bounds.X - 1, bounds.Y + 4f + addY);
            return !Body.World.SolidAt(point) && !Body.World.SolidAt(point + Vector2.UnitY * (-4f + addY));
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool ClimbHopBlocked(bool hasStrawberrySeedFollower)
        {
            if (hasStrawberrySeedFollower) return true;
            var player = (RoomPlayerSession)actualOwner;
            var scene = (global::Celeste.Scene.Tracking.ISourceScene)player.Scene;
            foreach (var component in scene.SourceScene.Components.GetTrackedComponents("Celeste.LedgeBlocker"))
                if (((global::Celeste.Simulation.Gameplay.Collision.Blockers.LedgeBlockerState)component)
                    .HopBlockCheck(player))
                    return true;
            return SolidAt(-Vector2.UnitY * 6f);
        }

        public bool WallBoosterCheck()
        {
            if (ClimbBlocked(Vector2.UnitX * State.Facing)) return false;
            var player = (RoomPlayerSession)actualOwner;
            var entities =
                ((global::Celeste.Scene.Tracking.ISourceScene)player.Scene).SourceScene.Entities.GetTrackedEntities(
                    "Celeste.WallBooster");
            foreach (var actual in entities)
            {
                var booster = (global::Celeste.Simulation.Gameplay.Interaction.WallBooster.ISourceWallBooster)actual;
                if (booster.Facing == State.Facing && booster.Collidable &&
                    global::Celeste.Physics.Collision.SourceEntityCollision.Check(player, booster)) return true;
            }

            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool WallJumpCheck(int direction)
        {
            int reach = 3;
            bool extended = ((RoomPlayerSession)actualOwner).DashAttacking && State.Direction.X == 0f &&
                            State.Direction.Y == -1f;
            if (extended)
            {
                var dangerousSide = direction > 0
                    ? global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection.Left
                    : global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection.Right;
                var player = (RoomPlayerSession)actualOwner;
                var scene = (global::Celeste.Scene.Tracking.ISourceScene)player.Scene;
                foreach (var entity in scene.SourceScene.Entities.GetTrackedEntities("Celeste.Spikes"))
                {
                    var spike = (global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikesState)entity;
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
