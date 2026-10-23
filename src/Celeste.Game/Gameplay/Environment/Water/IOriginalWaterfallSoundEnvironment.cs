using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Gameplay.Environment.Water
{
    public interface IOriginalWaterfallSoundEnvironment
    {
        ISourceSoundSourceFactory SoundSources { get; }
    }
}
