using Celeste.Core.Display;
using Celeste.Simulation.Gameplay.Collectibles.Hearts;
using Celeste.Game.Gameplay.Collectibles.Hearts;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Execution.Engine.Actions;
using Celeste.Game.Gameplay.Effects.Slashes;
using Celeste.Graphics.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Timing;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Audio;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Entities.Collectibles.Hearts;
using Celeste.Game.Entities.Effects.AbsorbOrbs;
using Celeste.Game.Presentation.Particles;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Particles.Sources;
using Celeste.Core.Rendering;

namespace Celeste.Game.Entities.Collectibles.Hearts
{
    public class OriginalFakeHeartState : SceneEntityState
    {
        private const float RespawnTime = 3f;
        private global::Celeste.Game.Execution.Areas.OriginalAreaMode color;
        private IOriginalHeartGemRuntimePolicy HeartPolicy => ((IOriginalHeartGemEnvironment)engine).HeartGemPolicy;


        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private global::Celeste.Graphics.Content.Atlas.AtlasData GameAtlas =>
            ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        private global::Celeste.Scene.Components.Oscillation.WigglerComponentPool WigglerPool =>
            ((ISourceWigglerPoolScope)engine).WigglerPool;

        private Sprite sprite;

        private global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation shineParticle;

        public WigglerComponent ScaleWiggler;

        private WigglerComponent moveWiggler;

        private Vector2 moveWiggleDir;

        private BloomPointState bloom;

        private VertexLightState light;

        private HoldableColliderState crystalCollider;

        private float timer;

        private float bounceSfxDelay;

        private float respawnTimer;

        public OriginalFakeHeartState(ISourceEngineContext engine, Vector2 position)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            OwnedComponents.Add(crystalCollider = new HoldableColliderState(OnHoldable));
            OwnedComponents.Add(new MirrorReflectionState());
        }

        public OriginalFakeHeartState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : this(engine, data.Position + offset)
        {
            if (HeartPolicy.InstalledFakeHeartColor)
                color = global::Celeste.Formats.Map.Entities.Attributes.EntityAttributeReader.Enum(data.Values,
                    "color", (global::Celeste.Game.Execution.Areas.OriginalAreaMode)(-1));
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            int areaMode = ((ISourceRandomEnvironment)engine).Random.Choose(0, 1, 2);
            if (HeartPolicy.InstalledFakeHeartColor &&
                color != (global::Celeste.Game.Execution.Areas.OriginalAreaMode)(-1))
                areaMode = (int)color;
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("heartgem" + (int)areaMode));
            sprite.Play("spin");
            sprite.OnLoop = delegate(string anim)
            {
                if (Visible && anim == "spin")
                {
                    Process.AudioSession.Play("event:/game/general/crystalheart_pulse", Position, Process.SaveContext);
                    ScaleWiggler.Start();
                    (base.Scene as OriginalLevelSceneRoot).Displacement.AddBurst(Position, 0.35f, 8f, 48f, 0.25f);
                }
            };
            base.Collider = new HitboxColliderGeometry(16f, 16f, -8f, -8f);
            OwnedComponents.Add(
                new global::Celeste.Simulation.Gameplay.Player.Collision.Components.PlayerColliderComponentState(
                    OnPlayer));
            OwnedComponents.Add(ScaleWiggler = WigglerPool.Create(0.5f, 4f,
                delegate(float f) { sprite.Scale = Vector2.One * (1f + f * 0.25f); }));
            OwnedComponents.Add(bloom = new BloomPointState(0.75f, 16f));
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
            OwnedComponents.Add(light = new VertexLightState(engine, value, 1f, 32, 64));
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
                Collidable = (Visible = true);
                ScaleWiggler.Start();
            }

            base.Update();
            if (Visible && ((OriginalLevelSceneRoot)Scene).OnInterval(0.1f))
            {
                ((OriginalLevelSceneRoot)Scene).Particles.Emit(shineParticle, 1, base.Center, Vector2.One * 8f);
            }
        }

        public void OnHoldable(HoldableState h)
        {
            RoomPlayerSession entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            if (Visible && h.Dangerous(crystalCollider))
            {
                Collect(entity, Vector2Geometry.Angle(h.GetSpeed()));
            }
        }

        public void OnPlayer(RoomPlayerSession player)
        {
            if (!Visible || (base.Scene as OriginalLevelSceneRoot).Frozen)
            {
                return;
            }

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

            player.PointBounce(base.Center);
            moveWiggler.Start();
            ScaleWiggler.Start();
            moveWiggleDir = VectorArithmetic.SafeNormalize(base.Center - player.Center, Vector2.UnitY);
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
        }

        private void Collect(RoomPlayerSession player, float angle)
        {
            FakeHeartShatter.Process(engine, this, player, angle, RespawnTime, ref respawnTimer);
        }
    }
}
