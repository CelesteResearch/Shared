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
                Completion = new(info.Name);
            }
        }

        private readonly Func<string, ValueTask> _prepareResources;
        private readonly Func<SourceLoadingWorkInfo, ValueTask> _prepareContext;
        private readonly Queue<PendingWork> _highPriority = new();
        private readonly Queue<PendingWork> _normalPriority = new();
        private bool _pumping;
        private int _blockingWork;

        public bool SourceUpdatesBlocked => _blockingWork != 0;

        public CooperativeSourceLoadingWorkScheduler(Func<string, ValueTask> prepareResources)
        {
            _prepareResources = prepareResources ?? throw new ArgumentNullException(nameof(prepareResources));
        }

        private CooperativeSourceLoadingWorkScheduler(Func<SourceLoadingWorkInfo, ValueTask> prepareContext)
        {
            _prepareContext = prepareContext ?? throw new ArgumentNullException(nameof(prepareContext));
        }

        public static CooperativeSourceLoadingWorkScheduler CreateWithContextPreparation(
            Func<SourceLoadingWorkInfo, ValueTask> prepareContext)
        {
            return new(prepareContext);
        }

        public Task Schedule(Action work, Action<Exception> preparationFailed, string name, bool highPriority)
        {
            return Schedule(work, preparationFailed, new SourceLoadingWorkInfo(name), highPriority);
        }

        public Task Schedule(Action work, Action<Exception> preparationFailed, SourceLoadingWorkInfo info,
            bool highPriority)
        {
            if (work == null) throw new ArgumentNullException(nameof(work));
            if (preparationFailed == null) throw new ArgumentNullException(nameof(preparationFailed));
            if (info == null) throw new ArgumentNullException(nameof(info));
            if (info.ContentContext != null && _prepareContext == null)
                throw new InvalidOperationException("This loading scheduler has no content context preparation.");
            var pending = new PendingWork(work, preparationFailed, info);
            if (info.BlocksSourceUpdates) _blockingWork++;
            (highPriority ? _highPriority : _normalPriority).Enqueue(pending);
            return pending.Completion.Task;
        }

        public void Pump()
        {
            if (_pumping) return;
            _pumping = true;
            try
            {
                var highCount = _highPriority.Count;
                var normalCount = _normalPriority.Count;
                Pump(_highPriority, highCount);
                Pump(_normalPriority, normalCount);
            }
            finally
            {
                _pumping = false;
            }
        }

        // Synchronous hosts may drain local loading work before releasing their graphics device.
        public void DrainReadyWork()
        {
            if (_pumping) throw new InvalidOperationException("Loading work cannot drain itself while pumping.");
            while (_highPriority.Count != 0 || _normalPriority.Count != 0)
            {
                Pump();
                RequireReady(_highPriority);
                RequireReady(_normalPriority);
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
            for (var i = 0; i < count; i++)
            {
                var pending = queue.Dequeue();
                try
                {
                    if (!pending.Preparing)
                    {
                        pending.Preparing = true;
                        pending.Readiness = _prepareContext != null
                            ? _prepareContext(pending.Info)
                            : _prepareResources(pending.Info.Name);
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
                    if (pending.Info.BlocksSourceUpdates) _blockingWork--;
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
                    if (pending.Info.BlocksSourceUpdates) _blockingWork--;
                }
            }
        }
    }
}
