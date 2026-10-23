using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Celeste.Everest.Runtime.Threading
{
    internal sealed class EverestMainThreadTaskScheduler : TaskScheduler
    {
        private readonly EverestMainThreadProcess owner;

        internal EverestMainThreadTaskScheduler(EverestMainThreadProcess owner)
        {
            this.owner = owner;
        }

        public bool TaskIsForceQueued;

        private readonly ConcurrentQueue<Task> _TasksQueue = new();

        private readonly Stopwatch _Stopwatch = new();

        public override int MaximumConcurrencyLevel => 1;

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return _TasksQueue;
        }

        protected override void QueueTask(Task task)
        {
            _TasksQueue.Enqueue(task);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            if (!owner.IsMainThread) return false;

            if (TaskIsForceQueued) return false;

            return TryExecuteTask(task);
        }

        public void ExecuteTasksFor(int timeSlice)
        {
            if (_TasksQueue.Count > 0)
            {
                _Stopwatch.Restart();
                Task result;
                while (_Stopwatch.ElapsedMilliseconds < timeSlice && _TasksQueue.TryDequeue(out result))
                    TryExecuteTask(result);
            }
        }
    }
}
