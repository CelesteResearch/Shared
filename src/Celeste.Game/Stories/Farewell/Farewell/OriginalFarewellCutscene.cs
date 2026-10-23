using Celeste.Core.Display;
using System.Collections;
using EventInstance = Celeste.Audio.Fmod.Events.FmodEventReference;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Game.Stories.Farewell.Effects;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.Gameplay.Player.Intro;
using Player = Celeste.Simulation.RoomPlayerSession;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;
using NPC = Celeste.Game.Entities.Npcs.OriginalNpcState;
using Coroutine = Celeste.Core.Scheduling.SimulationCoroutine;

namespace Celeste.Game.Stories.Farewell.Farewell
{
    public class OriginalFarewellCutscene : OriginalCutsceneEntityState
    {
        private Player player;

        private NPC granny;

        private float fade;

        private Coroutine grannyWalk;

        private EventInstance snapshot;

        private EventInstance dissipate;

        private readonly ISourceEngineContext engine;

        private Celeste.Game.Audio.Runtime.OriginalGameAudioSession Audio =>
            ((IOriginalGameplayProcess)engine).AudioSession;

        public OriginalFarewellCutscene(ISourceEngineContext engine, Player player)
            : base(engine, fadeInOnSkip: false)
        {
            this.engine = engine;
            this.player = player;
            base.Depth = -1000000;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            Level obj = scene as Level;
            obj.TimerStopped = true;
            obj.TimerHidden = true;
            obj.SaveQuitDisabled = true;
            obj.SnapColorGrade("none");
            snapshot = Audio.CreateSnapshot("snapshot:/game_10_granny_clouds_dialogue");
        }

