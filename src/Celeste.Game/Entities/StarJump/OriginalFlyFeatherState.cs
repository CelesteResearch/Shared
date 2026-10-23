using Celeste.Core.Display;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Scene.Entities;
using Celeste.Scene.Components.Oscillation;
using Celeste.Physics.Collision.Shapes;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Effects.Slashes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.StarJump
{
    public class OriginalFlyFeatherState : SceneEntityState
    {
        private const float RespawnTime = 3f;

        private Sprite sprite;

        private SpriteImage outline;

        private WigglerComponent wiggler;

        private BloomPointState bloom;

        private VertexLightState light;

        private OriginalLevelSceneRoot level;
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private SineWaveState sine;

        private bool shielded;

        private bool singleUse;

        private WigglerComponent shieldRadiusWiggle;

        private WigglerComponent moveWiggle;

        private Vector2 moveWiggleDir;

        private float respawnTimer;

        public OriginalFlyFeatherState(Vector2 position, bool shielded, bool singleUse, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            this.shielded = shielded;
            this.singleUse = singleUse;
            base.Collider = new HitboxColliderGeometry(20f, 20f, -10f, -10f);
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("flyFeather"));
            OwnedComponents.Add(wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(1f, 4f,
                delegate(float v) { sprite.Scale = Vector2.One * (1f + v * 0.2f); }));
            OwnedComponents.Add(bloom = new BloomPointState(0.5f, 20f));
            OwnedComponents.Add(light = new VertexLightState(engine, PackedColor.White, 1f, 16, 48));
            OwnedComponents.Add(sine = new SineWaveState(engine, 0.6f).Randomize());
            OwnedComponents.Add(outline =
                new SpriteImage(
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/flyFeather/outline"]));
            outline.CenterOrigin();
            outline.Visible = false;
            shieldRadiusWiggle = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.5f, 4f);
            OwnedComponents.Add(shieldRadiusWiggle);
            moveWiggle = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.8f, 2f);
            moveWiggle.StartZero = true;
            OwnedComponents.Add(moveWiggle);
            UpdateY();
        }

        public OriginalFlyFeatherState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, EntityAttributeReader.Bool(data.Values, "shielded", false),
                EntityAttributeReader.Bool(data.Values, "singleUse", false), engine)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = (OriginalLevelSceneRoot)Scene;
        }

        public override void Update()
        {
            base.Update();
            if (respawnTimer > 0f)
            {
                respawnTimer -= engine.DeltaTime;
                if (respawnTimer <= 0f)
                {
                    Respawn();
                }
            }

            UpdateY();
            light.Alpha = ScalarMath.Approach(light.Alpha, sprite.Visible ? 1f : 0f, 4f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            bloom.Alpha = light.Alpha * 0.8f;
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            if (shielded && sprite.Visible)
            {
                SourcePrimitiveDrawing.Circle(context, this, Position + sprite.Position,
                    10f - shieldRadiusWiggle.Value * 2f, PackedColor.White, 3,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
            }
        }

        private void Respawn()
        {
            if (!Collidable)
            {
                outline.Visible = false;
                Collidable = true;
                sprite.Visible = true;
                wiggler.Start();
                Play("event:/game/06_reflection/feather_reappear", Position);
                level.ParticlesFG.Emit(Process.ParticleTypes.FlyFeather.P_Respawn, 16, Position, Vector2.One * 2f);
            }
        }

        private void UpdateY()
        {
            sprite.Position.X = 0f;
            Sprite obj = sprite;
            float y = (bloom.Y = sine.Value * 2f);
            obj.Position.Y = y;
            sprite.Position += moveWiggleDir * moveWiggle.Value * -8f;
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            Vector2 speed = player.Speed;
            if (shielded && !player.DashAttacking)
            {
                player.PointBounce(base.Center);
                moveWiggle.Start();
                shieldRadiusWiggle.Start();
                moveWiggleDir =
                    ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(base.Center - player.Center,
                        Vector2.UnitY);
                Play("event:/game/06_reflection/feather_bubble_bounce", Position);
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
                return;
            }

            bool flag = player.Machine.State == 19;
            if (player.StartStarFly())
            {
                if (!flag)
                {
                    Play(
                        shielded
                            ? "event:/game/06_reflection/feather_bubble_get"
                            : "event:/game/06_reflection/feather_get",
                        Position);
                }
                else
                {
                    Play(
                        shielded
                            ? "event:/game/06_reflection/feather_bubble_renew"
                            : "event:/game/06_reflection/feather_renew", Position);
                }

                Collidable = false;
                OwnedComponents.Add(new SimulationCoroutine(engine, CollectRoutine(player, speed)));
                if (!singleUse)
                {
                    outline.Visible = true;
                    respawnTimer = 3f;
                }
            }
        }

        private IEnumerator CollectRoutine(RoomPlayerSession player, Vector2 playerSpeed)
        {
            level.Shake(0.2f);
            sprite.Visible = false;
            yield return 0.05f;
            float direction = ((!(playerSpeed != Vector2.Zero))
                ? Vector2Geometry.Angle(Position - player.Center)
                : Vector2Geometry.Angle(playerSpeed));
            level.ParticlesFG.Emit(Process.ParticleTypes.FlyFeather.P_Collect, 10, Position, Vector2.One * 6f);
            OriginalSlashFxState.Burst(engine, Position, direction);
        }

        private void Play(string path, Vector2 position)
            => Process.AudioSession.Play(path, position, Process.SaveContext);
    }
}
