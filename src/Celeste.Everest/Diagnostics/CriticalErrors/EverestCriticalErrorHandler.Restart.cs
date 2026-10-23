using Celeste.Everest.Runtime.Boot;
using Celeste.Everest.Runtime.Events;
using Celeste.Everest.UI.Shutdown;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public sealed partial class EverestCriticalErrorHandler
    {
        private void AddRestartButton()
        {
            optMenu.Add(new TextMenuPresentation.Button("Restart Game").Pressed(() =>
            {
                ((IEverestGameEventsEnvironment)EngineContext).GameEvents.OnShutdown += () =>
                {
                    ((IEverestBootProcessEnvironment)EngineContext).BootProcess.StartCelesteProcess();
                };
                ((ISourceScene)Scene).SourceScene.OnEndOfFrame += () =>
                    ((IEverestApplicationExitEnvironment)EngineContext).ApplicationLoop.Exit();
            }));
        }
    }
}
