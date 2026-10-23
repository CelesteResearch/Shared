using System;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Profiles;
using Celeste.Game.Audio.Application;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Presentation.Particles;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalGameplayProcess,
        Celeste.Everest.Audio.IEverestAudioRuntimeEnvironment
    {
        private OriginalGameAudioSession sourceAudioSession;
        private OriginalParticleCatalog sourceParticleTypes;
        private ParticleTypeRegistry sourceParticleTypeRegistry;

        public OriginalGameAudioSession AudioSession => sourceAudioSession ??
                                                        throw new InvalidOperationException(
                                                            "The actual source game audio session is not constructed.");

        public Celeste.Everest.Audio.EverestGameAudioSession EverestAudio =>
            (Celeste.Everest.Audio.EverestGameAudioSession)AudioSession;

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
                : new Celeste.Everest.Audio.EverestGameAudioSession(this, PhysicalIO.StudioAudioDevice,
                    PhysicalIO.AudioBankContent);
            ActualGame.Disposed += DisposeSourceAudioSession;
            sourceAudioSession.Device.ConfigureSourceOutput(PhysicalIO.AudioOutputAvailable
                ? Celeste.Audio.Fmod.Interop.FmodOutputDevice.AutoDetect
                : Celeste.Audio.Fmod.Interop.FmodOutputDevice.NoSound);
            sourceAudioSession.BindSourceRuntimeExtensions(this);
            sourceAudioSession.InitializeSourceEventNamePolicy(SourceProfile == GameProfile.Original
                ? (Celeste.Game.Audio.Channels.IOriginalAudioEventNamePolicy)
                new Celeste.Game.Audio.Channels.OriginalAudioEventNamePolicy()
                : new Celeste.Everest.Audio.EverestAudioEventNamePolicy(this));
            ISourceParticleTypeConstruction particles;
            if (SourceProfile == GameProfile.Original)
            {
                sourceParticleTypeRegistry = new ParticleTypeRegistry();
                particles = new OriginalParticleTypeConstruction(sourceParticleTypeRegistry);
            }
            else
                particles = new Celeste.Everest.Content.Particles.EverestParticleTypeConstruction();

            sourceParticleTypes = new OriginalParticleCatalog(particles);
            ConstructSourceClassicConsolePolicy();
        }

        private void DisposeSourceAudioSession(object sender, EventArgs args)
        {
            sourceAudioSession.Dispose();
        }
    }
}
