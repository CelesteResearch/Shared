using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay;
using Celeste.Scene.Following;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Camera;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Interaction.Talking;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision;
using Celeste.Simulation.Gameplay.Player.Configuration;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Gameplay.Player.Dummy;
using Celeste.Simulation.Gameplay.Player.Events;
using Celeste.Simulation.Gameplay.Player.Launch;
using Celeste.Simulation.Gameplay.Player.Presentation.Animation;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.Respawn;
using Celeste.Simulation.Gameplay.Player.Runtime;
using Celeste.Simulation.Gameplay.Player.Scene.Bounds;
using Celeste.Simulation.Gameplay.Player.State;
using Celeste.Simulation.Runtime.FramePacing;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    // A room host with an explicit engine/input clock. Rendering and native device APIs
    // are deliberately outside this class so recorded inputs can drive the same session.
    public sealed partial class
        RoomPlayerSession : SourceActorEntityState
    {
        public readonly PlayerState Data = new();

        public readonly IPlayerAssistSettings Settings;
        public readonly ISourceGameInput Input;
        public readonly SimulationStateMachine Machine;
        public readonly RoomPlayerWorld World;
        public readonly PlayerMotor Motor;

        public readonly SpecialPlayerState Special = new();

        public readonly HitSquashSequence HitSquash;
        public readonly LaunchSequence Launch;
        public PlayerSprite Sprite;
        public PlayerSpriteMode DefaultSpriteMode;
        public Sprite Sweat;
        public PlayerHair Hair;
        public readonly PlayerHairAppearance Appearance;
        public readonly PlayerRespawnSequence Respawn;
        public readonly PlayerHoldingController Holding;
        public readonly PlayerDummyController Dummy;
        private readonly PlayerBoostSequence boostSequence;
        public LeaderState Leader;
        public bool Dead { get; private set; }


        // Player.Die queues removal; the tracker retains the player until the
        // next scene frame commits that removal and adds the corpse.
        public bool PlayerEntityPresent => Scene != null;
        public bool JustRespawned { get; set; }
        public int EngineFrame => unchecked((int)EngineContext.Frame.FrameCounter);

        public RoomEngineFrameResult LastEngineFrameResult =>
            EngineContext.Frame.SceneUpdatedThisFrame
                ? RoomEngineFrameResult.SceneUpdated
                : RoomEngineFrameResult.EngineSuppressed;

        public bool Flash { get; private set; }

        internal void ToggleFlash()
        {
            Flash = !Flash;
        }

        private float rawDelta;


        // Engine-owned SoundSource adapters. The conditions are evaluated at the
        // same two Player.Update sites as wallSlideSfx and swimSurfaceLoopSfx;
        // simulation never owns an FMOD handle.


        // Player.cs constructs these two SoundSource Components after StateMachine
        // and Leader. Their identities survive temporary scene removal/re-add.
        public SoundSourceComponentState WallSlideSoundComponent { get; private set; }

        public SoundSourceComponentState SwimSurfaceSoundComponent { get; private set; }

        public bool UpdatingComponents => Components.LockMode ==
                                          SourceOwnedComponentList.LockModes.Locked;

        public RoomPlayerSession(Vector2 spawn,
            IPlayerAssistSettings settings,
            ISourceGameInput input, ISourceEngineContext engineContext,
            PlatformCollisionWorld platformWorld,
            IReadOnlyDictionary<string, string> chaseSoundMapping,
            PlayerSpriteMode mode = PlayerSpriteMode.Madeline)
            : base(new(platformWorld, new((int)spawn.X, (int)spawn.Y),
                    new(-4, -11, 8, 11), .16f), engineContext,
                ((ISourcePlatformTargetMotionEnvironment)
                    engineContext).TargetMotionPolicy)
        {
            Data.Dashes = 0;
            Data.Facing = 0;
            EngineContext = engineContext ?? throw new ArgumentNullException(nameof(engineContext));
            ChaseHistory =
                new(this, chaseSoundMapping);
            Settings = settings;
            Input = input;
            Input.ResetGrab(); // Player's constructor resets only the global grab toggle.
            DefaultSpriteMode = mode;
            Depth = 0;
            Tags =
                ((ISourcePersistentTransitionExecutionTagsEnvironment)
                    engineContext).PersistentTransitionExecutionTags.Persistent.Value;
            World = new(Data, settings, input, Body, this, engineContext.Effects, platformWorld,
                engineContext);
            if (Settings.PlayAsBadeline)
                mode = PlayerSpriteMode
                    .MadelineAsBadeline;
            Sprite = new(engineContext,
                mode);
            Hair = new(Sprite, engineContext);
            Components.Add(Hair);
            Components.Add(Sprite);
            Hair.Color = mode == PlayerSpriteMode
                .MadelineAsBadeline
                ? PlayerHairAppearance
                    .NormalBadelineHairColor
                : PlayerHairAppearance.NormalHairColor;
            Appearance =
                new(engineContext)
                    { StartHairCount = Sprite.HairCount };
            Sweat = ((ISourceGameGraphicsEnvironment)engineContext).GameGraphics
                .SpriteFactory.Create("player_sweat");
            Components.Add(Sweat);
            World.Contacts.SetDucking(false);
            Machine = ((ISourceStateMachineEnvironment)engineContext).StateMachines
                .Create(engineContext, 26);
            Components.Add(Machine);
            Data.Motion.ReadActualDucking = () => World.Contacts.Ducking;
            Data.Motion.SetActualDucking = World.Contacts.SetDucking;
            World.Interactions.FreezeRequested = Freeze;
            World.Interactions.PlayerOverTalk = _ =>
                ((ISourceTalkHoverEnvironment)
                    engineContext).HasTalkHover;
            World.Interactions.DashStarted = (_, direction) =>
            {
                foreach (DashListenerState listener in
                         ((ISourceScene)Scene).SourceScene.Components
                         .GetTrackedComponents("Celeste.DashListener"))
                    listener.OnDash?.Invoke(direction);
            };
            // Player starts facing right. SpawnFacingTrigger is resolved by
            // Player.Added, after earlier room entities have received Added.
            Motor = new(Data, settings, input, Body,
                Machine, World, engineContext);
            World.Bind(Motor);
            boostSequence =
                new(this, Data, settings, input,
                    Body, Machine, Motor.Dash, World);
            Machine.SetCallbacks(9, DreamDashUpdate, null, DreamDashBegin, DreamDashEnd);
            World.Interactions.TryBoosterBoosted = (_, __) => boostSequence.TryCallBoosterDashEvent();
            World.Interactions.Chapter9BoosterBusy = _ => boostSequence.Chapter9BoosterBusy;
            HitSquash = new(Data, Special, input,
                Machine, Motor.Dash, World, engineContext);
            Launch = new(Data, Special, input, Machine,
                Motor.Dash, World, engineContext);
            Data.Motion.Normal.BindSpriteScaleOwner(this);
            BindSummitLaunch();
            BindStarFly();
            BindAttract();
            BindFlingBird();
            Holding = new(World, this);
            Data.BindActualHolding(Holding);
            Dummy = new(World);
            // Player.Added owns StartHair; constructor nodes retain their CLR values.
            Machine.SetCallbacks(18, ReflectionFallUpdate, ReflectionFallCoroutine, ReflectionFallBegin,
                ReflectionFallEnd);
            Machine.SetCallbacks(21, CassetteFlyUpdate, CassetteFlyCoroutine, CassetteFlyBegin, CassetteFlyEnd);
            Intro = new(Data, Machine, Hair,
                new IntroWorld(this), engineContext);
            BindTempleFall();
            BindDashAssistEvents();
            BindBirdDash();
            Respawn = new(this);
            Motor.UpdateOwnedComponents = UpdateOwnedComponents;
            BindChaseHistory();
            BindAudioEvents();
            ConstructSourceComponents();
            BindFrameAudio();
            BindIdle();
            Components.Add(Reflection);
            if (((ISourcePlayerRuntimeEnvironment)engineContext)
                .PlayerRuntimePolicy is
                ISourcePlayerStateRegistrationPolicy
                stateRegistration)
                stateRegistration.RegisterStates(this);
        }


        private void Report(RoomPlayerEventKind kind, string name,
            Vector2 position, float value = 0,
            Vector2 direction = default)
        {
            World.Report(
                new(kind, position, direction, name,
                    value));
        }

        private void UpdateOwnedComponents(float dt, float rawDt)
        {
            Appearance.UpdatePhysics(Data, Machine.State, Hair, World.SceneTime, dt);
            base.Update();
            Light.Position = Data.Motion.Ducking ? DuckingLightOffset : NormalLightOffset;
        }

        public void Freeze(float duration)
        {
            ((ISourceFreezeEnvironment)EngineContext).Freeze(duration);
        }

        // The actual Player body. Level, scene, input and Engine phases are separate owners.
        public void UpdateActualPlayer(float deltaTime, float rawDeltaTime)
        {
            ((ISourcePlayerRuntimeEnvironment)EngineContext)
                .PlayerRuntimePolicy.Update(this, deltaTime, rawDeltaTime);
        }

        public void UpdateSourceBody(float deltaTime, float rawDeltaTime)
        {
            rawDelta = rawDeltaTime;
            UpdatePlayer(deltaTime);
        }

        private void UpdatePlayer(float dt)
        {
            Motor.UpdateMotion(dt, rawDelta);
            UpdateSourceWallSlideSound();
            PlayerAnimation.Update(Data,
                Machine.State, Sprite,
                new()
                {
                    InputMoveX = Input.MoveX.Value, InputMoveY = Input.MoveY.Value,
                    InSpace = World.InSpace, WindDirection = Appearance.WindDirection,
                    WindTimeout = Appearance.WindTimeout,
                }, World, dt);
            Holding.UpdateCarry();
            UpdateSourceSwimSurfaceSound();
            if (Machine.State != 18) CheckSourcePlayerTriggers();
            StrawberriesBlocked = CollideBlockField();
            ((ISourcePlayerCameraScene)Scene).PlayerCamera.Follow(this, dt);
            CheckPlayerColliders();
            if (Dead) return;
            if (PlayerFrameMotion.InControl(Machine.State) &&
                Machine.State != 9)
                ((ISourcePlayerBoundsScene)Level)
                    .EnforceBounds(this);
            CaptureChaseState();
            UpdateHair(true);
            UpdateChaseTail();
            // The original stores wasDucking after UpdateHair and bounds handling,
            // before the final onGround/wasOnGround bookkeeping.
            Data.WasDucking = Data.Motion.Ducking;
            Motor.FinishFrame();
        }

        public bool FlipInReflection;
    }
}
