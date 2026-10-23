using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Stories.Epilogue
{
    public class CS08EnterDoorState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly RoomPlayerSession player;

        private readonly float targetX;

        public CS08EnterDoorState(ISourceEngineContext engine, RoomPlayerSession player, float targetX) : base(engine)
        {
            this.engine = engine;
            this.player = player;
            this.targetX = targetX;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            OwnedComponents.Add(new SimulationCoroutine(engine,
                player.DummyWalkToExact((int)targetX, false, 0.7f)));
            OwnedComponents.Add(new SimulationCoroutine(engine,
                level.ZoomTo(new(targetX - level.Camera.X, 90f), 2f, 2f)));
            var fadeWipe = new FadeWipePresentation(level, false);
            fadeWipe.Duration = 2f;
            yield return fadeWipe.Wait();
            EndCutscene(level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            level.OnEndOfFrame += delegate
            {
                level.RemoveEntity(player);
                level.UnloadLevel();
                level.Session.Level = "inside";
                level.Session.RespawnPoint = level.GetSpawnPoint(new(level.Bounds.Left, level.Bounds.Top));
                level.LoadLevel(PlayerIntroType.None);
                level.Scheduler.QueueSourceEntity(new CS08EndingState(engine));
            };
        }
    }
}
