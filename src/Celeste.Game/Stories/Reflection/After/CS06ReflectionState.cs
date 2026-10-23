using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Simulation;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;

namespace Celeste.Game.Stories.Reflection.After
{
    public class CS06ReflectionState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;

        private RoomPlayerSession player;

        private float targetX;

        public CS06ReflectionState(ISourceEngineContext engine, RoomPlayerSession player, float targetX) : base(engine)
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
            player.Machine.Locked = true;
            player.ForceCameraUpdate = true;
            yield return player.DummyWalkToExact((int)targetX);
            yield return 0.1f;
            player.Data.Facing = 1;
            yield return 0.1f;
            yield return Level.ZoomTo(new Vector2(200f, 90f), 2f, 1f);
            yield return TextboxState.Say("CH6_REFLECT_AFTER", engine);
            yield return Level.ZoomBack(0.5f);
            EndCutscene(level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.Machine.Locked = false;
            player.Machine.State = 0;
            player.ForceCameraUpdate = false;
            player.FlipInReflection = false;
            level.Session.SetFlag("reflection");
        }
    }
}
