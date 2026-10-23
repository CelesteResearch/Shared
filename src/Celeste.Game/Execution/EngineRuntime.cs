using System;
using System.IO;
using System.Numerics;
using System.Runtime;
using Celeste.Core.Display;
using Celeste.Core.Framework.Startup;
using Celeste.Core.Framework.Timing;
using Celeste.Core.IO;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Framework.Startup;
using Celeste.Game.Execution.Engine.Screen;
using Celeste.Graphics.Content.Compiled;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Input.Bindings;
using Celeste.Input.Runtime;

namespace Celeste.Game.Execution
{
    public partial class EngineRuntime : SourceGameProcess, ISourceMInputEngine
    {
        public string Title;
        public Version Version;

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public OriginalEngineScreenState SourceScreen { get; private set; }

        public static EngineRuntime Instance { get; private set; }
        public static SourceGraphicsDeviceManager Graphics { get; private set; }
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        public static PackedColor ClearColor;
        public static bool ExitOnEscapeKeypress;
        private static string AssemblyDirectory;

        public static string ContentDirectory => Path.Combine(AssemblyDirectory, Instance.Content.RootDirectory);

        // Borrowed process capabilities; no parallel Engine/Commands current slot.
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public ISourceEngineContext Process { get; private set; }
        Matrix4x4 ISourceMInputEngine.ScreenMatrix => ScreenMatrix;
        bool ISourceMInputEngine.IsCommandConsoleOpen => Commands.Open;
        float ISourceMInputEngine.DeltaTime => Process.Frame.DeltaTime;

        ISourceVectorArithmetic ISourceMInputEngine.VectorArithmetic =>
            ((ISourceVectorEnvironment)Process).VectorArithmetic;

        public SourceCommands Commands =>
            ((ISourceCommandsProcessEnvironment)Process).Commands;

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
            AssemblyDirectory = ((ISourceGameRuntimePathsEnvironment)process)
                .GameAssemblyDirectory;
            Instance = this;
            Process = process;
            Title = Window.Title = windowTitle;
            Width = width;
            Height = height;
            ClearColor = new(0, 0, 0, 255);
            Timing.InactiveSleepTime = new(0);
            Graphics = new(this, adapters, graphicsIO, deviceInput, windows);
            SourceScreen = new(Graphics);
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
                ((ISourceContentDirectoryEnvironment)process).ContentDirectory;
            IsMouseVisible = false;
            ExitOnEscapeKeypress = true;
            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
        }
    }
}
