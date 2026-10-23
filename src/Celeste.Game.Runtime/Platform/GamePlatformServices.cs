using Celeste.Core.IO.Content;
using Celeste.Input.Devices.Text;
using Celeste.Input.Devices.Mouse;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using System;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Randomness;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Content.Compiled;
using Celeste.Graphics.Content.Images;
using Celeste.Audio.IO;
using Celeste.Everest.Modules.Persistence.GameSaves;

namespace Celeste.Game.Runtime.Platform
{
// Physical endpoints only. All game policies and process state are created in shared startup.
    public sealed partial class GamePlatformServices
    {
        private readonly string? physicalOwnerAssemblyPath;

        public string PhysicalOwnerAssemblyPath => physicalOwnerAssemblyPath ??
                                                   throw new PlatformNotSupportedException(
                                                       "The compiled source deployment has no physical managed owner DLL.");

        public CompiledSourceDeployment? CompiledSourceDeployment { get; }
        public global::Celeste.Core.Framework.Loading.ISourceLoadingWorkScheduler? LoadingWorkScheduler { get; }
        public Celeste.Game.Menus.Title.MainMenuAdditionalButton? MainMenuAdditionalButton { get; }
        public Celeste.Game.Menus.Options.IMenuOptionsExtension? MenuOptionsExtension { get; }
        public string ContentRoot { get; }
        public string? TemporaryDirectoryPath { get; }
        public System.IO.TextWriter ConsoleOutput { get; }
        public Celeste.Core.Framework.GarbageCollection.ISourceGarbageCollectionDevice GarbageCollection { get; }
        public Celeste.Everest.Runtime.Discord.IEverestDiscordSdkProcess? DiscordSdk { get; }

        public Celeste.Everest.Modules.Updating.Transport.IEverestCompressedHttpTransport? CompressedHttpTransport
        {
            get;
        }

        public ISourceHostWindowIO Window { get; }
        public ISourceGraphicsDeviceIOFactory GraphicsFactory { get; }
        public ISourceGraphicsAdapterDisplayIO Displays { get; }
        public IContentSource ContentFiles { get; }
        public ISourceImageCodecDevice ImageCodec { get; }
        public ISourceKeyboardDevice Keyboard { get; }
        public ISourceSDLMouseTouchDevice MouseTouch { get; }
        public ISourceSDLGamePadDevice GamePads { get; }
        public ISourceGameTickDevice Clock { get; }
        public ISourceGameTimerStartDevice TimerStart { get; }
        public ISourceRandomSeedDevice RandomSeeds { get; }
        public ISourceFAudioIOFactory FrameworkAudioFactory { get; }
        public ISourceMicrophoneIO Microphones { get; }
        public bool AudioOutputAvailable { get; }
        public global::Celeste.Audio.Fmod.IO.IFmodStudioDeviceIO StudioAudioDevice { get; }
        public IContentMemorySource? AudioBankContent { get; }
        public ISourceTheoraIO Theora { get; }
        public IEverestUserIOPathDevice SavePaths { get; }
        public ISourceFnaInputClock InputClock { get; }
        public Celeste.Core.Framework.Time.ISourceFrameworkTimeResources TimeResources { get; }
        public Celeste.Game.Execution.Diagnostics.IOriginalErrorLogIo ErrorLog { get; }
        public Celeste.Everest.Runtime.Failures.ISourceFatalExitIo FatalExit { get; }
        public Celeste.Core.IO.Platform.SDL.ISourceSDLRuntimeDevice SDLRuntime { get; }
        public Celeste.Core.Framework.Startup.ISourceCommandLineDevice CommandLine { get; }
        public Celeste.Framework.Startup.ISourceRuntimeErrorDevice RuntimeErrors { get; }
        public Celeste.Game.Platform.Statistics.IOriginalPlatformStatisticsOutput? StatisticsOutput { get; }
        public Celeste.Core.Framework.Startup.ISourceGameHostRuntimeIO HostRuntime { get; }

        public Celeste.Everest.Runtime.Compatibility.ISourceLegacyAssemblyMetadataRuntimeFactory?
            AssemblyMetadataRuntimeFactory { get; }

        public Celeste.Framework.Startup.ISourceWindowFocusDevice WindowFocus { get; }
        public Celeste.Everest.Runtime.Startup.IEverestSplashPhysicalIO? Splash { get; }
        public Celeste.Core.IO.Console.ISourceConsoleModeIO ConsoleModes { get; }
        public Celeste.Core.Framework.Startup.ISourceHostDrawTransportIO DrawTransport { get; }
        public Celeste.Everest.Runtime.Processes.IEverestProcessStartIo ProcessStart { get; }
        public ISourceTextInputPlatform TextInputPlatform { get; }
        public ISourceClipboardIO Clipboard { get; }
        public Celeste.Core.Diagnostics.Runtime.ISourceRuntimeDiagnosticsIO RuntimeDiagnostics { get; }
        public Celeste.Core.Platform.Steam.ISourceSteamRuntimeIO? SteamRuntime { get; }

