using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Core.Framework.Loading;

namespace Celeste.Game.Execution.Threading
{
    public sealed class OriginalGameThreadSession
    {
        private readonly List<Thread> threads = new();
        private readonly List<DateTime> threadTimes = new();
        private readonly List<string> threadInfos = new();
        private readonly IOriginalThreadFailureOutput failureOutput;
        private readonly IOriginalThreadAbortDiagnostics diagnostics;
        private readonly OriginalGameThreadProfile profile;
        private readonly ISourceLoadingWorkScheduler scheduler;
        private readonly List<Task> scheduledWork;

        public OriginalGameThreadProfile Profile => profile;
        public bool SupportsContentPreparation => scheduler is ISourceContextualLoadingWorkScheduler;
        public bool OwnsHostThreadScheduling { get; set; } = true;
        public WeakReference<Thread> Current;

        public OriginalGameThreadSession(IOriginalThreadFailureOutput failureOutput)
            : this(failureOutput, OriginalGameThreadProfile.Original, null)
        {
        }

        public OriginalGameThreadSession(IOriginalThreadFailureOutput failureOutput,
            ISourceLoadingWorkScheduler scheduler)
            : this(failureOutput, OriginalGameThreadProfile.Original, null, scheduler)
        {
        }

        public OriginalGameThreadSession(IOriginalThreadFailureOutput failureOutput,
            OriginalGameThreadProfile profile, IOriginalThreadAbortDiagnostics diagnostics)
            : this(failureOutput, profile, diagnostics, null)
        {
        }

        public OriginalGameThreadSession(IOriginalThreadFailureOutput failureOutput,
            OriginalGameThreadProfile profile, IOriginalThreadAbortDiagnostics diagnostics,
            ISourceLoadingWorkScheduler scheduler)
        {
            this.failureOutput = failureOutput ?? throw new ArgumentNullException(nameof(failureOutput));
            if (profile != OriginalGameThreadProfile.Original && profile != OriginalGameThreadProfile.Installed)
                throw new ArgumentOutOfRangeException(nameof(profile));
            if (profile == OriginalGameThreadProfile.Installed && diagnostics == null)
                throw new ArgumentNullException(nameof(diagnostics));
            this.profile = profile;
            this.diagnostics = diagnostics;
            this.scheduler = scheduler;
            if (scheduler != null) scheduledWork = new List<Task>();
        }

        public void SetHostThreadPriority(Thread thread, ThreadPriority priority)
        {
            if (scheduler == null && OwnsHostThreadScheduling) thread.Priority = priority;
        }

        public void Start(Action sourceMethod, string name, bool highPriority = false)
        {
            if (scheduler != null)
            {
                RemoveCompletedScheduledWork();
                scheduledWork.Add(scheduler.Schedule(() => RunScheduledWorkWithLogging(sourceMethod),
                    ReportScheduledFailure, name, highPriority));
                return;
            }

            var thread = new Thread(() => RunThreadWithLogging(sourceMethod));
            if (profile == OriginalGameThreadProfile.Original)
            {
                lock (threads)
                    threads.Add(thread);
                thread.Name = name;
                thread.IsBackground = true;
                if (highPriority)
                    thread.Priority = ThreadPriority.Highest;
            }
            else
            {
                thread.Name = name;
                thread.IsBackground = true;
                thread.Priority = highPriority ? ThreadPriority.Highest : ThreadPriority.Normal;
                lock (threads)
                {
                    threads.Add(thread);
                    threadTimes.Add(DateTime.UtcNow);
                    threadInfos.Add(string.Format("Name: {0}\nAction: {1}\nStarter:\n{2}",
                        name, sourceMethod?.Method?.ToString() ?? sourceMethod.ToString(), new StackTrace(1)));
                }

                Current = new WeakReference<Thread>(thread);
            }

            thread.Start();
        }

        public Task Start(Action sourceMethod, SourceLoadingWorkInfo info, bool highPriority = false)
        {
            if (sourceMethod == null) throw new ArgumentNullException(nameof(sourceMethod));
            if (info == null) throw new ArgumentNullException(nameof(info));
            if (scheduler is not ISourceContextualLoadingWorkScheduler contextual)
                throw new InvalidOperationException("Contextual content loading requires an owner loading scheduler.");
            RemoveCompletedScheduledWork();
            Task task = contextual.Schedule(() => RunScheduledWorkWithLogging(sourceMethod), ReportScheduledFailure,
                info, highPriority);
            scheduledWork.Add(task);
            return task;
        }

