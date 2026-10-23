using Celeste.Core.Display;
using Celeste.Graphics.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Hazards.Lightning;
using Celeste.Audio.Fmod.Events;
using Celeste.Game.Audio;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Entities.BadelineBoosts;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Presentation.Particles;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Core.Components.Timing;
using Celeste.Scene.Lifecycle;
using Celeste.Simulation.Audio.Emitters;
using Celeste.Game.Gameplay.Hazards.Lightning;
using Celeste.Game.Entities.Mechanisms.RumbleWalls;

namespace Celeste.Game.Entities.Birds.Fling
{
    public class CS10MissTheBirdState : OriginalCutsceneEntityState
    {
        public const string Flag = "MissTheBird";

        private RoomPlayerSession player;

        private OriginalFlingBirdIntroState flingBird;

        private BirdNpcState bird;

        private SimulationCoroutine zoomRoutine;

        private FmodEventReference crashMusicSfx;

        private readonly ISourceEngineContext engine;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private OriginalGameAudioSession Audio => ((IOriginalGameplayProcess)engine).AudioSession;

        public CS10MissTheBirdState(ISourceEngineContext engine, RoomPlayerSession player,
            OriginalFlingBirdIntroState flingBird) : base(engine)
        {
            this.engine = engine;
            this.player = player;
            this.flingBird = flingBird;
            OwnedComponents.Add(new LevelEndingHookState(delegate { Audio.Stop(crashMusicSfx); }));
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            Audio.SetMusicParam("bird_grab", 1f);
            crashMusicSfx = Audio.Play("event:/new_content/music/lvl10/cinematic/bird_crash_first");
            yield return flingBird.DoGrabbingRoutine(player);
            bird = BirdNpcState.Create(level, flingBird.Position, BirdNpcMode.None);
            level.Scheduler.QueueSourceEntity(bird);
            flingBird.RemoveSelf();
            yield return null;
            level.ResetZoom();
            level.Shake(0.5f);
            player.Position = Vector2Geometry.Floor(player.Position);
            player.Dummy.Gravity = true;
            player.Dummy.AutoAnimate = false;
            player.Dummy.Friction = false;
            player.ForceCameraUpdate = true;
            player.Data.Motion.Normal.Speed = new Vector2(200f, 200f);
            bird.Position += Vector2.UnitX * 16f;
            bird.OwnedComponents.Add(new SimulationCoroutine(engine, bird.Startle(null, 0.5f, new Vector2(3f, 0.25f))));
            SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, .1f, delegate
            {
                bird.Sprite.Play("hoverStressed");
                SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, .8f, delegate
                {
                    OwnedComponents.Add(new SimulationCoroutine(engine, bird.FlyAway(.2f)));
                    bird.Position += new Vector2(0f, -4f);
                });
            });
            while (!player.OnGround())
            {
                player.MoveVExact(1);
            }

            engine.Effects.TimeRate = 0.5f;
            player.Sprite.Play("roll");
            while (player.Data.Motion.Normal.Speed.X != 0f)
            {
                player.Data.Motion.Normal.Speed.X = ScalarMath.Approach(player.Data.Motion.Normal.Speed.X, 0f,
                    120f * engine.DeltaTime, Extrema);
                if (Level.OnInterval(.1f))
                {
                    OriginalDustBurstSource.BurstFG(engine, player.Position, -(float)Math.PI / 2f, 2);
                }

                yield return null;
            }

            while (engine.Effects.TimeRate < 1f)
            {
                engine.Effects.TimeRate =
                    ScalarMath.Approach(engine.Effects.TimeRate, 1f, 4f * engine.DeltaTime, Extrema);
                yield return null;
            }

