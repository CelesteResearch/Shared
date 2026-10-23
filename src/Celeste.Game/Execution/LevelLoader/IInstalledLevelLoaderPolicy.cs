using System;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Threading;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.LevelLoader
{
    public interface IInstalledLevelLoaderPolicy
    {
        bool HasPendingError { get; }
        void BeforeOriginalConstructor(ChapterCompletionSession session);
        void AfterLoadingThreadStarted(OriginalGameThreadSession threads);
        void OnLoadingThread(OriginalLevelSceneRoot level);
        void HandleLoadingFailure(ChapterCompletionSession session, Exception exception);
        void HandleStartFailure(ChapterCompletionSession session, Exception exception);
        void RouteError(ChapterCompletionSession session);
    }
}
