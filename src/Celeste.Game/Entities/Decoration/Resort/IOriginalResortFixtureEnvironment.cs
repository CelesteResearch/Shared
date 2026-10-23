using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Entities.Decoration.Resort
{
    public interface IOriginalResortFixtureEnvironment : ISourceEngineContext
    {
        ISourceSoundSourceFactory SoundSources { get; }
        void PlaySound(string eventName, Vector2 position);
    }
}
