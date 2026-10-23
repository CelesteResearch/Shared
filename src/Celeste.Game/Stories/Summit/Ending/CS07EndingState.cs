using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Core.Mathematics.Easing;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Controls.Source;

namespace Celeste.Game.Stories.Summit.Ending
{
    public class CS07EndingState : OriginalCutsceneEntityState
    {
        private RoomPlayerSession player;

        private BadelineDummyPresentation badeline;

        private Vector2 target;

        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        public CS07EndingState(RoomPlayerSession player, Vector2 target, ISourceEngineContext engine)
            : base(engine, fadeInOnSkip: false, endingChapterAfter: true)
        {
            this.engine = engine;
            this.player = player;
            this.target = target;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            level.RegisterAreaComplete();
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            Process.AudioSession.SetMusic(null);
            player.Machine.State = 11;
            yield return player.DummyWalkTo(target.X);
            yield return 0.25f;
            OwnedComponents.Add(new SimulationCoroutine(engine,
                OriginalCutsceneEntityState.CameraTo(engine, target + new Vector2(-160f, -130f), 3f,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut)));
            player.Data.Facing = 1;
            yield return 1f;
            player.Sprite.Play("idle");
            player.Dummy.AutoAnimate = false;
            player.Data.Dashes = 1;
            level.Session.Inventory.Dashes = 1;
            level.Scheduler.QueueSourceEntity(badeline = new BadelineDummyPresentation(engine, player.Center));
            player.CreateSplitParticles();
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble((int)RumbleStrength.Light,
                (int)RumbleLength.Medium);
            Level.Displacement.AddBurst(player.Center, 0.4f, 8f, 32f, 0.5f);
            badeline.Sprite.Scale.X = 1f;
            Process.AudioSession.Play("event:/char/badeline/maddy_split", player.Position, Process.SaveContext);
            yield return badeline.FloatTo(target + new Vector2(-10f, -30f), 1, faceDirection: false);
            yield return 0.5f;
            yield return TextboxState.Say("CH7_ENDING", engine, WaitABit, SitDown, BadelineApproaches);
            yield return 1f;
            EndCutscene(level);
        }

        private IEnumerator WaitABit()
        {
            yield return 3f;
        }

        private IEnumerator SitDown()
        {
            yield return 0.5f;
            player.Dummy.AutoAnimate = true;
            yield return player.DummyWalkTo(player.X + 16f, walkBackwards: false, 0.25f);
            yield return 0.1f;
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("sitDown");
            yield return 1f;
        }

        private IEnumerator BadelineApproaches()
        {
            yield return 0.5f;
            badeline.Sprite.Scale.X = -1f;
            yield return 1f;
            badeline.Sprite.Scale.X = 1f;
            yield return 1f;
            OwnedComponents.Add(new SimulationCoroutine(engine,
                OriginalCutsceneEntityState.CameraTo(engine, Level.Camera.Position + new Vector2(88f, 0f), 6f,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut)));
            badeline.FloatSpeed = 40f;
            yield return badeline.FloatTo(new Vector2(player.X - 10f, player.Y - 4f));
            yield return 0.5f;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            Process.AudioSession.SetMusic(null);
            var screenWipe = level.CompleteArea(spotlightWipe: false);
            if (screenWipe != null)
            {
                screenWipe.Duration = 2f;
                screenWipe.EndTimer = 1f;
            }
        }
    }
}