        public override void OnBegin(Level level)
        {
            OwnedComponents.Add(new Coroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(Level level)
        {
            player.Data.Dashes = 1;
            player.Machine.State = 11;
            player.Sprite.Play("idle");
            player.Visible = false;
            Audio.SetMusic("event:/new_content/music/lvl10/granny_farewell");
            FadeWipePresentation fadeWipe = new FadeWipePresentation(Level, wipeIn: true);
            fadeWipe.Duration = 2f;
            ((ISourceScreenWipeEnvironment)engine).ProcessWipe.WipeColor = PackedColor.White;
            yield return fadeWipe.Duration;
            yield return 1.5f;
            OwnedComponents.Add(new Coroutine(engine, Level.ZoomTo(new Vector2(160f, 125f), 2f, 5f)));
            yield return 0.2f;
            Audio.Play("event:/new_content/char/madeline/screenentry_gran");
            yield return 0.3f;
            _ = player.Position;
            player.Position = new Vector2(player.X, level.Bounds.Bottom + 8);
            player.Data.Motion.Normal.Speed.Y = -160f;
            player.Visible = true;
            player.Dummy.Gravity = false;
            player.Data.MuffleLanding = true;
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(0, 1);
            while (!player.OnGround() || player.Data.Motion.Normal.Speed.Y < 0f)
            {
                float y = player.Data.Motion.Normal.Speed.Y;
                player.Data.Motion.Normal.Speed.Y += engine.DeltaTime * 900f * 0.2f;
                if (y < 0f && player.Data.Motion.Normal.Speed.Y >= 0f)
                {
                    player.Data.Motion.Normal.Speed.Y = 0f;
                    yield return 0.2f;
                }

                yield return null;
            }

            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(0, 0);
            Audio.Play("event:/new_content/char/madeline/screenentry_gran_landing", player.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            granny = new NPC(engine, player.Position + new Vector2(164f, 0f));
            granny.IdleAnim = "idle";
            granny.MoveAnim = "walk";
            granny.Maxspeed = 15f;
            granny.OwnedComponents.Add(granny.Sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("granny"));
            OriginalGrannyLaughSfxState grannyLaughSfx = new OriginalGrannyLaughSfxState(engine, granny.Sprite);
            grannyLaughSfx.FirstPlay = false;
            granny.OwnedComponents.Add(grannyLaughSfx);
            granny.Sprite.OnFrameChange = delegate(string anim)
            {
                int currentAnimationFrame = granny.Sprite.CurrentAnimationFrame;
                if (anim == "walk" && currentAnimationFrame == 2)
                {
                    float volume =
                        ScalarMath.ClampedMap(
                            ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(
                                player.Position - granny.Position),
                            64f, 128f, 1f, 0f);
                    Audio.Play("event:/new_content/char/granny/cane_tap_ending", granny.Position,
                        ((IOriginalGameplayProcess)engine).SaveContext).SetVolume(volume);
                }
            };
            ((Level)Scene).AddEntity(granny);
            grannyWalk = new Coroutine(engine, granny.MoveTo(player.Position + new Vector2(32f, 0f)));
            OwnedComponents.Add(grannyWalk);
            yield return 2f;
            player.Data.Facing = -1;
            yield return 1.6f;
            player.Data.Facing = 1;
            yield return 0.8f;
            yield return player.DummyWalkToExact((int)player.X + 4, walkBackwards: false, 0.4f);
            yield return 0.8f;
            yield return TextboxState.Say("CH9_FAREWELL", engine, Laugh, StopLaughing, StepForward, GrannyDisappear,
                FadeToWhite, WaitForGranny);
            yield return 2f;
            while (fade < 1f)
            {
                yield return null;
            }

            EndCutscene(level);
        }

        private IEnumerator WaitForGranny()
        {
            while (grannyWalk != null && !grannyWalk.Finished)
            {
                yield return null;
            }
        }

        private IEnumerator Laugh()
        {
            granny.Sprite.Play("laugh");
            yield break;
        }

        private IEnumerator StopLaughing()
        {
            granny.Sprite.Play("idle");
            yield break;
        }

        private IEnumerator StepForward()
        {
            yield return player.DummyWalkToExact((int)player.X + 8, walkBackwards: false, 0.4f);
        }

        private IEnumerator GrannyDisappear()
        {
            Audio.SetMusicParam("end", 1f);
            OwnedComponents.Add(new Coroutine(engine,
                player.DummyWalkToExact((int)player.X + 8, walkBackwards: false, 0.4f)));
            yield return 0.1f;
            dissipate = Audio.Play("event:/new_content/char/granny/dissipate", granny.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            AtlasEntry frame =
                granny.Sprite.GetFrame(granny.Sprite.CurrentAnimationID, granny.Sprite.CurrentAnimationFrame);
            Level.AddEntity(new OriginalDisperseImageState(engine, granny.Position, new Vector2(1f, -0.1f),
                granny.Sprite.Origin, granny.Sprite.Scale, frame));
            yield return null;
            granny.Visible = false;
            yield return 3.5f;
        }

        private IEnumerator FadeToWhite()
        {
            OwnedComponents.Add(new Coroutine(engine, DoFadeToWhite()));
            yield break;
        }

        private IEnumerator DoFadeToWhite()
        {
            OwnedComponents.Add(new Coroutine(engine, Level.ZoomBack(8f)));
            while (fade < 1f)
            {
                fade = ScalarMath.Approach(fade, 1f, engine.DeltaTime / 8f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }
        }

        public override void OnEnd(Level level)
        {
            Dispose();
            if (WasSkipped)
            {
                Audio.Stop(dissipate);
            }

            Level.OnEndOfFrame += delegate
            {
                ((IOriginalPlatformStatisticsEnvironment)engine).Statistics.Achievements.Register(OriginalAchievement
                    .FAREWELL);
                Level.TeleportTo(player, "end-cinematic", PlayerIntroType.Transition);
            };
        }

        public override void SceneEnd(object scene)
        {
            base.SceneEnd(scene);
            Dispose();
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            Dispose();
        }

        private void Dispose()
        {
            Audio.ReleaseSnapshot(snapshot);
            snapshot = null;
        }

        public override void Render(ISourceRenderContext context)
        {
            if (fade > 0f)
            {
                SourcePrimitiveDrawing.Rect(context, this, Level.Camera.X - 1f, Level.Camera.Y - 1f, 322f, 182f,
                    PackedColor.White * fade);
            }
        }
    }
}
