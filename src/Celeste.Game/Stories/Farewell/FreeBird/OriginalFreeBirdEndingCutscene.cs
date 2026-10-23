using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Stories.Farewell.FreeBird
{
    public class OriginalFreeBirdEndingCutscene : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;

        public OriginalFreeBirdEndingCutscene(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            yield return TextboxState.Say("CH9_FREE_BIRD", engine);
            var fadeWipe = new FadeWipePresentation(level, false);
            fadeWipe.Duration = 3f;
            yield return fadeWipe.Duration;
            EndCutscene(level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            level.CompleteArea(false, true);
        }
    }
}
