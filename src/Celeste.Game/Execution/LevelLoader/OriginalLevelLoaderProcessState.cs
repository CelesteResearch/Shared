using System;
using System.Threading;

namespace Celeste.Game.Execution.LevelLoader
{
    public sealed class OriginalLevelLoaderProcessState
    {
        public WeakReference<Thread> LastLoadingThread;
    }
}
