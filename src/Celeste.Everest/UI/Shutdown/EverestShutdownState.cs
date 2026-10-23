using Celeste.Scene.Rendering;
using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Core.Framework.Timing;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Scenes;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Everest.UI.Shutdown
{
    public class EverestShutdownState : OuiState
    {
        private readonly ISourceEngineContext engine;
        public EverestShutdownState(ISourceEngineContext engine) : base(engine) => this.engine = engine;

        public override IEnumerator Enter(OuiState from)
        {
            Focused = false;
            new FadeWipePresentation((ISourceRendererScene)Scene, false, () =>
            {
                engine.Frame.Scenes.NextScene = new OriginalPlainScene(engine);
                ((IEverestApplicationExitEnvironment)engine).ApplicationLoop.Exit();
            });
            yield break;
        }

        public override IEnumerator Leave(OuiState next)
        {
            yield break;
        }
    }
}
