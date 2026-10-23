using System;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        public void WaitSourceBackgroundThreads(Action pump)
        {
            sourceGeneralThreads?.WaitAll(pump);
            sourceSaveThreads?.WaitAll(pump);
        }

        public async Task WaitSourceBackgroundThreadsAsync()
        {
            ExceptionDispatchInfo failure = null;
            do
            {
                try
                {
                    if (sourceGeneralThreads != null) await sourceGeneralThreads.WaitAllAsync();
                }
                catch (Exception exception)
                {
                    failure ??= ExceptionDispatchInfo.Capture(exception);
                }

                try
                {
                    if (sourceSaveThreads != null) await sourceSaveThreads.WaitAllAsync();
                }
                catch (Exception exception)
                {
                    failure ??= ExceptionDispatchInfo.Capture(exception);
                }
            } while (sourceGeneralThreads?.HasPendingWork == true || sourceSaveThreads?.HasPendingWork == true);

            failure?.Throw();
        }
    }
}
