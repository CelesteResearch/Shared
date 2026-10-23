using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Core.Framework.Components;

namespace Celeste.Everest.Runtime.Threading
{
    public sealed class EverestMainThreadProcess : SourceGameComponentState
    {
        public readonly TaskCreationOptions ForceQueue;

        public int Boost;

        private readonly EverestMainThreadTaskScheduler TaskScheduler;

        private readonly TaskFactory TaskFactory;

        private readonly ConcurrentDictionary<object, Task> KeyedTasks;

        public readonly SourceYieldFrameAwaitable YieldFrame;

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public Thread MainThread { get; private set; }

        public bool UpdatedOnce { get; private set; }

        public bool IsMainThread => MainThread == Thread.CurrentThread;

        private int TaskTimeSlice => Boost == 0 ? 10 : Boost;

        public EverestMainThreadProcess(SourceGameFrameworkState game) : base(game)
        {
            ForceQueue = TaskCreationOptions.LongRunning;
            KeyedTasks = new();
            TaskScheduler = new(this);
            TaskFactory = new(CancellationToken.None, TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler);
            UpdateOrder = -500000;
            MainThread = Thread.CurrentThread;
            YieldFrame = new(this);
        }

        public ValueTask Schedule(Action act, bool forceQueue = false)
        {
            if (forceQueue && IsMainThread)
                try
                {
                    TaskScheduler.TaskIsForceQueued = true;
                    return Schedule(act);
                }
                finally
                {
                    TaskScheduler.TaskIsForceQueued = false;
                }

            if (IsMainThread)
            {
                act();
                return default;
            }

            return new(TaskFactory.StartNew(act));
        }

        public ValueTask<T> Schedule<T>(Func<T> act, bool forceQueue = false)
        {
            if (forceQueue && IsMainThread)
                try
                {
                    TaskScheduler.TaskIsForceQueued = true;
                    return Schedule(act);
                }
                finally
                {
                    TaskScheduler.TaskIsForceQueued = false;
                }

            if (IsMainThread) return new(act());

            return new(TaskFactory.StartNew(act));
        }

        public Task Schedule(Func<Task> act, bool forceQueue = false)
        {
            if (forceQueue && IsMainThread)
                try
                {
                    TaskScheduler.TaskIsForceQueued = true;
                    return Schedule(act);
                }
                finally
                {
                    TaskScheduler.TaskIsForceQueued = false;
                }

            if (IsMainThread) return act();

            return TaskFactory.StartNew(act).Unwrap();
        }

        public Task<T> Schedule<T>(Func<Task<T>> act, bool forceQueue = false)
        {
            if (forceQueue && IsMainThread)
                try
                {
                    TaskScheduler.TaskIsForceQueued = true;
                    return Schedule(act);
                }
                finally
                {
                    TaskScheduler.TaskIsForceQueued = false;
                }

            if (IsMainThread) return act();

            return TaskFactory.StartNew(act).Unwrap();
        }

        public void Do(Action a)
        {
            Schedule(a);
        }

        public SourceMaybeAwaitable<T> Get<T>(Func<T> f)
        {
            return new(Schedule(f));
        }

        public SourceMaybeAwaitable<T> GetForceQueue<T>(Func<T> f)
        {
            return new(Schedule(f, true));
        }

        public void Do(object key, Action act)
        {
            if (IsMainThread)
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

        public SourceMaybeAwaitable<T> Get<T>(object key, Func<T> act)
        {
            if (IsMainThread) return new(act());

            if (!KeyedTasks.TryGetValue(key, out var value) || value.IsCompleted)
                lock (KeyedTasks)
                {
                    if (!KeyedTasks.TryGetValue(key, out value) || value.IsCompleted)
                        value = KeyedTasks[key] = Schedule(act).AsTask();
                }

            return new(((Task<T>)value).GetAwaiter());
        }

        public SourceMaybeAwaitable<T> GetForceQueue<T>(object key, Func<T> act)
        {
            if (IsMainThread) return new(act());

            if (!KeyedTasks.TryGetValue(key, out var value) || value.IsCompleted)
                lock (KeyedTasks)
                {
                    if (!KeyedTasks.TryGetValue(key, out value) || value.IsCompleted)
                        value = KeyedTasks[key] = Schedule(act, true).AsTask();
                }

            return new(((Task<T>)value).GetAwaiter());
        }

        public void PumpPendingWork()
        {
            TaskScheduler.ExecuteTasksFor(TaskTimeSlice);
        }

        public override void Update(SourceGameTime gameTime)
        {
            UpdatedOnce = true;
            PumpPendingWork();
            if (gameTime != null) base.Update(gameTime);
        }
    }
}
