using System;
using Celeste.Core.Framework.Components;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Celeste.Everest.Runtime.Threading
{
    public sealed class EverestMainThreadProcess : SourceGameComponentState
    {
        public readonly TaskCreationOptions ForceQueue;

        public int Boost;

        private EverestMainThreadTaskScheduler TaskScheduler;

        private TaskFactory TaskFactory;

        private ConcurrentDictionary<object, Task> KeyedTasks;

        public readonly SourceYieldFrameAwaitable YieldFrame;

        public Thread MainThread { get; private set; }

        public bool UpdatedOnce { get; private set; }

        public bool IsMainThread => MainThread == Thread.CurrentThread;

        private int TaskTimeSlice
        {
            get
            {
                if (Boost == 0)
                {
                    return 10;
                }

                return Boost;
            }
        }

        public EverestMainThreadProcess(SourceGameFrameworkState game) : base(game)
        {
            ForceQueue = TaskCreationOptions.LongRunning;
            KeyedTasks = new ConcurrentDictionary<object, Task>();
            TaskScheduler = new EverestMainThreadTaskScheduler(this);
            TaskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler);
            UpdateOrder = -500000;
            MainThread = Thread.CurrentThread;
            YieldFrame = new SourceYieldFrameAwaitable(this);
        }

        public ValueTask Schedule(Action act, bool forceQueue = false)
        {
            if (forceQueue && IsMainThread)
            {
                try
                {
                    TaskScheduler.TaskIsForceQueued = true;
                    return Schedule(act);
                }
                finally
                {
                    TaskScheduler.TaskIsForceQueued = false;
                }
            }

            if (IsMainThread)
            {
                act();
                return default;
            }

            return new ValueTask(TaskFactory.StartNew(act));
        }

        public ValueTask<T> Schedule<T>(Func<T> act, bool forceQueue = false)
        {
            if (forceQueue && IsMainThread)
            {
                try
                {
                    TaskScheduler.TaskIsForceQueued = true;
                    return Schedule(act);
                }
                finally
                {
                    TaskScheduler.TaskIsForceQueued = false;
                }
            }

            if (IsMainThread)
            {
                return new ValueTask<T>(act());
            }

            return new ValueTask<T>(TaskFactory.StartNew(act));
        }

        public Task Schedule(Func<Task> act, bool forceQueue = false)
        {
            if (forceQueue && IsMainThread)
            {
                try
                {
                    TaskScheduler.TaskIsForceQueued = true;
                    return Schedule(act);
                }
                finally
                {
                    TaskScheduler.TaskIsForceQueued = false;
                }
            }

            if (IsMainThread)
            {
                return act();
            }

            return TaskFactory.StartNew(act).Unwrap();
        }

        public Task<T> Schedule<T>(Func<Task<T>> act, bool forceQueue = false)
        {
            if (forceQueue && IsMainThread)
            {
                try
                {
                    TaskScheduler.TaskIsForceQueued = true;
                    return Schedule(act);
                }
                finally
                {
                    TaskScheduler.TaskIsForceQueued = false;
                }
            }

            if (IsMainThread)
            {
                return act();
            }

            return TaskFactory.StartNew(act).Unwrap();
        }

        public void Do(Action a)
        {
            Schedule(a);
        }

        public SourceMaybeAwaitable<T> Get<T>(Func<T> f)
        {
            return new SourceMaybeAwaitable<T>(Schedule(f));
        }

        public SourceMaybeAwaitable<T> GetForceQueue<T>(Func<T> f)
        {
            return new SourceMaybeAwaitable<T>(Schedule(f, forceQueue: true));
        }

        public void Do(object key, Action act)
        {
            if (IsMainThread)
            {
                act();
            }
            else
            {
                if (KeyedTasks.TryGetValue(key, out var value) && !value.IsCompleted)
                {
                    return;
                }

                lock (KeyedTasks)
                {
                    if (!KeyedTasks.TryGetValue(key, out value) || !value.IsCompleted)
                    {
                        KeyedTasks[key] = Schedule(act).AsTask();
                    }
                }
            }
        }

        public SourceMaybeAwaitable<T> Get<T>(object key, Func<T> act)
        {
            if (IsMainThread)
            {
                return new SourceMaybeAwaitable<T>(act());
            }

            if (!KeyedTasks.TryGetValue(key, out var value) || value.IsCompleted)
            {
                lock (KeyedTasks)
                {
                    if (!KeyedTasks.TryGetValue(key, out value) || value.IsCompleted)
                    {
                        value = (KeyedTasks[key] = Schedule(act).AsTask());
                    }
                }
            }

            return new SourceMaybeAwaitable<T>(((Task<T>)value).GetAwaiter());
        }

        public SourceMaybeAwaitable<T> GetForceQueue<T>(object key, Func<T> act)
        {
            if (IsMainThread)
            {
                return new SourceMaybeAwaitable<T>(act());
            }

            if (!KeyedTasks.TryGetValue(key, out var value) || value.IsCompleted)
            {
                lock (KeyedTasks)
                {
                    if (!KeyedTasks.TryGetValue(key, out value) || value.IsCompleted)
                    {
                        value = (KeyedTasks[key] = Schedule(act, forceQueue: true).AsTask());
                    }
                }
            }

            return new SourceMaybeAwaitable<T>(((Task<T>)value).GetAwaiter());
        }

        public void PumpPendingWork() => TaskScheduler.ExecuteTasksFor(TaskTimeSlice);

        public override void Update(SourceGameTime gameTime)
        {
            UpdatedOnce = true;
            PumpPendingWork();
            if (gameTime != null) base.Update(gameTime);
        }
    }
}
