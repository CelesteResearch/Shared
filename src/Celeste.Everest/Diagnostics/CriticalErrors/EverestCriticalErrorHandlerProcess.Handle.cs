#define TRACE
using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Hud;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public sealed partial class EverestCriticalErrorHandlerProcess
    {
        private sealed class RecoveryScene : SourceSceneState
        {
            public RecoveryScene(EverestCriticalErrorHandlerProcess process)
                : base(process.EngineContext, process.Catalog, process.ScenePolicy)
            {
            }
        }

        public event Action<EverestCriticalErrorHandler> CriticalError;

        public ExceptionDispatchInfo HandleCriticalError(ExceptionDispatchInfo error)
        {
            if (global::Celeste.Core.Scheduling.SourceRuntimeExtensions
                    .Get<IEverestCriticalErrorSourceHooksEnvironment>(EngineContext) is { } hooks)
                return hooks.HandleSourceCriticalError(error, HandleCriticalErrorOriginal);
            return HandleCriticalErrorOriginal(error);
        }

        private ExceptionDispatchInfo HandleCriticalErrorOriginal(ExceptionDispatchInfo error)
        {
            if (!((global::Celeste.Everest.Modules.Settings.IEverestCurrentCoreSettingsEnvironment)EngineContext)
                .CurrentCoreSettings.UseInGameCrashHandler) return error;
            if (Debugger.IsAttached)
            {
                Trace.WriteLine(">>> CRITICAL ERROR: " + error.SourceException);
                Debugger.Break();
            }

            Logger.Log(EverestLogLevel.Error, "crit-error-handler",
                ">>>>>>>>>>>>>>> ENCOUNTERED A CRITICAL ERROR <<<<<<<<<<<<<<<");
            Logger.LogDetailed(error.SourceException, "crit-error-handler");
            if (CurrentHandler == null)
            {
                string logFile = BackupLogFile(error.SourceException, out string logFileError);
                CurrentHandler = new EverestCriticalErrorHandler(this, error, logFile, logFileError);
            }
            else
            {
                CurrentHandler.EncounteredAdditionalErrors = true;
                AmendLogFile(CurrentHandler.LogFile, "Encountered an additional critical error", error.SourceException);
            }

            CriticalError?.Invoke(CurrentHandler);
            if (CurrentHandler.State < EverestCriticalErrorHandler.DisplayState.Overlay &&
                EngineContext.Frame.Scenes.CurrentScene is OriginalLevelSceneRoot level)
            {
                CurrentHandler.State = EverestCriticalErrorHandler.DisplayState.Overlay;
                level.Scheduler.QueueSourceEntity(CurrentHandler);
                if (level.Wipe != null)
                {
                    level.Renderers.Remove(level.Wipe);
                    level.Wipe = null;
                }

                var renderers = level.Renderers.Renderers.ToArray();
                foreach (var renderer in renderers)
                    if (renderer is ScreenWipePresentation)
                        level.Renderers.Remove(renderer);
                return null;
            }

            if (CurrentHandler.State < EverestCriticalErrorHandler.DisplayState.CleanScene)
            {
                var previous = CurrentHandler.Scene;
                CurrentHandler.RemoveSelf();
                if (previous != null) ((ISourceScene)previous).SourceScene.CommitQueuedEntityLists();
                var scene = new RecoveryScene(this);
                scene.Renderers.Add(new HudRendererState());
                scene.Renderers.Add(new HiresSnowState(EngineContext));
                scene.SourceScene.QueueSourceEntity(CurrentHandler);
                CurrentHandler.State = EverestCriticalErrorHandler.DisplayState.CleanScene;
                scene.SourceScene.CommitQueuedEntityLists();
                DoImmediateSceneSwitch(scene);
                return null;
            }

            if (CurrentHandler.State < EverestCriticalErrorHandler.DisplayState.BlueScreen)
            {
                var previous = CurrentHandler.Scene;
                CurrentHandler.RemoveSelf();
                if (previous != null) ((ISourceScene)previous).SourceScene.CommitQueuedEntityLists();
                var scene = new RecoveryScene(this);
                scene.Renderers.Add(new HudRendererState());
                scene.SourceScene.QueueSourceEntity(CurrentHandler);
                CurrentHandler.State = EverestCriticalErrorHandler.DisplayState.BlueScreen;
                scene.SourceScene.CommitQueuedEntityLists();
                DoImmediateSceneSwitch(scene);
                return null;
            }

            return CurrentHandler.Error;
        }
    }
}
