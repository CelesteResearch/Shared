using System;
using System.Collections.Generic;
using System.Threading;

namespace Celeste.Everest.Tasks.Queuing
{
    public sealed class QueuedTaskScheduler
    {
        internal readonly IQueuedTaskDiagnostics Diagnostics;

        public QueuedTaskScheduler(IQueuedTaskDiagnostics diagnostics)
        {
            Diagnostics = diagnostics ?? throw new ArgumentNullException(nameof(diagnostics));
        }

        internal readonly Dictionary<object, QueuedTaskBase> RunningTasks = new();

        public static readonly TimeSpan DefaultDelay = TimeSpan.FromSeconds(0.5);

        public QueuedTask Do(object key, Action @delegate)
        {
            return Do(key, DefaultDelay, @delegate, CancellationToken.None);
        }

        public QueuedTask Do(object key, TimeSpan delay, Action @delegate)
        {
            return Do(key, delay, @delegate, CancellationToken.None);
        }

        public QueuedTask Do(object key, TimeSpan delay, Action @delegate, CancellationToken cancellationToken)
        {
            lock (RunningTasks)
            {
                if (RunningTasks.TryGetValue(key, out var value) && !value.Queued.IsCompleted)
                {
                    var obj = value as QueuedTask ??
                              throw new InvalidOperationException(
                                  "A queued task with an incompatible type is already running.");
                    obj.UpdateDelay(delay);
                    return obj;
                }

                var queuedTask = new QueuedTask(this, key, @delegate, delay, cancellationToken);
                RunningTasks[key] = queuedTask;
                return queuedTask;
            }
        }

        public QueuedTask<T> Get<T>(object key, Func<T> @delegate)
        {
            return Get(key, @delegate, DefaultDelay, CancellationToken.None);
        }

        public QueuedTask<T> Get<T>(object key, Func<T> @delegate, TimeSpan delay)
        {
            return Get(key, @delegate, delay, CancellationToken.None);
        }

        public QueuedTask<T> Get<T>(object key, Func<T> @delegate, TimeSpan delay, CancellationToken cancellationToken)
        {
            lock (RunningTasks)
            {
                if (RunningTasks.TryGetValue(key, out var value) && !value.Queued.IsCompleted)
                {
                    var obj = value as QueuedTask<T> ??
                              throw new InvalidOperationException(
                                  "A queued task with an incompatible type is already running.");
                    obj.UpdateDelay(delay);
                    return obj;
                }

                var queuedTask = new QueuedTask<T>(this, key, @delegate, delay, cancellationToken);
                RunningTasks[key] = queuedTask;
                return queuedTask;
            }
        }
    }
}
