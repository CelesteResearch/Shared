#nullable enable annotations
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Diagnostics.AutoSplitting;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Runtime.Input;
using Celeste.Everest.Runtime.Threading;
using Celeste.Game.Audio.Runtime;

namespace Celeste.Everest.Runtime.Startup
{
    public interface IEverestGameInitializationEnvironment : IEverestAutoSplitterInitializationEnvironment
    {
        EverestContentRegistry InitializationContent { get; }
        EverestTextInputProcess InitializationTextInput { get; }
        EverestStartupRuntimeProcess InitializationRuntime { get; }
        IEverestInitializationSaveLinkIO InitializationSaveLinks { get; }
        EverestAutoSplitterMemoryProcess? InitializationAutoSplitter { get; }
        EverestMainThreadProcess InitializationMainThread { get; }
        EverestStaThreadProcess InitializationStaThread { get; }
        SourceEverestModulesProcess ModulesProcess { get; }
        void LoadSourceInitializationDecalRegistry();
        OriginalGameAudioSession InitializationAudio { get; }
    }
}
