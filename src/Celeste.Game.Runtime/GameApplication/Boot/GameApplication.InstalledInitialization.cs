using System;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Diagnostics.AutoSplitting;
using Celeste.Everest.Runtime.Input;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.Runtime.Threading;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Profiles;
using Celeste.Game.Runtime.Physical.Files;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalGameInitializationCompletionEnvironment,
        IEverestGameInitializationEnvironment
    {
        private IEverestAutoSplitterMemoryDevice sourceInstalledAutoSplitterDevice;
        private EverestAutoSplitterMemoryProcess sourceInstalledAutoSplitterMemory;

        private IEverestInitializationSaveLinkIO sourceInitializationSaveLinks =
            new SourceDirectoryLinkTargetIO();

        private bool sourceInitializationSaveLinksBound;

        public void BindSourceInitializationSaveLinkIO(IEverestInitializationSaveLinkIO actualIO)
        {
            if (actualIO == null) throw new ArgumentNullException(nameof(actualIO));
            if (sourceInitializationSaveLinksBound)
                throw new InvalidOperationException(
                    "The actual initialization save-directory link IO is already bound.");
            sourceInitializationSaveLinks = actualIO;
            sourceInitializationSaveLinksBound = true;
        }

        public void BindSourceInstalledAutoSplitterDevice(IEverestAutoSplitterMemoryDevice actualDevice)
        {
            if (actualDevice == null) throw new ArgumentNullException(nameof(actualDevice));
            if (sourceInstalledAutoSplitterDevice != null)
                throw new InvalidOperationException("The actual AutoSplitter mapped-memory device is already bound.");
            sourceInstalledAutoSplitterDevice = actualDevice;
        }

        public void CompleteSourceGameInitialization()
        {
            if (SourceProfile == GameProfile.InstalledEverest)
            {
                EverestGameInitializationLifecycle.Initialize(this, ActualGame);
                // The allocation-time callback also owns Lua if initialization fails partway.
                ActualGame.Disposed -= DisposeSourceLuaContext;
                ActualGame.Disposed += DisposeSourceLuaContext;
            }

            // Retain Everest's native bank/system unload before closing the session owner.
            // The allocation-time binding still covers incomplete game initialization.
            ActualGame.Disposed -= DisposeSourceAudioSession;
            ActualGame.Disposed += DisposeSourceAudioSession;
            // Detour teardown can rebuild remaining IL chains and still needs their physical module readers.
            if (sourceRuntimeModuleMetadata != null)
            {
                ActualGame.Disposed -= DisposeSourceRuntimeModuleMetadata;
                ActualGame.Disposed += DisposeSourceRuntimeModuleMetadata;
            }

            // Content sources remain available through saves, audio and module teardown.
            if (!(sourceContentRegistry != null))
                return;
            ActualGame.Disposed -= DisposeSourceContentRegistry;
            ActualGame.Disposed += DisposeSourceContentRegistry;
        }

        Version IEverestAutoSplitterInitializationEnvironment.CelesteVersion => ActualGame.Version;
        string IEverestAutoSplitterInitializationEnvironment.EverestVersionString => EverestRuntime.VersionString;
        EverestContentRegistry IEverestGameInitializationEnvironment.InitializationContent => SourceContentRegistry;
        EverestTextInputProcess IEverestGameInitializationEnvironment.InitializationTextInput => InstalledTextInput;
        EverestStartupRuntimeProcess IEverestGameInitializationEnvironment.InitializationRuntime => EverestRuntime;

        IEverestInitializationSaveLinkIO IEverestGameInitializationEnvironment.InitializationSaveLinks =>
            sourceInitializationSaveLinks;

        EverestAutoSplitterMemoryProcess? IEverestGameInitializationEnvironment.InitializationAutoSplitter =>
            sourceInstalledAutoSplitterDevice == null
                ? null
                : sourceInstalledAutoSplitterMemory ??=
                    new(sourceInstalledAutoSplitterDevice);

        EverestMainThreadProcess IEverestGameInitializationEnvironment.InitializationMainThread => MainThread;
        EverestStaThreadProcess IEverestGameInitializationEnvironment.InitializationStaThread => StaThread;

        void IEverestGameInitializationEnvironment.LoadSourceInitializationDecalRegistry()
        {
            DecalRegistry.Load();
        }

        OriginalGameAudioSession IEverestGameInitializationEnvironment.InitializationAudio => AudioSession;
    }
}
