using System;
using Celeste.Core.Audio;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceSoundSourceEnvironment, ISourceSoundSourceAudioEnvironment
    {
        private ISourceSoundSourceFactory sourceSoundSources;

        public ISourceSoundSourceFactory SoundSources => sourceSoundSources ??
                                                         throw new InvalidOperationException(
                                                             "The actual SoundSource factory is not constructed.");

        public ISourceSoundSourceAudio SoundSourceAudio => AudioSession;

        public void ConstructSourceSoundSources()
        {
            if (sourceSoundSources != null)
                throw new InvalidOperationException("The actual SoundSource factory is already constructed.");
            sourceSoundSources = new SourceSoundSourceFactory(this);
        }
    }
}
