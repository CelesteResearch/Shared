using System;
using Celeste.Everest.Modules.Runtime;
using Celeste.Game.Execution.Levels;

namespace Celeste.Everest.Runtime.Events.LevelLoading
{
    public static class EverestLevelLoaderSourceEvents
    {
        private static Action<OriginalLevelSceneRoot> loadingThread;

        public static event Action<OriginalLevelSceneRoot> OnLoadingThread
        {
            add
            {
                loadingThread += value;
                EverestModuleLifetime.Track(() => loadingThread -= value);
            }
            remove { loadingThread -= value; }
        }

        public static void LoadingThread(OriginalLevelSceneRoot level) => loadingThread?.Invoke(level);
    }
}
