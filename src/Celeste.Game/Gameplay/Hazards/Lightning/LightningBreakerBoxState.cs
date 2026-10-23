using Celeste.Simulation;
using System;
using System.Numerics;
using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Scene;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Components.Shaking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Game.Audio;

namespace Celeste.Game.Gameplay.Hazards.Lightning
{
    public class LightningBreakerBoxState : SourceSolidEntityState
    {
        private readonly ISourceEngineContext engine;
        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation P_Smash =>
            Process.ParticleTypes.LightningBreakerBox.P_Smash;

        private Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation P_Sparks =>
            Process.ParticleTypes.LightningBreakerBox.P_Sparks;

        private Sprite sprite;

        private SineWaveState sine;

        private Vector2 start;

        private float sink;

        private int health = 2;

        private bool flag;

        private float shakeCounter;

        private string music;

        private int musicProgress = -1;

        private bool musicStoreInSession;

        private Vector2 bounceDir;

        private WigglerComponent bounce;

        private ShakerComponentState shaker;

        private bool makeSparks;

        private bool smashParticles;

        private SimulationCoroutine pulseRoutine;

        private SoundSourceComponentState firstHitSfx;

        private bool spikesLeft;

        private bool spikesRight;

        private bool spikesUp;

        private bool spikesDown;

        public LightningBreakerBoxState(Vector2 position, bool flipX, ISourceSolidWorldFactory factory,
            ISourceEngineContext engine)
            : base(position, 32f, 32f, true, factory.Create(position, true))
        {
            this.engine = engine;
            SurfaceSoundIndex = 9;
            start = Position;
            sprite = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("breakerBox");
            Sprite obj = sprite;
            obj.OnLastFrame = (Action<string>)Delegate.Combine(obj.OnLastFrame, (Action<string>)delegate(string anim)
            {
                if (anim == "break")
                {
                    Visible = false;
                }
                else if (anim == "open")
                {
                    makeSparks = true;
                }
            });
            sprite.Position = new Vector2(base.Width, base.Height) / 2f;
            sprite.FlipX = flipX;
            OwnedComponents.Add(sprite);
            sine = new SineWaveState(engine, 0.5f);
            OwnedComponents.Add(sine);
            bounce = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(1f, 0.5f);
            bounce.StartZero = false;
            OwnedComponents.Add(bounce);
            OwnedComponents.Add(shaker = new ShakerComponentState(engine, on: false));
            OnDashCollide = Dashed;
        }

        public LightningBreakerBoxState(EntityData e, Vector2 levelOffset, ISourceSolidWorldFactory factory,
            ISourceEngineContext engine)
            : this(e.Position + levelOffset, EntityAttributeReader.Bool(e.Values, "flipX", false), factory, engine)
        {
            flag = EntityAttributeReader.Bool(e.Values, "flag", false);
            music = EntityAttributeReader.Attr(e.Values, "music", null);
            musicProgress = EntityAttributeReader.Int(e.Values, "music_progress", -1);
            musicStoreInSession = EntityAttributeReader.Bool(e.Values, "music_session", false);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            spikesUp = CollideCheck("Celeste.Spikes", Position - Vector2.UnitY);
            spikesDown = CollideCheck("Celeste.Spikes", Position + Vector2.UnitY);
            spikesLeft = CollideCheck("Celeste.Spikes", Position - Vector2.UnitX);
            spikesRight = CollideCheck("Celeste.Spikes", Position + Vector2.UnitX);
        }

