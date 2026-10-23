using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Effects.SpeedRings;
using Celeste.Input.Gameplay;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Scene.Lifecycle;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Collectibles.Strawberry;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Environment.Space;
using Celeste.Simulation.Gameplay.Environment.Water;
using Celeste.Simulation.Gameplay.Environment.Wind;
using Celeste.Simulation.Gameplay.Hazards.Spikes;
using Celeste.Simulation.Gameplay.Hazards.TriggerSpikes.Components;
using Celeste.Simulation.Gameplay.Platforms.Audio;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.DreamBlock;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Movement;
using Celeste.Simulation.Gameplay.Platforms.SwapBlocks;
using Celeste.Simulation.Gameplay.Player.Audio.Frame;
using Celeste.Simulation.Gameplay.Player.Collision;
using Celeste.Simulation.Gameplay.Player.Collision.Contacts;
using Celeste.Simulation.Gameplay.Player.Collision.Responses;
using Celeste.Simulation.Gameplay.Player.Configuration;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Gameplay.Player.Events;
using Celeste.Simulation.Gameplay.Player.Inventory;
using Celeste.Simulation.Gameplay.Player.Launch;
using Celeste.Simulation.Gameplay.Player.Movement;
using Celeste.Simulation.Gameplay.Player.Presentation.Animation;
using Celeste.Simulation.Gameplay.Player.Presentation.Particles;
using Celeste.Simulation.Gameplay.Player.Runtime;
using Celeste.Simulation.Gameplay.Player.Scene;
using Celeste.Simulation.Gameplay.Player.Scene.Effects;
using Celeste.Simulation.Gameplay.Player.Scene.Particles;
using Celeste.Simulation.Gameplay.Player.State;
using Celeste.Simulation.Gameplay.Player.Statistics;
using Celeste.Simulation.Presentation.ScreenEffects;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerWorld : IPlayerMotorWorld,
        IPlayerAnimationWorld,
        IHitSquashWorld,
        ILaunchWorld,
        IPlayerBoostWorld,
        IPlayerDirectionalCollisionWorld
    {
        public readonly PlayerState Data;
        public readonly IPlayerAssistSettings Settings;
        public readonly ISourceGameInput Input;
        public SimulationStateMachine Machine => SourcePlayer.Machine;

        public PlatformCollisionWorld Platforms =>
            ((ISourcePlatformCollisionScene)SourcePlayer.Scene)
            .PlatformWorld;

        public readonly PixelActor Body;
        public readonly PlayerContacts Contacts;

        public readonly RoomPlayerInteractions Interactions = new();

        private PlayerMotor motor;

        private readonly List<RoomPlayerEvent> events = [];

        public IReadOnlyList<RoomPlayerEvent> Events => events;
        public event Action<RoomPlayerEvent> Emitted;
        public readonly ISourceEngineContext EngineContext;
        public RoomPlayerSession SourcePlayer { get; }

        public float SceneTime => ((ISourceSceneTime)SourcePlayer.Scene).TimeActive;
        public SourceEngineEffectsState EngineEffects { get; }

        public float FreezeRemaining
        {
            get => EngineEffects.FreezeTimer;
            set => EngineEffects.FreezeTimer = value;
        }

        public bool Cold =>
            ((ISourceCoreModeScene)SourcePlayer.Level)
            .CoreMode == RoomCoreMode.Cold;

        public bool CoreHot =>
            ((ISourceCoreModeScene)SourcePlayer.Level)
            .CoreMode == RoomCoreMode.Hot;

        public bool InSpace =>
            ((ISourceSpaceScene)SourcePlayer.Level).InSpace;

        public float WindY =>
            ((ISourceWindScene)
                SourcePlayer.Level).Wind.Y;

        public bool HoldingSlowRun => SourcePlayer.Holding.Holding is { } held && held.SlowRun;
        public bool HoldingSlowFall => SourcePlayer.Holding.Holding is { } held && held.SlowFall;

        public bool InCutscene =>
            ((ISceneCutsceneState)SourcePlayer.Level).InCutscene;

        public bool NoRefills
        {
            get => SourcePlayer.Inventory.NoRefills;
            set
            {
                var scene =
                    (ISourcePlayerInventoryScene)SourcePlayer.Level;
                var inventory = scene.Inventory;
                inventory.NoRefills = value;
                scene.Inventory = inventory;
            }
        }

        public int InventoryDashes
        {
            get => SourcePlayer.Inventory.Dashes;
            set
            {
                var scene =
                    (ISourcePlayerInventoryScene)SourcePlayer.Level;
                var inventory = scene.Inventory;
                inventory.Dashes = value;
                scene.Inventory = inventory;
            }
        }

        public bool InventoryDreamDash
        {
            get => SourcePlayer.Inventory.DreamDash;
            set
            {
                var scene =
                    (ISourcePlayerInventoryScene)SourcePlayer.Level;
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
            SourcePlayer.Leader
                .HasFollower<
                    ISourceStrawberrySeedFollower>();

        public string DefaultJumpThruTexture { get; set; } = "wood";
        public bool ConveyorLoopActive => SourcePlayer.ConveyorLoopActive;
        public string SweatAnimation => SourcePlayer.Sweat.CurrentAnimationID;
        public IPlayerActionStatistics SaveStatistics;
        public int TotalJumps { get; private set; }
        public int TotalWallJumps { get; private set; }
        public int TotalDashes { get; private set; }

        public RoomPlayerWorld(PlayerState data,
            IPlayerAssistSettings settings,
            ISourceGameInput input,
            PixelActor body,
            RoomPlayerSession sourceOwner, SourceEngineEffectsState engineEffects,
            PlatformCollisionWorld platformWorld,
            ISourceEngineContext engine)
        {
            EngineContext = engine;
            SourcePlayer = sourceOwner ?? throw new ArgumentNullException(nameof(sourceOwner));
            EngineEffects = engineEffects ?? throw new ArgumentNullException(nameof(engineEffects));
            Data = data;
            Settings = settings;
            Input = input;
            if (platformWorld == null) throw new ArgumentNullException(nameof(platformWorld));
            Body = body;
            Contacts = new(Body, data,
                sourceOwner);
            Data.Motion.DuckingChanged = Contacts.SyncCollider;
        }

        public void Bind(PlayerMotor value)
        {
            if (value == null || value.Body != Body || value.Data != Data || value.Machine != Machine)
                throw new ArgumentException("The motor must use this room's body, data and state machine.",
                    nameof(value));
            motor = value;
        }

        public void ClearEvents()
        {
            events.Clear();
        }

        public void Report(RoomPlayerEvent value)
        {
            Publish(value);
        }

        private void Publish(RoomPlayerEvent value)
        {
            events.Add(value);
            Emitted?.Invoke(value);
        }

        private void Publish(RoomPlayerEventKind kind, string name,
            float value = 0, Vector2? position = null,
            Vector2? direction = null,
            CollisionPlatform platform = null)
        {
            Publish(new(kind, position ?? Position,
                direction ?? Vector2.Zero, name, value, platform));
        }

        public Vector2 Position => Body.Position;

        public Vector2 LiftSpeed
        {
            get => SourcePlayer.LiftSpeed;
            set => SourcePlayer.LiftSpeed = value;
        }

        public Bounds Bounds => Contacts.BoundsAt(Vector2.Zero);
        public Vector2 Center => new(Bounds.X + Bounds.Width / 2f, Bounds.Y + Bounds.Height / 2f);
        public float PlayerCenterY => Center.Y;
        public bool DashAttacking => SourcePlayer.DashAttacking;
        public bool CanUnDuck => Contacts.CanUnDuck;
        public bool InWater => Contacts.WaterAt(Vector2.Zero);
        public bool DreamDashIntoBlock => InventoryDreamDash && FirstDreamBlockAt(Vector2.UnitY) != null;
        public bool PlayerOverTalk => Interactions.PlayerOverTalk?.Invoke(this) ?? false;
        public bool Chapter9BoosterBusy => Interactions.Chapter9BoosterBusy?.Invoke(this) ?? false;
        public bool ParticleInterval => OnInterval(.02f);

        public bool OnInterval(float interval)
        {
            return ((ISourceScene)SourcePlayer.Scene).SourceScene.Clock
                .OnInterval(interval, EngineContext);
        }

        public bool CanUnDuckAt(Vector2 offset)
        {
            return Contacts.CanUnDuckAt(offset);
        }

        public bool SolidAt(Vector2 offset)
        {
            return Contacts.SolidAt(offset);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        bool INormalWorld.SolidAt(Vector2 offset)
        {
            return Contacts.SolidAt(offset);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        bool IClimbWorld.SolidAt(Vector2 offset)
        {
            return Contacts.SolidAt(offset);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        bool IPlayerMovementWorld.SolidAt(Vector2 offset)
        {
            return Contacts.SolidAt(offset);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        bool IPlayerAnimationWorld.SolidAt(
            Vector2 offset)
        {
            return Contacts.SolidAt(offset);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        bool IPlayerAnimationWorld.SolidPointAt(
            Vector2 offset)
        {
            return SolidPointAt(offset);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        bool IPlayerDirectionalCollisionWorld.
            HorizontalSolidAt(Vector2 offset)
        {
            return Contacts.SolidAt(offset);
        }

        public bool SolidPointAt(Vector2 offset)
        {
            return Platforms.SolidAt(Position + offset);
        }

        public bool DuckFreeAt(Vector2 offset)
        {
            return Contacts.DuckFreeAt(offset);
        }

        public bool GroundAt(Vector2 offset)
        {
            return Contacts.GroundAt(offset);
        }

        public bool JumpThruAt(Vector2 offset)
        {
            return Contacts.JumpThruAt(offset);
        }

        public bool JumpThruOutsideAt(Vector2 offset)
        {
            return Contacts.JumpThruOutsideAt(offset);
        }

        public bool JumpThruBoostBlocked()
        {
            return Contacts.JumpThruBoostBlocked();
        }

        public bool DashCorrectBlocked(Vector2 offset)
        {
            return Contacts.DashCorrectBlocked(offset);
        }

        public bool ClimbBoundsCheck(int direction)
        {
            return Contacts.ClimbBoundsCheck(direction);
        }

        public bool ClimbCheck(int direction, int yOffset = 0)
        {
            return Contacts.ClimbCheck(direction, yOffset);
        }

        bool ISwimWorld.ClimbCheck(int direction)
        {
            return Contacts.ClimbCheck(direction);
        }

        bool IHitSquashWorld.ClimbCheck(int direction)
        {
            return Contacts.ClimbCheck(direction);
        }

        public bool ClimbEdgeBlocked(int xOffset)
        {
            return Contacts.ClimbBlocked(Vector2.UnitX * xOffset, true);
        }

        public bool ClimbBlocked(int xOffset)
        {
            return Contacts.ClimbBlocked(Vector2.UnitX * xOffset);
        }

        public bool WallJumpCheck(int direction)
        {
            return Contacts.WallJumpCheck(direction);
        }

        public bool WallBoosterCheck()
        {
            return Contacts.WallBoosterCheck();
        }

        public bool SlipCheck(float addY = 0f)
        {
            return Contacts.SlipCheck(addY);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool ClimbHopBlockedCheck()
        {
            return Contacts.ClimbHopBlocked(HasStrawberrySeedFollower);
        }

        public bool SwimCheck()
        {
            return Contacts.SwimCheck();
        }

        public bool SwimUnderwaterCheck()
        {
            return Contacts.SwimUnderwaterCheck();
        }

        public bool SwimJumpCheck()
        {
            return Contacts.SwimJumpCheck();
        }

        public bool SwimRiseCheck()
        {
            return Contacts.SwimRiseCheck();
        }

        public ISourceWater FirstWaterAt(Vector2 offset)
        {
            return Contacts.FirstWaterAt(offset);
        }

        public IMovingSolid FirstSolidAt(Vector2 offset)
        {
            return Platforms.FirstSolidAt(Contacts.BoundsAt(offset));
        }

        public ISourceDreamBlock FirstDreamBlockAt(
            Vector2 offset)
        {
            return SourceTrackedEntityCollision.FirstAt<
                ISourceDreamBlock>(
                ((ISourceScene)SourcePlayer.Scene).SourceScene.Entities,
                "Celeste.DreamBlock", SourcePlayer, SourcePlayer.Position + offset);
        }

        public bool SolidExceptDreamBlockAt(Vector2 offset)
        {
            return SourceTrackedEntityCollision.CheckAtExcept(
                ((ISourceScene)SourcePlayer.Scene).SourceScene.Entities,
                "Celeste.Solid", "Celeste.DreamBlock", SourcePlayer, SourcePlayer.Position + offset);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GroundAtOnePixel(out bool safe)
        {
            var registry = ((ISourceScene)SourcePlayer.Scene).SourceScene.Entities;
            var platform = SourceTrackedEntityCollision.FirstAt<
                SourcePlatformEntityState>(
                registry, "Celeste.Solid", SourcePlayer, SourcePlayer.Position + Vector2.UnitY);
            if (platform == null)
                platform = SourceTrackedEntityCollision.FirstOutsideAt<
                    SourcePlatformEntityState,
                    RoomPlayerSession>(
                    registry, "Celeste.JumpThru", SourcePlayer, SourcePlayer.Position + Vector2.UnitY);
            safe = platform != null && platform.Safe;
            return platform != null;
        }

        public bool SafeGroundBlocked()
        {
            var scene = (ISourceScene)SourcePlayer.Scene;
            foreach (var component in scene.SourceScene.Components.GetTrackedComponents("Celeste.SafeGroundBlocker"))
                if (((SafeGroundBlockerComponentState)component).Check(SourcePlayer))
                    return true;
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool RefillGroundAtOnePixel()
        {
            var registry = ((ISourceScene)SourcePlayer.Scene).SourceScene.Entities;
            return SourceTrackedEntityCollision.CheckAtExcept(
                       registry, "Celeste.Solid", "Celeste.NegaBlock", SourcePlayer,
                       SourcePlayer.Position + Vector2.UnitY)
                   || SourceTrackedEntityCollision
                       .FirstOutsideAt<object, RoomPlayerSession>(
                           registry, "Celeste.JumpThru", SourcePlayer, SourcePlayer.Position + Vector2.UnitY) != null;
        }

        public bool TouchingSpikes()
        {
            var scene = (ISourceScene)SourcePlayer.Scene;
            foreach (var entry in scene.SourceScene.Entities.GetTrackedEntities("Celeste.Spikes"))
                if (SourceEntityCollision.Check(SourcePlayer,
                        (SpikesState)entry))
                    return true;
            return false;
        }

        public bool TryPickup()
        {
            return SourcePlayer.Holding.TryPickup();
        }

        public void Throw()
        {
            SourcePlayer.Holding.Throw();
        }

        public void Drop()
        {
            SourcePlayer.Holding.Drop();
        }

        public bool MatchingSwapBlockAhead(int direction)
        {
            var first = SourceTrackedEntityCollision
                .FirstAt<ISourceSwapBlock>(
                    ((ISourceScene)SourcePlayer.Scene).SourceScene.Entities,
                    "Celeste.SwapBlock", SourcePlayer,
                    SourceVector2Math.Add(SourcePlayer.Position,
                        SourceVector2Math.Multiply(Vector2.UnitX,
                            direction)));
            return first != null && first.Direction.X == direction;
        }

        public Vector2 SwapCancel(Vector2 direction)
        {
            var mask = Vector2.One;
            foreach (var entry in ((ISourceScene)SourcePlayer.Scene)
                     .SourceScene.Entities.GetTrackedEntities("Celeste.SwapBlock"))
            {
                var entity = (ISourceSwapBlock)entry;
                if (SourceEntityCollision.CheckAt(SourcePlayer, entity,
                        SourceVector2Math.Add(SourcePlayer.Position,
                            Vector2.UnitY))
                    && entity != null && entity.Swapping)
                {
                    if (direction.X != 0f && entity.Direction.X == Math.Sign(direction.X)) mask.X = 0f;
                    if (direction.Y != 0f && entity.Direction.Y == Math.Sign(direction.Y)) mask.Y = 0f;
                }
            }

            return mask;
        }

        public void Freeze(float duration)
        {
            SourcePlayer.Freeze(duration);
        }

        public void MoveTowardsX(float target, float maximumMove)
        {
            Contacts.SyncCollider();
            SourcePlayer.MoveTowardsX(target, maximumMove);
        }

        public void MoveH(float amount)
        {
            Contacts.SyncCollider();
            SourcePlayer.MoveH(amount);
        }

        public void MoveH(float amount, SourceCollisionHandler callback)
        {
            Contacts.SyncCollider();
            SourcePlayer.MoveH(amount, callback);
        }

        public void MoveV(float amount, SourceCollisionHandler callback)
        {
            Contacts.SyncCollider();
            SourcePlayer.MoveV(amount, callback);
        }

        public void MoveHExact(int amount)
        {
            Contacts.SyncCollider();
            SourcePlayer.MoveHExact(amount);
        }

        public bool MoveVExact(int amount)
        {
            Contacts.SyncCollider();
            return SourcePlayer.MoveVExact(amount);
        }

        void INormalWorld.MoveVExact(int amount)
        {
            MoveVExact(amount);
        }

        void IPlayerFrameWorld.MoveVExact(int amount)
        {
            MoveVExact(amount);
        }

        void IPlayerCollisionWorld.
            MoveVExact(int amount)
        {
            MoveVExact(amount);
        }

        public void NudgePosition(Vector2 amount)
        {
            Body.Position += amount;
        }

        public SourcePlatformEntityState CollisionSurface(
            PixelCollision collision)
        {
            return collision.Hit as SourcePlatformEntityState;
        }

        public SourceSurfaceSoundSelection PlatformByPriority(
            Vector2 offset, bool solidOnly = false)
        {
            return SourcePlayer.FrameCallbackPlatform(Position + offset,
                solidOnly ? "Celeste.Solid" : "Celeste.Platform");
        }

        public SourceSurfaceSoundSelection LandingSurface()
        {
            return PlatformByPriority(Vector2.UnitY);
        }

        public void CorrectJumpThrus()
        {
            var registry = ((ISourceScene)SourcePlayer.Scene).SourceScene.Entities;
            foreach (var entity in registry.GetTrackedEntities("Celeste.JumpThru"))
            {
                var platform =
                    (SourceJumpThruEntityState)entity;
                if (SourceEntityCollision.Check(SourcePlayer, platform)
                    && SourcePlayer.Bottom - platform.Top <= 6f
                    && !DashCorrectBlocked(Vector2.UnitY * (platform.Top - SourcePlayer.Bottom)))
                    MoveVExact((int)(platform.Top - SourcePlayer.Bottom));
            }
        }

        public void RedDashCorrectJumpThrus()
        {
            var registry = ((ISourceScene)SourcePlayer.Scene).SourceScene.Entities;
            foreach (var entity in registry.GetTrackedEntities("Celeste.JumpThru"))
            {
                var platform =
                    (SourceJumpThruEntityState)entity;
                if (SourceEntityCollision.Check(SourcePlayer, platform)
                    && SourcePlayer.Bottom - platform.Top <= 6f)
                    MoveVExact((int)(platform.Top - SourcePlayer.Bottom));
            }
        }

        public bool RefillDash()
        {
            return SourcePlayer.RefillDash();
        }

        public void SyncCollider()
        {
            Contacts.SyncCollider();
        }

        public void RedDashDust(float direction, int count)
        {
            ((ISourcePlayerDashEffectsScene)SourcePlayer.Level)
                .BurstPlayerDashDust(Position, direction, count);
            PublishDust(RoomPlayerEventKind.Particles,
                "RedDashDust",
                new(Position,
                    direction, count));
        }

        public void RedDashDisplacement()
        {
            Contacts.SyncCollider();
            var bounds = Body.Hitbox;
            var center = Body.Position + new Vector2(bounds.X + bounds.Width / 2f, bounds.Y + bounds.Height / 2f);
            ((ISourcePlayerDashEffectsScene)SourcePlayer.Level)
                .AddPlayerDashBurst(center, .5f, 0f, 80f, .666f);
            Publish(RoomPlayerEventKind.Displacement, "RedDash", .5f,
                center, new Vector2(0, 80));
        }

        public void ClimbHop()
        {
            if (motor == null) throw new InvalidOperationException("Bind the room motor before using its ledge hop.");
            motor.Climb.Hop();
        }

        public void Jump()
        {
            Jump(PlayerJump.Standard, Data.Facing);
        }

        public bool JumpFromWater()
        {
            var water = FirstWaterAt(Vector2.UnitY * 2);
            if (water == null) return false;
            Jump();
            water.TopSurface.DoRipple(Position, 1f);
            return true;
        }

        public void Jump(PlayerJump kind, int direction)
        {
            switch (kind)
            {
                case PlayerJump.Standard: SourcePlayer.Jump(); break;
                case PlayerJump.Climb:
                    SourcePlayer.ClimbJump(); break;
                case PlayerJump.Super:
                    SourcePlayer.SuperJump(); break;
                case PlayerJump.SuperWall:
                    SourcePlayer.SuperWallJump(direction); break;
                case PlayerJump.Wall:
                    SourcePlayer.WallJump(direction); break;
            }
        }

        private void Sound(string name, float value = 0, string parameter = null)
        {
            Publish(new(
                RoomPlayerEventKind.Sound,
                Position, Vector2.Zero, "event:/char/madeline/" + name, value, parameter: parameter));
        }

        public void PlayLanding(bool footstep, int surfaceIndex)
        {
            Sound(footstep ? "footstep" : "landing", surfaceIndex, "surface_index");
        }

        public void LandingDust(int surfaceIndex)
        {
            PublishDust(
                RoomPlayerEventKind.Particles, "LandingDust",
                new(Position,
                    -(float)Math.PI / 2, 8, surfaceIndex));
        }

        public void WallSlideParticles(int direction)
        {
            SourcePlayer.CreateWallSlideParticles(direction);
        }

        public void SkidDust()
        {
            PublishDust(
                RoomPlayerEventKind.SkidDust, "SkidDust",
                new(Position,
                    -(float)Math.PI / 2, 1));
        }

        private void PublishDust(RoomPlayerEventKind kind,
            string name, PlayerDustEmission dust,
            CollisionPlatform platform = null)
        {
            Publish(new(kind, dust.Position,
                new((float)Math.Cos(dust.Angle), (float)Math.Sin(dust.Angle)), name, dust.SurfaceIndex,
                platform, dust));
        }

        public void UpdateHiccups(float deltaTime)
        {
            SourcePlayer.UpdateHiccups(deltaTime);
        }

        public void UpdateIdleBookkeeping(float deltaTime)
        {
            SourcePlayer.UpdateIdleBookkeeping(deltaTime);
        }

        public void FlushSpriteReset()
        {
            SourcePlayer.FlushSpriteReset();
        }

        public void ToggleFlash()
        {
            SourcePlayer.ToggleFlash();
        }

        public void ResetSweat()
        {
            PlaySweat("idle");
        }

        public void PlaySweat(string animation)
        {
            PlaySweat(animation, false);
        }

        public void PlaySweat(string animation, bool restart)
        {
            SourcePlayer.Sweat.Play(animation, restart);
        }

        public void SpeedRing()
        {
            CreateSpeedRing(false);
        }

        public void SpeedRingUp()
        {
            CreateSpeedRing(true);
        }

        private void CreateSpeedRing(bool upwards)
        {
            var level = SourcePlayer.Level;
            var ring = ((ISourceSpeedRingEnvironment)EngineContext)
                .CreateSpeedRing();
            var initialized = ring.Init(SourcePlayer.Center,
                upwards
                    ? (float)Math.PI / 2f
                    : Vector2Geometry.Angle(Data.Motion.Normal.Speed),
                PackedColor.White);
            ((ISourceScene)level).SourceScene.QueueSourceEntity(
                (ISourceEntityUpdate)initialized);
        }

        public void Emit(DashEffect effect)
        {
            if (effect == DashEffect.Particle)
                SourcePlayer.EmitNormalDashParticle();
            if (effect == DashEffect.Trail)
                SourcePlayer.CreateTrail();
            if (effect == DashEffect.Rumble)
                SourcePlayer.Rumble(2, 1);
            if (effect == DashEffect.DirectionalShake)
                ((ISourceLevelShakeScene)SourcePlayer.Level)
                    .DirectionalShake(Data.Direction, .2f);
            if (effect == DashEffect.Displacement)
                ((ISourcePlayerDashEffectsScene)SourcePlayer
                        .Level)
                    .AddPlayerDashBurst(SourcePlayer.Center, .4f, 8f, 64f, .5f);
            if (effect == DashEffect.Slash)
                SourcePlayer.CreateDashSlash(SourcePlayer.Center,
                    Vector2Geometry.Angle(Data.Direction));
            if (effect == DashEffect.FeatherBoost)
                ((ISourcePlayerStarFlyScene)SourcePlayer
                        .Level)
                    .EmitStarFlyParticles(true, 12, SourcePlayer.Center, Vector2.One * 4f,
                        Vector2Geometry.Angle(-Data.Direction));
            if (effect == DashEffect.DashStarted)
            {
                var boosted = Interactions.TryBoosterBoosted?.Invoke(this, Data.Direction) ?? false;
                if (!boosted && Interactions.BoosterBoosted != null)
                {
                    Interactions.BoosterBoosted(this, Data.Direction);
                    boosted = true;
                }

                if (!boosted)
                {
                    TotalDashes++;
                    if (SaveStatistics != null) SaveStatistics.TotalDashes++;
                    if (SourcePlayer?.Level is
                        ISourcePlayerDashStatisticsScene
                        statistics)
                        statistics.RegisterPlayerDash();
                    var right = Data.Direction == Vector2.Zero
                        ? Data.Facing == 1
                        : Data.Direction.Y < 0 || (Data.Direction.Y == 0 && Data.Direction.X > 0);
                    Sound("dash_" + (Data.WasDashB ? "pink_" : "red_") + (right ? "right" : "left"));
                    if (SwimCheck()) Sound("water_dash_gen");
                    Interactions.DashStarted?.Invoke(this, Data.Direction);
                }
            }

            Publish(RoomPlayerEventKind.Dash, effect.ToString(),
                position: Center, direction: Data.Direction);
        }

        public void Emit(ClimbEffect effect)
        {
            if (effect == ClimbEffect.GrabRumble)
                SourcePlayer.Rumble(1, 0);
            if (effect == ClimbEffect.BoosterRumble)
                SourcePlayer.Rumble(0, 0);
            if (effect == ClimbEffect.ClimbRumble)
                SourcePlayer.Rumble(3, 0);
            if (effect == ClimbEffect.ConveyorStart)
                SourcePlayer.StartConveyorAudio();
            if (effect == ClimbEffect.ConveyorStop)
                SourcePlayer.EndConveyorAudio();
            if (effect == ClimbEffect.ConveyorPosition)
                SourcePlayer.PositionConveyorAudio();
            if (effect == ClimbEffect.LetGo) Sound("grab_letgo");
            if (effect == ClimbEffect.LedgeHop)
                Sound("climb_ledge");
            if (effect == ClimbEffect.GrabSurface)
                SourcePlayer.PlayClimbGrabSurface();

            Publish(RoomPlayerEventKind.Climb, effect.ToString(),
                position: Center,
                direction: Vector2.UnitX * Data.Facing);
        }

        public void Emit(PlayerCollisionEffect effect)
        {
            if (effect == PlayerCollisionEffect
                    .FeatherBump)
                SourcePlayer.Play("event:/game/06_reflection/feather_state_bump");
            if (effect == PlayerCollisionEffect
                    .FeatherRumble)
                SourcePlayer.Rumble(0, 1);
            if (effect == PlayerCollisionEffect
                    .RedDashRumble)
                SourcePlayer.Rumble(1, 0);
            if (effect == PlayerCollisionEffect
                    .LandRumble)
                SourcePlayer.Rumble(0, 0);
            if (effect == PlayerCollisionEffect
                    .RunStumble)
                SourcePlayer.Sprite.Play("runStumble");
            var center = Center;
            if (effect == PlayerCollisionEffect
                    .RedDashBurst)
            {
                var bounds = Body.Hitbox;
                center = Body.Position + new Vector2(bounds.X + bounds.Width / 2f, bounds.Y + bounds.Height / 2f);
                ((ISourcePlayerDashEffectsScene)SourcePlayer
                        .Level)
                    .AddPlayerDashBurst(center, .5f, 8f, 48f, .4f);
            }

            Publish(RoomPlayerEventKind.Collision, effect.ToString(),
                position: center);
        }
    }
}
