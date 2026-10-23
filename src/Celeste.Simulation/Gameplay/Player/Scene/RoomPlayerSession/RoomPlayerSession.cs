using Celeste.Simulation.Gameplay.Player.Presentation;
using Celeste.Scene.Following;
using Celeste.Graphics.Content.Atlas;
using Celeste.Physics.Collision;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation
{
    // A room host with an explicit engine/input clock. Rendering and native device APIs
    // are deliberately outside this class so recorded inputs can drive the same session.
    public sealed partial class
        RoomPlayerSession : global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState
    {
        public readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState Data =
            new global::Celeste.Simulation.Gameplay.Player.State.PlayerState();

        public readonly global::Celeste.Simulation.Gameplay.Player.Configuration.IPlayerAssistSettings Settings;
        public readonly ISourceGameInput Input;
        public readonly global::Celeste.Core.Scheduling.SimulationStateMachine Machine;
        public readonly RoomPlayerWorld World;
        public readonly global::Celeste.Simulation.Gameplay.Player.Runtime.PlayerMotor Motor;

        public readonly global::Celeste.Simulation.Gameplay.Player.State.SpecialPlayerState Special =
            new global::Celeste.Simulation.Gameplay.Player.State.SpecialPlayerState();

        public readonly global::Celeste.Simulation.Gameplay.Player.Collision.HitSquashSequence HitSquash;
        public readonly global::Celeste.Simulation.Gameplay.Player.Launch.LaunchSequence Launch;
        public global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSprite Sprite;
        public global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode DefaultSpriteMode;
        public global::Celeste.Graphics.Animation.Sprite Sweat;
        public global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHair Hair;
        public readonly global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHairAppearance Appearance;
        public readonly global::Celeste.Simulation.Gameplay.Player.Respawn.PlayerRespawnSequence Respawn;
        public readonly global::Celeste.Simulation.Gameplay.Holdables.PlayerHoldingController Holding;
        public readonly global::Celeste.Simulation.Gameplay.Player.Dummy.PlayerDummyController Dummy;
        private readonly global::Celeste.Simulation.Gameplay.Player.Dash.PlayerBoostSequence boostSequence;
        public LeaderState Leader;
        public bool Dead { get; private set; }


        // Player.Die queues removal; the tracker retains the player until the
        // next scene frame commits that removal and adds the corpse.
        public bool PlayerEntityPresent => Scene != null;
        public bool JustRespawned { get; set; }
        public int EngineFrame => unchecked((int)engineContext.Frame.FrameCounter);
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engineContext;

        public global::Celeste.Simulation.Runtime.FramePacing.RoomEngineFrameResult LastEngineFrameResult =>
            engineContext.Frame.SceneUpdatedThisFrame
                ? global::Celeste.Simulation.Runtime.FramePacing.RoomEngineFrameResult.SceneUpdated
                : global::Celeste.Simulation.Runtime.FramePacing.RoomEngineFrameResult.EngineSuppressed;

        public bool Flash { get; private set; }
        internal void ToggleFlash() => Flash = !Flash;
        private float rawDelta;


        // Engine-owned SoundSource adapters. The conditions are evaluated at the
        // same two Player.Update sites as wallSlideSfx and swimSurfaceLoopSfx;
        // simulation never owns an FMOD handle.


        // Player.cs constructs these two SoundSource Components after StateMachine
        // and Leader. Their identities survive temporary scene removal/re-add.
        public global::Celeste.Simulation.Audio.Sources.SoundSourceComponentState WallSlideSoundComponent
        {
            get;
            private set;
        }

        public global::Celeste.Simulation.Audio.Sources.SoundSourceComponentState SwimSurfaceSoundComponent
        {
            get;
            private set;
        }

        public bool UpdatingComponents => Components.LockMode ==
                                          global::Celeste.Core.Components.SourceOwnedComponentList.LockModes.Locked;

        public RoomPlayerSession(Vector2 spawn,
            global::Celeste.Simulation.Gameplay.Player.Configuration.IPlayerAssistSettings settings,
            ISourceGameInput input, global::Celeste.Core.Scheduling.ISourceEngineContext engineContext,
            global::Celeste.Simulation.Gameplay.Platforms.Collision.PlatformCollisionWorld platformWorld,
            IReadOnlyDictionary<string, string> chaseSoundMapping,
            global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode mode = global::Celeste
                .Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode.Madeline)
            : base(new PixelActor(platformWorld, new Vector2((int)spawn.X, (int)spawn.Y),
                    new global::Celeste.Core.Geometry.Bounds(-4, -11, 8, 11), .16f), engineContext,
                ((global::Celeste.Simulation.Gameplay.Platforms.Foundation.ISourcePlatformTargetMotionEnvironment)
                    engineContext).TargetMotionPolicy)
        {
            Data.Dashes = 0;
            Data.Facing = 0;
            this.engineContext = engineContext ?? throw new ArgumentNullException(nameof(engineContext));
            ChaseHistory =
                new global::Celeste.Simulation.Gameplay.Player.ChaseHistory.PlayerChaseHistory(this, chaseSoundMapping);
            Settings = settings;
            Input = input;
            Input.ResetGrab(); // Player's constructor resets only the global grab toggle.
            DefaultSpriteMode = mode;
            Depth = 0;
            Tags =
                ((global::Celeste.Scene.Scheduling.ExecutionTags.ISourcePersistentTransitionExecutionTagsEnvironment)
                    engineContext).PersistentTransitionExecutionTags.Persistent.Value;
            World = new RoomPlayerWorld(Data, settings, input, Body, this, engineContext.Effects, platformWorld,
                engineContext);
            if (Settings.PlayAsBadeline)
                mode = global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode
                    .MadelineAsBadeline;
            Sprite = new global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSprite(engineContext,
                mode);
            Hair = new global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHair(Sprite, engineContext);
            Components.Add(Hair);
            Components.Add(Sprite);
            Hair.Color = mode == global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode
                .MadelineAsBadeline
                ? global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHairAppearance
                    .NormalBadelineHairColor
                : global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHairAppearance.NormalHairColor;
            Appearance =
                new global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHairAppearance(engineContext)
                    { StartHairCount = Sprite.HairCount };
            Sweat = ((global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engineContext).GameGraphics
                .SpriteFactory.Create("player_sweat");
            Components.Add(Sweat);
            World.Contacts.SetDucking(false);
            Machine = ((global::Celeste.Core.Scheduling.ISourceStateMachineEnvironment)engineContext).StateMachines
                .Create(engineContext, 26);
            Components.Add(Machine);
            Data.Motion.ReadActualDucking = () => World.Contacts.Ducking;
            Data.Motion.SetActualDucking = World.Contacts.SetDucking;
            World.Interactions.FreezeRequested = Freeze;
            World.Interactions.PlayerOverTalk = _ =>
                ((global::Celeste.Simulation.Gameplay.Interaction.Talking.ISourceTalkHoverEnvironment)
                    engineContext).HasTalkHover;
            World.Interactions.DashStarted = (_, direction) =>
            {
                foreach (global::Celeste.Simulation.Gameplay.Player.Dash.DashListenerState listener in
                         ((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Components
                         .GetTrackedComponents("Celeste.DashListener"))
                    listener.OnDash?.Invoke(direction);
            };
            // Player starts facing right. SpawnFacingTrigger is resolved by
            // Player.Added, after earlier room entities have received Added.
            Motor = new global::Celeste.Simulation.Gameplay.Player.Runtime.PlayerMotor(Data, settings, input, Body,
                Machine, World, engineContext);
            World.Bind(Motor);
            boostSequence =
                new global::Celeste.Simulation.Gameplay.Player.Dash.PlayerBoostSequence(this, Data, settings, input,
                    Body, Machine, Motor.Dash, World);
            Machine.SetCallbacks(9, DreamDashUpdate, null, DreamDashBegin, DreamDashEnd);
            World.Interactions.TryBoosterBoosted = (_, __) => boostSequence.TryCallBoosterDashEvent();
            World.Interactions.Chapter9BoosterBusy = _ => boostSequence.Chapter9BoosterBusy;
            HitSquash = new global::Celeste.Simulation.Gameplay.Player.Collision.HitSquashSequence(Data, Special, input,
                Machine, Motor.Dash, World, engineContext);
            Launch = new global::Celeste.Simulation.Gameplay.Player.Launch.LaunchSequence(Data, Special, input, Machine,
                Motor.Dash, World, engineContext);
            Data.Motion.Normal.BindSpriteScaleOwner(this);
            BindSummitLaunch();
            BindStarFly();
            BindAttract();
            BindFlingBird();
            Holding = new global::Celeste.Simulation.Gameplay.Holdables.PlayerHoldingController(World, this);
            Data.BindActualHolding(Holding);
            Dummy = new global::Celeste.Simulation.Gameplay.Player.Dummy.PlayerDummyController(World);
            // Player.Added owns StartHair; constructor nodes retain their CLR values.
            Machine.SetCallbacks(18, ReflectionFallUpdate, ReflectionFallCoroutine, ReflectionFallBegin,
                ReflectionFallEnd);
            Machine.SetCallbacks(21, CassetteFlyUpdate, CassetteFlyCoroutine, CassetteFlyBegin, CassetteFlyEnd);
            Intro = new global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroSequence(Data, Machine, Hair,
                new IntroWorld(this), engineContext);
            BindTempleFall();
            BindDashAssistEvents();
            BindBirdDash();
            Respawn = new global::Celeste.Simulation.Gameplay.Player.Respawn.PlayerRespawnSequence(this);
            Motor.UpdateOwnedComponents = UpdateOwnedComponents;
            BindChaseHistory();
            BindAudioEvents();
            ConstructSourceComponents();
            BindFrameAudio();
            BindIdle();
            Components.Add(Reflection);
            if (((global::Celeste.Simulation.Gameplay.Player.Runtime.ISourcePlayerRuntimeEnvironment)engineContext)
                .PlayerRuntimePolicy is
                global::Celeste.Simulation.Gameplay.Player.Runtime.ISourcePlayerStateRegistrationPolicy
                stateRegistration)
                stateRegistration.RegisterStates(this);
        }


        private void Report(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind kind, string name,
            Vector2 position, float value = 0,
            Vector2 direction = default)
            => World.Report(
                new global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEvent(kind, position, direction, name,
                    value));

        private void UpdateOwnedComponents(float dt, float rawDt)
        {
            Appearance.UpdatePhysics(Data, Machine.State, Hair, World.SceneTime, dt);
            base.Update();
            Light.Position = Data.Motion.Ducking ? DuckingLightOffset : NormalLightOffset;
        }

        public void Freeze(float duration) =>
            ((global::Celeste.Core.Scheduling.ISourceFreezeEnvironment)engineContext).Freeze(duration);

        // The actual Player body. Level, scene, input and Engine phases are separate owners.
        public void UpdateActualPlayer(float deltaTime, float rawDeltaTime) =>
            ((global::Celeste.Simulation.Gameplay.Player.Runtime.ISourcePlayerRuntimeEnvironment)engineContext)
            .PlayerRuntimePolicy.Update(this, deltaTime, rawDeltaTime);

        public void UpdateSourceBody(float deltaTime, float rawDeltaTime)
        {
            rawDelta = rawDeltaTime;
            UpdatePlayer(deltaTime);
        }

        private void UpdatePlayer(float dt)
        {
            Motor.UpdateMotion(dt, rawDelta);
            UpdateSourceWallSlideSound();
            global::Celeste.Simulation.Gameplay.Player.Presentation.Animation.PlayerAnimation.Update(Data,
                Machine.State, Sprite,
                new global::Celeste.Simulation.Gameplay.Player.Presentation.Animation.PlayerAnimationContext
                {
                    InputMoveX = Input.MoveX.Value, InputMoveY = Input.MoveY.Value,
                    InSpace = World.InSpace, WindDirection = Appearance.WindDirection,
                    WindTimeout = Appearance.WindTimeout
                }, World, dt);
            Holding.UpdateCarry();
            UpdateSourceSwimSurfaceSound();
            if (Machine.State != 18) CheckSourcePlayerTriggers();
            StrawberriesBlocked = CollideBlockField();
            ((global::Celeste.Simulation.Gameplay.Camera.ISourcePlayerCameraScene)Scene).PlayerCamera.Follow(this, dt);
            CheckPlayerColliders();
            if (Dead) return;
            if (global::Celeste.Simulation.Gameplay.Player.Runtime.PlayerFrameMotion.InControl(Machine.State) &&
                Machine.State != 9)
                ((global::Celeste.Simulation.Gameplay.Player.Scene.Bounds.ISourcePlayerBoundsScene)Level)
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
