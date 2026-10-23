using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Rendering;
using Celeste.Simulation.Presentation.Hud.Overlays;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;

namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public sealed partial class EverestCriticalErrorHandler : OverlayPresentation, IDisposable
    {
        private sealed class BeforeRenderInterceptor : SceneRenderer
        {
            public Action OnBeforeRender;
            public BeforeRenderInterceptor(Action onBeforeRender) => OnBeforeRender = onBeforeRender;
            public override void BeforeRender(object scene) => OnBeforeRender();
        }

        public enum DisplayState
        {
            Initial,
            Overlay,
            CleanScene,
            BlueScreen
        }

        private enum UserChoice
        {
            FlushSaveData,
            RetryLevel,
            SaveAndQuit,
            ReturnToMainMenu
        }

        public readonly ExceptionDispatchInfo Error;
        private readonly string errorType;
        private readonly string errorMessage;
        private readonly string errorStackTrace;
        public readonly string LogFile;
        public readonly string LogFileError;
        public readonly ChapterCompletionSession Session;
        private readonly BeforeRenderInterceptor beforeRenderInterceptor;
        private readonly EverestCriticalErrorHandlerProcess process;
        private TextMenuPresentation optMenu;
        private readonly HashSet<UserChoice> failedChoices = new();
        private bool hasFlushedSaveData;
        private DisplayState state;
        private bool disablePlayerSprite;
        private PlayerSprite playerSprite;
        private PlayerHair playerHair;
        private VirtualRenderTarget playerRenderTarget;
        private bool playerShouldTeabag;
        private bool isCrouched;
        private float crouchTimer;
        public bool EncounteredAdditionalErrors { get; internal set; }

        public DisplayState State
        {
            get => state;
            internal set
            {
                state = value;
                if (optMenu != null) ConfigureOptionsMenu();
            }
        }

        private bool UsePlayerSprite => !disablePlayerSprite && State != DisplayState.BlueScreen;
        public event Action OnClose;
        internal void InvokeOnClose() => OnClose?.Invoke();

        internal EverestCriticalErrorHandler(EverestCriticalErrorHandlerProcess process,
            ExceptionDispatchInfo error, string logFile, string logFileError) : base(process.EngineContext)
        {
            this.process = process;
            Depth += 100;
            Session = (EngineContext.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot)?.Session;
            Error = error;
            errorType = error.SourceException.GetType().FullName;
            errorMessage = error.SourceException.Message;
            errorStackTrace = error.SourceException is AggregateException aggregate
                ? aggregate.InnerException.StackTrace
                : error.SourceException.StackTrace;
            LogFile = logFile;
            LogFileError = string.IsNullOrEmpty(logFile) ? logFileError : null;
            if (((global::Celeste.Everest.Modules.Settings.IEverestCurrentCoreSettingsEnvironment)EngineContext)
                .CurrentCoreSettings.CrashHandlerAlwaysTeabag)
                playerShouldTeabag = true;
            else
            {
                var settings = ((global::Celeste.Game.Settings.ISettingsRuntimeContext)EngineContext)
                    .SettingsProcess.Instance;
                playerShouldTeabag = settings != null && !settings.DisableFlashes &&
                                     ((global::Celeste.Core.Randomness.ISourceRandomProcessEnvironment)EngineContext)
                                     .RandomProcess.Factory.CreateUnseeded().Next(0, 10) == 0;
            }

            beforeRenderInterceptor = new BeforeRenderInterceptor(BeforeRender);
            Add(new SimulationCoroutine(EngineContext, Routine()));
            if (process.Logger.GetLogLevel("crit-error-handler") <= global::Celeste.Everest.EverestLogLevel.Info)
                process.Logger.Log(global::Celeste.Everest.EverestLogLevel.Info,
                    "crit-error-handler",
                    "Created critical error handler for exception " + errorType + ": " + errorMessage);
        }

        public void Dispose()
        {
            playerRenderTarget?.Dispose();
            playerRenderTarget = null;
        }
    }
}
