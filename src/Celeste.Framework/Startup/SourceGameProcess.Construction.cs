using System;
using Celeste.Core.Framework.Components;
using Celeste.Core.Framework.Services;
using Celeste.Core.Framework.Startup;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Audio;
using Celeste.Graphics.Content.Compiled;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Input.Bindings;
using Celeste.Input.Runtime;

namespace Celeste.Framework.Startup
{
    public partial class SourceGameProcess : ISourceGraphicsManagerGame
    {
        // Original Game instance field allocation precedes its constructor body.
        internal readonly TimeSpan[] previousSleepTimes = new TimeSpan[128];
        internal bool[] textInputControlDown;
        internal bool textInputSuppress;
        internal bool hasInitialized;
        internal bool isDisposed;
        internal SourceGameTime gameTime;
        public SourceLaunchParameters LaunchParameters { get; private set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public SourceGameComponentCollection Components { get; private set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public SourceGameServiceContainer Services { get; private set; }
        private SourceContentManager sourceContentManager;

        public SourceContentManager Content
        {
            get => sourceContentManager;
            set
            {
                if (value == null) throw new ArgumentNullException();
                sourceContentManager = value;
            }
        }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public SourceGameWindow Window { get; private set; }
        ISourceGraphicsManagerWindow ISourceGraphicsManagerGame.Window => Window;
        public SourceGameFrameworkState Framework;
        public readonly SourceEngineTimingState Timing = SourceEngineTimingState.CreateUninitialized();
        public readonly SourceGameLoopState GameLoop = new();
        private bool isMouseVisible;

        public bool IsMouseVisible
        {
            get => isMouseVisible;
            set
            {
                if (isMouseVisible != value)
                {
                    isMouseVisible = value;
                    runPlatform.OnIsMouseVisibleChanged(value);
                }
            }
        }

        private readonly ISourceRuntimeErrorDevice runtimeErrors;
        private readonly SourceContentProcessState contentProcess;
        private readonly ISourceGameWindowPlatform windows;
        private readonly SourceFrameworkDispatcherProcess dispatcher;

        protected SourceGameProcess(ISourceCommandLineDevice commandLine,
            SourceContentProcessState contentProcess, ISourceGameWindowPlatform windows,
            SourceFnaInputProcess input, SourceFnaTextInputBindings textBindings,
            SourceFrameworkDispatcherProcess dispatcher, ISourceRuntimeErrorDevice runtimeErrors,
            ISourceGameTickDevice tickDevice, ISourceGameTimerStartDevice timer, ISourceGameRunPlatform runPlatform,
            ISourceGameBeforeLoopPolicy beforeLoopPolicy)
        {
            this.runtimeErrors = runtimeErrors;
            this.contentProcess = contentProcess;
            this.windows = windows;
            this.dispatcher = dispatcher;
            fnaInput = input;
            this.timer = timer;
            this.runPlatform = runPlatform;
            this.beforeLoopPolicy = beforeLoopPolicy;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            LaunchParameters = new(commandLine);
            Components = [];
            Services = new();
            Content = new(Services, contentProcess);
            Framework = new(Components);
            IsMouseVisible = false;
            Timing.IsFixedTimeStep = true;
            Timing.TargetElapsedTime = TimeSpan.FromTicks(166667);
            Timing.InactiveSleepTime = TimeSpan.FromSeconds(0.02);
            for (var i = 0; i < previousSleepTimes.Length; i++)
                previousSleepTimes[i] = TimeSpan.FromMilliseconds(1.0);
            textInputControlDown = new bool[textBindings.TextInputCharacters.Length];
            hasInitialized = false;
            GameLoop.SuppressDrawing = false;
            isDisposed = false;
            gameTime = new();
            TickKernel = new(Timing, gameTime, tickDevice, this, GameLoop, previousSleepTimes);
            Window = windows.CreateWindow();
            input.MouseWindowHandle = Window.Handle;
            input.TouchWindowHandle = Window.Handle;
            dispatcher.Update();
            GameLoop.CompleteConstruction();
        }

        protected virtual bool ShowMissingRequirementMessage(Exception exception)
        {
            if (exception is NoAudioHardwareException)
            {
                runtimeErrors.ShowRuntimeError(Window.Title,
                    "Could not find a suitable audio device.  Verify that a sound card is\ninstalled, and check the driver properties to make sure it is not disabled.");
                return true;
            }

            if (exception is NoSuitableGraphicsDeviceException)
            {
                runtimeErrors.ShowRuntimeError(Window.Title,
                    "Could not find a suitable graphics device. More information:\n\n" + exception.Message);
                return true;
            }

            return false;
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            ShowMissingRequirementMessage(args.ExceptionObject as Exception);
        }
    }
}
