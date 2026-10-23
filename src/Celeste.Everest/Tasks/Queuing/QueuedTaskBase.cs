using System;
using System.Threading;
using System.Threading.Tasks;

namespace Celeste.Everest.Tasks.Queuing
{
    public abstract class QueuedTaskBase
    {
        protected readonly QueuedTaskScheduler Scheduler;
        public object Key { get; set; }
        public CancellationToken CancellationToken { get; }
        protected Task DelayTask { get; private set; }
        public Task Queued { get; protected set; }

        protected QueuedTaskBase(QueuedTaskScheduler scheduler, object key, TimeSpan delay,
            CancellationToken cancellationToken)
        {
            Scheduler = scheduler;
            Key = key;
            CancellationToken = cancellationToken;
            UpdateDelay(delay);
        }

        internal void UpdateDelay(TimeSpan delay)
        {
            var queued = Queued;
            if (queued is { IsCompleted: true })
                throw new InvalidOperationException("Cannot overlay a delay on a completed task.");

            DelayTask = Task.Delay(delay, CancellationToken);
        }

        protected async Task WaitForDelay()
        {
            await Task.Yield();
            do
            {
                await DelayTask;
            } while (!DelayTask.IsCompleted);
        }

        protected void LogError(Exception exception)
        {
            if (Scheduler.Diagnostics.IsErrorEnabled("QueuedTask"))
                Scheduler.Diagnostics.Error("QueuedTask",
                    $"A queued task with key hashcode {Key.GetHashCode()} failed.");
            Scheduler.Diagnostics.Detailed(exception);
        }

        protected void CompleteTask()
        {
            lock (Scheduler.RunningTasks)
            {
                Scheduler.RunningTasks.Remove(Key);
            }
        }
    }
}