            player.Data.Motion.Normal.Speed.X = 0f;
            player.Dummy.Friction = true;
            yield return 0.25f;
            OwnedComponents.Add(zoomRoutine =
                new SimulationCoroutine(engine, level.ZoomTo(new Vector2(160f, 110f), 1.5f, 6f)));
            yield return 1.5f;
            player.Sprite.Play("rollGetUp");
            yield return 0.5f;
            player.ForceCameraUpdate = false;
            yield return TextboxState.Say("CH9_MISS_THE_BIRD", engine, StandUpFaceLeft, TakeStepLeft, TakeStepRight,
                FlickerBlackhole, OpenBlackhole);
            StartMusic();
            EndCutscene(level);
        }

        private IEnumerator StandUpFaceLeft()
        {
            while (!zoomRoutine.Finished)
            {
                yield return null;
            }

            yield return 0.2f;
            Audio.Play("event:/char/madeline/stand", player.Position, ((IOriginalGameplayProcess)engine).SaveContext);
            player.Dummy.AutoAnimate = true;
            player.Sprite.Play("idle");
            yield return 0.2f;
            player.Data.Facing = -1;
            yield return 0.5f;
        }

        private IEnumerator TakeStepLeft()
        {
            yield return player.DummyWalkTo(player.X - 16f);
        }

        private IEnumerator TakeStepRight()
        {
            yield return player.DummyWalkTo(player.X + 32f);
        }

        private IEnumerator FlickerBlackhole()
        {
            yield return 0.5f;
            Audio.Play("event:/new_content/game/10_farewell/glitch_medium");
            yield return OriginalMoonGlitchBackgroundTriggerState.GlitchRoutine(engine, .5f, stayOn: false);
            yield return player.DummyWalkTo(player.X - 8f, walkBackwards: true);
            yield return 0.4f;
        }

        private IEnumerator OpenBlackhole()
        {
            yield return 0.2f;
            Level.ResetZoom();
            Level.Flash(PackedColor.White);
            Level.Shake(0.4f);
            Level.Scheduler.QueueSourceEntity(new LightningStrikeState(new Vector2(player.X, Level.Bounds.Top), 80,
                240f,
                engine));
            Level.Scheduler.QueueSourceEntity(new LightningStrikeState(new Vector2(player.X - 100f, Level.Bounds.Top),
                90,
                240f, engine, .5f));
            Audio.Play("event:/new_content/game/10_farewell/lightning_strike");
            TriggerEnvironmentalEvents();
            StartMusic();
            yield return 1.2f;
        }

        private void StartMusic()
        {
            Level.Session.Audio.Music.Event = "event:/new_content/music/lvl10/part03";
            Level.Session.Audio.Ambience.Event = "event:/new_content/env/10_voidspiral";
            OriginalAudioSession.Apply(Level.Session.Audio, Audio.ChannelOutput,
                ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
        }

        private void TriggerEnvironmentalEvents()
        {
            OriginalCutsceneNodeState cutsceneNode = OriginalCutsceneNodeState.Find(engine, "player_skip");
            if (cutsceneNode != null)
            {
                OriginalRumbleTriggerState.ManuallyTrigger(engine, cutsceneNode.X, 0f);
            }

            Level.SourceScene.Entities.FindFirst<OriginalMoonGlitchBackgroundTriggerState>()?.Invoke();
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            Audio.Stop(crashMusicSfx);
            engine.Effects.TimeRate = 1f;
            level.Session.SetFlag("MissTheBird");
            if (WasSkipped)
            {
                player.Sprite.Play("idle");
                OriginalCutsceneNodeState cutsceneNode = OriginalCutsceneNodeState.Find(engine, "player_skip");
                if (cutsceneNode != null)
                {
                    player.Position = Vector2Geometry.Floor(cutsceneNode.Position);
                    level.Camera.Position = player.CameraTarget;
                }

                if (flingBird != null)
                {
                    if (flingBird.CrashSfxEmitter != null)
                    {
                        flingBird.CrashSfxEmitter.RemoveSelf();
                    }

                    flingBird.RemoveSelf();
                }

                if (bird != null)
                {
                    bird.RemoveSelf();
                }

                TriggerEnvironmentalEvents();
                StartMusic();
            }

            player.Data.Motion.Normal.Speed = Vector2.Zero;
            player.Dummy.AutoAnimate = true;
            player.Dummy.Friction = true;
            player.Dummy.Gravity = true;
            player.ForceCameraUpdate = false;
            player.Machine.State = 0;
        }
    }
}
