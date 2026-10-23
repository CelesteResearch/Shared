using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Audio;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Display;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Components.Shaking;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Audio.Sources;
using Celeste.Physics.Collision.Shapes;
using Celeste.Graphics.Animation;

namespace Celeste.Game.Gameplay.Enemies.AngryOshiro
{
    public class OriginalAngryOshiroState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;

        private static RoomPlayerSession FirstPlayer(ISourceScene scene)
        {
            return scene.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
        }

        private float Lerp(float first, float second, float amount) =>
            ScalarMath.Lerp(first, second, amount, ((ISourceScalarEnvironment)engine).ScalarArithmetic);

        private void AddChargeAlarm(float duration, Action onComplete) =>
            Celeste.Core.Components.Timing.SourceAlarmState.Set(engine.AlarmPool, OwnedComponents,
                duration, onComplete);

        private const int StChase = 0;

        private const int StChargeUp = 1;

        private const int StAttack = 2;

        private const int StDummy = 3;

        private const int StWaiting = 4;

        private const int StHurt = 5;

        private const float HitboxBackRange = 4f;

        public Sprite Sprite;

        private Sprite lightning;

        private bool lightningVisible;

        private VertexLightState light;

        private OriginalLevelSceneRoot level;

        private SineWaveState sine;

        private float cameraXOffset;

        private SimulationStateMachine state;

        protected SimulationStateMachine StateMachine => state;

        private int attackIndex;

        private float targetAnxiety;

        private float anxietySpeed;

        private bool easeBackFromRightEdge;

        private bool fromCutscene;

        private bool doRespawnAnim;

        private bool leaving;

        private ShakerComponentState shaker;

        private PlayerColliderComponentState bounceCollider;

        private Vector2 colliderTargetPosition;

        private bool canControlTimeRate = true;

        private SoundSourceComponentState prechargeSfx;

        private SoundSourceComponentState chargeSfx;

        private bool hasEnteredSfx;

        private const float minCameraOffsetX = -48f;

        private const float yApproachTargetSpeed = 100f;

        private float yApproachSpeed = 100f;

        private static readonly float[] ChaseWaitTimes = new float[5] { 1f, 2f, 3f, 2f, 3f };

        private float attackSpeed;

        private const float HurtXSpeed = 100f;

        private const float HurtYSpeed = 200f;

        private float TargetY
        {
            get
            {
                RoomPlayerSession entity = FirstPlayer(level);
                if (entity != null)
                {
                    return ScalarMath.Clamp(entity.CenterY, level.Bounds.Top + 8, level.Bounds.Bottom - 8);
                }

                return base.Y;
            }
        }

        public bool DummyMode => state.State == 3;

