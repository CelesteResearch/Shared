using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Gameplay.Hazards.TempleEyes
{
    public class OriginalTempleBigEyeballState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private OriginalGameAudioSession Audio => ((IOriginalGameplayProcess)engine).AudioSession;

        private class Fader : SceneEntityState
        {
            public float Fade;

            public Fader(ISourceEngineContext engine)
                : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
            {
                Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            }

            public override void Render(ISourceRenderContext context)
            {
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, context.Graphics.Width + 20,
                    context.Graphics.Height + 20, PackedColor.White * Fade);
            }
        }

        private Sprite sprite;

        private SpriteImage pupil;

        private bool triggered;

        private Vector2 pupilTarget;

        private float pupilDelay;

        private WigglerComponent bounceWiggler;

        private WigglerComponent pupilWiggler;

        private float shockwaveTimer;

        private bool shockwaveFlag;

        private float pupilSpeed = 40f;

        private bool bursting;

        public OriginalTempleBigEyeballState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            Add(sprite = Graphics.SpriteBank.Create("temple_eyeball"));
            Add(pupil = new SpriteImage(Graphics.GameAtlas["danger/templeeye/pupil"]));
            pupil.CenterOrigin();
            base.Collider = new HitboxColliderGeometry(48f, 64f, -24f, -32f);
            Add(new PlayerColliderComponentState(OnPlayer));
            Add(new HoldableColliderState(OnHoldable));
            Add(bounceWiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.5f, 3f));
            Add(pupilWiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.5f, 3f));
            shockwaveTimer = 2f;
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (!triggered)
            {
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                    "event:/game/05_mirror_temple/eyewall_bounce",
                    player.Position);
                player.ExplodeLaunch(player.Center + Vector2.UnitX * 20f);
                player.Swat(-1);
                bounceWiggler.Start();
            }
        }

        private void OnHoldable(HoldableState h)
        {
            if (!(h.Entity is TheoCrystalState))
            {
                return;
            }

            TheoCrystalState theoCrystal = h.Entity as TheoCrystalState;
            if (!triggered && theoCrystal.Speed.X > 32f && !theoCrystal.Hold.IsHeld)
            {
                theoCrystal.Speed.X = -50f;
                theoCrystal.Speed.Y = -10f;
                triggered = true;
                bounceWiggler.Start();
                Collidable = false;
                Audio.SetAmbience(null);
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                    "event:/game/05_mirror_temple/eyewall_destroy",
                    Position);
                SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 1.3f, delegate { Audio.SetMusic(null); });
                Add(new SimulationCoroutine(engine, Burst()));
            }
        }

        private IEnumerator Burst()
        {
            bursting = true;
            OriginalLevelSceneRoot level = (OriginalLevelSceneRoot)Scene;
            level.StartCutscene(OnSkip, fadeInOnSkip: false, endingChapterAfterCutscene: true);
            level.RegisterAreaComplete();
            ((ISourceFreezeEnvironment)engine).Freeze(0.1f);
            yield return null;
            float start = engine.Effects.Glitch;
            SourceTweenState tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot, null,
                0.5f, start: true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                engine.Effects.Glitch =
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(start, 0f, t.Eased);
            };
            Add(tween);
            RoomPlayerSession player =
                Level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            TheoCrystalState entity =
                Level.SourceScene.Entities.GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
            if (player != null)
            {
                player.Machine.State = 11;
                player.Machine.Locked = true;
                if (player.OnGround())
                {
                    player.Dummy.AutoAnimate = false;
                    player.Sprite.Play("shaking");
                }
            }

            Add(new SimulationCoroutine(engine, level.ZoomTo(entity.TopCenter - level.Camera.Position, 2f, 0.5f)));
            Add(new SimulationCoroutine(engine, entity.Shatter()));
            foreach (OriginalTempleEyeState item in Level.SourceScene.Entities.FindAll<OriginalTempleEyeState>())
            {
                item.Burst();
            }

            sprite.Play("burst");
            pupil.Visible = false;
            level.Shake(0.4f);
            yield return 2f;
            if (player != null && player.OnGround())
            {
                player.Dummy.AutoAnimate = false;
                player.Sprite.Play("shaking");
            }

            Visible = false;
            Fader fade = new Fader(engine);
            level.Scheduler.QueueSourceEntity(fade);
            while ((fade.Fade += engine.DeltaTime) < 1f)
            {
                yield return null;
            }

            yield return 1f;
            level.EndCutscene();
            level.CompleteArea(spotlightWipe: false);
        }

        private void OnSkip(OriginalLevelSceneRoot level)
        {
            level.CompleteArea(spotlightWipe: false);
        }

        public override void Update()
        {
            base.Update();
            RoomPlayerSession entity =
                Level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (entity != null)
            {
                Audio.SetMusicParam("eye_distance", ScalarMath.ClampedMap(entity.X, Level.Bounds.Left, base.X));
            }

            if (entity != null && !bursting)
            {
                engine.Effects.Glitch = ScalarMath.ClampedMap(Math.Abs(base.X - entity.X), 100f, 900f, 0.2f, 0f);
            }

            if (!triggered && shockwaveTimer > 0f)
            {
                shockwaveTimer -= engine.DeltaTime;
                if (shockwaveTimer <= 0f)
                {
                    if (entity != null)
                    {
                        shockwaveTimer = ScalarMath.ClampedMap(Math.Abs(base.X - entity.X), 100f, 500f, 2f, 3f);
                        shockwaveFlag = !shockwaveFlag;
                        if (shockwaveFlag)
                        {
                            shockwaveTimer -= 1f;
                        }
                    }

                    Level.Scheduler.QueueSourceEntity(engine.EntityPools
                        .Create<OriginalTempleBigEyeballShockwaveState>()
                        .Init(Center + new Vector2(50f, 0f)));
                    pupilWiggler.Start();
                    pupilTarget = new Vector2(-1f, 0f);
                    pupilSpeed = 120f;
                    pupilDelay = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(0.5f, pupilDelay);
                }
            }

            pupil.Position =
                VectorArithmetic.Approach(pupil.Position, pupilTarget * 12f, engine.DeltaTime * pupilSpeed);
            pupilSpeed = ScalarMath.Approach(pupilSpeed, 40f, engine.DeltaTime * 400f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            TheoCrystalState entity2 =
                Level.SourceScene.Entities.GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
            if (entity2 != null && Math.Abs(base.X - entity2.X) < 64f && Math.Abs(base.Y - entity2.Y) < 64f)
            {
                pupilTarget = VectorArithmetic.SafeNormalize(entity2.Center - Position);
            }
            else if (pupilDelay < 0f)
            {
                pupilTarget = Vector2Geometry.AngleToVector(
                    SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, (float)Math.PI * 2f), 1f);
                pupilDelay = ((ISourceRandomEnvironment)engine).Random.Choose(0.2f, 1f, 2f);
            }
            else
            {
                pupilDelay -= engine.DeltaTime;
            }

            if (entity != null)
            {
                OriginalLevelSceneRoot level = (OriginalLevelSceneRoot)Scene;
                Audio.SetMusicParam("eye_distance",
                    ScalarMath.ClampedMap(entity.X, level.Bounds.Left + 32, base.X - 32f, 1f, 0f));
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            sprite.Scale.X = 1f + 0.15f * bounceWiggler.Value;
            pupil.Scale = Vector2.One * (1f + pupilWiggler.Value * 0.15f);
            base.Render(context);
        }
    }
}
