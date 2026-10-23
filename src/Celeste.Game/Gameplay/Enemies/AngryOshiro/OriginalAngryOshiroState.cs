using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components.Timing;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Animation;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Components.Shaking;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Simulation.Presentation.Lighting;
using JetBrains.Annotations;

namespace Celeste.Game.Gameplay.Enemies.AngryOshiro
{
    public class OriginalAngryOshiroState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;

        private static RoomPlayerSession FirstPlayer(ISourceScene scene)
        {
            return scene.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                typeof(RoomPlayerSession).FullName);
        }

        private float Lerp(float first, float second, float amount)
        {
            return ScalarMath.Lerp(first, second, amount, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
        }

        private void AddChargeAlarm(float duration, Action onComplete)
        {
            SourceAlarmState.Set(engine.AlarmPool, OwnedComponents,
                duration, onComplete);
        }

        private const int StChase = 0;

        private const int StChargeUp = 1;

        private const int StAttack = 2;

        private const int StDummy = 3;

        private const int StWaiting = 4;

        private const int StHurt = 5;

        private const float HitboxBackRange = 4f;

        public Sprite Sprite;

        private readonly Sprite lightning;

        private bool lightningVisible;

        private VertexLightState light;

        private OriginalLevelSceneRoot level;

        private SineWaveState sine;

        private float cameraXOffset;

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private SimulationStateMachine state;

        protected SimulationStateMachine StateMachine => state;

        private int attackIndex;

        private float targetAnxiety;

        private float anxietySpeed;

        private bool easeBackFromRightEdge;

        private readonly bool fromCutscene;

        private bool doRespawnAnim;

        private bool leaving;

        private readonly ShakerComponentState shaker;

        private PlayerColliderComponentState bounceCollider;

        private readonly Vector2 colliderTargetPosition;

        private bool canControlTimeRate = true;

        private readonly SoundSourceComponentState prechargeSfx;

        private readonly SoundSourceComponentState chargeSfx;

        private bool hasEnteredSfx;

        private const float minCameraOffsetX = -48f;

        private const float yApproachTargetSpeed = 100f;

        private float yApproachSpeed = 100f;

        private static readonly float[] ChaseWaitTimes = [1f, 2f, 3f, 2f, 3f];

        private float attackSpeed;

        private const float HurtXSpeed = 100f;

        private const float HurtYSpeed = 200f;

        private float TargetY
        {
            get
            {
                var entity = FirstPlayer(level);
                return entity != null
                    ? ScalarMath.Clamp(entity.CenterY, level.Bounds.Top + 8, level.Bounds.Bottom - 8)
                    : Y;
            }
        }

        public bool DummyMode => state.State == 3;

        public OriginalAngryOshiroState(Vector2 position, bool fromCutscene, IOriginalAngryOshiroProcess process)
            : base(process.EntitySourceDataRegistration, position)
        {
            engine = process;
            var sounds = process.SoundSources;
            OwnedComponents.Add(Sprite = process.GameGraphics.SpriteFactory.Create("oshiro_boss"));
            Sprite.Play("idle");
            OwnedComponents.Add(lightning = process.GameGraphics.SpriteFactory.Create("oshiro_boss_lightning"));
            lightning.Visible = false;
            lightning.OnFinish = delegate { lightningVisible = false; };
            Collider = new CircleColliderGeometry(((ISourceVectorEnvironment)engine).VectorArithmetic, 14f);
            Collider.Position = colliderTargetPosition = new(3f, 4f);
            OwnedComponents.Add(sine = new(engine, 0.5f));
            OwnedComponents.Add(bounceCollider =
                new(OnPlayerBounce, new HitboxColliderGeometry(28f, 6f, -11f, -11f)));
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            Depth = -12500;
            Visible = false;
            OwnedComponents.Add(light = new(engine, Vector2.Zero, PackedColor.White, 1f, 32, 64));
            OwnedComponents.Add(shaker = new(engine, false));
            state = ((ISourceStateMachineEnvironment)engine).StateMachines.Create(engine);
            state.SetCallbacks(0, ChaseUpdate, ChaseCoroutine, ChaseBegin);
            state.SetCallbacks(1, ChargeUpUpdate, ChargeUpCoroutine, null, ChargeUpEnd);
            state.SetCallbacks(2, AttackUpdate, AttackCoroutine, AttackBegin, AttackEnd);
            state.SetCallbacks(3, null);
            state.SetCallbacks(4, WaitingUpdate);
            state.SetCallbacks(5, HurtUpdate, null, HurtBegin);
            OwnedComponents.Add(state);
            if (fromCutscene) yApproachSpeed = 0f;

            this.fromCutscene = fromCutscene;
            OwnedComponents.Add(new RoomTransitionListener
            {
                OnOutBegin = delegate
                {
                    if (X > level.Bounds.Left + Sprite.Width / 2f)
                        Visible = false;
                    else
                        easeBackFromRightEdge = true;
                },
                OnOut = delegate
                {
                    lightning.Update();
                    if (easeBackFromRightEdge) X -= 128f * engine.RawDeltaTime;
                },
            });
            OwnedComponents.Add(prechargeSfx = sounds.Create());
            OwnedComponents.Add(chargeSfx = sounds.Create());
            engine.Effects.AnxietyOrigin = new(1f, 0.5f);
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
            else
            {
                cameraXOffset = X - level.Camera.Left;
            }
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (state.State != 5 && (CenterX < player.CenterX + 4f || Sprite.CurrentAnimationID != "respawn"))
                player.Die(((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(
                    player.Center - Center,
                    Vector2.UnitX));
        }

        private void OnPlayerBounce(RoomPlayerSession player)
        {
            if (state.State == 2 && player.Bottom <= Top + 6f)
            {
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/game/general/thing_booped",
                    Position);
                ((ISourceFreezeEnvironment)engine).Freeze(0.2f);
                player.Bounce(Top + 2f);
                state.State = 5;
                prechargeSfx.Stop();
                chargeSfx.Stop();
            }
        }

        public override void Update()
        {
            base.Update();
            Sprite.Scale =
                new(
                    ScalarMath.Approach(Sprite.Scale.X, 1f, 0.6f * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic), Sprite.Scale.Y);
            Sprite.Scale = new(Sprite.Scale.X,
                ScalarMath.Approach(Sprite.Scale.Y, 1f, 0.6f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic));
            if (!doRespawnAnim) Visible = X > level.Bounds.Left - Width / 2f;

            yApproachSpeed = ScalarMath.Approach(yApproachSpeed, 100f, 300f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (state.State != 3 && canControlTimeRate)
            {
                if (state.State == 2 && attackSpeed > 200f)
                {
                    var entity = FirstPlayer((ISourceScene)Scene);
                    if (entity != null && !entity.Dead && CenterX < entity.CenterX + 4f)
                        engine.Effects.TimeRate = Lerp(
                            ScalarMath.ClampedMap(entity.CenterX - CenterX, 30f, 80f, 0.5f),
                            1f, ScalarMath.ClampedMap(Math.Abs(entity.CenterY - CenterY), 32f, 48f));
                    else
                        engine.Effects.TimeRate = 1f;
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
                lightning.RenderPosition = new(level.Camera.Left - 2f, Top + 16f);
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
            Sprite.Scale = new(1.3f, 0.5f);
            shaker.ShakeFor(0.5f, false);
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
                Collider.Position = new(-48f, Collider.Position.Y);
                Visible = true;
                Sprite.Play("respawn");
                doRespawnAnim = false;
                if (FirstPlayer((ISourceScene)Scene) != null)
                    ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/oshiro/boss_reform",
                        Position);
            }

            cameraXOffset = ScalarMath.Approach(cameraXOffset, 20f, 80f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            X = level.Camera.Left + cameraXOffset;
            Collider.Position =
                new(
                    ScalarMath.Approach(Collider.Position.X, colliderTargetPosition.X, engine.DeltaTime * 128f,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic), Collider.Position.Y);
            Collidable = Visible;
            if (FirstPlayer(level) != null && Sprite.CurrentAnimationID != "respawn")
                CenterY = ScalarMath.Approach(CenterY, TargetY, yApproachSpeed * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);

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
                Sprite.Position = RandomShakeVector.Next(((ISourceRandomEnvironment)engine).Random);

            cameraXOffset = ScalarMath.Approach(cameraXOffset, 0f, 40f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            X = level.Camera.Left + cameraXOffset;
            var entity = FirstPlayer(level);
            if (entity != null)
                CenterY = ScalarMath.Approach(CenterY,
                    ScalarMath.Clamp(entity.CenterY, level.Bounds.Top + 8, level.Bounds.Bottom - 8),
                    30f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);

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
            lightning.Play("once", true);
            yield return 0.3f;
            if (FirstPlayer((ISourceScene)Scene) != null)
                state.State = 2;
            else
                state.State = 0;
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
            X += attackSpeed * engine.DeltaTime;
            attackSpeed = ScalarMath.Approach(attackSpeed, 500f, 2000f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (X >= level.Camera.Right + 48f)
            {
                if (leaving)
                {
                    RemoveSelf();
                    return 2;
                }

                X = level.Camera.Left + -48f;
                cameraXOffset = -48f;
                doRespawnAnim = true;
                Visible = false;
                return 0;
            }

            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Light, RumbleLength.Short);
            if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.05f, engine))
                TrailManagerState.Add(engine,
                    (ISourceRenderEnvironment)engine, this, new PackedColor(255, 0, 0, 255) * 0.6f, 0.5f);

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
            var entity = FirstPlayer((ISourceScene)Scene);
            if (entity != null && entity.Speed != Vector2.Zero && entity.X > level.Bounds.Left + 48) return 0;

            return 4;
        }

        private void HurtBegin()
        {
            Sprite.Play("hurt", true);
        }

        private int HurtUpdate()
        {
            X += 100f * engine.DeltaTime;
            Y += 200f * engine.DeltaTime;
            if (Top > level.Bounds.Bottom + 20)
            {
                if (leaving)
                {
                    RemoveSelf();
                    return 5;
                }

                X = level.Camera.Left + -48f;
                cameraXOffset = -48f;
                doRespawnAnim = true;
                Visible = false;
                return 0;
            }

            return 5;
        }
    }
}
