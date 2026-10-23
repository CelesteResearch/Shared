using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Game.Gameplay.Hazards.TempleEyes
{
    public class OriginalTempleBigEyeballState : SceneEntityState
    {
        private readonly ISourceEngineContext _engine;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)_engine).GameGraphics;

        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)_engine).VectorArithmetic;
        private OriginalGameAudioSession Audio => ((IOriginalGameplayProcess)_engine).AudioSession;

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

        private readonly Sprite _sprite;

        private readonly SpriteImage _pupil;

        private bool _triggered;

        private Vector2 _pupilTarget;

        private float _pupilDelay;

        private readonly WigglerComponent _bounceWiggler;

        private readonly WigglerComponent _pupilWiggler;

        private float _shockwaveTimer;

        private bool _shockwaveFlag;

        private float _pupilSpeed = 40f;

        private bool _bursting;

        public OriginalTempleBigEyeballState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            _engine = engine;
            Add(_sprite = Graphics.SpriteBank.Create("temple_eyeball"));
            Add(_pupil = new(Graphics.GameAtlas["danger/templeeye/pupil"]));
            _pupil.CenterOrigin();
            Collider = new HitboxColliderGeometry(48f, 64f, -24f, -32f);
            Add(new PlayerColliderComponentState(OnPlayer));
            Add(new HoldableColliderState(OnHoldable));
            Add(_bounceWiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.5f, 3f));
            Add(_pupilWiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.5f, 3f));
            _shockwaveTimer = 2f;
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (!_triggered)
            {
                ((ISourceSpatialAudioEnvironment)_engine).SpatialAudio.Play(
                    "event:/game/05_mirror_temple/eyewall_bounce",
                    player.Position);
                player.ExplodeLaunch(player.Center + Vector2.UnitX * 20f);
                player.Swat(-1);
                _bounceWiggler.Start();
            }
        }

        private void OnHoldable(HoldableState h)
        {
            if (!(h.Entity is TheoCrystalState)) return;

            var theoCrystal = h.Entity as TheoCrystalState;
            if (!_triggered && theoCrystal.Speed.X > 32f && !theoCrystal.Hold.IsHeld)
            {
                theoCrystal.Speed.X = -50f;
                theoCrystal.Speed.Y = -10f;
                _triggered = true;
                _bounceWiggler.Start();
                Collidable = false;
                Audio.SetAmbience(null);
                ((ISourceSpatialAudioEnvironment)_engine).SpatialAudio.Play(
                    "event:/game/05_mirror_temple/eyewall_destroy",
                    Position);
                SourceAlarmState.Set(_engine.AlarmPool, OwnedComponents, 1.3f, delegate { Audio.SetMusic(null); });
                Add(new SimulationCoroutine(_engine, Burst()));
            }
        }

        private IEnumerator Burst()
        {
            _bursting = true;
            var level = (OriginalLevelSceneRoot)Scene;
            level.StartCutscene(OnSkip, false, true);
            level.RegisterAreaComplete();
            ((ISourceFreezeEnvironment)_engine).Freeze(0.1f);
            yield return null;
            var start = _engine.Effects.Glitch;
            var tween = SourceTweenState.Create(_engine.TweenPool, SourceTweenState.TweenMode.Oneshot, null,
                0.5f, true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                _engine.Effects.Glitch =
                    ((ISourceScalarEnvironment)_engine).ScalarArithmetic.Lerp(start, 0f, t.Eased);
            };
            Add(tween);
            var player =
                Level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            var entity =
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

            Add(new SimulationCoroutine(_engine, level.ZoomTo(entity.TopCenter - level.Camera.Position, 2f, 0.5f)));
            Add(new SimulationCoroutine(_engine, entity.Shatter()));
            foreach (var item in Level.SourceScene.Entities.FindAll<OriginalTempleEyeState>()) item.Burst();

            _sprite.Play("burst");
            _pupil.Visible = false;
            level.Shake(0.4f);
            yield return 2f;
            if (player != null && player.OnGround())
            {
                player.Dummy.AutoAnimate = false;
                player.Sprite.Play("shaking");
            }

            Visible = false;
            var fade = new Fader(_engine);
            level.Scheduler.QueueSourceEntity(fade);
            while ((fade.Fade += _engine.DeltaTime) < 1f) yield return null;

            yield return 1f;
            level.EndCutscene();
            level.CompleteArea(false);
        }

        private void OnSkip(OriginalLevelSceneRoot level)
        {
            level.CompleteArea(false);
        }

        public override void Update()
        {
            base.Update();
            var entity =
                Level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity != null)
                Audio.SetMusicParam("eye_distance", ScalarMath.ClampedMap(entity.X, Level.Bounds.Left, X));

            if (entity != null && !_bursting)
                _engine.Effects.Glitch = ScalarMath.ClampedMap(Math.Abs(X - entity.X), 100f, 900f, 0.2f, 0f);

            if (!_triggered && _shockwaveTimer > 0f)
            {
                _shockwaveTimer -= _engine.DeltaTime;
                if (_shockwaveTimer <= 0f)
                {
                    if (entity != null)
                    {
                        _shockwaveTimer = ScalarMath.ClampedMap(Math.Abs(X - entity.X), 100f, 500f, 2f, 3f);
                        _shockwaveFlag = !_shockwaveFlag;
                        if (_shockwaveFlag) _shockwaveTimer -= 1f;
                    }

                    Level.Scheduler.QueueSourceEntity(_engine.EntityPools
                        .Create<OriginalTempleBigEyeballShockwaveState>()
                        .Init(Center + new Vector2(50f, 0f)));
                    _pupilWiggler.Start();
                    _pupilTarget = new(-1f, 0f);
                    _pupilSpeed = 120f;
                    _pupilDelay = ((ISourceExtremaEnvironment)_engine).ExtremaArithmetic.Max(0.5f, _pupilDelay);
                }
            }

            _pupil.Position =
                VectorArithmetic.Approach(_pupil.Position, _pupilTarget * 12f, _engine.DeltaTime * _pupilSpeed);
            _pupilSpeed = ScalarMath.Approach(_pupilSpeed, 40f, _engine.DeltaTime * 400f,
                ((ISourceExtremaEnvironment)_engine).ExtremaArithmetic);
            var entity2 =
                Level.SourceScene.Entities.GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
            if (entity2 != null && Math.Abs(X - entity2.X) < 64f && Math.Abs(Y - entity2.Y) < 64f)
            {
                _pupilTarget = VectorArithmetic.SafeNormalize(entity2.Center - Position);
            }
            else if (_pupilDelay < 0f)
            {
                _pupilTarget = Vector2Geometry.AngleToVector(
                    SourceRandomMath.NextFloat(((ISourceRandomEnvironment)_engine).Random, (float)Math.PI * 2f), 1f);
                _pupilDelay = ((ISourceRandomEnvironment)_engine).Random.Choose(0.2f, 1f, 2f);
            }
            else
            {
                _pupilDelay -= _engine.DeltaTime;
            }

            if (entity != null)
            {
                var level = (OriginalLevelSceneRoot)Scene;
                Audio.SetMusicParam("eye_distance",
                    ScalarMath.ClampedMap(entity.X, level.Bounds.Left + 32, X - 32f, 1f, 0f));
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            _sprite.Scale.X = 1f + 0.15f * _bounceWiggler.Value;
            _pupil.Scale = Vector2.One * (1f + _pupilWiggler.Value * 0.15f);
            base.Render(context);
        }
    }
}
