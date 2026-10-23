using System;
using Celeste.Audio.Fmod.Interop;
using Celeste.Everest.Audio;
using Celeste.Everest.Content.Particles;
using Celeste.Game.Audio.Application;
using Celeste.Game.Audio.Channels;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Presentation.Particles;
using Celeste.Game.Profiles;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalGameplayProcess,
        IEverestAudioRuntimeEnvironment
    {
        private OriginalGameAudioSession sourceAudioSession;
        private OriginalParticleCatalog sourceParticleTypes;
        private ParticleTypeRegistry sourceParticleTypeRegistry;

        public OriginalGameAudioSession AudioSession => sourceAudioSession ??
                                                        throw new InvalidOperationException(
                                                            "The actual source game audio session is not constructed.");

        public EverestGameAudioSession EverestAudio =>
            (EverestGameAudioSession)AudioSession;

        public OriginalParticleCatalog ParticleTypes => sourceParticleTypes ??
                                                        throw new InvalidOperationException(
                                                            "The actual source particle catalog is not constructed.");

        public OriginalAudioStateApplyPolicy AudioApplyPolicy => SourceProfile == GameProfile.Original
            ? OriginalAudioStateApplyPolicy.Vanilla
            : OriginalAudioStateApplyPolicy.Installed;

        public void ConstructSourceGameplayProcesses()
        {
            if (sourceAudioSession != null)
                throw new InvalidOperationException("The actual gameplay processes are already constructed.");
            sourceAudioSession = SourceProfile == GameProfile.Original
                ? new OriginalGameAudioSession(PhysicalIO.StudioAudioDevice, PhysicalIO.AudioBankContent)
                : new EverestGameAudioSession(this, PhysicalIO.StudioAudioDevice,
                    PhysicalIO.AudioBankContent);
            ActualGame.Disposed += DisposeSourceAudioSession;
            sourceAudioSession.Device.ConfigureSourceOutput(PhysicalIO.AudioOutputAvailable
                ? FmodOutputDevice.AutoDetect
                : FmodOutputDevice.NoSound);
            sourceAudioSession.BindSourceRuntimeExtensions(this);
            sourceAudioSession.InitializeSourceEventNamePolicy(SourceProfile == GameProfile.Original
                ? new OriginalAudioEventNamePolicy()
                : new EverestAudioEventNamePolicy(this));
            ISourceParticleTypeConstruction particles;
            if (SourceProfile == GameProfile.Original)
            {
                sourceParticleTypeRegistry = new();
                particles = new OriginalParticleTypeConstruction(sourceParticleTypeRegistry);
            }
            else
            {
                particles = new EverestParticleTypeConstruction();
            }

            sourceParticleTypes = new(particles);
            ConstructSourceClassicConsolePolicy();
        }

        private void DisposeSourceAudioSession(object sender, EventArgs args)
        {
            sourceAudioSession.Dispose();
        }
    }
}
