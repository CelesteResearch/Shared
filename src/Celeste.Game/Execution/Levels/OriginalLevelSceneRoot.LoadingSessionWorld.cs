using Celeste.Game.Save.Runtime;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public void PublishSourceLoaderSession(ChapterCompletionSession actualSession,
            IOriginalGameSaveContext sameProcessSave)
        {
            Session = actualSession;
            ((IOriginalSaveSessionStartEnvironment)EngineContext).SaveSessionStart
                .StartSession(sameProcessSave.CurrentSave, Session);
        }
    }
}
