using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Core.Framework.Components;
using Celeste.Everest.Threading;

namespace Celeste.Everest.Runtime.Threading
{
    public class EverestStaThreadProcess : SourceGameComponentState
    {
        private readonly ConcurrentDictionary<object, Task> KeyedTasks = new();

        private readonly WorkerThreadTaskScheduler TaskScheduler;

        private readonly TaskFactory TaskFactory;


        private bool IsWorkerThread => Thread.CurrentThread == TaskScheduler.WorkerThread;

        public EverestStaThreadProcess(SourceGameFrameworkState game)
            : base(game)
        {
            UpdateOrder = -500000;
            TaskScheduler = new("Everest STAThread Worker", false);
            TaskFactory = new(TaskScheduler.CancellationToken);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                TaskScheduler.WorkerThread.SetApartmentState(ApartmentState.STA);

            TaskScheduler.WorkerThread.Start();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            TaskScheduler.Dispose();
        }

        public ValueTask Schedule(Action act)
        {
            if (IsWorkerThread)
            {
                act();
                return default;
            }

            return new(TaskFactory.StartNew(act));
        }

        public ValueTask<T> Schedule<T>(Func<T> act)
        {
            if (IsWorkerThread) return new(act());

            return new(TaskFactory.StartNew(act));
        }

        public Task Schedule(Func<Task> act)
        {
            return IsWorkerThread ? act() : TaskFactory.StartNew(() => act()).Unwrap();
        }

        public Task<T> Schedule<T>(Func<Task<T>> act)
        {
            return IsWorkerThread ? act() : TaskFactory.StartNew(() => act()).Unwrap();
        }

        [Obsolete("Use Schedule instead")]
        public void Do(Action a)
        {
            Schedule(a);
        }

        [Obsolete("Use Schedule instead")]
        public void Do(object key, Action act)
        {
            if (IsWorkerThread)
            {
                act();
            }
            else
            {
                if (KeyedTasks.TryGetValue(key, out var value) && !value.IsCompleted) return;

                lock (KeyedTasks)
                {
                    if (!KeyedTasks.TryGetValue(key, out value) || !value.IsCompleted)
                        KeyedTasks[key] = Schedule(act).AsTask();
                }
            }
        }

        [Obsolete("Use Schedule instead")]
        public SourceMaybeAwaitable<T> Get<T>(Func<T> f)
        {
            return new(Schedule(f));
        }

        [Obsolete("Use Schedule instead")]
        public SourceMaybeAwaitable<T> Get<T>(object key, Func<T> act)
        {
            if (IsWorkerThread) return new(act());

            if (!KeyedTasks.TryGetValue(key, out var value) || value.IsCompleted)
                lock (KeyedTasks)
                {
                    if (!KeyedTasks.TryGetValue(key, out value) || value.IsCompleted)
                        value = KeyedTasks[key] = Schedule(act).AsTask();
                }

            return new(((Task<T>)value).GetAwaiter());
        }
    }
}
