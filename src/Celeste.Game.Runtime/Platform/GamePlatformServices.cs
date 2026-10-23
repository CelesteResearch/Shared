using System;
using System.IO;
using Celeste.Audio.Fmod.IO;
using Celeste.Audio.IO;
using Celeste.Core.Diagnostics.Runtime;
using Celeste.Core.Framework.GarbageCollection;
using Celeste.Core.Framework.Loading;
using Celeste.Core.Framework.Startup;
using Celeste.Core.Framework.Time;
using Celeste.Core.Framework.Timing;
using Celeste.Core.IO.Console;
using Celeste.Core.IO.Content;
using Celeste.Core.IO.Platform.SDL;
using Celeste.Core.Platform.Steam;
using Celeste.Core.Randomness;
using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Everest.Modules.Updating.Transport;
using Celeste.Everest.Runtime.Boot;
using Celeste.Everest.Runtime.Compatibility;
using Celeste.Everest.Runtime.Discord;
using Celeste.Everest.Runtime.Failures;
using Celeste.Everest.Runtime.Processes;
using Celeste.Everest.Runtime.Startup;
using Celeste.Framework.Startup;
using Celeste.Game.Execution.Diagnostics;
using Celeste.Game.Menus.Options;
using Celeste.Game.Menus.Title;
using Celeste.Game.Platform.Statistics;
using Celeste.Graphics.Content.Images;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.Mouse;
using Celeste.Input.Devices.Text;

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
        public ISourceLoadingWorkScheduler? LoadingWorkScheduler { get; }
        public MainMenuAdditionalButton? MainMenuAdditionalButton { get; }
        public IMenuOptionsExtension? MenuOptionsExtension { get; }
        public string ContentRoot { get; }
        public string? TemporaryDirectoryPath { get; }
        public TextWriter ConsoleOutput { get; }
        public ISourceGarbageCollectionDevice GarbageCollection { get; }
        public IEverestDiscordSdkProcess? DiscordSdk { get; }

        public IEverestCompressedHttpTransport? CompressedHttpTransport { get; }

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
        public IFmodStudioDeviceIO StudioAudioDevice { get; }
        public IContentMemorySource? AudioBankContent { get; }
        public ISourceTheoraIO Theora { get; }
        public IEverestUserIOPathDevice SavePaths { get; }
        public ISourceFnaInputClock InputClock { get; }
        public ISourceFrameworkTimeResources TimeResources { get; }
        public IOriginalErrorLogIo ErrorLog { get; }
        public ISourceFatalExitIo FatalExit { get; }
        public ISourceSDLRuntimeDevice SDLRuntime { get; }
        public ISourceCommandLineDevice CommandLine { get; }
        public ISourceRuntimeErrorDevice RuntimeErrors { get; }
        public IOriginalPlatformStatisticsOutput? StatisticsOutput { get; }
        public ISourceGameHostRuntimeIO HostRuntime { get; }

        public ISourceLegacyAssemblyMetadataRuntimeFactory?
            AssemblyMetadataRuntimeFactory { get; }

        public ISourceWindowFocusDevice WindowFocus { get; }
        public IEverestSplashPhysicalIO? Splash { get; }
        public ISourceConsoleModeIO ConsoleModes { get; }
        public ISourceHostDrawTransportIO DrawTransport { get; }
        public IEverestProcessStartIo ProcessStart { get; }
        public ISourceTextInputPlatform TextInputPlatform { get; }
        public ISourceClipboardIO Clipboard { get; }
        public ISourceRuntimeDiagnosticsIO RuntimeDiagnostics { get; }
        public ISourceSteamRuntimeIO? SteamRuntime { get; }

        public ISourceRuntimeMemoryDiagnostics RuntimeMemoryDiagnostics =>
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
            ISourceFrameworkTimeResources timeResources,
            IOriginalErrorLogIo errorLog,
            ISourceFatalExitIo fatalExit,
            ISourceSDLRuntimeDevice sdlRuntime,
            ISourceCommandLineDevice commandLine,
            ISourceRuntimeErrorDevice runtimeErrors,
            IOriginalPlatformStatisticsOutput? statisticsOutput,
            ISourceGameHostRuntimeIO hostRuntime,
            ISourceWindowFocusDevice windowFocus,
            IEverestSplashPhysicalIO? splash,
            ISourceConsoleModeIO consoleModes,
            ISourceHostDrawTransportIO drawTransport,
            IEverestProcessStartIo processStart,
            ISourceTextInputPlatform textInputPlatform,
            ISourceRuntimeDiagnosticsIO runtimeMemoryDiagnostics,
            ISourceSteamRuntimeIO? steamRuntime,
            ISourceClipboardIO clipboard,
            IEverestCompressedHttpTransport? compressedHttpTransport,
            IEverestBootProcessIo? bootProcessIO = null,
            IEverestDiscordSdkProcess? discordSdk = null,
            ISourceLegacyAssemblyMetadataRuntimeFactory?
                assemblyMetadataRuntimeFactory = null,
            bool audioOutputAvailable = true,
            ISourceGarbageCollectionDevice? garbageCollection = null,
            TextWriter? consoleOutput = null,
            string? temporaryDirectoryPath = null,
            CompiledSourceDeployment? compiledSourceDeployment = null,
            ISourceLoadingWorkScheduler? loadingWorkScheduler = null,
            IFmodStudioDeviceIO? studioAudioDevice = null,
            IContentMemorySource? audioBankContent = null,
            MainMenuAdditionalButton? mainMenuAdditionalButton = null,
            IMenuOptionsExtension? menuOptionsExtension = null)
        {
            if (compiledSourceDeployment == null)
            {
                if (!Path.IsPathRooted(physicalOwnerAssemblyPath))
                    throw new ArgumentException("An absolute deployed physical managed owner DLL path is required.",
                        nameof(physicalOwnerAssemblyPath));
            }
            else if (physicalOwnerAssemblyPath != null)
            {
                throw new ArgumentException("A compiled source deployment must not claim a physical owner DLL.",
                    nameof(physicalOwnerAssemblyPath));
            }

            if (!Path.IsPathRooted(contentRoot))
                throw new ArgumentException("An absolute deployed content root is required.", nameof(contentRoot));
            this.physicalOwnerAssemblyPath = physicalOwnerAssemblyPath;
            CompiledSourceDeployment = compiledSourceDeployment;
            LoadingWorkScheduler = loadingWorkScheduler;
            ContentRoot = contentRoot;
            TemporaryDirectoryPath = temporaryDirectoryPath;
            ConsoleOutput = consoleOutput ?? Console.Out;
            GarbageCollection = garbageCollection ??
                                SystemGarbageCollectionDevice.Instance;
            BootProcessIO = bootProcessIO;
            DiscordSdk = discordSdk;
            AssemblyMetadataRuntimeFactory = assemblyMetadataRuntimeFactory;
            AudioOutputAvailable = audioOutputAvailable;
            StudioAudioDevice = studioAudioDevice ?? NativeFmodStudioDeviceIO.Instance;
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
