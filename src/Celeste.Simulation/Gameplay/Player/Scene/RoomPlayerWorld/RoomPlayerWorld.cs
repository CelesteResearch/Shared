using Celeste.Core.Display;
using Celeste.Physics.Collision;
using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Gameplay.Player.Statistics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerWorld : global::Celeste.Simulation.Gameplay.Player.Runtime.IPlayerMotorWorld,
        global::Celeste.Simulation.Gameplay.Player.Presentation.Animation.IPlayerAnimationWorld,
        global::Celeste.Simulation.Gameplay.Player.Collision.IHitSquashWorld,
        global::Celeste.Simulation.Gameplay.Player.Launch.ILaunchWorld,
        global::Celeste.Simulation.Gameplay.Player.Dash.IPlayerBoostWorld,
        global::Celeste.Simulation.Gameplay.Player.Collision.Responses.IPlayerDirectionalCollisionWorld
    {
        public readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState Data;
        public readonly global::Celeste.Simulation.Gameplay.Player.Configuration.IPlayerAssistSettings Settings;
        public readonly ISourceGameInput Input;
        public global::Celeste.Core.Scheduling.SimulationStateMachine Machine => sourceOwner.Machine;

        public global::Celeste.Simulation.Gameplay.Platforms.Collision.PlatformCollisionWorld Platforms =>
            ((global::Celeste.Simulation.Gameplay.Platforms.Collision.ISourcePlatformCollisionScene)sourceOwner.Scene)
            .PlatformWorld;

        public readonly PixelActor Body;
        public readonly global::Celeste.Simulation.Gameplay.Player.Collision.Contacts.PlayerContacts Contacts;

        public readonly global::Celeste.Simulation.Gameplay.Player.Scene.RoomPlayerInteractions Interactions =
            new global::Celeste.Simulation.Gameplay.Player.Scene.RoomPlayerInteractions();

        private global::Celeste.Simulation.Gameplay.Player.Runtime.PlayerMotor motor;

        private readonly List<global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEvent> events =
            new List<global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEvent>();

        public IReadOnlyList<global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEvent> Events => events;
        public event Action<global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEvent> Emitted;
        public readonly global::Celeste.Core.Scheduling.ISourceEngineContext EngineContext;
        private readonly RoomPlayerSession sourceOwner;
        public RoomPlayerSession SourcePlayer => sourceOwner;
        private readonly global::Celeste.Core.Scheduling.SourceEngineEffectsState engineEffects;
        public float SceneTime => ((global::Celeste.Core.Scheduling.ISourceSceneTime)sourceOwner.Scene).TimeActive;
        public global::Celeste.Core.Scheduling.SourceEngineEffectsState EngineEffects => engineEffects;

        public float FreezeRemaining
        {
            get => engineEffects.FreezeTimer;
            set => engineEffects.FreezeTimer = value;
        }

        public bool Cold =>
            ((global::Celeste.Simulation.Gameplay.Environment.Core.ISourceCoreModeScene)sourceOwner.Level)
            .CoreMode == global::Celeste.Simulation.Gameplay.Environment.Core.RoomCoreMode.Cold;

        public bool CoreHot =>
            ((global::Celeste.Simulation.Gameplay.Environment.Core.ISourceCoreModeScene)sourceOwner.Level)
            .CoreMode == global::Celeste.Simulation.Gameplay.Environment.Core.RoomCoreMode.Hot;

        public bool InSpace =>
            ((global::Celeste.Simulation.Gameplay.Environment.Space.ISourceSpaceScene)sourceOwner.Level).InSpace;

        public float WindY =>
            ((global::Celeste.Simulation.Gameplay.Environment.Wind.ISourceWindScene)
                sourceOwner.Level).Wind.Y;

        public bool HoldingSlowRun => sourceOwner.Holding.Holding is { } held && held.SlowRun;
        public bool HoldingSlowFall => sourceOwner.Holding.Holding is { } held && held.SlowFall;

        public bool InCutscene =>
            ((global::Celeste.Scene.Lifecycle.ISceneCutsceneState)sourceOwner.Level).InCutscene;

        public bool NoRefills
        {
            get => sourceOwner.Inventory.NoRefills;
            set
            {
                var scene =
                    (global::Celeste.Simulation.Gameplay.Player.Inventory.ISourcePlayerInventoryScene)sourceOwner.Level;
                var inventory = scene.Inventory;
                inventory.NoRefills = value;
                scene.Inventory = inventory;
            }
        }

        public int InventoryDashes
        {
            get => sourceOwner.Inventory.Dashes;
            set
            {
                var scene =
                    (global::Celeste.Simulation.Gameplay.Player.Inventory.ISourcePlayerInventoryScene)sourceOwner.Level;
                var inventory = scene.Inventory;
                inventory.Dashes = value;
                scene.Inventory = inventory;
            }
        }

        public bool InventoryDreamDash
        {
            get => sourceOwner.Inventory.DreamDash;
            set
            {
                var scene =
                    (global::Celeste.Simulation.Gameplay.Player.Inventory.ISourcePlayerInventoryScene)sourceOwner.Level;
                var inventory = scene.Inventory;
                inventory.DreamDash = value;
                scene.Inventory = inventory;
            }
        }

        public bool UsesFeatherCollider
        {
            get => Contacts.UsesFeatherCollider;
            set => Contacts.UsesFeatherCollider = value;
        }

        public bool HasStrawberrySeedFollower =>
            sourceOwner.Leader
                .HasFollower<
                    global::Celeste.Simulation.Gameplay.Collectibles.Strawberry.ISourceStrawberrySeedFollower>();

        public string DefaultJumpThruTexture { get; set; } = "wood";
        public bool ConveyorLoopActive => sourceOwner.ConveyorLoopActive;
        public string SweatAnimation => sourceOwner.Sweat.CurrentAnimationID;
        public IPlayerActionStatistics SaveStatistics;
        public int TotalJumps { get; private set; }
        public int TotalWallJumps { get; private set; }
        public int TotalDashes { get; private set; }

        public RoomPlayerWorld(global::Celeste.Simulation.Gameplay.Player.State.PlayerState data,
            global::Celeste.Simulation.Gameplay.Player.Configuration.IPlayerAssistSettings settings,
            ISourceGameInput input,
            PixelActor body,
            RoomPlayerSession sourceOwner, global::Celeste.Core.Scheduling.SourceEngineEffectsState engineEffects,
            global::Celeste.Simulation.Gameplay.Platforms.Collision.PlatformCollisionWorld platformWorld,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            EngineContext = engine;
            this.sourceOwner = sourceOwner ?? throw new ArgumentNullException(nameof(sourceOwner));
            this.engineEffects = engineEffects ?? throw new ArgumentNullException(nameof(engineEffects));
            Data = data;
            Settings = settings;
            Input = input;
            if (platformWorld == null) throw new ArgumentNullException(nameof(platformWorld));
            Body = body;
            Contacts = new global::Celeste.Simulation.Gameplay.Player.Collision.Contacts.PlayerContacts(Body, data,
                sourceOwner);
            Data.Motion.DuckingChanged = Contacts.SyncCollider;
        }

        public void Bind(global::Celeste.Simulation.Gameplay.Player.Runtime.PlayerMotor value)
        {
            if (value == null || value.Body != Body || value.Data != Data || value.Machine != Machine)
                throw new ArgumentException("The motor must use this room's body, data and state machine.",
                    nameof(value));
            motor = value;
        }

        public void ClearEvents() => events.Clear();
        public void Report(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEvent value) => Publish(value);

        private void Publish(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEvent value)
        {
            events.Add(value);
            Emitted?.Invoke(value);
        }

        private void Publish(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind kind, string name,
            float value = 0, Vector2? position = null,
            Vector2? direction = null,
            global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform platform = null)
            => Publish(new global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEvent(kind, position ?? Position,
                direction ?? Vector2.Zero, name, value, platform));

        public Vector2 Position => Body.Position;

        public Vector2 LiftSpeed
        {
            get => sourceOwner.LiftSpeed;
            set => sourceOwner.LiftSpeed = value;
        }

        public global::Celeste.Core.Geometry.Bounds Bounds => Contacts.BoundsAt(Vector2.Zero);
        public Vector2 Center => new Vector2(Bounds.X + Bounds.Width / 2f, Bounds.Y + Bounds.Height / 2f);
        public float PlayerCenterY => Center.Y;
        public bool DashAttacking => sourceOwner.DashAttacking;
        public bool CanUnDuck => Contacts.CanUnDuck;
        public bool InWater => Contacts.WaterAt(Vector2.Zero);
        public bool DreamDashIntoBlock => InventoryDreamDash && FirstDreamBlockAt(Vector2.UnitY) != null;
        public bool PlayerOverTalk => Interactions.PlayerOverTalk?.Invoke(this) ?? false;
        public bool Chapter9BoosterBusy => Interactions.Chapter9BoosterBusy?.Invoke(this) ?? false;
        public bool ParticleInterval => OnInterval(.02f);

        public bool OnInterval(float interval) =>
            ((global::Celeste.Scene.Tracking.ISourceScene)sourceOwner.Scene).SourceScene.Clock
            .OnInterval(interval, EngineContext);

        public bool CanUnDuckAt(Vector2 offset) => Contacts.CanUnDuckAt(offset);
        public bool SolidAt(Vector2 offset) => Contacts.SolidAt(offset);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        bool global::Celeste.Simulation.Gameplay.Player.Movement.INormalWorld.SolidAt(Vector2 offset)
            => Contacts.SolidAt(offset);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        bool global::Celeste.Simulation.Gameplay.Player.Movement.IClimbWorld.SolidAt(Vector2 offset)
            => Contacts.SolidAt(offset);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        bool global::Celeste.Simulation.Gameplay.Player.Movement.IPlayerMovementWorld.SolidAt(Vector2 offset)
            => Contacts.SolidAt(offset);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        bool global::Celeste.Simulation.Gameplay.Player.Presentation.Animation.IPlayerAnimationWorld.SolidAt(
            Vector2 offset)
            => Contacts.SolidAt(offset);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        bool global::Celeste.Simulation.Gameplay.Player.Presentation.Animation.IPlayerAnimationWorld.SolidPointAt(
            Vector2 offset)
            => SolidPointAt(offset);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        bool global::Celeste.Simulation.Gameplay.Player.Collision.Responses.IPlayerDirectionalCollisionWorld.
            HorizontalSolidAt(Vector2 offset)
            => Contacts.SolidAt(offset);

        public bool SolidPointAt(Vector2 offset) => Platforms.SolidAt(Position + offset);
        public bool DuckFreeAt(Vector2 offset) => Contacts.DuckFreeAt(offset);
        public bool GroundAt(Vector2 offset) => Contacts.GroundAt(offset);
        public bool JumpThruAt(Vector2 offset) => Contacts.JumpThruAt(offset);
        public bool JumpThruOutsideAt(Vector2 offset) => Contacts.JumpThruOutsideAt(offset);
        public bool JumpThruBoostBlocked() => Contacts.JumpThruBoostBlocked();
        public bool DashCorrectBlocked(Vector2 offset) => Contacts.DashCorrectBlocked(offset);
        public bool ClimbBoundsCheck(int direction) => Contacts.ClimbBoundsCheck(direction);
        public bool ClimbCheck(int direction, int yOffset = 0) => Contacts.ClimbCheck(direction, yOffset);

        bool global::Celeste.Simulation.Gameplay.Player.Movement.ISwimWorld.ClimbCheck(int direction) =>
            Contacts.ClimbCheck(direction);

        bool global::Celeste.Simulation.Gameplay.Player.Collision.IHitSquashWorld.ClimbCheck(int direction) =>
            Contacts.ClimbCheck(direction);

        public bool ClimbEdgeBlocked(int xOffset) => Contacts.ClimbBlocked(Vector2.UnitX * xOffset, true);
        public bool ClimbBlocked(int xOffset) => Contacts.ClimbBlocked(Vector2.UnitX * xOffset);
        public bool WallJumpCheck(int direction) => Contacts.WallJumpCheck(direction);
        public bool WallBoosterCheck() => Contacts.WallBoosterCheck();
        public bool SlipCheck(float addY = 0f) => Contacts.SlipCheck(addY);

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool ClimbHopBlockedCheck() => Contacts.ClimbHopBlocked(HasStrawberrySeedFollower);

        public bool SwimCheck() => Contacts.SwimCheck();
        public bool SwimUnderwaterCheck() => Contacts.SwimUnderwaterCheck();
        public bool SwimJumpCheck() => Contacts.SwimJumpCheck();
        public bool SwimRiseCheck() => Contacts.SwimRiseCheck();

        public global::Celeste.Simulation.Gameplay.Environment.Water.ISourceWater FirstWaterAt(Vector2 offset) =>
            Contacts.FirstWaterAt(offset);

        public global::Celeste.Simulation.Gameplay.Platforms.Movement.IMovingSolid FirstSolidAt(Vector2 offset) =>
            Platforms.FirstSolidAt(Contacts.BoundsAt(offset));

        public global::Celeste.Simulation.Gameplay.Platforms.DreamBlock.ISourceDreamBlock FirstDreamBlockAt(
            Vector2 offset)
            => global::Celeste.Scene.Entities.SourceTrackedEntityCollision.FirstAt<
                global::Celeste.Simulation.Gameplay.Platforms.DreamBlock.ISourceDreamBlock>(
                ((global::Celeste.Scene.Tracking.ISourceScene)sourceOwner.Scene).SourceScene.Entities,
                "Celeste.DreamBlock", sourceOwner, sourceOwner.Position + offset);

        public bool SolidExceptDreamBlockAt(Vector2 offset)
            => global::Celeste.Scene.Entities.SourceTrackedEntityCollision.CheckAtExcept(
                ((global::Celeste.Scene.Tracking.ISourceScene)sourceOwner.Scene).SourceScene.Entities,
                "Celeste.Solid", "Celeste.DreamBlock", sourceOwner, sourceOwner.Position + offset);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool GroundAtOnePixel(out bool safe)
        {
            var registry = ((global::Celeste.Scene.Tracking.ISourceScene)sourceOwner.Scene).SourceScene.Entities;
            var platform = global::Celeste.Scene.Entities.SourceTrackedEntityCollision.FirstAt<
                global::Celeste.Simulation.Gameplay.Platforms.Foundation.SourcePlatformEntityState>(
                registry, "Celeste.Solid", sourceOwner, sourceOwner.Position + Vector2.UnitY);
            if (platform == null)
                platform = global::Celeste.Scene.Entities.SourceTrackedEntityCollision.FirstOutsideAt<
                    global::Celeste.Simulation.Gameplay.Platforms.Foundation.SourcePlatformEntityState,
                    RoomPlayerSession>(
                    registry, "Celeste.JumpThru", sourceOwner, sourceOwner.Position + Vector2.UnitY);
            safe = platform != null && platform.Safe;
            return platform != null;
        }

        public bool SafeGroundBlocked()
        {
            var scene = (global::Celeste.Scene.Tracking.ISourceScene)sourceOwner.Scene;
            foreach (var component in scene.SourceScene.Components.GetTrackedComponents("Celeste.SafeGroundBlocker"))
                if (((global::Celeste.Simulation.Gameplay.Hazards.TriggerSpikes.Components.
                        SafeGroundBlockerComponentState)component).Check(sourceOwner))
                    return true;
            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool RefillGroundAtOnePixel()
        {
            var registry = ((global::Celeste.Scene.Tracking.ISourceScene)sourceOwner.Scene).SourceScene.Entities;
            return global::Celeste.Scene.Entities.SourceTrackedEntityCollision.CheckAtExcept(
                       registry, "Celeste.Solid", "Celeste.NegaBlock", sourceOwner,
                       sourceOwner.Position + Vector2.UnitY)
                   || global::Celeste.Scene.Entities.SourceTrackedEntityCollision
                       .FirstOutsideAt<object, RoomPlayerSession>(
                           registry, "Celeste.JumpThru", sourceOwner, sourceOwner.Position + Vector2.UnitY) != null;
        }

        public bool TouchingSpikes()
        {
            var scene = (global::Celeste.Scene.Tracking.ISourceScene)sourceOwner.Scene;
            foreach (var entry in scene.SourceScene.Entities.GetTrackedEntities("Celeste.Spikes"))
                if (global::Celeste.Physics.Collision.SourceEntityCollision.Check(sourceOwner,
                        (global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikesState)entry))
                    return true;
            return false;
        }

        public bool TryPickup() => sourceOwner.Holding.TryPickup();
        public void Throw() => sourceOwner.Holding.Throw();
        public void Drop() => sourceOwner.Holding.Drop();

        public bool MatchingSwapBlockAhead(int direction)
        {
            var first = global::Celeste.Scene.Entities.SourceTrackedEntityCollision
                .FirstAt<global::Celeste.Simulation.Gameplay.Platforms.SwapBlocks.ISourceSwapBlock>(
                    ((global::Celeste.Scene.Tracking.ISourceScene)sourceOwner.Scene).SourceScene.Entities,
                    "Celeste.SwapBlock", sourceOwner,
                    global::Celeste.Core.Mathematics.LinearAlgebra.SourceVector2Math.Add(sourceOwner.Position,
                        global::Celeste.Core.Mathematics.LinearAlgebra.SourceVector2Math.Multiply(Vector2.UnitX,
                            direction)));
            return first != null && first.Direction.X == direction;
        }

        public Vector2 SwapCancel(Vector2 direction)
        {
            var mask = Vector2.One;
            foreach (var entry in ((global::Celeste.Scene.Tracking.ISourceScene)sourceOwner.Scene)
                     .SourceScene.Entities.GetTrackedEntities("Celeste.SwapBlock"))
            {
                var entity = (global::Celeste.Simulation.Gameplay.Platforms.SwapBlocks.ISourceSwapBlock)entry;
                if (global::Celeste.Physics.Collision.SourceEntityCollision.CheckAt(sourceOwner, entity,
                        global::Celeste.Core.Mathematics.LinearAlgebra.SourceVector2Math.Add(sourceOwner.Position,
                            Vector2.UnitY))
                    && entity != null && entity.Swapping)
                {
                    if (direction.X != 0f && entity.Direction.X == Math.Sign(direction.X)) mask.X = 0f;
                    if (direction.Y != 0f && entity.Direction.Y == Math.Sign(direction.Y)) mask.Y = 0f;
                }
            }

            return mask;
        }

        public void Freeze(float duration) => sourceOwner.Freeze(duration);

        public void MoveTowardsX(float target, float maximumMove)
        {
            Contacts.SyncCollider();
            sourceOwner.MoveTowardsX(target, maximumMove);
        }

        public void MoveH(float amount)
        {
            Contacts.SyncCollider();
            sourceOwner.MoveH(amount);
        }

        public void MoveH(float amount, global::Celeste.Physics.Collision.SourceCollisionHandler callback)
        {
            Contacts.SyncCollider();
            sourceOwner.MoveH(amount, callback);
        }

        public void MoveV(float amount, global::Celeste.Physics.Collision.SourceCollisionHandler callback)
        {
            Contacts.SyncCollider();
            sourceOwner.MoveV(amount, callback);
        }

        public void MoveHExact(int amount)
        {
            Contacts.SyncCollider();
            sourceOwner.MoveHExact(amount);
        }

        public bool MoveVExact(int amount)
        {
            Contacts.SyncCollider();
            return sourceOwner.MoveVExact(amount);
        }

        void global::Celeste.Simulation.Gameplay.Player.Movement.INormalWorld.MoveVExact(int amount) =>
            MoveVExact(amount);

        void global::Celeste.Simulation.Gameplay.Player.Audio.Frame.IPlayerFrameWorld.MoveVExact(int amount) =>
            MoveVExact(amount);

        void global::Celeste.Simulation.Gameplay.Player.Collision.Responses.IPlayerCollisionWorld.
            MoveVExact(int amount) => MoveVExact(amount);

        public void NudgePosition(Vector2 amount) => Body.Position += amount;

        public global::Celeste.Simulation.Gameplay.Platforms.Foundation.SourcePlatformEntityState CollisionSurface(
            PixelCollision collision)
            => collision.Hit as global::Celeste.Simulation.Gameplay.Platforms.Foundation.SourcePlatformEntityState;

        public global::Celeste.Simulation.Gameplay.Platforms.Audio.SourceSurfaceSoundSelection PlatformByPriority(
            Vector2 offset, bool solidOnly = false)
            => sourceOwner.FrameCallbackPlatform(Position + offset, solidOnly ? "Celeste.Solid" : "Celeste.Platform");

        public global::Celeste.Simulation.Gameplay.Platforms.Audio.SourceSurfaceSoundSelection LandingSurface()
            => PlatformByPriority(Vector2.UnitY);

        public void CorrectJumpThrus()
        {
            var registry = ((global::Celeste.Scene.Tracking.ISourceScene)sourceOwner.Scene).SourceScene.Entities;
            foreach (var entity in registry.GetTrackedEntities("Celeste.JumpThru"))
            {
                var platform =
                    (global::Celeste.Simulation.Gameplay.Platforms.Foundation.SourceJumpThruEntityState)entity;
                if (SourceEntityCollision.Check(sourceOwner, platform)
                    && sourceOwner.Bottom - platform.Top <= 6f
                    && !DashCorrectBlocked(Vector2.UnitY * (platform.Top - sourceOwner.Bottom)))
                    MoveVExact((int)(platform.Top - sourceOwner.Bottom));
            }
        }

        public void RedDashCorrectJumpThrus()
        {
            var registry = ((global::Celeste.Scene.Tracking.ISourceScene)sourceOwner.Scene).SourceScene.Entities;
            foreach (var entity in registry.GetTrackedEntities("Celeste.JumpThru"))
            {
                var platform =
                    (global::Celeste.Simulation.Gameplay.Platforms.Foundation.SourceJumpThruEntityState)entity;
                if (SourceEntityCollision.Check(sourceOwner, platform)
                    && sourceOwner.Bottom - platform.Top <= 6f)
                    MoveVExact((int)(platform.Top - sourceOwner.Bottom));
            }
        }

        public bool RefillDash() => sourceOwner.RefillDash();
        public void SyncCollider() => Contacts.SyncCollider();

        public void RedDashDust(float direction, int count)
        {
            ((global::Celeste.Simulation.Gameplay.Player.Scene.Effects.ISourcePlayerDashEffectsScene)sourceOwner.Level)
                .BurstPlayerDashDust(Position, direction, count);
            PublishDust(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Particles,
                "RedDashDust",
                new global::Celeste.Simulation.Gameplay.Player.Presentation.Particles.PlayerDustEmission(Position,
                    direction, count));
        }

        public void RedDashDisplacement()
        {
            Contacts.SyncCollider();
            global::Celeste.Core.Geometry.Bounds bounds = Body.Hitbox;
            var center = Body.Position + new Vector2(bounds.X + bounds.Width / 2f, bounds.Y + bounds.Height / 2f);
            ((global::Celeste.Simulation.Gameplay.Player.Scene.Effects.ISourcePlayerDashEffectsScene)sourceOwner.Level)
                .AddPlayerDashBurst(center, .5f, 0f, 80f, .666f);
            Publish(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Displacement, "RedDash", .5f,
                center, new Vector2(0, 80));
        }

        public void ClimbHop()
        {
            if (motor == null) throw new InvalidOperationException("Bind the room motor before using its ledge hop.");
            motor.Climb.Hop();
        }

        public void Jump() =>
            Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Standard, Data.Facing);

        public bool JumpFromWater()
        {
            var water = FirstWaterAt(Vector2.UnitY * 2);
            if (water == null) return false;
            Jump();
            water.TopSurface.DoRipple(Position, 1f);
            return true;
        }

        public void Jump(global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump kind, int direction)
        {
            switch (kind)
            {
                case global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Standard: sourceOwner.Jump(); break;
                case global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Climb:
                    sourceOwner.ClimbJump(); break;
                case global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Super:
                    sourceOwner.SuperJump(); break;
                case global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.SuperWall:
                    sourceOwner.SuperWallJump(direction); break;
                case global::Celeste.Simulation.Gameplay.Player.Movement.PlayerJump.Wall:
                    sourceOwner.WallJump(direction); break;
            }
        }

        private void Sound(string name, float value = 0, string parameter = null)
        {
            Publish(new global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEvent(
                global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Sound,
                Position, Vector2.Zero, "event:/char/madeline/" + name, value, parameter: parameter));
        }

        public void PlayLanding(bool footstep, int surfaceIndex) =>
            Sound(footstep ? "footstep" : "landing", surfaceIndex, "surface_index");

        public void LandingDust(int surfaceIndex) => PublishDust(
            global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Particles, "LandingDust",
            new global::Celeste.Simulation.Gameplay.Player.Presentation.Particles.PlayerDustEmission(Position,
                -(float)Math.PI / 2, 8, surfaceIndex));

        public void WallSlideParticles(int direction) => sourceOwner.CreateWallSlideParticles(direction);

        public void SkidDust() => PublishDust(
            global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.SkidDust, "SkidDust",
            new global::Celeste.Simulation.Gameplay.Player.Presentation.Particles.PlayerDustEmission(Position,
                -(float)Math.PI / 2, 1));

        private void PublishDust(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind kind,
            string name, global::Celeste.Simulation.Gameplay.Player.Presentation.Particles.PlayerDustEmission dust,
            global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform platform = null)
            => Publish(new global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEvent(kind, dust.Position,
                new Vector2((float)Math.Cos(dust.Angle), (float)Math.Sin(dust.Angle)), name, dust.SurfaceIndex,
                platform, dust: dust));

        public void UpdateHiccups(float deltaTime) => sourceOwner.UpdateHiccups(deltaTime);
        public void UpdateIdleBookkeeping(float deltaTime) => sourceOwner.UpdateIdleBookkeeping(deltaTime);
        public void FlushSpriteReset() => sourceOwner.FlushSpriteReset();
        public void ToggleFlash() => sourceOwner.ToggleFlash();
        public void ResetSweat() => PlaySweat("idle");
        public void PlaySweat(string animation) => PlaySweat(animation, false);

        public void PlaySweat(string animation, bool restart) => sourceOwner.Sweat.Play(animation, restart);

        public void SpeedRing() => CreateSpeedRing(false);
        public void SpeedRingUp() => CreateSpeedRing(true);

        private void CreateSpeedRing(bool upwards)
        {
            var level = sourceOwner.Level;
            var ring = ((global::Celeste.Graphics.Effects.SpeedRings.ISourceSpeedRingEnvironment)EngineContext)
                .CreateSpeedRing();
            var initialized = ring.Init(sourceOwner.Center,
                upwards
                    ? (float)Math.PI / 2f
                    : global::Celeste.Core.Mathematics.Vector2Geometry.Angle(Data.Motion.Normal.Speed),
                global::Celeste.Core.Display.PackedColor.White);
            ((global::Celeste.Scene.Tracking.ISourceScene)level).SourceScene.QueueSourceEntity(
                (global::Celeste.Core.Components.ISourceEntityUpdate)initialized);
        }

        public void Emit(global::Celeste.Simulation.Gameplay.Player.Dash.DashEffect effect)
        {
            if (effect == global::Celeste.Simulation.Gameplay.Player.Dash.DashEffect.Particle)
                sourceOwner.EmitNormalDashParticle();
            if (effect == global::Celeste.Simulation.Gameplay.Player.Dash.DashEffect.Trail)
                sourceOwner.CreateTrail();
            if (effect == global::Celeste.Simulation.Gameplay.Player.Dash.DashEffect.Rumble)
                sourceOwner.Rumble(2, 1);
            if (effect == global::Celeste.Simulation.Gameplay.Player.Dash.DashEffect.DirectionalShake)
                ((global::Celeste.Simulation.Presentation.ScreenEffects.ISourceLevelShakeScene)sourceOwner.Level)
                    .DirectionalShake(Data.Direction, .2f);
            if (effect == global::Celeste.Simulation.Gameplay.Player.Dash.DashEffect.Displacement)
                ((global::Celeste.Simulation.Gameplay.Player.Scene.Effects.ISourcePlayerDashEffectsScene)sourceOwner
                        .Level)
                    .AddPlayerDashBurst(sourceOwner.Center, .4f, 8f, 64f, .5f);
            if (effect == global::Celeste.Simulation.Gameplay.Player.Dash.DashEffect.Slash)
                sourceOwner.CreateDashSlash(sourceOwner.Center,
                    global::Celeste.Core.Mathematics.Vector2Geometry.Angle(Data.Direction));
            if (effect == global::Celeste.Simulation.Gameplay.Player.Dash.DashEffect.FeatherBoost)
                ((global::Celeste.Simulation.Gameplay.Player.Scene.Particles.ISourcePlayerStarFlyScene)sourceOwner
                        .Level)
                    .EmitStarFlyParticles(true, 12, sourceOwner.Center, Vector2.One * 4f,
                        global::Celeste.Core.Mathematics.Vector2Geometry.Angle(-Data.Direction));
            if (effect == global::Celeste.Simulation.Gameplay.Player.Dash.DashEffect.DashStarted)
            {
                bool boosted = Interactions.TryBoosterBoosted?.Invoke(this, Data.Direction) ?? false;
                if (!boosted && Interactions.BoosterBoosted != null)
                {
                    Interactions.BoosterBoosted(this, Data.Direction);
                    boosted = true;
                }

                if (!boosted)
                {
                    TotalDashes++;
                    if (SaveStatistics != null) SaveStatistics.TotalDashes++;
                    if (sourceOwner?.Level is
                        global::Celeste.Simulation.Gameplay.Player.Statistics.ISourcePlayerDashStatisticsScene
                        statistics)
                        statistics.RegisterPlayerDash();
                    bool right = Data.Direction == Vector2.Zero
                        ? Data.Facing == 1
                        : Data.Direction.Y < 0 || Data.Direction.Y == 0 && Data.Direction.X > 0;
                    Sound("dash_" + (Data.WasDashB ? "pink_" : "red_") + (right ? "right" : "left"));
                    if (SwimCheck()) Sound("water_dash_gen");
                    Interactions.DashStarted?.Invoke(this, Data.Direction);
                }
            }

            Publish(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Dash, effect.ToString(),
                position: Center, direction: Data.Direction);
        }

        public void Emit(global::Celeste.Simulation.Gameplay.Player.Movement.ClimbEffect effect)
        {
            if (effect == global::Celeste.Simulation.Gameplay.Player.Movement.ClimbEffect.GrabRumble)
                sourceOwner.Rumble(1, 0);
            if (effect == global::Celeste.Simulation.Gameplay.Player.Movement.ClimbEffect.BoosterRumble)
                sourceOwner.Rumble(0, 0);
            if (effect == global::Celeste.Simulation.Gameplay.Player.Movement.ClimbEffect.ClimbRumble)
                sourceOwner.Rumble(3, 0);
            if (effect == global::Celeste.Simulation.Gameplay.Player.Movement.ClimbEffect.ConveyorStart)
                sourceOwner.StartConveyorAudio();
            if (effect == global::Celeste.Simulation.Gameplay.Player.Movement.ClimbEffect.ConveyorStop)
                sourceOwner.EndConveyorAudio();
            if (effect == global::Celeste.Simulation.Gameplay.Player.Movement.ClimbEffect.ConveyorPosition)
                sourceOwner.PositionConveyorAudio();
            if (effect == global::Celeste.Simulation.Gameplay.Player.Movement.ClimbEffect.LetGo) Sound("grab_letgo");
            if (effect == global::Celeste.Simulation.Gameplay.Player.Movement.ClimbEffect.LedgeHop)
                Sound("climb_ledge");
            if (effect == global::Celeste.Simulation.Gameplay.Player.Movement.ClimbEffect.GrabSurface)
                sourceOwner.PlayClimbGrabSurface();

            Publish(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Climb, effect.ToString(),
                position: Center,
                direction: Vector2.UnitX * Data.Facing);
        }

        public void Emit(global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect effect)
        {
            if (effect == global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect
                    .FeatherBump)
                sourceOwner.Play("event:/game/06_reflection/feather_state_bump");
            if (effect == global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect
                    .FeatherRumble)
                sourceOwner.Rumble(0, 1);
            if (effect == global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect
                    .RedDashRumble)
                sourceOwner.Rumble(1, 0);
            if (effect == global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect
                    .LandRumble)
                sourceOwner.Rumble(0, 0);
            if (effect == global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect
                    .RunStumble)
                sourceOwner.Sprite.Play("runStumble");
            var center = Center;
            if (effect == global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionEffect
                    .RedDashBurst)
            {
                global::Celeste.Core.Geometry.Bounds bounds = Body.Hitbox;
                center = Body.Position + new Vector2(bounds.X + bounds.Width / 2f, bounds.Y + bounds.Height / 2f);
                ((global::Celeste.Simulation.Gameplay.Player.Scene.Effects.ISourcePlayerDashEffectsScene)sourceOwner
                        .Level)
                    .AddPlayerDashBurst(center, .5f, 8f, 48f, .4f);
            }

            Publish(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Collision, effect.ToString(),
                position: center);
        }
    }
}
