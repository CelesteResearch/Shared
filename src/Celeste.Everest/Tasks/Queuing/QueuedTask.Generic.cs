using System;
using System.Threading;
using System.Threading.Tasks;

namespace Celeste.Everest.Tasks.Queuing
{
    public sealed class QueuedTask<T> : QueuedTaskBase
    {
        public new Task<T> Queued => (Task<T>)base.Queued;

        internal QueuedTask(QueuedTaskScheduler scheduler, object key, Func<T> @delegate, TimeSpan delay,
            CancellationToken cancellationToken)
            : base(scheduler, key, delay, cancellationToken)
        {
            if (@delegate == null) throw new ArgumentNullException("@delegate");
            base.Queued = Run(@delegate);
        }

        private async Task<T> Run(Func<T> @delegate)
        {
            try
            {
                await WaitForDelay();
                return @delegate();
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
