using Celeste.Everest.Audio;
using Celeste.Everest.Modules.Updating;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed partial class SourceEverestModulesProcess
    {
        // Original Metadata.RegisterMod runs once per mod after all module instances.
        public void RegisterMod(EverestModuleMetadata metadata)
        {
            InvalidateInstallationHash();
            var audio = ((IEverestAudioRuntimeEnvironment)sourceEngine).EverestAudio;
            if (audio.AudioInitialized)
                audio.IngestNewBanks();
            ((IEverestLoaderProcessEnvironment)sourceEngine).Loader.CheckDependenciesOfDelayedMods();
        }
    }
}
