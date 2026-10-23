using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Celeste.Core.Framework.Loading
{
    // Owned by the host loop. Resource readiness never runs source work through a task continuation.
    public sealed class CooperativeSourceLoadingWorkScheduler : ISourceContextualLoadingWorkScheduler
    {
        private sealed class PendingWork
        {
            internal readonly Action Work;
            internal readonly Action<Exception> PreparationFailed;
            internal readonly SourceLoadingWorkInfo Info;
            internal readonly TaskCompletionSource<object> Completion;
            internal bool Preparing;
            internal ValueTask Readiness;

            internal PendingWork(Action work, Action<Exception> preparationFailed, SourceLoadingWorkInfo info)
            {
                Work = work;
                PreparationFailed = preparationFailed;
                Info = info;
                Completion = new TaskCompletionSource<object>(info.Name);
            }
        }

        private readonly Func<string, ValueTask> prepareResources;
        private readonly Func<SourceLoadingWorkInfo, ValueTask> prepareContext;
        private readonly Queue<PendingWork> highPriority = new();
        private readonly Queue<PendingWork> normalPriority = new();
        private bool pumping;
        private int blockingWork;

        public bool SourceUpdatesBlocked => blockingWork != 0;

        public CooperativeSourceLoadingWorkScheduler(Func<string, ValueTask> prepareResources)
            => this.prepareResources = prepareResources ?? throw new ArgumentNullException(nameof(prepareResources));

        private CooperativeSourceLoadingWorkScheduler(Func<SourceLoadingWorkInfo, ValueTask> prepareContext)
            => this.prepareContext = prepareContext ?? throw new ArgumentNullException(nameof(prepareContext));

        public static CooperativeSourceLoadingWorkScheduler CreateWithContextPreparation(
            Func<SourceLoadingWorkInfo, ValueTask> prepareContext)
            => new CooperativeSourceLoadingWorkScheduler(prepareContext);

        public Task Schedule(Action work, Action<Exception> preparationFailed, string name, bool highPriority)
            => Schedule(work, preparationFailed, new SourceLoadingWorkInfo(name), highPriority);

        public Task Schedule(Action work, Action<Exception> preparationFailed, SourceLoadingWorkInfo info,
            bool highPriority)
        {
            if (work == null) throw new ArgumentNullException(nameof(work));
            if (preparationFailed == null) throw new ArgumentNullException(nameof(preparationFailed));
            if (info == null) throw new ArgumentNullException(nameof(info));
            if (info.ContentContext != null && prepareContext == null)
                throw new InvalidOperationException("This loading scheduler has no content context preparation.");
            var pending = new PendingWork(work, preparationFailed, info);
            if (info.BlocksSourceUpdates) blockingWork++;
            (highPriority ? this.highPriority : normalPriority).Enqueue(pending);
            return pending.Completion.Task;
        }

        public void Pump()
        {
            if (pumping) return;
            pumping = true;
            try
            {
                int highCount = highPriority.Count;
                int normalCount = normalPriority.Count;
                Pump(highPriority, highCount);
                Pump(normalPriority, normalCount);
            }
            finally
            {
                pumping = false;
            }
        }

        // Synchronous hosts may drain local loading work before releasing their graphics device.
        public void DrainReadyWork()
        {
            if (pumping) throw new InvalidOperationException("Loading work cannot drain itself while pumping.");
            while (highPriority.Count != 0 || normalPriority.Count != 0)
            {
                Pump();
                RequireReady(highPriority);
                RequireReady(normalPriority);
            }
        }

        private static void RequireReady(Queue<PendingWork> queue)
        {
            foreach (var pending in queue)
                if (pending.Preparing && !pending.Readiness.IsCompleted)
                    throw new InvalidOperationException(
                        "Asynchronous resources require the host to continue pumping loading work.");
        }

        private void Pump(Queue<PendingWork> queue, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var pending = queue.Dequeue();
                try
                {
                    if (!pending.Preparing)
                    {
                        pending.Preparing = true;
                        pending.Readiness = prepareContext != null
                            ? prepareContext(pending.Info)
                            : prepareResources(pending.Info.Name);
                    }

                    if (!pending.Readiness.IsCompleted)
                    {
                        queue.Enqueue(pending);
                        continue;
                    }

                    pending.Readiness.GetAwaiter().GetResult();
                }
                catch (Exception exception)
                {
                    pending.Completion.TrySetException(exception);
                    if (pending.Info.BlocksSourceUpdates) blockingWork--;
                    pending.PreparationFailed(exception);
                    continue;
                }

                try
                {
                    pending.Work();
                    pending.Completion.TrySetResult(null);
                }
                catch (Exception exception)
                {
                    pending.Completion.TrySetException(exception);
                    throw;
                }
                finally
                {
                    if (pending.Info.BlocksSourceUpdates) blockingWork--;
                }
            }
        }
    }
}
