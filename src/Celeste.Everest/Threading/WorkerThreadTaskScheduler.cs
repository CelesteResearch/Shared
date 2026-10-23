using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Celeste.Everest.Threading
{
    public class WorkerThreadTaskScheduler : TaskScheduler, IDisposable
    {
        public readonly Thread WorkerThread;

        private readonly CancellationTokenSource cancelSrc = new CancellationTokenSource();

        private readonly BlockingCollection<Task> tasks = new BlockingCollection<Task>();

        private bool isDisposed;
        private bool resourcesDisposed;
        private readonly object disposalGate = new();

        public bool HasWork => tasks.Count > 0;

        public CancellationToken CancellationToken => cancelSrc.Token;

        public override int MaximumConcurrencyLevel => 1;

        public WorkerThreadTaskScheduler(string name, bool autoStart = true)
        {
            WorkerThread = new Thread(WorkerThreadFunc)
            {
                Name = name,
                IsBackground = true
            };
            if (autoStart)
            {
                WorkerThread.Start();
            }
        }

        public void Dispose()
        {
            lock (disposalGate)
            {
                if (!isDisposed)
                {
                    isDisposed = true;
                    cancelSrc.Cancel();
                    tasks.CompleteAdding();
                }
            }

            if (Thread.CurrentThread == WorkerThread) return;
            if ((WorkerThread.ThreadState & ThreadState.Unstarted) == 0)
                WorkerThread.Join();
            DisposeResources();
        }

        private void DisposeResources()
        {
            lock (disposalGate)
            {
                if (!isDisposed || resourcesDisposed) return;
                resourcesDisposed = true;
                cancelSrc.Dispose();
                tasks.Dispose();
            }
        }

        private void WorkerThreadFunc()
        {
            CancellationToken token = cancelSrc.Token;
            try
            {
                while (!token.IsCancellationRequested)
                {
                    TryExecuteTask(tasks.Take(token));
                }
            }
            catch (OperationCanceledException ex)
            {
                if (ex.CancellationToken != token)
                {
                    throw;
                }
            }
            finally
            {
                DisposeResources();
            }
        }

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return tasks;
        }

        protected override void QueueTask(Task task)
        {
            tasks.Add(task);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            if (Thread.CurrentThread != WorkerThread)
            {
                return false;
            }

            return TryExecuteTask(task);
        }
    }
}
