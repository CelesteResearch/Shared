using System;
using System.Threading;
using System.Threading.Tasks;

namespace Celeste.Everest.Tasks.Queuing
{
    public sealed class QueuedTask : QueuedTaskBase
    {
        internal QueuedTask(QueuedTaskScheduler scheduler, object key, Action @delegate, TimeSpan delay,
            CancellationToken cancellationToken)
            : base(scheduler, key, delay, cancellationToken)
        {
            if (@delegate == null) throw new ArgumentNullException("@delegate");
            base.Queued = Run(@delegate);
        }

        private async Task Run(Action @delegate)
        {
            try
            {
                await WaitForDelay();
                @delegate();
            }
            catch (Exception ex) when (!(ex is OperationCanceledException))
            {
                LogError(ex);
                throw;
            }
            finally
            {
                CompleteTask();
            }
        }
    }
}
