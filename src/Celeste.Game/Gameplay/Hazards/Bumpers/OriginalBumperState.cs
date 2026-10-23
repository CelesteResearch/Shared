using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Gameplay.Hazards.Bumpers
{
    public class OriginalBumperState : SceneEntityState
    {
        protected readonly ISourceEngineContext engine;


        private const float RespawnTime = 0.6f;

        private const float MoveCycleTime = 1.8181819f;

        private const float SineCycleFreq = 0.44f;

        private readonly Sprite sprite;

        private readonly Sprite spriteEvil;

        private readonly VertexLightState light;

        private readonly BloomPointState bloom;

        private Vector2? node;

        private bool goBack;

        private Vector2 anchor;

        private readonly SineWaveState sine;

        private float respawnTimer;

        private bool fireMode;

        private readonly WigglerComponent hitWiggler;

        private Vector2 hitDir;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public OriginalBumperState(Vector2 position, Vector2? node,
            ISourceEngineContext engine)
            : base(
                ((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration,
                position)
        {
            this.engine = engine;
            Collider =
                new CircleColliderGeometry(
                    ((ISourceVectorEnvironment)engine).VectorArithmetic,
                    12f);
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(sine = new SineWaveState(engine, 0.44f).Randomize());
            OwnedComponents.Add(sprite = ((ISourceGameGraphicsEnvironment)engine)
                .GameGraphics.SpriteFactory.Create("bumper"));
            OwnedComponents.Add(spriteEvil = ((ISourceGameGraphicsEnvironment)engine)
                .GameGraphics.SpriteFactory.Create("bumper_evil"));
            spriteEvil.Visible = false;
            OwnedComponents.Add(light =
                new(engine, new(0, 128, 128, 255), 1f, 16, 32));
            OwnedComponents.Add(bloom = new(0.5f, 16f));
            this.node = node;
            anchor = Position;
            if (node.HasValue)
            {
                var start = Position;
                var end = node.Value;
                var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Looping,
                    ((ISourceEasingEnvironment)engine)
                    .EasingArithmetic
                    .CubeInOut,
                    MoveCycleTime, true);
                tween.OnUpdate = delegate(SourceTweenState t)
                {
                    if (goBack)
                        anchor = Vector2Interpolation.Lerp(end, start, t.Eased,
                            ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                    else
                        anchor = Vector2Interpolation.Lerp(start, end, t.Eased,
                            ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                };
                tween.OnComplete = delegate { goBack = !goBack; };
                OwnedComponents.Add(tween);
            }

            UpdatePosition();
            OwnedComponents.Add(hitWiggler =
                ((ISourceWigglerPoolScope)engine).WigglerPool.Create(1.2f,
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
            Position = new(
                ((ISourceScalarEnvironment)engine).ScalarArithmetic.AddProduct(
                    anchor.X,
                    sine.Value, 3f),
                ((ISourceScalarEnvironment)engine).ScalarArithmetic.AddProduct(
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
                        ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                            "event:/game/06_reflection/pinballbumper_reset", Position);
                }
            }
            else if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.05f, engine))
            {
                var num = SourceRandomMath.NextAngle(
                    ((ISourceRandomEnvironment)engine)
                    .Random);
                var type = fireMode
                    ? ((IOriginalGameplayProcess)engine).ParticleTypes.Bumper
                    .P_FireAmbience
                    : ((IOriginalGameplayProcess)engine).ParticleTypes.Bumper
                    .P_Ambience;
                var direction = fireMode ? -(float)Math.PI / 2f : num;
                float length = fireMode ? 12 : 8;
                ((OriginalLevelSceneRoot)Scene).Particles.Emit(type, 1,
                    Center + Vector2Geometry.AngleToVector(num, length), Vector2.One * 2f, direction);
            }

            UpdatePosition();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OnPlayer(RoomPlayerSession player)
        {
            if (fireMode)
            {
                if (!((IOriginalGameplayProcess)engine).SaveContext.CurrentSave
                    .Assists.Invincible)
                    HitHotPlayerCore(player);
            }
            else
            {
                LaunchPlayerCore(player);
            }
        }

        private void HitHotPlayerCore(RoomPlayerSession player)
        {
            var vector =
                ((ISourceVectorEnvironment)engine).VectorArithmetic
                .SafeNormalize(
                    player.Center - Center);
            hitDir = -vector;
            hitWiggler.Start();
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                "event:/game/09_core/hotpinball_activate", Position);
            respawnTimer = RespawnTime;
            player.Die(vector);
            ((OriginalLevelSceneRoot)Scene).Particles.Emit(
                ((IOriginalGameplayProcess)engine).ParticleTypes
                .Bumper.P_FireHit, 12, Center + vector * 12f, Vector2.One * 3f,
                Vector2Geometry.Angle(vector));
        }

        private void LaunchPlayerCore(RoomPlayerSession player)
        {
            if (!(respawnTimer <= 0f)) return;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                ((IOriginalAreaKeyEnvironment)engine).AreaKeys
                .GetSessionArea(((OriginalLevelSceneRoot)Scene).Session).ID == 9
                    ? "event:/game/09_core/pinballbumper_hit"
                    : "event:/game/06_reflection/pinballbumper_hit",
                Position);

            respawnTimer = RespawnTime;
            var vector2 = player.ExplodeLaunch(Position, false);
            sprite.Play("hit", true);
            spriteEvil.Play("hit", true);
            light.Visible = false;
            bloom.Visible = false;
            ((OriginalLevelSceneRoot)Scene).DirectionalShake(vector2, 0.15f);
            ((OriginalLevelSceneRoot)Scene).Displacement.AddBurst(Center, 0.3f, 8f, 32f, 0.8f);
            ((OriginalLevelSceneRoot)Scene).Particles.Emit(
                ((IOriginalGameplayProcess)engine).ParticleTypes.Bumper
                .P_Launch, 12, Center + vector2 * 12f, Vector2.One * 3f,
                Vector2Geometry.Angle(vector2));
        }
    }
}
