using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;

namespace Celeste.Everest.Stories.Dialogue
{
    public class EverestDialogCutsceneState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly RoomPlayerSession player;

        private readonly string dialogID;

        private readonly bool endLevel;

        public EverestDialogCutsceneState(string dialogID, RoomPlayerSession player, bool endLevel,
            ISourceEngineContext engine)
            : base(engine)
        {
            this.engine = engine;
            this.dialogID = dialogID;
            this.player = player;
            this.endLevel = endLevel;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            if (endLevel) level.RegisterAreaComplete();

            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            player.ForceCameraUpdate = true;
            yield return TextboxState.Say(dialogID, engine);
            EndCutscene(level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.Machine.Locked = false;
            player.Machine.State = 0;
            player.ForceCameraUpdate = false;
            if (WasSkipped) level.Camera.Position = player.CameraTarget;

            if (!endLevel)
                return;
            level.CompleteArea();
            player.Machine.State = 11;
            RemoveSelf();
        }
    }
}