        private void RunScheduledWorkWithLogging(Action sourceMethod)
        {
            try
            {
                sourceMethod();
            }
            catch (Exception exception)
            {
                ReportScheduledFailure(exception);
            }
        }

        private void ReportScheduledFailure(Exception exception)
        {
            if (exception is ThreadAbortException && profile == OriginalGameThreadProfile.Installed)
            {
                diagnostics.WarnBackgroundThreadAborted();
                diagnostics.LogDetailed(exception, null);
                return;
            }

            if (profile == OriginalGameThreadProfile.Original)
                Console.WriteLine(exception.ToString());
            failureOutput.WriteErrorLog(exception);
            failureOutput.OpenErrorLog();
            failureOutput.ExitGame();
        }

        public bool HasPendingWork
        {
            get
            {
                if (scheduler == null)
                {
                    lock (threads) return threads.Count != 0;
                }

                foreach (var task in scheduledWork)
                    if (!task.IsCompleted || task.IsFaulted || task.IsCanceled)
                        return true;
                return false;
            }
        }

        private void RemoveCompletedScheduledWork()
        {
            for (int i = scheduledWork.Count - 1; i >= 0; i--)
            {
                var task = scheduledWork[i];
                if (!task.IsCompleted) continue;
                if (task.IsFaulted || task.IsCanceled) continue;
                _ = task.Exception;
                scheduledWork.RemoveAt(i);
            }
        }

        private void CompleteReadyScheduledWork()
        {
            scheduler.Pump();
            RemoveCompletedScheduledWork();
            if (scheduledWork.Count != 0)
                throw new InvalidOperationException(
                    "Pending asynchronous resources require WaitAllAsync while the host continues pumping loading work.");
        }

        public Task WaitAllAsync()
        {
            if (scheduler == null)
            {
                WaitAll();
                return Task.CompletedTask;
            }

            return WaitScheduledWorkAsync();
        }

        private async Task WaitScheduledWorkAsync()
        {
            System.Runtime.ExceptionServices.ExceptionDispatchInfo failure = null;
            while (scheduledWork.Count != 0)
            {
                var snapshot = scheduledWork.ToArray();
                try
                {
                    await Task.WhenAll(snapshot);
                }
                catch (Exception exception)
                {
                    failure ??= System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(exception);
                }

                foreach (var task in snapshot) scheduledWork.Remove(task);
            }

            failure?.Throw();
        }

        private void RunThreadWithLogging(Action sourceMethod)
        {
            try
            {
                sourceMethod();
            }
            catch (ThreadAbortException exception) when (profile == OriginalGameThreadProfile.Installed)
            {
                diagnostics.WarnBackgroundThreadAborted();
                diagnostics.LogDetailed(exception, null);
            }
            catch (Exception exception)
            {
                if (profile == OriginalGameThreadProfile.Original)
                    Console.WriteLine(exception.ToString());
                failureOutput.WriteErrorLog(exception);
                failureOutput.OpenErrorLog();
                failureOutput.ExitGame();
            }
            finally
            {
                lock (threads)
                {
                    if (profile == OriginalGameThreadProfile.Original)
                        threads.Remove(Thread.CurrentThread);
                    else
                    {
                        int index = threads.IndexOf(Thread.CurrentThread);
                        if (index != -1)
                        {
                            threads.RemoveAt(index);
                            threadTimes.RemoveAt(index);
                            threadInfos.RemoveAt(0);
                        }
                    }
                }
            }
        }

        public void WaitAll(Action pump)
        {
            if (pump == null) throw new ArgumentNullException(nameof(pump));
            if (scheduler != null)
            {
                pump();
                CompleteReadyScheduledWork();
                return;
            }

            while (true)
            {
                Thread thread;
                lock (threads)
                {
                    if (threads.Count == 0) break;
                    thread = threads[0];
                }

                pump();
                while (!thread.Join(10)) pump();
            }
        }

        public void WaitAll()
        {
            if (scheduler != null)
            {
                CompleteReadyScheduledWork();
                return;
            }

            while (true)
            {
                Thread thread;
                lock (threads)
                {
                    if (threads.Count == 0)
                        break;
                    thread = threads[0];
                }

                thread.Join();
            }
        }
    }
}
