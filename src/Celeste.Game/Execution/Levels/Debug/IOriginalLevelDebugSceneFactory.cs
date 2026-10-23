using Celeste.Core.Scheduling;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.Levels.Debug
{
    public interface IOriginalLevelDebugSceneFactory
    {
        ISourceSceneExecution CreateMapEditor(int areaID, int mode);
        ISourceSceneExecution CreateLevelLoader(ChapterCompletionSession session);
    }
}
