using Celeste.Scene.Entities;
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

namespace Celeste.Game.Entities.Birds.Fling
{
    public class CS10CatchTheBirdState : OriginalCutsceneEntityState
    {
        private RoomPlayerSession player;

        private OriginalFlingBirdIntroState flingBird;

        private BadelineDummyPresentation badeline;

        private BirdNpcState bird;

        private Vector2 birdWaitPosition;

        private FmodEventReference snapshot;

        private readonly ISourceEngineContext engine;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private OriginalGameAudioSession Audio => ((IOriginalGameplayProcess)engine).AudioSession;

        public CS10CatchTheBirdState(ISourceEngineContext engine, RoomPlayerSession player,
            OriginalFlingBirdIntroState flingBird) : base(engine)
        {
            this.engine = engine;
            this.player = player;
            this.flingBird = flingBird;
            birdWaitPosition = flingBird.BirdEndPosition;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            Audio.SetMusic("event:/new_content/music/lvl10/cinematic/bird_crash_second");
            BadelineBoostState boost = Level.SourceScene.Entities.FindFirst<BadelineBoostState>();
            if (boost != null)
            {
                bool visible = false;
                boost.Collidable = false;
                boost.Active = (boost.Visible = visible);
            }

            yield return flingBird.DoGrabbingRoutine(player);
            flingBird.Sprite.Play("hurt");
            flingBird.X += 8f;
            while (!player.OnGround())
            {
                player.MoveVExact(1);
            }

            while (SourceTrackedEntityCollision.Check(Level.SourceScene.Entities, "Celeste.Solid", player))
            {
                player.Y--;
            }

            engine.Effects.TimeRate = 0.65f;
            float ground = player.Position.Y;
            player.Data.Dashes = 1;
            player.Sprite.Play("roll");
            player.Data.Motion.Normal.Speed.X = 200f;
            player.Dummy.Friction = false;
            for (float p = 0f; p < 1f; p += engine.DeltaTime)
            {
                player.Data.Motion.Normal.Speed.X = ScalarMath.Approach(player.Data.Motion.Normal.Speed.X, 0f,
                    160f * engine.DeltaTime, Extrema);
                if (player.Data.Motion.Normal.Speed.X != 0f && Level.OnInterval(.1f))
                {
                    OriginalDustBurstSource.BurstFG(engine, player.Position, -(float)Math.PI / 2f, 2);
                }

                flingBird.X += engine.DeltaTime * 80f *
                               ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(1f - p);
                flingBird.Y = ground;
                yield return null;
            }

            player.Data.Motion.Normal.Speed.X = 0f;
            player.Dummy.Friction = true;
            player.Dummy.Gravity = true;
            yield return 0.25f;
            while (engine.Effects.TimeRate < 1f)
            {
                engine.Effects.TimeRate =
                    ScalarMath.Approach(engine.Effects.TimeRate, 1f, 4f * engine.DeltaTime, Extrema);
                yield return null;
            }

            player.ForceCameraUpdate = false;
            yield return 0.6f;
            player.Sprite.Play("rollGetUp");
            yield return 0.8f;
            level.Session.Audio.Music.Event = "event:/new_content/music/lvl10/reconciliation";
            OriginalAudioSession.Apply(level.Session.Audio, Audio.ChannelOutput,
                ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
            yield return TextboxState.Say("CH9_CATCH_THE_BIRD", engine, BirdLooksHurt, BirdSquakOnGround, ApproachBird,
                ApproachBirdAgain, BadelineAppears, WaitABeat, MadelineSits, BadelineHugs, StandUp, ShiftCameraToBird);
            yield return level.ZoomBack(0.5f);
            if (badeline != null)
            {
                badeline.Vanish();
            }

            yield return 0.5f;
            if (boost != null)
            {
                Level.Displacement.AddBurst(boost.Center, 0.5f, 8f, 32f, 0.5f);
                Audio.Play("event:/new_content/char/badeline/booster_first_appear", boost.Center,
                    ((IOriginalGameplayProcess)engine).SaveContext);
                bool visible = true;
                boost.Collidable = true;
                boost.Active = (boost.Visible = visible);
                yield return 0.2f;
            }

            EndCutscene(level);
        }

        private IEnumerator BirdTwitches(string sfx = null)
        {
            flingBird.Sprite.Scale.Y = 1.6f;
            if (!string.IsNullOrWhiteSpace(sfx))
            {
                Audio.Play(sfx, flingBird.Position, ((IOriginalGameplayProcess)engine).SaveContext);
            }

            while (flingBird.Sprite.Scale.Y > 1f)
            {
                flingBird.Sprite.Scale.Y =
                    ScalarMath.Approach(flingBird.Sprite.Scale.Y, 1f, 2f * engine.DeltaTime, Extrema);
                yield return null;
            }
        }

        private IEnumerator BirdLooksHurt()
        {
            yield return 0.8f;
            yield return BirdTwitches("event:/new_content/game/10_farewell/bird_crashscene_twitch_1");
            yield return 0.4f;
            yield return BirdTwitches("event:/new_content/game/10_farewell/bird_crashscene_twitch_2");
            yield return 0.5f;
        }

        private IEnumerator BirdSquakOnGround()
        {
            yield return 0.6f;
            yield return BirdTwitches("event:/new_content/game/10_farewell/bird_crashscene_twitch_3");
            yield return 0.8f;
            Audio.Play("event:/new_content/game/10_farewell/bird_crashscene_recover", flingBird.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            flingBird.RemoveSelf();
            Level.Scheduler.QueueSourceEntity(bird = BirdNpcState.Create(Level, flingBird.Position, BirdNpcMode.None));
            bird.Facing = 1;
            bird.Sprite.Play("recover");
            yield return 0.6f;
            bird.Facing = -1;
            bird.Sprite.Play("idle");
            bird.X += 3f;
            yield return 0.4f;
            yield return bird.Caw();
        }

        private IEnumerator ApproachBird()
        {
            player.Dummy.AutoAnimate = true;
            yield return 0.25f;
            yield return bird.Caw();
            OwnedComponents.Add(new SimulationCoroutine(engine, player.DummyWalkTo(player.X + 20f)));
            yield return 0.1f;
            Audio.Play("event:/game/general/bird_startle", bird.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            yield return bird.Startle("event:/new_content/game/10_farewell/bird_crashscene_relocate");
            yield return bird.FlyTo(new Vector2(player.X + 80f, player.Y), 3f, relocateSfx: false);
        }

        private IEnumerator ApproachBirdAgain()
        {
            Audio.Play("event:/new_content/game/10_farewell/bird_crashscene_leave", bird.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            OwnedComponents.Add(new SimulationCoroutine(engine, bird.FlyTo(birdWaitPosition, 2f, relocateSfx: false)));
            yield return player.DummyWalkTo(player.X + 20f);
            snapshot = Audio.CreateSnapshot("snapshot:/game_10_bird_wings_silenced");
            yield return 0.8f;
            bird.RemoveSelf();
            Level.Scheduler.QueueSourceEntity(bird =
                BirdNpcState.Create(Level, birdWaitPosition, BirdNpcMode.WaitForLightningOff));
            bird.Facing = 1;
            bird.FlyAwayUp = false;
            bird.WaitForLightningPostDelay = 1f;
        }

        private IEnumerator BadelineAppears()
        {
            yield return player.DummyWalkToExact((int)player.X + 20, walkBackwards: false, 0.5f);
            Level.Scheduler.QueueSourceEntity(badeline =
                BadelineDummyPresentation.Create(Level, player.Position + new Vector2(24f, -8f)));
            Level.Displacement.AddBurst(badeline.Center, 0.5f, 8f, 32f, 0.5f);
            Audio.Play("event:/char/badeline/maddy_split", player.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            badeline.Sprite.Scale.X = -1f;
            yield return 0.2f;
        }

        private IEnumerator WaitABeat()
        {
            yield return player.DummyWalkToExact((int)player.X - 4, walkBackwards: true, 0.5f);
            yield return 0.8f;
        }

        private IEnumerator MadelineSits()
        {
            yield return 0.5f;
            yield return player.DummyWalkToExact((int)player.X - 16, walkBackwards: false, 0.25f);
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("sitDown");
            yield return 1.5f;
        }

        private IEnumerator BadelineHugs()
        {
            yield return 1f;
            yield return badeline.FloatTo(badeline.Position + new Vector2(0f, 8f), null, faceDirection: true,
                fadeLight: false, quickEnd: true);
            badeline.Floatness = 0f;
            badeline.AutoAnimator.Enabled = false;
            badeline.Sprite.Play("idle");
            Audio.Play("event:/char/badeline/landing", badeline.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            yield return 0.5f;
            yield return badeline.WalkTo(player.X - 9f, 40f);
            badeline.Sprite.Scale.X = 1f;
            yield return 0.2f;
            Audio.Play("event:/char/badeline/duck", badeline.Position, ((IOriginalGameplayProcess)engine).SaveContext);
            badeline.Depth = player.Depth + 5;
            badeline.Sprite.Play("hug");
            yield return 1f;
        }

        private IEnumerator StandUp()
        {
            Audio.Play("event:/char/badeline/stand", badeline.Position, ((IOriginalGameplayProcess)engine).SaveContext);
            yield return badeline.WalkTo(badeline.X - 8f);
            badeline.Sprite.Scale.X = 1f;
            yield return 0.2f;
            player.Dummy.AutoAnimate = true;
            Level.NextColorGrade("none", 0.25f);
            yield return 0.25f;
        }

        private IEnumerator ShiftCameraToBird()
        {
            Audio.ReleaseSnapshot(snapshot);
            snapshot = null;
            Audio.Play("event:/new_content/char/badeline/birdcrash_scene_float", badeline.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            OwnedComponents.Add(new SimulationCoroutine(engine,
                badeline.FloatTo(player.Position + new Vector2(-16f, -16f), 1)));
            OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
            player.Data.Facing = 1;
            yield return level.ZoomAcross(level.ZoomFocusPoint + new Vector2(70f, 0f), 1.5f, 1f);
            yield return 0.4;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            Audio.ReleaseSnapshot(snapshot);
            snapshot = null;
            if (WasSkipped)
            {
                OriginalCutsceneNodeState cutsceneNode = OriginalCutsceneNodeState.Find(engine, "player_skip");
                if (cutsceneNode != null)
                {
                    player.Sprite.Play("idle");
                    player.Position = Vector2Geometry.Floor(cutsceneNode.Position);
                    level.Camera.Position = player.CameraTarget;
                }

                foreach (LightningState item in Level.SourceScene.Entities.FindAll<LightningState>())
                {
                    item.ToggleCheck();
                }

                Level.SourceScene.Entities.GetTrackedEntity<LightningRendererState>("Celeste.LightningRenderer")
                    ?.ToggleEdges(immediate: true);
                level.Session.Audio.Music.Event = "event:/new_content/music/lvl10/reconciliation";
                OriginalAudioSession.Apply(level.Session.Audio, Audio.ChannelOutput,
                    ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
            }

            player.Data.Motion.Normal.Speed = Vector2.Zero;
            player.Dummy.Gravity = true;
            player.Dummy.Friction = true;
            player.Dummy.AutoAnimate = true;
            player.ForceCameraUpdate = false;
            player.Machine.State = 0;
            BadelineBoostState badelineBoost = Level.SourceScene.Entities.FindFirst<BadelineBoostState>();
            if (badelineBoost != null)
            {
                badelineBoost.Active = (badelineBoost.Visible = (badelineBoost.Collidable = true));
            }

            if (badeline != null)
            {
                badeline.RemoveSelf();
            }

            if (flingBird != null)
            {
                if (flingBird.CrashSfxEmitter != null)
                {
                    flingBird.CrashSfxEmitter.RemoveSelf();
                }

                flingBird.RemoveSelf();
            }

            if (WasSkipped)
            {
                if (bird != null)
                {
                    bird.RemoveSelf();
                }

                Level.Scheduler.QueueSourceEntity(bird =
                    BirdNpcState.Create(Level, birdWaitPosition, BirdNpcMode.WaitForLightningOff));
                bird.Facing = 1;
                bird.FlyAwayUp = false;
                bird.WaitForLightningPostDelay = 1f;
                level.SnapColorGrade("none");
            }

            level.ResetZoom();
        }

        public override void Removed(object scene)
        {
            Audio.ReleaseSnapshot(snapshot);
            snapshot = null;
            base.Removed(scene);
        }

        public override void SceneEnd(object scene)
        {
            Audio.ReleaseSnapshot(snapshot);
            snapshot = null;
            base.SceneEnd(scene);
        }

        public static void HandlePostCutsceneSpawn(OriginalFlingBirdIntroState flingBird, OriginalLevelSceneRoot level)
        {
            BadelineBoostState badelineBoost = level.SourceScene.Entities.FindFirst<BadelineBoostState>();
            if (badelineBoost != null)
            {
                badelineBoost.Active = (badelineBoost.Visible = (badelineBoost.Collidable = true));
            }

            flingBird?.RemoveSelf();
            BirdNpcState birdNPC;
            level.Scheduler.QueueSourceEntity(birdNPC =
                BirdNpcState.Create(level, flingBird.BirdEndPosition, BirdNpcMode.WaitForLightningOff));
            birdNPC.Facing = 1;
            birdNPC.FlyAwayUp = false;
        }
    }
}
