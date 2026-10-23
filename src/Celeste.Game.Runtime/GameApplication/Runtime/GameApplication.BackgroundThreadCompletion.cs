using System;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        public void WaitSourceBackgroundThreads(Action pump)
        {
            sourceGeneralThreads?.WaitAll(pump);
            sourceSaveThreads?.WaitAll(pump);
        }

        public async System.Threading.Tasks.Task WaitSourceBackgroundThreadsAsync()
        {
            System.Runtime.ExceptionServices.ExceptionDispatchInfo failure = null;
            do
            {
                try
                {
                    if (sourceGeneralThreads != null) await sourceGeneralThreads.WaitAllAsync();
                }
                catch (Exception exception)
                {
                    failure ??= System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(exception);
                }

                try
                {
                    if (sourceSaveThreads != null) await sourceSaveThreads.WaitAllAsync();
                }
                catch (Exception exception)
                {
                    failure ??= System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(exception);
                }
            } while (sourceGeneralThreads?.HasPendingWork == true || sourceSaveThreads?.HasPendingWork == true);

            failure?.Throw();
        }
    }
}
