using System;
using System.Collections.Concurrent;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Everest.Threading;

namespace Celeste.Everest.Content.Reloading
{
    public sealed partial class EverestAssetReloadScene
    {
        internal readonly ConcurrentQueue<(string Text, Func<Task> Task)> taskQueue = new();
        private Task curTask;
        private string curTaskText;
        private string curDisplayText;
        private readonly WorkerThreadTaskScheduler workerTaskScheduler;
        internal readonly TaskFactory workerTaskFactory;
        private bool outTransition;
        private float transitionTimer;
        private float cogwheelRot;

        public CancellationToken CancellationToken => workerTaskScheduler.CancellationToken;

        public override void Update()
        {
            base.Update();
            cogwheelRot += 4f * EngineContext.Frame.RawDeltaTime;
            transitionTimer += EngineContext.Frame.RawDeltaTime;
            if (transitionTimer > (outTransition ? .15f : .3f))
                transitionTimer = outTransition ? .15f : .3f;
            while (true)
            {
                var task = curTask;
                if (task is { IsCompleted: false }) break;
                var previous = curTask;
                if (previous is { IsFaulted: true })
                {
                    var exception = curTask?.Exception;
                    if (exception != null)
                    {
                        process.Logger.ReloadTaskError(curTaskText);
                        process.Logger.LogDetailed(exception, "reload");
                        process.CriticalErrors.HandleCriticalError(ExceptionDispatchInfo.Capture(exception))?.Throw();
                        return;
                    }
                }

                if (!taskQueue.TryDequeue(out var next))
                {
                    if (curTask != null) process.Logger.ReloadTaskFinished(curTaskText);
                    curTask = null;
                    break;
                }

                if (curTask != null) process.Logger.ReloadTaskMoving(curTaskText, next.Text);
                else process.Logger.ReloadTaskStarting(next.Text);
                curTask = next.Task();
                (curTaskText, _) = next;
            }

            if (curTaskText != null) curDisplayText = curTaskText;
            if (!outTransition && transitionTimer >= .3f && curTask == null && !workerTaskScheduler.HasWork)
            {
                outTransition = true;
                transitionTimer = 0;
            }
            else if (outTransition && (curTask != null || workerTaskScheduler.HasWork))
            {
                process.Logger.Log(EverestLogLevel.Info, "reload",
                    "A new reload task was enqueued during the out transition, restarting...");
                outTransition = false;
                transitionTimer = .3f * (1f - transitionTimer / .15f);
            }

            if (!outTransition || !(transitionTimer >= .15f)) return;
            lock (process.CurrentHelperSceneLock)
            {
                if (!taskQueue.IsEmpty || workerTaskScheduler.HasWork) return;
                process.CurrentHelperScene = null;
            }

            process.EndReloadScene(this);
        }
    }
}