        public Celeste.Core.Diagnostics.Runtime.ISourceRuntimeMemoryDiagnostics RuntimeMemoryDiagnostics =>
            RuntimeDiagnostics;

        public GamePlatformServices(
            string? physicalOwnerAssemblyPath, string contentRoot,
            ISourceHostWindowIO window,
            ISourceGraphicsDeviceIOFactory graphicsFactory,
            ISourceGraphicsAdapterDisplayIO displays,
            IContentSource contentFiles,
            ISourceImageCodecDevice imageCodec,
            ISourceKeyboardDevice keyboard,
            ISourceSDLMouseTouchDevice mouseTouch,
            ISourceSDLGamePadDevice gamePads,
            ISourceGameTickDevice clock,
            ISourceGameTimerStartDevice timerStart,
            ISourceRandomSeedDevice randomSeeds,
            ISourceFAudioIOFactory frameworkAudioFactory,
            ISourceMicrophoneIO microphones,
            ISourceTheoraIO theora,
            IEverestUserIOPathDevice savePaths,
            ISourceFnaInputClock inputClock,
            Celeste.Core.Framework.Time.ISourceFrameworkTimeResources timeResources,
            Celeste.Game.Execution.Diagnostics.IOriginalErrorLogIo errorLog,
            Celeste.Everest.Runtime.Failures.ISourceFatalExitIo fatalExit,
            Celeste.Core.IO.Platform.SDL.ISourceSDLRuntimeDevice sdlRuntime,
            Celeste.Core.Framework.Startup.ISourceCommandLineDevice commandLine,
            Celeste.Framework.Startup.ISourceRuntimeErrorDevice runtimeErrors,
            Celeste.Game.Platform.Statistics.IOriginalPlatformStatisticsOutput? statisticsOutput,
            Celeste.Core.Framework.Startup.ISourceGameHostRuntimeIO hostRuntime,
            Celeste.Framework.Startup.ISourceWindowFocusDevice windowFocus,
            Celeste.Everest.Runtime.Startup.IEverestSplashPhysicalIO? splash,
            Celeste.Core.IO.Console.ISourceConsoleModeIO consoleModes,
            Celeste.Core.Framework.Startup.ISourceHostDrawTransportIO drawTransport,
            Celeste.Everest.Runtime.Processes.IEverestProcessStartIo processStart,
            ISourceTextInputPlatform textInputPlatform,
            Celeste.Core.Diagnostics.Runtime.ISourceRuntimeDiagnosticsIO runtimeMemoryDiagnostics,
            Celeste.Core.Platform.Steam.ISourceSteamRuntimeIO? steamRuntime,
            ISourceClipboardIO clipboard,
            Celeste.Everest.Modules.Updating.Transport.IEverestCompressedHttpTransport? compressedHttpTransport,
            Celeste.Everest.Runtime.Boot.IEverestBootProcessIo? bootProcessIO = null,
            Celeste.Everest.Runtime.Discord.IEverestDiscordSdkProcess? discordSdk = null,
            Celeste.Everest.Runtime.Compatibility.ISourceLegacyAssemblyMetadataRuntimeFactory?
                assemblyMetadataRuntimeFactory = null,
            bool audioOutputAvailable = true,
            Celeste.Core.Framework.GarbageCollection.ISourceGarbageCollectionDevice? garbageCollection = null,
            System.IO.TextWriter? consoleOutput = null,
            string? temporaryDirectoryPath = null,
            CompiledSourceDeployment? compiledSourceDeployment = null,
            global::Celeste.Core.Framework.Loading.ISourceLoadingWorkScheduler? loadingWorkScheduler = null,
            global::Celeste.Audio.Fmod.IO.IFmodStudioDeviceIO? studioAudioDevice = null,
            IContentMemorySource? audioBankContent = null,
            Celeste.Game.Menus.Title.MainMenuAdditionalButton? mainMenuAdditionalButton = null,
            Celeste.Game.Menus.Options.IMenuOptionsExtension? menuOptionsExtension = null)
        {
            if (compiledSourceDeployment == null)
            {
                if (!System.IO.Path.IsPathRooted(physicalOwnerAssemblyPath))
                    throw new ArgumentException("An absolute deployed physical managed owner DLL path is required.",
                        nameof(physicalOwnerAssemblyPath));
            }
            else if (physicalOwnerAssemblyPath != null)
                throw new ArgumentException("A compiled source deployment must not claim a physical owner DLL.",
                    nameof(physicalOwnerAssemblyPath));

            if (!System.IO.Path.IsPathRooted(contentRoot))
                throw new ArgumentException("An absolute deployed content root is required.", nameof(contentRoot));
            this.physicalOwnerAssemblyPath = physicalOwnerAssemblyPath;
            CompiledSourceDeployment = compiledSourceDeployment;
            LoadingWorkScheduler = loadingWorkScheduler;
            ContentRoot = contentRoot;
            TemporaryDirectoryPath = temporaryDirectoryPath;
            ConsoleOutput = consoleOutput ?? Console.Out;
            GarbageCollection = garbageCollection ??
                                Celeste.Core.Framework.GarbageCollection.SystemGarbageCollectionDevice.Instance;
            BootProcessIO = bootProcessIO;
            DiscordSdk = discordSdk;
            AssemblyMetadataRuntimeFactory = assemblyMetadataRuntimeFactory;
            AudioOutputAvailable = audioOutputAvailable;
            StudioAudioDevice = studioAudioDevice ?? global::Celeste.Audio.Fmod.IO.NativeFmodStudioDeviceIO.Instance;
            AudioBankContent = audioBankContent;
            MainMenuAdditionalButton = mainMenuAdditionalButton;
            MenuOptionsExtension = menuOptionsExtension;
            Window = window ?? throw new ArgumentNullException(nameof(window));
            GraphicsFactory = graphicsFactory ?? throw new ArgumentNullException(nameof(graphicsFactory));
            Displays = displays ?? throw new ArgumentNullException(nameof(displays));
            ContentFiles = contentFiles ?? throw new ArgumentNullException(nameof(contentFiles));
            ImageCodec = imageCodec ?? throw new ArgumentNullException(nameof(imageCodec));
            Keyboard = keyboard ?? throw new ArgumentNullException(nameof(keyboard));
            MouseTouch = mouseTouch ?? throw new ArgumentNullException(nameof(mouseTouch));
            GamePads = gamePads ?? throw new ArgumentNullException(nameof(gamePads));
            Clock = clock ?? throw new ArgumentNullException(nameof(clock));
            TimerStart = timerStart ?? throw new ArgumentNullException(nameof(timerStart));
            RandomSeeds = randomSeeds ?? throw new ArgumentNullException(nameof(randomSeeds));
            FrameworkAudioFactory =
                frameworkAudioFactory ?? throw new ArgumentNullException(nameof(frameworkAudioFactory));
            Microphones = microphones ?? throw new ArgumentNullException(nameof(microphones));
            Theora = theora ?? throw new ArgumentNullException(nameof(theora));
            SavePaths = savePaths ?? throw new ArgumentNullException(nameof(savePaths));
            InputClock = inputClock ?? throw new ArgumentNullException(nameof(inputClock));
            TimeResources = timeResources ?? throw new ArgumentNullException(nameof(timeResources));
            ErrorLog = errorLog ?? throw new ArgumentNullException(nameof(errorLog));
            FatalExit = fatalExit ?? throw new ArgumentNullException(nameof(fatalExit));
            SDLRuntime = sdlRuntime ?? throw new ArgumentNullException(nameof(sdlRuntime));
            CommandLine = commandLine ?? throw new ArgumentNullException(nameof(commandLine));
            RuntimeErrors = runtimeErrors ?? throw new ArgumentNullException(nameof(runtimeErrors));
            StatisticsOutput = statisticsOutput;
            HostRuntime = hostRuntime ?? throw new ArgumentNullException(nameof(hostRuntime));
            WindowFocus = windowFocus ?? throw new ArgumentNullException(nameof(windowFocus));
            Splash = splash;
            ConsoleModes = consoleModes ?? throw new ArgumentNullException(nameof(consoleModes));
            DrawTransport = drawTransport ?? throw new ArgumentNullException(nameof(drawTransport));
            ProcessStart = processStart ?? throw new ArgumentNullException(nameof(processStart));
            TextInputPlatform = textInputPlatform ?? throw new ArgumentNullException(nameof(textInputPlatform));
            RuntimeDiagnostics = runtimeMemoryDiagnostics ??
                                 throw new ArgumentNullException(nameof(runtimeMemoryDiagnostics));
            SteamRuntime = steamRuntime;
            Clipboard = clipboard ?? throw new ArgumentNullException(nameof(clipboard));
            CompressedHttpTransport = compressedHttpTransport;
        }
    }
}
