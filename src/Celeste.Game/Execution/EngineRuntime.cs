using Celeste.Input.Runtime;
using Celeste.Input.Bindings;
using Celeste.Core.Display;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Core.Framework.Timing;
using System;
using System.IO;
using System.Runtime;
using Celeste.Core.Framework.Startup;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.Compiled;
using Celeste.Graphics.Display;
using Celeste.Framework.Startup;
using Celeste.Graphics.Rendering.Devices;
using global::Celeste.Game.Execution.Engine;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution
{
    public partial class EngineRuntime : SourceGameProcess, ISourceMInputEngine
    {
        public string Title;
        public Version Version;

        public global::Celeste.Game.Execution.Engine.Screen.OriginalEngineScreenState SourceScreen { get; private set; }

        public static EngineRuntime Instance { get; private set; }
        public static SourceGraphicsDeviceManager Graphics { get; private set; }
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        public static PackedColor ClearColor;
        public static bool ExitOnEscapeKeypress;
        private static string AssemblyDirectory;

        public static string ContentDirectory => Path.Combine(AssemblyDirectory, Instance.Content.RootDirectory);

        // Borrowed process capabilities; no parallel Engine/Commands current slot.
        public ISourceEngineContext Process { get; private set; }
        System.Numerics.Matrix4x4 ISourceMInputEngine.ScreenMatrix => ScreenMatrix;
        bool ISourceMInputEngine.IsCommandConsoleOpen => Commands.Open;
        float ISourceMInputEngine.DeltaTime => Process.Frame.DeltaTime;

        global::Celeste.Core.Mathematics.ISourceVectorArithmetic ISourceMInputEngine.VectorArithmetic =>
            ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)Process).VectorArithmetic;

        public global::Celeste.Framework.Diagnostics.Commands.SourceCommands Commands =>
            ((global::Celeste.Framework.Diagnostics.Commands.ISourceCommandsProcessEnvironment)Process).Commands;

        public EngineRuntime(int width, int height, int windowWidth, int windowHeight,
            string windowTitle, bool fullscreen, bool vsync, ISourceEngineContext process,
            ISourceCommandLineDevice commandLine, SourceContentProcessState contentProcess,
            ISourceGameWindowPlatform windows, SourceFnaInputProcess input,
            SourceFnaTextInputBindings textBindings, SourceFrameworkDispatcherProcess dispatcher,
            ISourceRuntimeErrorDevice runtimeErrors,
            SourceGraphicsAdapterProcess adapters, ISourceGraphicsDeviceIO graphicsIO,
            ISourceGraphicsDeviceInputMetrics deviceInput,
            ISourceGameTickDevice tickDevice, ISourceGameTimerStartDevice timer, ISourceGameRunPlatform runPlatform,
            ISourceGameBeforeLoopPolicy beforeLoopPolicy)
            : base(commandLine, contentProcess, windows, input, textBindings, dispatcher, runtimeErrors, tickDevice,
                timer,
                runPlatform, beforeLoopPolicy)
        {
            AssemblyDirectory = ((global::Celeste.Core.IO.ISourceGameRuntimePathsEnvironment)process)
                .GameAssemblyDirectory;
            Instance = this;
            Process = process;
            Title = (Window.Title = windowTitle);
            Width = width;
            Height = height;
            ClearColor = new PackedColor(0, 0, 0, 255);
            Timing.InactiveSleepTime = new TimeSpan(0);
            Graphics = new SourceGraphicsDeviceManager(this, adapters, graphicsIO, deviceInput, windows);
            SourceScreen = new global::Celeste.Game.Execution.Engine.Screen.OriginalEngineScreenState(Graphics);
            Graphics.DeviceReset += OnGraphicsReset;
            Graphics.DeviceCreated += OnGraphicsCreate;
            Graphics.SynchronizeWithVerticalRetrace = vsync;
            Graphics.PreferMultiSampling = false;
            Graphics.GraphicsProfile = SourceGraphicsProfile.HiDef;
            Graphics.PreferredBackBufferFormat = SourceSurfaceFormat.Color;
            Graphics.PreferredDepthStencilFormat = SourceDepthFormat.Depth24Stencil8;
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += OnClientSizeChanged;
            if (fullscreen)
            {
                Graphics.PreferredBackBufferWidth = adapters.DefaultAdapter.CurrentDisplayMode.Width;
                Graphics.PreferredBackBufferHeight = adapters.DefaultAdapter.CurrentDisplayMode.Height;
                Graphics.IsFullScreen = true;
            }
            else
            {
                Graphics.PreferredBackBufferWidth = windowWidth;
                Graphics.PreferredBackBufferHeight = windowHeight;
                Graphics.IsFullScreen = false;
            }

            Content.RootDirectory =
                ((global::Celeste.Core.IO.ISourceContentDirectoryEnvironment)process).ContentDirectory;
            IsMouseVisible = false;
            ExitOnEscapeKeypress = true;
            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
        }
    }
}
