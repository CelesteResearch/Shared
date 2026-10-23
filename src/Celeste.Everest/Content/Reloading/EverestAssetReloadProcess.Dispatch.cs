using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Celeste.Everest.Content.Reloading
{
    public sealed partial class EverestAssetReloadProcess
    {
        public readonly HashSet<string> SilentThreadList =
        [
            "Main Thread", "GAME_LOADER", "OVERWORLD_LOADER", "SUMMIT_VIGNETTE", "LEVEL_LOADER",
            "COMPLETE_LEVEL", "Wave Dash Presentation Loading",
        ];

        private readonly SemaphoreSlim ReloadSemaphore = new(1, 1);
        internal readonly object CurrentHelperSceneLock = new();
        internal volatile Task<EverestAssetReloadScene> CurrentHelperScene;

        public void Do(string text, Action reload = null, Action done = null)
        {
            Do(false, text, reload, done);
        }

        public void Do(bool silent, string text, Action reload = null, Action done = null)
        {
            Do(text, flag =>
            {
                reload?.Invoke();
                if (flag)
                {
                    done?.Invoke();
                    return Task.CompletedTask;
                }

                return done != null ? MainThread.Schedule(done).AsTask() : Task.CompletedTask;
            }, silent, reload != null);
        }

        public Task Do(string text, Func<bool, Task> action, bool silent = false, bool useWorkerThread = true)
        {
            if (CriticalErrors.CurrentHandler != null)
            {
                Logger.ReloadDelayedByCriticalError(text);
                return DelayReloadUntilAfterCrash(silent, text, action, useWorkerThread);
            }

            if (Timing.LoadTimer != null)
            {
                silent = true;
            }
            else if (silent)
            {
                var threadName = Thread.CurrentThread.Name ?? "<null>";
                // Hosts may leave the actual game owner thread unnamed. Cooperative loading
                // still executes on that owner; its identity is stronger than its display name.
                if (!MainThread.IsMainThread && !SilentThreadList.Contains(threadName))
                {
                    Logger.ReloadInvalidSilentThread(threadName, text);
                    silent = false;
                }
            }

            if (silent)
                return ((Func<Task>)(async () =>
                {
                    await ReloadSemaphore.WaitAsync();
                    try
                    {
                        Logger.SilentReloadStarting(text);
                        Events.BeforeReload(true);
                        await action(true);
                        Events.AfterReload(true);
                        Logger.SilentReloadFinished(text);
                    }
                    finally
                    {
                        ReloadSemaphore.Release();
                    }
                }))();

            if (EngineContext.Frame.Scenes.CurrentScene == null)
                return MainThread.Schedule(async () =>
                {
                    while (EngineContext.Frame.Scenes.CurrentScene == null)
                        await MainThread.YieldFrame;
                    return Do(text, action, false, useWorkerThread);
                }).Unwrap();

            lock (CurrentHelperSceneLock)
            {
                if (CurrentHelperScene == null)
                    CurrentHelperScene =
                        MainThread.Schedule((Func<Task<EverestAssetReloadScene>>)StartReloadScene);
                return CurrentHelperScene.ContinueWith(t =>
                {
                    var helper = t.Result;
                    Func<Task> taskFunction;
                    if (useWorkerThread)
                        taskFunction = () => helper.workerTaskFactory.StartNew(() => action(false)).Unwrap();
                    else taskFunction = () => action(false);
                    TaskCompletionSource<Task> completion = new();
                    var cancellation =
                        helper.CancellationToken.Register(completion.SetCanceled);
                    helper.taskQueue.Enqueue((text, () =>
                    {
                        var result = taskFunction();
                        cancellation.Dispose();
                        completion.SetResult(result);
                        return result;
                    }));
                    Logger.NonSilentReloadQueued(text);
                    return completion.Task.Unwrap();
                }).Unwrap();
            }
        }

        private Task DelayReloadUntilAfterCrash(bool silent, string text, Func<bool, Task> action, bool useWorkerThread)
        {
            if (silent && !MainThread.IsMainThread)
            {
                ManualResetEventSlim signal = new(false);
                try
                {
                    MainThread.Schedule(() =>
                    {
                        if (CriticalErrors.CurrentHandler == null) signal.Set();
                        else CriticalErrors.CurrentHandler.OnClose += signal.Set;
                    });
                    signal.Wait();
                    return Do(text, action, true, useWorkerThread);
                }
                finally
                {
                    signal.Dispose();
                }
            }

            if (silent && MainThread.IsMainThread)
                Logger.Log(EverestLogLevel.Warn, "reload",
                    " - can't immediately execute the action silently because we are on the main thread; this might break caller logic!");
            TaskCompletionSource<Task> completion = new();
            MainThread.Schedule(() =>
            {
                if (CriticalErrors.CurrentHandler == null)
                    completion.SetResult(Do(text, action, silent, useWorkerThread));
                else
                    CriticalErrors.CurrentHandler.OnClose += () =>
                        completion.SetResult(Do(text, action, silent, useWorkerThread));
            });
            return completion.Task.Unwrap();
        }
    }
}