        public OriginalAngryOshiroState(Vector2 position, bool fromCutscene, IOriginalAngryOshiroProcess process)
            : base(((ISourceEntitySourceDataEnvironment)process).EntitySourceDataRegistration, position)
        {
            engine = process;
            var sounds = process.SoundSources;
            OwnedComponents.Add(Sprite = process.GameGraphics.SpriteFactory.Create("oshiro_boss"));
            Sprite.Play("idle");
            OwnedComponents.Add(lightning = process.GameGraphics.SpriteFactory.Create("oshiro_boss_lightning"));
            lightning.Visible = false;
            lightning.OnFinish = delegate { lightningVisible = false; };
            base.Collider = new CircleColliderGeometry(((ISourceVectorEnvironment)engine).VectorArithmetic, 14f);
            base.Collider.Position = (colliderTargetPosition = new Vector2(3f, 4f));
            OwnedComponents.Add(sine = new SineWaveState(engine, 0.5f));
            OwnedComponents.Add(bounceCollider =
                new PlayerColliderComponentState(OnPlayerBounce, new HitboxColliderGeometry(28f, 6f, -11f, -11f)));
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            base.Depth = -12500;
            Visible = false;
            OwnedComponents.Add(light = new VertexLightState(engine, Vector2.Zero, PackedColor.White, 1f, 32, 64));
            OwnedComponents.Add(shaker = new ShakerComponentState(engine, on: false));
            state = ((ISourceStateMachineEnvironment)engine).StateMachines.Create(engine);
            state.SetCallbacks(0, ChaseUpdate, ChaseCoroutine, ChaseBegin);
            state.SetCallbacks(1, ChargeUpUpdate, ChargeUpCoroutine, null, ChargeUpEnd);
            state.SetCallbacks(2, AttackUpdate, AttackCoroutine, AttackBegin, AttackEnd);
            state.SetCallbacks(3, null);
            state.SetCallbacks(4, WaitingUpdate);
            state.SetCallbacks(5, HurtUpdate, null, HurtBegin);
            OwnedComponents.Add(state);
            if (fromCutscene)
            {
                yApproachSpeed = 0f;
            }

            this.fromCutscene = fromCutscene;
            OwnedComponents.Add(new RoomTransitionListener
            {
                OnOutBegin = delegate
                {
                    if (base.X > (float)level.Bounds.Left + Sprite.Width / 2f)
                    {
                        Visible = false;
                    }
                    else
                    {
                        easeBackFromRightEdge = true;
                    }
                },
                OnOut = delegate
                {
                    lightning.Update();
                    if (easeBackFromRightEdge)
                    {
                        base.X -= 128f * engine.RawDeltaTime;
                    }
                }
            });
            OwnedComponents.Add(prechargeSfx = sounds.Create());
            OwnedComponents.Add(chargeSfx = sounds.Create());
            engine.Effects.AnxietyOrigin = new Vector2(1f, 0.5f);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = Scene as OriginalLevelSceneRoot;
            if (level.Session.GetFlag("oshiroEnding") ||
                (!level.Session.GetFlag("oshiro_resort_roof") && level.Session.Level.Equals("roof00"))) RemoveSelf();
            if (state.State != 3 && !fromCutscene) state.State = 4;
            if (!fromCutscene)
            {
                Y = TargetY;
                cameraXOffset = -48f;
            }
            else cameraXOffset = X - level.Camera.Left;
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (state.State != 5 && (base.CenterX < player.CenterX + 4f || Sprite.CurrentAnimationID != "respawn"))
            {
                player.Die(((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(
                    player.Center - base.Center,
                    Vector2.UnitX));
            }
        }

        private void OnPlayerBounce(RoomPlayerSession player)
        {
            if (state.State == 2 && player.Bottom <= base.Top + 6f)
            {
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/game/general/thing_booped",
                    Position);
                ((ISourceFreezeEnvironment)engine).Freeze(0.2f);
                player.Bounce(base.Top + 2f);
                state.State = 5;
                prechargeSfx.Stop();
                chargeSfx.Stop();
            }
        }

        public override void Update()
        {
            base.Update();
            Sprite.Scale =
                new Vector2(
                    ScalarMath.Approach(Sprite.Scale.X, 1f, 0.6f * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic), Sprite.Scale.Y);
            Sprite.Scale = new Vector2(Sprite.Scale.X,
                ScalarMath.Approach(Sprite.Scale.Y, 1f, 0.6f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic));
            if (!doRespawnAnim)
            {
                Visible = base.X > (float)level.Bounds.Left - base.Width / 2f;
            }

            yApproachSpeed = ScalarMath.Approach(yApproachSpeed, 100f, 300f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (state.State != 3 && canControlTimeRate)
            {
                if (state.State == 2 && attackSpeed > 200f)
                {
                    RoomPlayerSession entity = FirstPlayer((ISourceScene)Scene);
                    if (entity != null && !entity.Dead && base.CenterX < entity.CenterX + 4f)
                    {
                        engine.Effects.TimeRate = Lerp(
                            ScalarMath.ClampedMap(entity.CenterX - base.CenterX, 30f, 80f, 0.5f),
                            1f, ScalarMath.ClampedMap(Math.Abs(entity.CenterY - base.CenterY), 32f, 48f));
                    }
                    else
                    {
                        engine.Effects.TimeRate = 1f;
                    }
                }
                else
                {
                    engine.Effects.TimeRate = 1f;
                }

                engine.Effects.GameRate = ScalarMath.Approach(engine.Effects.GameRate,
                    ScalarMath.Map(engine.Effects.TimeRate, 0.5f, 1f), engine.DeltaTime * 8f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                engine.Effects.Anxiety = ScalarMath.Approach(engine.Effects.Anxiety, targetAnxiety,
                    anxietySpeed * engine.DeltaTime, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }
            else
            {
                engine.Effects.GameRate = 1f;
                engine.Effects.Anxiety = 0f;
            }
        }

        public void StopControllingTime()
        {
            canControlTimeRate = false;
        }

        public override void Render(ISourceRenderContext context)
        {
            if (lightningVisible)
            {
                lightning.RenderPosition = new Vector2(level.Camera.Left - 2f, base.Top + 16f);
                lightning.Render(context);
            }

            Sprite.Position = shaker.Value * 2f;
            base.Render(context);
        }

        public void Leave()
        {
            leaving = true;
        }

        public void Squish()
        {
            Sprite.Scale = new Vector2(1.3f, 0.5f);
            shaker.ShakeFor(0.5f, removeOnFinish: false);
        }

        private void ChaseBegin()
        {
            Sprite.Play("idle");
        }

        private int ChaseUpdate()
        {
            if (!hasEnteredSfx && cameraXOffset >= -16f && !doRespawnAnim)
            {
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/oshiro/boss_enter_screen",
                    Position);
                hasEnteredSfx = true;
            }

            if (doRespawnAnim && cameraXOffset >= 0f)
            {
                base.Collider.Position = new Vector2(-48f, base.Collider.Position.Y);
                Visible = true;
                Sprite.Play("respawn");
                doRespawnAnim = false;
                if (FirstPlayer((ISourceScene)Scene) != null)
                {
                    ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/oshiro/boss_reform",
                        Position);
                }
            }

            cameraXOffset = ScalarMath.Approach(cameraXOffset, 20f, 80f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.X = level.Camera.Left + cameraXOffset;
            base.Collider.Position =
                new Vector2(
                    ScalarMath.Approach(base.Collider.Position.X, colliderTargetPosition.X, engine.DeltaTime * 128f,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic), base.Collider.Position.Y);
            Collidable = Visible;
            if (FirstPlayer(level) != null && Sprite.CurrentAnimationID != "respawn")
            {
                base.CenterY = ScalarMath.Approach(base.CenterY, TargetY, yApproachSpeed * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }

            return 0;
        }

        private IEnumerator ChaseCoroutine()
        {
            if (level.Session.Mode != 0)
            {
                yield return 1f;
            }
            else
            {
                yield return ChaseWaitTimes[attackIndex];
                attackIndex++;
                attackIndex %= ChaseWaitTimes.Length;
            }

            prechargeSfx.Play("event:/char/oshiro/boss_precharge");
            Sprite.Play("charge");
            yield return 0.7f;
            if (FirstPlayer((ISourceScene)Scene) != null)
            {
                AddChargeAlarm(0.216f, delegate { chargeSfx.Play("event:/char/oshiro/boss_charge"); });
                state.State = 1;
            }
            else
            {
                Sprite.Play("idle");
            }
        }

        private int ChargeUpUpdate()
        {
            if (level.OnInterval(0.05f))
            {
                Sprite.Position = RandomShakeVector.Next(((ISourceRandomEnvironment)engine).Random);
            }

            cameraXOffset = ScalarMath.Approach(cameraXOffset, 0f, 40f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.X = level.Camera.Left + cameraXOffset;
            RoomPlayerSession entity = FirstPlayer(level);
            if (entity != null)
            {
                base.CenterY = ScalarMath.Approach(base.CenterY,
                    ScalarMath.Clamp(entity.CenterY, level.Bounds.Top + 8, level.Bounds.Bottom - 8),
                    30f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }

            return 1;
        }

        private void ChargeUpEnd()
        {
            Sprite.Position = Vector2.Zero;
        }

        private IEnumerator ChargeUpCoroutine()
        {
            ((ISourceFreezeEnvironment)engine).Freeze(0.05f);
            engine.Effects.Anxiety = 0.3f;
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Strong,
                RumbleLength.Medium);
            lightningVisible = true;
            lightning.Play("once", restart: true);
            yield return 0.3f;
            if (FirstPlayer((ISourceScene)Scene) != null)
            {
                state.State = 2;
            }
            else
            {
                state.State = 0;
            }
        }

        private void AttackBegin()
        {
            attackSpeed = 0f;
            targetAnxiety = 0.3f;
            anxietySpeed = 4f;
            level.DirectionalShake(Vector2.UnitX);
        }

        private void AttackEnd()
        {
            targetAnxiety = 0f;
            anxietySpeed = 0.5f;
        }

        private int AttackUpdate()
        {
            base.X += attackSpeed * engine.DeltaTime;
            attackSpeed = ScalarMath.Approach(attackSpeed, 500f, 2000f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (base.X >= level.Camera.Right + 48f)
            {
                if (leaving)
                {
                    RemoveSelf();
                    return 2;
                }

                base.X = level.Camera.Left + -48f;
                cameraXOffset = -48f;
                doRespawnAnim = true;
                Visible = false;
                return 0;
            }

            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Light, RumbleLength.Short);
            if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.05f, engine))
            {
                Celeste.Simulation.Presentation.Effects.Trails.Lifecycle.TrailManagerState.Add(engine,
                    (ISourceRenderEnvironment)engine, this, new PackedColor(255, 0, 0, 255) * 0.6f, 0.5f);
            }

            return 2;
        }

        private IEnumerator AttackCoroutine()
        {
            yield return 0.1f;
            targetAnxiety = 0f;
            anxietySpeed = 0.5f;
        }

        public void EnterDummyMode()
        {
            state.State = 3;
        }

        public void LeaveDummyMode()
        {
            state.State = 0;
        }

        private int WaitingUpdate()
        {
            RoomPlayerSession entity = FirstPlayer((ISourceScene)Scene);
            if (entity != null && entity.Speed != Vector2.Zero && entity.X > (float)(level.Bounds.Left + 48))
            {
                return 0;
            }

            return 4;
        }

        private void HurtBegin()
        {
            Sprite.Play("hurt", restart: true);
        }

        private int HurtUpdate()
        {
            base.X += 100f * engine.DeltaTime;
            base.Y += 200f * engine.DeltaTime;
            if (base.Top > (float)(level.Bounds.Bottom + 20))
            {
                if (leaving)
                {
                    RemoveSelf();
                    return 5;
                }

                base.X = level.Camera.Left + -48f;
                cameraXOffset = -48f;
                doRespawnAnim = true;
                Visible = false;
                return 0;
            }

            return 5;
        }
    }
}
