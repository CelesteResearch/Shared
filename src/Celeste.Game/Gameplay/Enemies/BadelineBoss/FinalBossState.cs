using Celeste.Core.Display;
using Celeste.Core.Components;
using Celeste.Core.Randomness;
using Celeste.Graphics.Content;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Scheduling;
using Celeste.Simulation.Gameplay.Player.Presentation;
using System;
using Celeste.Core.Mathematics;
using static Celeste.Core.Mathematics.ScalarMath;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Progression;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss
{
    public partial class FinalBossState : global::Celeste.Scene.Entities.SceneEntityState,
        global::Celeste.Simulation.Gameplay.Enemies.Badeline.Projectiles.IFinalBossSource
    {
        private OriginalLevelSceneRoot level;
        public OriginalLevelSceneRoot Level => level;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private global::Celeste.Graphics.Animation.ISpriteFactory Bank =>
            ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory;

        private ISourceRandom ProcessRandom => ((ISourceRandomEnvironment)engine).Random;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;

        public Vector2 BeamOrigin => Center + Sprite.Position + new Vector2(0, -14);
        public Vector2 ShotOrigin => Center + Sprite.Position + new Vector2(6 * Sprite.Scale.X, 2);
        public bool Moving;
        bool global::Celeste.Simulation.Gameplay.Enemies.Badeline.Projectiles.IFinalBossSource.Moving => Moving;
        public float CameraYPastMax;
        public bool CanChangeMusicSetting;
        public bool CanChangeMusic(bool value) => progression.CanChangeMusic(this, value);

        public bool Sitting;
        public int PatternIndex;
        public int NodeIndex;
        public int Facing;
        public Vector2[] Nodes;
        public bool Dialog, StartHit;
        public global::Celeste.Simulation.Gameplay.Camera.RoomCameraLocker CameraLocker;
        public global::Celeste.Scene.Components.Oscillation.SineWaveState FloatSine;
        public global::Celeste.Scene.Components.Oscillation.WigglerComponent ScaleWiggler;

        public global::Celeste.Simulation.Presentation.Lighting.VertexLightState Light;

        public readonly global::Celeste.Simulation.Gameplay.Player.Collision.Components.PlayerColliderComponentState
            PlayerColliderComponent;

        private global::Celeste.Physics.Collision.Shapes.CircleColliderGeometry circle;

        public float CircleRadius
        {
            get => circle.Radius;
            set => circle.Radius = value;
        }

        public Vector2 AvoidPosition;
        public bool PlayerHasMoved;
        public global::Celeste.Core.Scheduling.SimulationCoroutine AttackCoroutine, TriggerBlocksCoroutine;
        public global::Celeste.Simulation.Audio.Sources.SoundSourceComponentState ChargeSound, LaserSound;

        public global::Celeste.Simulation.Presentation.Backdrops.Stars.FinalBossStarfieldBackdropPresentation
            BossBackground { get; private set; }

        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;
        private global::Celeste.Core.Scheduling.ISourceEngineContext EngineContext => engine;

        private RoomPlayerSession LevelPlayer
        {
            get
            {
                var players =
                    level.SourceScene.Entities.GetTrackedEntities(typeof(global::Celeste.Simulation.RoomPlayerSession)
                        .FullName);

                return players.Count > 0 ? (RoomPlayerSession)players[0] : null;
            }
        }

        readonly FinalBossProgressionPolicy progression;
        List<object> falling;
        List<object> moving;

        public FinalBossState(Vector2 at, Vector2[] nodes, int patternIndex, FinalBossProgressionPolicy progression,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine,
            float cameraYPastMax = 120,
            bool dialog = false, bool startHit = false, bool cameraLockY = true,
            bool canChangeMusic = false)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, at)
        {
            this.engine = engine;
            this.progression = progression ?? throw new ArgumentNullException(nameof(progression));
            PatternIndex = patternIndex;
            Dialog = dialog;
            StartHit = startHit;
            CameraYPastMax = cameraYPastMax;
            CanChangeMusicSetting = canChangeMusic;
            Position = at;
            Light = new global::Celeste.Simulation.Presentation.Lighting.VertexLightState(engine,
                global::Celeste.Core.Display.PackedColor.White, 1f, 32, 64);
            OwnedComponents.Add(Light);
            Collider = circle = new global::Celeste.Physics.Collision.Shapes.CircleColliderGeometry(
                ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic, 14f, 0f, -6f);
            PlayerColliderComponent =
                new global::Celeste.Simulation.Gameplay.Player.Collision.Components.PlayerColliderComponentState(
                    OnPlayer);
            OwnedComponents.Add(PlayerColliderComponent);
            Nodes = new Vector2[nodes.Length + 1];
            Nodes[0] = at;
            Array.Copy(nodes, 0, Nodes, 1, nodes.Length);
            AttackCoroutine = new global::Celeste.Core.Scheduling.SimulationCoroutine(engine, false);
            OwnedComponents.Add(AttackCoroutine);
            TriggerBlocksCoroutine = new global::Celeste.Core.Scheduling.SimulationCoroutine(engine, false);
            OwnedComponents.Add(TriggerBlocksCoroutine);
            CameraLocker = new global::Celeste.Simulation.Gameplay.Camera.RoomCameraLocker(
                cameraLockY
                    ? global::Celeste.Simulation.Gameplay.Camera.RoomCameraLockMode.FinalBoss
                    : global::Celeste.Simulation.Gameplay.Camera.RoomCameraLockMode.FinalBossNoY,
                140, cameraYPastMax);
            OwnedComponents.Add(CameraLocker);
            FloatSine = new global::Celeste.Scene.Components.Oscillation.SineWaveState(engine, .6f);
            OwnedComponents.Add(FloatSine);
            ScaleWiggler =
                ((global::Celeste.Scene.Components.Oscillation.ISourceWigglerPoolScope)engine).WigglerPool.Create(.6f,
                    3f, null);
            OwnedComponents.Add(ScaleWiggler);
            ChargeSound = ((global::Celeste.Simulation.Audio.Sources.ISourceSoundSourceEnvironment)engine).SoundSources
                .Create();
            OwnedComponents.Add(ChargeSound);
            LaserSound = ((global::Celeste.Simulation.Audio.Sources.ISourceSoundSourceEnvironment)engine).SoundSources
                .Create();
            OwnedComponents.Add(LaserSound);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = (OriginalLevelSceneRoot)Scene;
            if (PatternIndex == 0) CreateNormalSprite();
            else CreateBossSprite();
            BossBackground = level.Background
                .Get<global::Celeste.Simulation.Presentation.Backdrops.Stars.FinalBossStarfieldBackdropPresentation>();
            FinalBossEntranceKind entrance = progression.Choose(level, PatternIndex);
            if (entrance == FinalBossEntranceKind.Intro)
            {
                progression.ApplyIntroAudio(this);
                if (BossBackground != null) BossBackground.Alpha = 0;
                Sitting = true;
                Position += new Vector2(0, 16);
                NormalSprite.Play("pretendDead");
                NormalSprite.Scale = new Vector2(1, NormalSprite.Scale.Y);
            }
            else if (entrance == FinalBossEntranceKind.Mid)
                level.SourceScene.QueueSourceEntity(new Cutscenes.CS06BossMidState(engine));
            else if (StartHit) AddAlarm(.5f, () => OnPlayer(null));

            Light.Position = CurrentSprite.Position + new Vector2(0, -10);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var tracker = ((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Entities;
            falling = new List<object>(tracker.GetTrackedEntities("Celeste.FallingBlock"));
            falling.Sort((a, b) => (int)(((global::Celeste.Scene.Entities.SceneEntityState)a).X -
                                         ((global::Celeste.Scene.Entities.SceneEntityState)b).X));
            moving = new List<object>(tracker.GetTrackedEntities("Celeste.FinalBossMovingBlock"));
            moving.Sort((a, b) => (int)(((global::Celeste.Scene.Entities.SceneEntityState)a).X -
                                        ((global::Celeste.Scene.Entities.SceneEntityState)b).X));
        }

        public override void Removed(object scene)
        {
            if (BossBackground != null && PatternIndex == 0) BossBackground.Alpha = 1;
            base.Removed(scene);
        }

        public global::Celeste.Core.Scheduling.SimulationCoroutine AddCoroutine(IEnumerator routine)
        {
            var component = new global::Celeste.Core.Scheduling.SimulationCoroutine(engine, routine);
            OwnedComponents.Add(component);
            return component;
        }

        public global::Celeste.Core.Components.Timing.SourceAlarmState AddAlarm(float delay, Action action) =>
            global::Celeste.Core.Components.Timing.SourceAlarmState.Set(EngineContext.AlarmPool, OwnedComponents, delay,
                action);

        private void AddTween(float duration, Func<float, float> easer,
            Action<global::Celeste.Core.Components.Animation.SourceTweenState> onUpdate,
            Action<global::Celeste.Core.Components.Animation.SourceTweenState> onComplete = null,
            bool useRawDeltaTime = false)
        {
            var tween = global::Celeste.Core.Components.Animation.SourceTweenState.Create(EngineContext.TweenPool,
                global::Celeste.Core.Components.Animation.SourceTweenState.TweenMode.Oneshot, easer, duration, true);
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
                    ((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

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
                    : VectorArithmetic.Approach(sprite.Position, Vector2.Zero, 12 * engine.DeltaTime);
                float radius = CircleRadius;
                CircleRadius = 6;
                CollideFirst<global::Celeste.Game.Gameplay.Walls.Breakable.OriginalDashBlockState>(
                    "Celeste.DashBlock")?.Break(Center, -Vector2.UnitY);
                CircleRadius = radius;
                if (!level.IsInBounds(Position, 24))
                {
                    Active = Visible = Collidable = false;
                    return;
                }

                Vector2 target = Vector2.Zero;
                if (!Moving && player != null)
                {
                    float value = VectorArithmetic.Length(Center - player.Center);
                    value = ClampedMap(value, 32f, 88f, 12f, 0f);
                    if (!(value <= 0f)) target = VectorArithmetic.SafeNormalize(Center - player.Center, value);
                }

                AvoidPosition = VectorArithmetic.Approach(AvoidPosition, target, 40 * engine.DeltaTime);
            }

            Light.Position = sprite.Position + new Vector2(0, -10);
        }

        public void OnPlayer(RoomPlayerSession player)
        {
            if (Sprite == null) CreateBossSprite();
            Sprite.Play("getHit");
            ((global::Celeste.Core.Audio.ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
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

            foreach (var entry in level.SourceScene.Entities.GetTrackedEntities("Celeste.FinalBossShot"))
                ((global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles.FinalBossShotState)entry)
                    .Destroy();
            foreach (var entry in level.SourceScene.Entities.GetTrackedEntities("Celeste.FinalBossBeam"))
                ((global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles.FinalBossBeamState)entry)
                    .Destroy();
            TriggerFallingBlocks(Position.X);
            TriggerMovingBlocks(NodeIndex);
            AttackCoroutine.Active = false;
            Moving = true;
            bool last = NodeIndex == Nodes.Length - 1;
            progression.AfterHit(this, last);

            AddCoroutine(MoveSequence(player, last));
        }

        public IEnumerator MoveSequence(RoomPlayerSession player, bool lastHit)
        {
            if (lastHit)
            {
                Process.AudioSession.SetMusicParam("boss_pitch", 1f);
                AddTween(.3f, null, t => level.Glitch.Value = .6f * t.Eased);
            }
            else AddTween(.3f, null, t => level.Glitch.Value = .5f * (1 - t.Eased));

            if (player != null && !player.Dead) player.StartAttract(Center + Vector2.UnitY * 4);
            float timer = .15f;
            while (player != null && !player.Dead && !player.AtAttractTarget)
            {
                yield return null;
                timer -= engine.DeltaTime;
            }

            if (timer > 0) yield return timer;
            RetreatTentacles();
            if (player != null)
            {
                ((global::Celeste.Core.Scheduling.ISourceFreezeEnvironment)engine).Freeze(.1f);
                engine.Effects.TimeRate = lastHit ? .5f : .75f;
                ((global::Celeste.Input.Gameplay.Feedback.ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
            }

            PushPlayer(player);
            level.Shake();
            yield return .05f;
            for (float angle = 0; angle < (float)Math.PI * 2; angle += .17453292f)
            {
                var at = Center + Sprite.Position + Vector2Geometry.AngleToVector(
                    angle + (-(float)Math.PI / 90f + (float)ProcessRandom.NextDouble() *
                        ((float)Math.PI / 90f - (-(float)Math.PI / 90f))), ProcessRandom.Next(16, 20));
                level.Particles.Emit(Process.ParticleTypes.FinalBoss.P_Burst, at, angle);
            }

            yield return .05f;
            Process.AudioSession.SetMusicParam("boss_pitch", 0f);
            float from = engine.Effects.TimeRate;
            AddTween(.35f / engine.Effects.TimeRateB, null, t =>
            {
                if (BossBackground != null && BossBackground.Alpha < t.Eased) BossBackground.Alpha = t.Eased;
                engine.Effects.TimeRate =
                    ScalarMath.Lerp(from, 1, t.Eased, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                if (lastHit) level.Glitch.Value = .6f * (1 - t.Eased);
            }, useRawDeltaTime: true);
            yield return .2f;
            Vector2 fromPosition = Position, to = Nodes[NodeIndex];
            float duration = VectorArithmetic.Distance(fromPosition, to) / 600f;
            float direction = Vector2Geometry.Angle(to - fromPosition);
            AddTween(duration,
                ((global::Celeste.Core.Mathematics.Easing.ISourceEasingEnvironment)engine).EasingArithmetic.SineInOut,
                t =>
                {
                    Position = Vector2Interpolation.Lerp(fromPosition, to, t.Eased,
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                    if (t.Eased >= .1f && t.Eased <= .9f &&
                        ((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Clock.OnInterval(.02f, engine))
                    {
                        global::Celeste.Simulation.Presentation.Effects.Trails.Lifecycle.TrailManagerState.Add(engine,
                            (global::Celeste.Core.Rendering.ISourceRenderEnvironment)engine, this,
                            global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHairAppearance
                                .NormalHairColor, .5f);
                        level.Particles.Emit(Process.ParticleTypes.Player.P_DashB, 2, Center, Vector2.One * 3,
                            direction);
                    }
                },
                onComplete: t =>
                {
                    Sprite.Play("recoverHit");
                    Moving = false;
                    Collidable = true;
                    var players =
                        ((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                            typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

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

        void PushPlayer(RoomPlayerSession player) => progression.PushPlayer(this, player);

        internal void PushPlayerOriginal(RoomPlayerSession player)
        {
            if (player != null && !player.Dead)
            {
                int direction = Math.Sign(Position.X - Nodes[NodeIndex].X);
                if (direction == 0) direction = -1;
                player.FinalBossPushLaunch(direction);
            }

            level.Displacement.AddBurst(Position, .4f, 12, 36, .5f);
            level.Displacement.AddBurst(Position, .4f, 24, 48, .5f);
            level.Displacement.AddBurst(Position, .4f, 36, 60, .5f);
        }

        void TriggerFallingBlocks(float leftOfX)
        {
            while (falling.Count > 0 &&
                   ((global::Celeste.Game.Gameplay.Platforms.FallingBlocks.OriginalFallingBlockState)falling[0])
                   .Scene == null) falling.RemoveAt(0);
            int index = 0;
            while (falling.Count > 0 &&
                   ((global::Celeste.Game.Gameplay.Platforms.FallingBlocks.OriginalFallingBlockState)falling[0])
                   .X < leftOfX)
            {
                var b =
                    (global::Celeste.Game.Gameplay.Platforms.FallingBlocks.OriginalFallingBlockState)falling[0];
                b.StartShaking();
                b.Triggered = true;
                b.FallDelay = .4f * index;
                index++;
                falling.RemoveAt(0);
            }
        }

        void TriggerMovingBlocks(int nodeIndex)
        {
            if (nodeIndex > 0)
            {
                float delay = 0;
                foreach (global::Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock.
                             OriginalFinalBossMovingBlockState b in moving)
                    if (b.BossNodeIndex == nodeIndex - 1)
                    {
                        b.Destroy(delay);
                        delay += .05f;
                    }
            }

            float start = 0;
            foreach (global::Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock.
                         OriginalFinalBossMovingBlockState b in moving)
                if (b.BossNodeIndex == nodeIndex)
                {
                    b.StartMoving(start);
                    start += .15f;
                }
        }
    }
}
