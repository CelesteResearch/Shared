using System;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Audio;
using Celeste.Game.Entities.Mechanisms.RumbleWalls;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Components.Shaking;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Gameplay.Hazards.Lightning
{
    public class LightningBreakerBoxState : SourceSolidEntityState
    {
        private readonly ISourceEngineContext _engine;
        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)_engine;

        private ParticleTypePresentation P_Smash =>
            Process.ParticleTypes.LightningBreakerBox.P_Smash;

        private ParticleTypePresentation P_Sparks =>
            Process.ParticleTypes.LightningBreakerBox.P_Sparks;

        private readonly Sprite _sprite;

        private readonly SineWaveState _sine;

        private readonly Vector2 _start;

        private float _sink;

        private int _health = 2;

        private readonly bool _flag;

        private float _shakeCounter;

        private readonly string _music;

        private readonly int _musicProgress = -1;

        private readonly bool _musicStoreInSession;

        private Vector2 _bounceDir;

        private readonly WigglerComponent _bounce;

        private readonly ShakerComponentState _shaker;

        private bool _makeSparks;

        private bool _smashParticles;

        private SimulationCoroutine _pulseRoutine;

        private SoundSourceComponentState _firstHitSfx;

        private bool _spikesLeft;

        private bool _spikesRight;

        private bool _spikesUp;

        private bool _spikesDown;

        public LightningBreakerBoxState(Vector2 position, bool flipX, ISourceSolidWorldFactory factory,
            ISourceEngineContext engine)
            : base(position, 32f, 32f, true, factory.Create(position, true))
        {
            _engine = engine;
            SurfaceSoundIndex = 9;
            _start = Position;
            _sprite = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("breakerBox");
            var obj = _sprite;
            obj.OnLastFrame = (Action<string>)Delegate.Combine(obj.OnLastFrame, (Action<string>)delegate(string anim)
            {
                if (anim == "break")
                    Visible = false;
                else if (anim == "open") _makeSparks = true;
            });
            _sprite.Position = new Vector2(Width, Height) / 2f;
            _sprite.FlipX = flipX;
            OwnedComponents.Add(_sprite);
            _sine = new(engine, 0.5f);
            OwnedComponents.Add(_sine);
            _bounce = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(1f, 0.5f);
            _bounce.StartZero = false;
            OwnedComponents.Add(_bounce);
            OwnedComponents.Add(_shaker = new(engine, false));
            OnDashCollide = Dashed;
        }

        public LightningBreakerBoxState(EntityData e, Vector2 levelOffset, ISourceSolidWorldFactory factory,
            ISourceEngineContext engine)
            : this(e.Position + levelOffset, EntityAttributeReader.Bool(e.Values, "flipX"), factory, engine)
        {
            _flag = EntityAttributeReader.Bool(e.Values, "flag");
            _music = EntityAttributeReader.Attr(e.Values, "music", null);
            _musicProgress = EntityAttributeReader.Int(e.Values, "music_progress", -1);
            _musicStoreInSession = EntityAttributeReader.Bool(e.Values, "music_session");
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            _spikesUp = CollideCheck("Celeste.Spikes", Position - Vector2.UnitY);
            _spikesDown = CollideCheck("Celeste.Spikes", Position + Vector2.UnitY);
            _spikesLeft = CollideCheck("Celeste.Spikes", Position - Vector2.UnitX);
            _spikesRight = CollideCheck("Celeste.Spikes", Position + Vector2.UnitX);
        }

        public DashCollisionResult Dashed(RoomPlayerSession player, Vector2 dir)
        {
            if (!Process.SaveContext.CurrentSave.Assists.Invincible)
            {
                if (dir == Vector2.UnitX && _spikesLeft) return DashCollisionResult.NormalCollision;

                if (dir == -Vector2.UnitX && _spikesRight) return DashCollisionResult.NormalCollision;

                if (dir == Vector2.UnitY && _spikesUp) return DashCollisionResult.NormalCollision;

                if (dir == -Vector2.UnitY && _spikesDown) return DashCollisionResult.NormalCollision;
            }

            Level.DirectionalShake(dir);
            _sprite.Scale = new(1f + Math.Abs(dir.Y) * 0.4f - Math.Abs(dir.X) * 0.4f,
                1f + Math.Abs(dir.X) * 0.4f - Math.Abs(dir.Y) * 0.4f);
            _health--;
            if (_health > 0)
            {
                OwnedComponents.Add(_firstHitSfx = ((ISourceSoundSourceEnvironment)_engine).SoundSources.Create()
                    .Play("event:/new_content/game/10_farewell/fusebox_hit_1"));
                ((ISourceFreezeEnvironment)_engine).Freeze(0.1f);
                _shakeCounter = 0.2f;
                _shaker.On = true;
                _bounceDir = dir;
                _bounce.Start();
                _smashParticles = true;
                Pulse();
                ((ISourceRumbleEnvironment)_engine).RumbleSession.Rumble(1, 1);
            }
            else
            {
                if (_firstHitSfx != null) _firstHitSfx.Stop();

                ((ISourceSpatialAudio)_engine).Play(
                    "event:/new_content/game/10_farewell/fusebox_hit_2",
                    Position);
                ((ISourceFreezeEnvironment)_engine).Freeze(0.2f);
                player.RefillDash();
                Break();
                ((ISourceRumbleEnvironment)_engine).RumbleSession.Rumble(2, 2);
                SmashParticles(Vector2Geometry.Perpendicular(dir));
                SmashParticles(-Vector2Geometry.Perpendicular(dir));
            }

            return DashCollisionResult.Rebound;
        }

        private void SmashParticles(Vector2 dir)
        {
            float direction;
            Vector2 position;
            Vector2 positionRange;
            int num;
            if (dir == Vector2.UnitX)
            {
                direction = 0f;
                position = CenterRight - Vector2.UnitX * 12f;
                positionRange = Vector2.UnitY * (Height - 6f) * 0.5f;
                num = (int)(Height / 8f) * 4;
            }
            else if (dir == -Vector2.UnitX)
            {
                direction = (float)Math.PI;
                position = CenterLeft + Vector2.UnitX * 12f;
                positionRange = Vector2.UnitY * (Height - 6f) * 0.5f;
                num = (int)(Height / 8f) * 4;
            }
            else if (dir == Vector2.UnitY)
            {
                direction = (float)Math.PI / 2f;
                position = BottomCenter - Vector2.UnitY * 12f;
                positionRange = Vector2.UnitX * (Width - 6f) * 0.5f;
                num = (int)(Width / 8f) * 4;
            }
            else
            {
                direction = -(float)Math.PI / 2f;
                position = TopCenter + Vector2.UnitY * 12f;
                positionRange = Vector2.UnitX * (Width - 6f) * 0.5f;
                num = (int)(Width / 8f) * 4;
            }

            num += 2;
            Level.Particles.Emit(P_Smash, num, position, positionRange, direction);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (_flag && Level.Session.GetFlag("disable_lightning")) RemoveSelf();
        }

        public override void Update()
        {
            base.Update();
            if (_makeSparks && ((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.03f, _engine))
                Level.ParticlesFG.Emit(P_Sparks, 1, Center, Vector2.One * 12f);

            if (_shakeCounter > 0f)
            {
                _shakeCounter -= _engine.DeltaTime;
                if (_shakeCounter <= 0f)
                {
                    _shaker.On = false;
                    _sprite.Scale = Vector2.One * 1.2f;
                    _sprite.Play("open");
                }
            }

            if (Collidable)
            {
                var flag = HasPlayerRider();
                _sink = ScalarMath.Approach(_sink, flag ? 1 : 0, 2f * _engine.DeltaTime,
                    ((ISourceExtremaEnvironment)_engine).ExtremaArithmetic);
                _sine.Rate = ScalarMath.Lerp(1f, 0.5f, _sink, ((ISourceScalarEnvironment)_engine).ScalarArithmetic);
                var vector = _start;
                vector.Y += _sink * 6f + _sine.Value *
                    ScalarMath.Lerp(4f, 2f, _sink, ((ISourceScalarEnvironment)_engine).ScalarArithmetic);
                vector += _bounce.Value * _bounceDir * 12f;
                MoveToX(vector.X);
                MoveToY(vector.Y);
                if (_smashParticles)
                {
                    _smashParticles = false;
                    SmashParticles(Vector2Geometry.Perpendicular(_bounceDir));
                    SmashParticles(-Vector2Geometry.Perpendicular(_bounceDir));
                }
            }

            _sprite.Scale.X = ScalarMath.Approach(_sprite.Scale.X, 1f, _engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)_engine).ExtremaArithmetic);
            _sprite.Scale.Y = ScalarMath.Approach(_sprite.Scale.Y, 1f, _engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)_engine).ExtremaArithmetic);
            LiftSpeed = Vector2.Zero;
        }

        public override void Render(ISourceRenderContext context)
        {
            var position = _sprite.Position;
            _sprite.Position += _shaker.Value;
            base.Render(context);
            _sprite.Position = position;
        }

        private void Pulse()
        {
            _pulseRoutine = new(_engine, LightningSourceRoutines.PulseRoutine(Level));
            OwnedComponents.Add(_pulseRoutine);
        }

        private void Break()
        {
            var session = Level.Session;
            OriginalRumbleTriggerState.ManuallyTrigger(_engine,
                Center.X, 1.2f);
            Tags = ((IOriginalGameTagsEnvironment)_engine).Tags.Persistent.Value;
            _shakeCounter = 0f;
            _shaker.On = false;
            _sprite.Play("break");
            Collidable = false;
            DestroyStaticMovers();
            if (_flag) session.SetFlag("disable_lightning");

            if (_musicStoreInSession)
            {
                if (!string.IsNullOrEmpty(_music))
                    session.Audio.Music.Event = ((IOriginalSfxEnvironment)_engine).Sfx.EventnameByHandle(_music);

                if (_musicProgress >= 0) session.Audio.Music.SetProgress(_musicProgress);

                OriginalAudioSession.Apply(session.Audio, Process.AudioSession.ChannelOutput, Process.AudioApplyPolicy);
            }
            else
            {
                if (!string.IsNullOrEmpty(_music))
                    Process.AudioSession.SetMusic(((IOriginalSfxEnvironment)_engine).Sfx.EventnameByHandle(_music),
                        false);

                if (_musicProgress >= 0) Process.AudioSession.SetMusicParam("progress", _musicProgress);

                if (!string.IsNullOrEmpty(_music) && Process.AudioSession.CurrentMusicEventInstance != null)
                    Process.AudioSession.CurrentMusicEventInstance.Start();
            }

            if (_pulseRoutine != null) _pulseRoutine.Active = false;

            OwnedComponents.Add(new SimulationCoroutine(_engine,
                LightningSourceRoutines.RemoveRoutine(Level, RemoveSelf)));
        }
    }
}
