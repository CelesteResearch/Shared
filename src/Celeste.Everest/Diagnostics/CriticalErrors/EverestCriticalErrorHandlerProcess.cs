using System;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Scene.Scheduling;
using Celeste.Game.Save.Runtime;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Execution.Engine.Update;

namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public sealed partial class EverestCriticalErrorHandlerProcess
    {
        internal readonly ISourceEngineContext EngineContext;
        internal readonly EverestLoggerProcess Logger;
        internal readonly SceneEntityCatalog Catalog;
        internal readonly SceneUpdatePolicy ScenePolicy;
        internal readonly IOriginalGameSaveContext Saves;
        public EverestCriticalErrorHandler CurrentHandler { get; private set; }

        public EverestCriticalErrorHandlerProcess(ISourceEngineContext engine, EverestLoggerProcess logger,
            SceneEntityCatalog catalog, SceneUpdatePolicy policy, IOriginalGameSaveContext saves)
        {
            EngineContext = engine ?? throw new ArgumentNullException(nameof(engine));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
            ScenePolicy = policy ?? throw new ArgumentNullException(nameof(policy));
            Saves = saves ?? throw new ArgumentNullException(nameof(saves));
        }

        internal void ResetErrorHandler()
        {
            Logger.Log(EverestLogLevel.Info, "crit-error-handler", "Resetting critical error handler");
            CurrentHandler?.Dispose();
            CurrentHandler?.InvokeOnClose();
            CurrentHandler = null;
        }

        private void DoImmediateSceneSwitch(ISourceSceneExecution newScene)
        {
            EngineContext.Effects.TimeRate = 1f;
            EngineContext.Effects.DashAssistFreeze = false;
            ((IOriginalEngineUpdateEnvironment)EngineContext).EngineUpdate.OverloadGameLoop = null;
            EngineContext.Frame.Scenes.NextScene = newScene;
            try
            {
                EngineContext.Frame.Scenes.CurrentScene?.End();
            }
            catch (Exception exception)
            {
                Logger.Log(EverestLogLevel.Error, "crit-error-handler",
                    "Error executing scene End function on immediate scene switch:");
                Logger.LogDetailed(exception, "crit-error-handler");
            }

            EngineContext.Frame.Scenes.SetCurrentSceneImmediately(newScene);
            try
            {
                EngineContext.Frame.Scenes.CurrentScene?.Begin();
            }
            catch (Exception exception)
            {
                Logger.Log(EverestLogLevel.Error, "crit-error-handler",
                    "Error executing scene Begin function on immediate scene switch:");
                Logger.LogDetailed(exception, "crit-error-handler");
            }
        }

        internal void AmendLogFile(string logFile, string description, Exception error)
            => EverestCriticalLogFiles.AmendLogFile(Logger, logFile, description, error);
    }
}
