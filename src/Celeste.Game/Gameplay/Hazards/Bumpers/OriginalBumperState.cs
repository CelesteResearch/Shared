using Celeste.Core.Display;
using System.Runtime.CompilerServices;
using Celeste.Physics.Collision.Shapes;
using System;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Scene.Entities;
using Celeste.Scene.Components.Oscillation;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display;

namespace Celeste.Game.Gameplay.Hazards.Bumpers
{
    public class OriginalBumperState : SceneEntityState
    {
        protected readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;


        private const float RespawnTime = 0.6f;

        private const float MoveCycleTime = 1.8181819f;

        private const float SineCycleFreq = 0.44f;

        private Sprite sprite;

        private Sprite spriteEvil;

        private VertexLightState light;

        private BloomPointState bloom;

        private Vector2? node;

        private bool goBack;

        private Vector2 anchor;

        private SineWaveState sine;

        private float respawnTimer;

        private bool fireMode;

        private WigglerComponent hitWiggler;

        private Vector2 hitDir;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public OriginalBumperState(Vector2 position, Vector2? node,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
            : base(
                ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration,
                position)
        {
            this.engine = engine;
            base.Collider =
                new CircleColliderGeometry(
                    ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic,
                    12f);
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(sine = new SineWaveState(engine, 0.44f).Randomize());
            OwnedComponents.Add(sprite = ((global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engine)
                .GameGraphics.SpriteFactory.Create("bumper"));
            OwnedComponents.Add(spriteEvil = ((global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engine)
                .GameGraphics.SpriteFactory.Create("bumper_evil"));
            spriteEvil.Visible = false;
            OwnedComponents.Add(light =
                new VertexLightState(engine, new PackedColor(0, 128, 128, 255), 1f, 16, 32));
            OwnedComponents.Add(bloom = new BloomPointState(0.5f, 16f));
            this.node = node;
            anchor = Position;
            if (node.HasValue)
            {
                Vector2 start = Position;
                Vector2 end = node.Value;
                SourceTweenState tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Looping,
                    ((global::Celeste.Core.Mathematics.Easing.ISourceEasingEnvironment)engine)
                    .EasingArithmetic
                    .CubeInOut,
                    MoveCycleTime, start: true);
                tween.OnUpdate = delegate(SourceTweenState t)
                {
                    if (goBack)
                    {
                        anchor = Vector2Interpolation.Lerp(end, start, t.Eased,
                            ((global::Celeste.Core.Mathematics.ISourceScalarEnvironment)engine).ScalarArithmetic);
                    }
                    else
                    {
                        anchor = Vector2Interpolation.Lerp(start, end, t.Eased,
                            ((global::Celeste.Core.Mathematics.ISourceScalarEnvironment)engine).ScalarArithmetic);
                    }
                };
                tween.OnComplete = delegate { goBack = !goBack; };
                OwnedComponents.Add(tween);
            }

            UpdatePosition();
            OwnedComponents.Add(hitWiggler =
                ((global::Celeste.Scene.Components.Oscillation.ISourceWigglerPoolScope)engine).WigglerPool.Create(1.2f,
                    2f,
                    delegate { spriteEvil.Position = hitDir * hitWiggler.Value * 8f; }));
            OwnedComponents.Add(new CoreModeListenerState(OnChangeMode));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void Added(object scene)
        {
            base.Added(scene);
            fireMode = ((OriginalLevelSceneRoot)Scene).CoreMode == RoomCoreMode.Hot;
            spriteEvil.Visible = fireMode;
            sprite.Visible = !fireMode;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OnChangeMode(RoomCoreMode coreMode)
        {
            fireMode = coreMode == RoomCoreMode.Hot;
            spriteEvil.Visible = fireMode;
            sprite.Visible = !fireMode;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void UpdatePosition()
        {
            Position = new Vector2(
                ((global::Celeste.Core.Mathematics.ISourceScalarEnvironment)engine).ScalarArithmetic.AddProduct(
                    anchor.X,
                    sine.Value, 3f),
                ((global::Celeste.Core.Mathematics.ISourceScalarEnvironment)engine).ScalarArithmetic.AddProduct(
                    anchor.Y,
                    sine.ValueOverTwo, 2f));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void Update()
        {
            base.Update();
            if (respawnTimer > 0f)
            {
                respawnTimer -= engine.DeltaTime;
                if (respawnTimer <= 0f)
                {
                    light.Visible = true;
                    bloom.Visible = true;
                    sprite.Play("on");
                    spriteEvil.Play("on");
                    if (!fireMode)
                        ((global::Celeste.Core.Audio.ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                            "event:/game/06_reflection/pinballbumper_reset", Position);
                }
            }
            else if (((Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Clock.OnInterval(0.05f, engine))
            {
                float num = SourceRandomMath.NextAngle(
                    ((global::Celeste.Core.Randomness.ISourceRandomEnvironment)engine)
                    .Random);
                var type = (fireMode
                    ? ((global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)engine).ParticleTypes.Bumper
                    .P_FireAmbience
                    : ((global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)engine).ParticleTypes.Bumper
                    .P_Ambience);
                float direction = (fireMode ? (-(float)Math.PI / 2f) : num);
                float length = (fireMode ? 12 : 8);
                ((OriginalLevelSceneRoot)Scene).Particles.Emit(type, 1,
                    base.Center + Vector2Geometry.AngleToVector(num, length), Vector2.One * 2f, direction);
            }

            UpdatePosition();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OnPlayer(RoomPlayerSession player)
        {
            if (fireMode)
            {
                if (!((global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)engine).SaveContext.CurrentSave
                    .Assists.Invincible)
                    HitHotPlayerCore(player);
            }
            else
                LaunchPlayerCore(player);
        }

        private void HitHotPlayerCore(RoomPlayerSession player)
        {
            Vector2 vector =
                ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic
                .SafeNormalize(
                    player.Center - base.Center);
            hitDir = -vector;
            hitWiggler.Start();
            ((global::Celeste.Core.Audio.ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                "event:/game/09_core/hotpinball_activate", Position);
            respawnTimer = RespawnTime;
            player.Die(vector);
            ((OriginalLevelSceneRoot)Scene).Particles.Emit(
                ((global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)engine).ParticleTypes
                .Bumper.P_FireHit, 12, base.Center + vector * 12f, Vector2.One * 3f,
                Vector2Geometry.Angle(vector));
        }

        private void LaunchPlayerCore(RoomPlayerSession player)
        {
            if (!(respawnTimer <= 0f)) return;
            ((global::Celeste.Core.Audio.ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                ((global::Celeste.Game.Execution.Areas.IOriginalAreaKeyEnvironment)engine).AreaKeys
                .GetSessionArea(((OriginalLevelSceneRoot)Scene).Session).ID == 9
                    ? "event:/game/09_core/pinballbumper_hit"
                    : "event:/game/06_reflection/pinballbumper_hit",
                Position);

            respawnTimer = RespawnTime;
            Vector2 vector2 = player.ExplodeLaunch(Position, snapUp: false);
            sprite.Play("hit", restart: true);
            spriteEvil.Play("hit", restart: true);
            light.Visible = false;
            bloom.Visible = false;
            ((OriginalLevelSceneRoot)Scene).DirectionalShake(vector2, 0.15f);
            ((OriginalLevelSceneRoot)Scene).Displacement.AddBurst(base.Center, 0.3f, 8f, 32f, 0.8f);
            ((OriginalLevelSceneRoot)Scene).Particles.Emit(
                ((global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)engine).ParticleTypes.Bumper
                .P_Launch, 12, base.Center + vector2 * 12f, Vector2.One * 3f,
                Vector2Geometry.Angle(vector2));
        }
    }
}
