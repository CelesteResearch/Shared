using Celeste.Core.Scheduling;

namespace Celeste.Simulation.Audio.Sources
{
    public sealed class SourceSoundSourceFactory : ISourceSoundSourceFactory
    {
        private readonly ISourceEngineContext engine;
        public SourceSoundSourceFactory(ISourceEngineContext engine) => this.engine = engine;
        public SoundSourceComponentState Create() => new SoundSourceComponentState(engine);
    }
}
