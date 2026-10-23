using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Environment;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Chapters.Flow
{
// Composition creates actual shared scenes. It cannot return a native view or an object route.
    public interface ILevelEntrySceneFactory
    {
        ISourceSceneExecution CreateIntroVignette(ChapterCompletionSession session, HiresSnowState snow);
        ISourceSceneExecution CreateSummitVignette(ChapterCompletionSession session);
        ISourceSceneExecution CreateCoreVignette(ChapterCompletionSession session, HiresSnowState snow);
        ISourceSceneExecution CreateLevelEnter(ChapterCompletionSession session, bool fromSaveData);
    }
}
