using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Cutscenes;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Progression;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles;
using Celeste.Game.Gameplay.Platforms.FallingBlocks;
using Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock;
using Celeste.Game.Gameplay.Walls.Breakable;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Camera;
using Celeste.Simulation.Gameplay.Enemies.Badeline.Projectiles;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Presentation.Backdrops.Stars;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Simulation.Presentation.Lighting;
using static Celeste.Core.Mathematics.ScalarMath;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss
{
    public partial class FinalBossState : SceneEntityState,
        IFinalBossSource
    {
        private OriginalLevelSceneRoot level;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public OriginalLevelSceneRoot Level => level;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)EngineContext;

        private ISpriteFactory Bank =>
            ((ISourceGameGraphicsEnvironment)EngineContext).GameGraphics.SpriteFactory;

        private ISourceRandom ProcessRandom => ((ISourceRandomEnvironment)EngineContext).Random;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)EngineContext).VectorArithmetic;

        public Vector2 BeamOrigin => Center + Sprite.Position + new Vector2(0, -14);
        public Vector2 ShotOrigin => Center + Sprite.Position + new Vector2(6 * Sprite.Scale.X, 2);
        public bool Moving;
        bool IFinalBossSource.Moving => Moving;
        public float CameraYPastMax;
        public bool CanChangeMusicSetting;

        public bool CanChangeMusic(bool value)
        {
            return progression.CanChangeMusic(this, value);
        }

        public bool Sitting;
        public int PatternIndex;
        public int NodeIndex;
        public int Facing;
        public Vector2[] Nodes;
        public bool Dialog, StartHit;
        public RoomCameraLocker CameraLocker;
        public SineWaveState FloatSine;
        public WigglerComponent ScaleWiggler;

        public VertexLightState Light;

        public readonly PlayerColliderComponentState
            PlayerColliderComponent;

        private readonly CircleColliderGeometry circle;

        public float CircleRadius
        {
            get => circle.Radius;
            set => circle.Radius = value;
        }

        public Vector2 AvoidPosition;
        public bool PlayerHasMoved;
        public SimulationCoroutine AttackCoroutine, TriggerBlocksCoroutine;
        public SoundSourceComponentState ChargeSound, LaserSound;

        public FinalBossStarfieldBackdropPresentation
            BossBackground { get; private set; }

        private ISourceEngineContext EngineContext { get; }

        private RoomPlayerSession LevelPlayer
        {
            get
            {
                var players =
                    Level.SourceScene.Entities.GetTrackedEntities(typeof(RoomPlayerSession)
                        .FullName);

                return players.Count > 0 ? (RoomPlayerSession)players[0] : null;
            }
        }

        private readonly FinalBossProgressionPolicy progression;
        private List<object> falling;
        private List<object> moving;

        public FinalBossState(Vector2 at, Vector2[] nodes, int patternIndex, FinalBossProgressionPolicy progression,
            ISourceEngineContext engine,
            float cameraYPastMax = 120,
            bool dialog = false, bool startHit = false, bool cameraLockY = true,
            bool canChangeMusic = false)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, at)
        {
            EngineContext = engine;
            this.progression = progression ?? throw new ArgumentNullException(nameof(progression));
            PatternIndex = patternIndex;
            Dialog = dialog;
            StartHit = startHit;
            CameraYPastMax = cameraYPastMax;
            CanChangeMusicSetting = canChangeMusic;
            Position = at;
            Light = new(engine,
                PackedColor.White, 1f, 32, 64);
            OwnedComponents.Add(Light);
            Collider = circle = new(
                ((ISourceVectorEnvironment)engine).VectorArithmetic, 14f, 0f, -6f);
            PlayerColliderComponent =
                new(
                    OnPlayer);
            OwnedComponents.Add(PlayerColliderComponent);
            Nodes = new Vector2[nodes.Length + 1];
            Nodes[0] = at;
            Array.Copy(nodes, 0, Nodes, 1, nodes.Length);
            AttackCoroutine = new(engine, false);
            OwnedComponents.Add(AttackCoroutine);
            TriggerBlocksCoroutine = new(engine, false);
            OwnedComponents.Add(TriggerBlocksCoroutine);
            CameraLocker = new(
                cameraLockY
                    ? RoomCameraLockMode.FinalBoss
                    : RoomCameraLockMode.FinalBossNoY,
                140, cameraYPastMax);
            OwnedComponents.Add(CameraLocker);
            FloatSine = new(engine, .6f);
            OwnedComponents.Add(FloatSine);
            ScaleWiggler =
                ((ISourceWigglerPoolScope)engine).WigglerPool.Create(.6f,
                    3f);
            OwnedComponents.Add(ScaleWiggler);
            ChargeSound = ((ISourceSoundSourceEnvironment)engine).SoundSources
                .Create();
            OwnedComponents.Add(ChargeSound);
            LaserSound = ((ISourceSoundSourceEnvironment)engine).SoundSources
                .Create();
            OwnedComponents.Add(LaserSound);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = (OriginalLevelSceneRoot)Scene;
            if (PatternIndex == 0) CreateNormalSprite();
            else CreateBossSprite();
            BossBackground = Level.Background
                .Get<FinalBossStarfieldBackdropPresentation>();
            var entrance = progression.Choose(Level, PatternIndex);
            if (entrance == FinalBossEntranceKind.Intro)
            {
                progression.ApplyIntroAudio(this);
                if (BossBackground != null) BossBackground.Alpha = 0;
                Sitting = true;
                Position += new Vector2(0, 16);
                NormalSprite.Play("pretendDead");
                NormalSprite.Scale = new(1, NormalSprite.Scale.Y);
            }
            else if (entrance == FinalBossEntranceKind.Mid)
            {
                Level.SourceScene.QueueSourceEntity(new CS06BossMidState(EngineContext));
            }
            else if (StartHit)
            {
                AddAlarm(.5f, () => OnPlayer(null));
            }

            Light.Position = CurrentSprite.Position + new Vector2(0, -10);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var tracker = ((ISourceScene)Scene).SourceScene.Entities;
            falling = [.. tracker.GetTrackedEntities("Celeste.FallingBlock")];
            falling.Sort((a, b) => (int)(((SceneEntityState)a).X -
                                         ((SceneEntityState)b).X));
            moving = [.. tracker.GetTrackedEntities("Celeste.FinalBossMovingBlock")];
            moving.Sort((a, b) => (int)(((SceneEntityState)a).X -
                                        ((SceneEntityState)b).X));
        }

        public override void Removed(object scene)
        {
            if (BossBackground != null && PatternIndex == 0) BossBackground.Alpha = 1;
            base.Removed(scene);
        }

        public SimulationCoroutine AddCoroutine(IEnumerator routine)
        {
            var component = new SimulationCoroutine(EngineContext, routine);
            OwnedComponents.Add(component);
            return component;
        }

        public SourceAlarmState AddAlarm(float delay, Action action)
        {
            return SourceAlarmState.Set(EngineContext.AlarmPool, OwnedComponents, delay,
                action);
        }

        private void AddTween(float duration, Func<float, float> easer,
            Action<SourceTweenState> onUpdate,
            Action<SourceTweenState> onComplete = null,
            bool useRawDeltaTime = false)
        {
            var tween = SourceTweenState.Create(EngineContext.TweenPool,
                SourceTweenState.TweenMode.Oneshot, easer, duration, true);
            tween.UseRawDeltaTime = useRawDeltaTime;
            tween.OnUpdate = onUpdate;
            tween.OnComplete = onComplete;
            OwnedComponents.Add(tween);
        }

        public override void Update()
        {
            base.Update();
            var sprite = CurrentSprite;
            if (!Sitting)
            {
                var players =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                        typeof(RoomPlayerSession).FullName);

                var player = players.Count > 0 ? (RoomPlayerSession)players[0] : null;
                if (!Moving && player != null)
                {
                    if (Facing == -1 && player.Position.X > Position.X + 20)
                    {
                        Facing = 1;
                        ScaleWiggler.Start();
                    }
                    else if (Facing == 1 && player.Position.X < Position.X - 20)
                    {
                        Facing = -1;
                        ScaleWiggler.Start();
                    }
                }

                if (!PlayerHasMoved && player != null && player.Speed != Vector2.Zero)
                {
                    PlayerHasMoved = true;
                    if (PatternIndex != 0) StartAttacking();
                    TriggerMovingBlocks(0);
                }

                sprite.Position = !Moving
                    ? AvoidPosition + new Vector2(FloatSine.Value * 3, FloatSine.ValueOverTwo * 4)
                    : VectorArithmetic.Approach(sprite.Position, Vector2.Zero, 12 * EngineContext.DeltaTime);
                var radius = CircleRadius;
                CircleRadius = 6;
                CollideFirst<OriginalDashBlockState>(
                    "Celeste.DashBlock")?.Break(Center, -Vector2.UnitY);
                CircleRadius = radius;
                if (!Level.IsInBounds(Position, 24))
                {
                    Active = Visible = Collidable = false;
                    return;
                }

                var target = Vector2.Zero;
                if (!Moving && player != null)
                {
                    var value = VectorArithmetic.Length(Center - player.Center);
                    value = ClampedMap(value, 32f, 88f, 12f, 0f);
                    if (!(value <= 0f)) target = VectorArithmetic.SafeNormalize(Center - player.Center, value);
                }

                AvoidPosition = VectorArithmetic.Approach(AvoidPosition, target, 40 * EngineContext.DeltaTime);
            }

            Light.Position = sprite.Position + new Vector2(0, -10);
        }

        public void OnPlayer(RoomPlayerSession player)
        {
            if (Sprite == null) CreateBossSprite();
            Sprite.Play("getHit");
            ((ISourceSpatialAudioEnvironment)EngineContext).SpatialAudio.Play(
                "event:/char/badeline/boss_hug", Position);
            ChargeSound.Stop();
            if (LaserSound.EventName == "event:/char/badeline/boss_laser_charge" && LaserSound.Playing)
                LaserSound.Stop();
            Collidable = false;
            AvoidPosition = Vector2.Zero;
            NodeIndex++;
            if (Dialog)
            {
                if (NodeIndex == 1) AddMiniTextbox("ch6_boss_tired_a");
                else if (NodeIndex == 2) AddMiniTextbox("ch6_boss_tired_b");
                else if (NodeIndex == 3) AddMiniTextbox("ch6_boss_tired_c");
            }

            foreach (var entry in Level.SourceScene.Entities.GetTrackedEntities("Celeste.FinalBossShot"))
                ((FinalBossShotState)entry)
                    .Destroy();
            foreach (var entry in Level.SourceScene.Entities.GetTrackedEntities("Celeste.FinalBossBeam"))
                ((FinalBossBeamState)entry)
                    .Destroy();
            TriggerFallingBlocks(Position.X);
            TriggerMovingBlocks(NodeIndex);
            AttackCoroutine.Active = false;
            Moving = true;
            var last = NodeIndex == Nodes.Length - 1;
            progression.AfterHit(this, last);

            AddCoroutine(MoveSequence(player, last));
        }

        public IEnumerator MoveSequence(RoomPlayerSession player, bool lastHit)
        {
            if (lastHit)
            {
                Process.AudioSession.SetMusicParam("boss_pitch", 1f);
                AddTween(.3f, null, t => Level.Glitch.Value = .6f * t.Eased);
            }
            else
            {
                AddTween(.3f, null, t => Level.Glitch.Value = .5f * (1 - t.Eased));
            }

            if (player != null && !player.Dead) player.StartAttract(Center + Vector2.UnitY * 4);
            var timer = .15f;
            while (player != null && !player.Dead && !player.AtAttractTarget)
            {
                yield return null;
                timer -= EngineContext.DeltaTime;
            }

            if (timer > 0) yield return timer;
            RetreatTentacles();
            if (player != null)
            {
                ((ISourceFreezeEnvironment)EngineContext).Freeze(.1f);
                EngineContext.Effects.TimeRate = lastHit ? .5f : .75f;
                ((ISourceRumbleEnvironment)EngineContext).RumbleSession.Rumble(2, 1);
            }

            PushPlayer(player);
            Level.Shake();
            yield return .05f;
            for (float angle = 0; angle < (float)Math.PI * 2; angle += .17453292f)
            {
                var at = Center + Sprite.Position + Vector2Geometry.AngleToVector(
                    angle + (-(float)Math.PI / 90f + (float)ProcessRandom.NextDouble() *
                        ((float)Math.PI / 90f - -(float)Math.PI / 90f)), ProcessRandom.Next(16, 20));
                Level.Particles.Emit(Process.ParticleTypes.FinalBoss.P_Burst, at, angle);
            }

            yield return .05f;
            Process.AudioSession.SetMusicParam("boss_pitch", 0f);
            var from = EngineContext.Effects.TimeRate;
            AddTween(.35f / EngineContext.Effects.TimeRateB, null, t =>
            {
                if (BossBackground != null && BossBackground.Alpha < t.Eased) BossBackground.Alpha = t.Eased;
                EngineContext.Effects.TimeRate =
                    Lerp(from, 1, t.Eased, ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic);
                if (lastHit) Level.Glitch.Value = .6f * (1 - t.Eased);
            }, useRawDeltaTime: true);
            yield return .2f;
            Vector2 fromPosition = Position, to = Nodes[NodeIndex];
            var duration = VectorArithmetic.Distance(fromPosition, to) / 600f;
            var direction = Vector2Geometry.Angle(to - fromPosition);
            AddTween(duration,
                ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.SineInOut,
                t =>
                {
                    Position = Vector2Interpolation.Lerp(fromPosition, to, t.Eased,
                        ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic);
                    if (t.Eased >= .1f && t.Eased <= .9f &&
                        ((ISourceScene)Scene).SourceScene.Clock.OnInterval(.02f, EngineContext))
                    {
                        TrailManagerState.Add(EngineContext,
                            (ISourceRenderEnvironment)EngineContext, this,
                            PlayerHairAppearance
                                .NormalHairColor, .5f);
                        Level.Particles.Emit(Process.ParticleTypes.Player.P_DashB, 2, Center, Vector2.One * 3,
                            direction);
                    }
                },
                t =>
                {
                    Sprite.Play("recoverHit");
                    Moving = false;
                    Collidable = true;
                    var players =
                        ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                            typeof(RoomPlayerSession).FullName);

                    var p = players.Count > 0 ? (RoomPlayerSession)players[0] : null;
                    if (p != null)
                    {
                        Facing = Math.Sign(p.Position.X - Position.X);
                        if (Facing == 0) Facing = -1;
                    }

                    StartAttacking();
                    FloatSine.Reset();
                });
        }

        private void PushPlayer(RoomPlayerSession player)
        {
            progression.PushPlayer(this, player);
        }

        internal void PushPlayerOriginal(RoomPlayerSession player)
        {
            if (player != null && !player.Dead)
            {
                var direction = Math.Sign(Position.X - Nodes[NodeIndex].X);
                if (direction == 0) direction = -1;
                player.FinalBossPushLaunch(direction);
            }

            Level.Displacement.AddBurst(Position, .4f, 12, 36, .5f);
            Level.Displacement.AddBurst(Position, .4f, 24, 48, .5f);
            Level.Displacement.AddBurst(Position, .4f, 36, 60, .5f);
        }

        private void TriggerFallingBlocks(float leftOfX)
        {
            while (falling.Count > 0 &&
                   ((OriginalFallingBlockState)falling[0])
                   .Scene == null) falling.RemoveAt(0);
            var index = 0;
            while (falling.Count > 0 &&
                   ((OriginalFallingBlockState)falling[0])
                   .X < leftOfX)
            {
                var b =
                    (OriginalFallingBlockState)falling[0];
                b.StartShaking();
                b.Triggered = true;
                b.FallDelay = .4f * index;
                index++;
                falling.RemoveAt(0);
            }
        }

        private void TriggerMovingBlocks(int nodeIndex)
        {
            if (nodeIndex > 0)
            {
                float delay = 0;
                foreach (OriginalFinalBossMovingBlockState b in moving)
                    if (b.BossNodeIndex == nodeIndex - 1)
                    {
                        b.Destroy(delay);
                        delay += .05f;
                    }
            }

            float start = 0;
            foreach (OriginalFinalBossMovingBlockState b in moving)
                if (b.BossNodeIndex == nodeIndex)
                {
                    b.StartMoving(start);
                    start += .15f;
                }
        }
    }
}
