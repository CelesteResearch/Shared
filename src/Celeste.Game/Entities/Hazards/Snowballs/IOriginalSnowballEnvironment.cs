using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Entities.Hazards.Snowballs
{
    public interface IOriginalSnowballEnvironment : ISourceEngineContext
    {
        ISourceSoundSourceFactory SoundSources { get; }
        void PlaySound(string eventName, Vector2 position);
        void Freeze(float time);
    }
}
