using System;
using System.Threading.Tasks;
using Celeste.Core.Scheduling;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Runtime.Threading;
using Celeste.Everest.Diagnostics.CriticalErrors;
using Celeste.Game.Execution.Engine.Update;
using Celeste.Game.Execution.ProcessState;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Content.Textures;
using Celeste.Game.Execution.Engine.Rendering;
using Celeste.Scene.Scheduling;

namespace Celeste.Everest.Content.Reloading
{
    public sealed partial class EverestAssetReloadProcess
    {
        // Original helper restricts this query to the main thread; no extra lock or cached flag.
        public bool IsReloading => EngineContext.Frame.Scenes.CurrentScene is EverestAssetReloadScene;

        public ISourceSceneExecution ReturnToScene { get; set; }
        public Action ReturnToGameLoop;
        internal readonly ISourceEngineContext EngineContext;
        internal readonly EverestMainThreadProcess MainThread;
        internal readonly OriginalGameProcessTiming Timing;
        internal readonly EverestLoggerProcess Logger;
        public readonly EverestAssetReloadEvents Events;
        internal readonly EverestCriticalErrorHandlerProcess CriticalErrors;
        internal readonly SceneEntityCatalog Catalog;
        internal readonly SceneUpdatePolicy ScenePolicy;
        internal readonly EverestAssetReloadSynchronization Synchronization;
        internal OriginalEngineFrame EngineUpdate => ((IOriginalEngineUpdateEnvironment)EngineContext).EngineUpdate;

        public EverestAssetReloadProcess(ISourceEngineContext engine, EverestMainThreadProcess mainThread,
            OriginalGameProcessTiming timing, EverestLoggerProcess logger, EverestAssetReloadEvents events,
            EverestCriticalErrorHandlerProcess criticalErrors, SceneEntityCatalog catalog, SceneUpdatePolicy policy,
            EverestAssetReloadSynchronization synchronization)
        {
            Synchronization = synchronization ?? throw new ArgumentNullException(nameof(synchronization));
            EngineContext = engine ?? throw new ArgumentNullException(nameof(engine));
            MainThread = mainThread ?? throw new ArgumentNullException(nameof(mainThread));
            Timing = timing ?? throw new ArgumentNullException(nameof(timing));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Events = events ?? throw new ArgumentNullException(nameof(events));
            CriticalErrors = criticalErrors ?? throw new ArgumentNullException(nameof(criticalErrors));
            Catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
            ScenePolicy = policy ?? throw new ArgumentNullException(nameof(policy));
        }

        private void DoImmediateSceneSwitch(ISourceSceneExecution scene)
        {
            EngineContext.Frame.Scenes.SetCurrentSceneImmediately(scene);
            EngineContext.Frame.Scenes.NextScene = scene;
        }

        private async Task<EverestAssetReloadScene> StartReloadScene()
        {
            await ReloadSemaphore.WaitAsync();
            try
            {
                ReturnToScene = EngineContext.Frame.Scenes.CurrentScene;
                ReturnToGameLoop = EngineUpdate.OverloadGameLoop;
                var helper = new EverestAssetReloadScene(this, ReturnToScene);
                DoImmediateSceneSwitch(helper);
                EngineUpdate.OverloadGameLoop = helper.Update;
                Events.BeforeReload(false);
                Logger.Log(EverestLogLevel.Verbose, "reload",
                    "Started non-silent reload; switched to reload helper scene");
                return helper;
            }
            catch
            {
                ReloadSemaphore.Release();
                throw;
            }
        }

        internal void EndReloadScene(EverestAssetReloadScene helper)
        {
            try
            {
                EngineUpdate.OverloadGameLoop = ReturnToGameLoop;
                DoImmediateSceneSwitch(helper.OrigScene);
                if (helper.OrigScene != ReturnToScene)
                {
                    EngineContext.Frame.Scenes.NextScene = ReturnToScene;
                    helper.OrigScene?.End();
                    DoImmediateSceneSwitch(ReturnToScene);
                    ReturnToScene?.Begin();
                }

                ReturnToScene = null;
                ReturnToGameLoop = null;
                Events.AfterReload(false);
                if (Logger.GetLogLevel("reload") <= EverestLogLevel.Verbose)
                    Logger.Log(EverestLogLevel.Verbose, "reload",
                        "Finished non-silent reload; switched back to scene " +
                        EngineContext.Frame.Scenes.CurrentScene);
            }
            finally
            {
                helper.Dispose();
                ReloadSemaphore.Release();
            }
        }

        internal void ReleaseReloadSemaphore() => ReloadSemaphore.Release();
    }
}
