using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Collectibles.Hearts;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display.Colors;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Collectibles.Hearts;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Entities.Collectibles.Hearts
{
    public class OriginalFakeHeartState : SceneEntityState
    {
        private const float RespawnTime = 3f;
        private readonly OriginalAreaMode color;
        private IOriginalHeartGemRuntimePolicy HeartPolicy => ((IOriginalHeartGemEnvironment)engine).HeartGemPolicy;


        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private AtlasData GameAtlas =>
            ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        private WigglerComponentPool WigglerPool =>
            ((ISourceWigglerPoolScope)engine).WigglerPool;

        private Sprite sprite;

        private ParticleTypePresentation shineParticle;

        public WigglerComponent ScaleWiggler;

        private WigglerComponent moveWiggler;

        private Vector2 moveWiggleDir;

        private BloomPointState bloom;

        private VertexLightState light;

        private readonly HoldableColliderState crystalCollider;

        private float timer;

        private float bounceSfxDelay;

        private float respawnTimer;

        public OriginalFakeHeartState(ISourceEngineContext engine, Vector2 position)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            OwnedComponents.Add(crystalCollider = new(OnHoldable));
            OwnedComponents.Add(new MirrorReflectionState());
        }

        public OriginalFakeHeartState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : this(engine, data.Position + offset)
        {
            if (HeartPolicy.InstalledFakeHeartColor)
                color = EntityAttributeReader.Enum(data.Values,
                    "color", (OriginalAreaMode)(-1));
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var areaMode = ((ISourceRandomEnvironment)engine).Random.Choose(0, 1, 2);
            if (HeartPolicy.InstalledFakeHeartColor &&
                color != (OriginalAreaMode)(-1))
                areaMode = (int)color;
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("heartgem" + areaMode));
            sprite.Play("spin");
            sprite.OnLoop = delegate(string anim)
            {
                if (Visible && anim == "spin")
                {
                    Process.AudioSession.Play("event:/game/general/crystalheart_pulse", Position, Process.SaveContext);
                    ScaleWiggler.Start();
                    (Scene as OriginalLevelSceneRoot).Displacement.AddBurst(Position, 0.35f, 8f, 48f, 0.25f);
                }
            };
            Collider = new HitboxColliderGeometry(16f, 16f, -8f, -8f);
            OwnedComponents.Add(
                new PlayerColliderComponentState(
                    OnPlayer));
            OwnedComponents.Add(ScaleWiggler = WigglerPool.Create(0.5f, 4f,
                delegate(float f) { sprite.Scale = Vector2.One * (1f + f * 0.25f); }));
            OwnedComponents.Add(bloom = new(0.75f, 16f));
            PackedColor value;
            switch (areaMode)
            {
                case 0:
                    value = PackedColor.Aqua;
                    shineParticle = Process.ParticleTypes.HeartGem.P_BlueShine;
                    break;
                case 1:
                    value = PackedColor.Red;
                    shineParticle = Process.ParticleTypes.HeartGem.P_RedShine;
                    break;
                default:
                    value = PackedColor.Gold;
                    shineParticle = Process.ParticleTypes.HeartGem.P_GoldShine;
                    break;
            }

            value = SourceColorInterpolation.Lerp(value, PackedColor.White, 0.5f,
                ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            OwnedComponents.Add(light = new(engine, value, 1f, 32, 64));
            moveWiggler = WigglerPool.Create(0.8f, 2f);
            moveWiggler.StartZero = true;
            OwnedComponents.Add(moveWiggler);
        }

        public override void Update()
        {
            bounceSfxDelay -= engine.DeltaTime;
            timer += engine.DeltaTime;
            sprite.Position = FakeHeartHoverMotion.Offset(timer, moveWiggleDir, moveWiggler);
            if (FakeHeartHoverMotion.AdvanceRespawnTimer(ref respawnTimer, engine))
            {
                Collidable = Visible = true;
                ScaleWiggler.Start();
            }

            base.Update();
            if (Visible && ((OriginalLevelSceneRoot)Scene).OnInterval(0.1f))
                ((OriginalLevelSceneRoot)Scene).Particles.Emit(shineParticle, 1, Center, Vector2.One * 8f);
        }

        public void OnHoldable(HoldableState h)
        {
            var entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
            if (Visible && h.Dangerous(crystalCollider)) Collect(entity, Vector2Geometry.Angle(h.GetSpeed()));
        }

        public void OnPlayer(RoomPlayerSession player)
        {
            if (!Visible || (Scene as OriginalLevelSceneRoot).Frozen) return;

            if (player.DashAttacking)
            {
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
                Collect(player, Vector2Geometry.Angle(player.Data.Motion.Normal.Speed));
                return;
            }

            if (bounceSfxDelay <= 0f)
            {
                Process.AudioSession.Play("event:/game/general/crystalheart_bounce", Position, Process.SaveContext);
                bounceSfxDelay = 0.1f;
            }

            player.PointBounce(Center);
            moveWiggler.Start();
            ScaleWiggler.Start();
            moveWiggleDir = VectorArithmetic.SafeNormalize(Center - player.Center, Vector2.UnitY);
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
        }

        private void Collect(RoomPlayerSession player, float angle)
        {
            FakeHeartShatter.Process(engine, this, player, angle, RespawnTime, ref respawnTimer);
        }
    }
}