        public DashCollisionResult Dashed(RoomPlayerSession player, Vector2 dir)
        {
            if (!Process.SaveContext.CurrentSave.Assists.Invincible)
            {
                if (dir == Vector2.UnitX && spikesLeft)
                {
                    return DashCollisionResult.NormalCollision;
                }

                if (dir == -Vector2.UnitX && spikesRight)
                {
                    return DashCollisionResult.NormalCollision;
                }

                if (dir == Vector2.UnitY && spikesUp)
                {
                    return DashCollisionResult.NormalCollision;
                }

                if (dir == -Vector2.UnitY && spikesDown)
                {
                    return DashCollisionResult.NormalCollision;
                }
            }

            Level.DirectionalShake(dir);
            sprite.Scale = new Vector2(1f + Math.Abs(dir.Y) * 0.4f - Math.Abs(dir.X) * 0.4f,
                1f + Math.Abs(dir.X) * 0.4f - Math.Abs(dir.Y) * 0.4f);
            health--;
            if (health > 0)
            {
                OwnedComponents.Add(firstHitSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create()
                    .Play("event:/new_content/game/10_farewell/fusebox_hit_1"));
                ((ISourceFreezeEnvironment)engine).Freeze(0.1f);
                shakeCounter = 0.2f;
                shaker.On = true;
                bounceDir = dir;
                bounce.Start();
                smashParticles = true;
                Pulse();
                ((Celeste.Input.Gameplay.Feedback.ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
            }
            else
            {
                if (firstHitSfx != null)
                {
                    firstHitSfx.Stop();
                }

                ((Celeste.Core.Audio.ISourceSpatialAudio)engine).Play(
                    "event:/new_content/game/10_farewell/fusebox_hit_2",
                    Position);
                ((ISourceFreezeEnvironment)engine).Freeze(0.2f);
                player.RefillDash();
                Break();
                ((Celeste.Input.Gameplay.Feedback.ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 2);
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
                position = base.CenterRight - Vector2.UnitX * 12f;
                positionRange = Vector2.UnitY * (base.Height - 6f) * 0.5f;
                num = (int)(base.Height / 8f) * 4;
            }
            else if (dir == -Vector2.UnitX)
            {
                direction = (float)Math.PI;
                position = base.CenterLeft + Vector2.UnitX * 12f;
                positionRange = Vector2.UnitY * (base.Height - 6f) * 0.5f;
                num = (int)(base.Height / 8f) * 4;
            }
            else if (dir == Vector2.UnitY)
            {
                direction = (float)Math.PI / 2f;
                position = base.BottomCenter - Vector2.UnitY * 12f;
                positionRange = Vector2.UnitX * (base.Width - 6f) * 0.5f;
                num = (int)(base.Width / 8f) * 4;
            }
            else
            {
                direction = -(float)Math.PI / 2f;
                position = base.TopCenter + Vector2.UnitY * 12f;
                positionRange = Vector2.UnitX * (base.Width - 6f) * 0.5f;
                num = (int)(base.Width / 8f) * 4;
            }

            num += 2;
            Level.Particles.Emit(P_Smash, num, position, positionRange, direction);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (flag && Level.Session.GetFlag("disable_lightning"))
            {
                RemoveSelf();
            }
        }

        public override void Update()
        {
            base.Update();
            if (makeSparks && ((Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Clock.OnInterval(0.03f, engine))
            {
                Level.ParticlesFG.Emit(P_Sparks, 1, base.Center, Vector2.One * 12f);
            }

            if (shakeCounter > 0f)
            {
                shakeCounter -= engine.DeltaTime;
                if (shakeCounter <= 0f)
                {
                    shaker.On = false;
                    sprite.Scale = Vector2.One * 1.2f;
                    sprite.Play("open");
                }
            }

            if (Collidable)
            {
                bool flag = HasPlayerRider();
                sink = ScalarMath.Approach(sink, flag ? 1 : 0, 2f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                sine.Rate = ScalarMath.Lerp(1f, 0.5f, sink, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                Vector2 vector = start;
                vector.Y += sink * 6f + sine.Value *
                    ScalarMath.Lerp(4f, 2f, sink, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                vector += bounce.Value * bounceDir * 12f;
                MoveToX(vector.X);
                MoveToY(vector.Y);
                if (smashParticles)
                {
                    smashParticles = false;
                    SmashParticles(Vector2Geometry.Perpendicular(bounceDir));
                    SmashParticles(-Vector2Geometry.Perpendicular(bounceDir));
                }
            }

            sprite.Scale.X = ScalarMath.Approach(sprite.Scale.X, 1f, engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            sprite.Scale.Y = ScalarMath.Approach(sprite.Scale.Y, 1f, engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            LiftSpeed = Vector2.Zero;
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 position = sprite.Position;
            sprite.Position += shaker.Value;
            base.Render(context);
            sprite.Position = position;
        }

        private void Pulse()
        {
            pulseRoutine = new SimulationCoroutine(engine, LightningSourceRoutines.PulseRoutine(Level));
            OwnedComponents.Add(pulseRoutine);
        }

        private void Break()
        {
            var session = Level.Session;
            Celeste.Game.Entities.Mechanisms.RumbleWalls.OriginalRumbleTriggerState.ManuallyTrigger(engine,
                base.Center.X, 1.2f);
            base.Tags = ((Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value;
            shakeCounter = 0f;
            shaker.On = false;
            sprite.Play("break");
            Collidable = false;
            DestroyStaticMovers();
            if (flag)
            {
                session.SetFlag("disable_lightning");
            }

            if (musicStoreInSession)
            {
                if (!string.IsNullOrEmpty(music))
                {
                    session.Audio.Music.Event = ((IOriginalSfxEnvironment)engine).Sfx.EventnameByHandle(music);
                }

                if (musicProgress >= 0)
                {
                    session.Audio.Music.SetProgress(musicProgress);
                }

                OriginalAudioSession.Apply(session.Audio, Process.AudioSession.ChannelOutput, Process.AudioApplyPolicy);
            }
            else
            {
                if (!string.IsNullOrEmpty(music))
                {
                    Process.AudioSession.SetMusic(((IOriginalSfxEnvironment)engine).Sfx.EventnameByHandle(music),
                        startPlaying: false);
                }

                if (musicProgress >= 0)
                {
                    Process.AudioSession.SetMusicParam("progress", musicProgress);
                }

                if (!string.IsNullOrEmpty(music) && Process.AudioSession.CurrentMusicEventInstance != null)
                {
                    Process.AudioSession.CurrentMusicEventInstance.Start();
                }
            }

            if (pulseRoutine != null)
            {
                pulseRoutine.Active = false;
            }

            OwnedComponents.Add(new SimulationCoroutine(engine,
                LightningSourceRoutines.RemoveRoutine(Level, base.RemoveSelf)));
        }
    }
}
