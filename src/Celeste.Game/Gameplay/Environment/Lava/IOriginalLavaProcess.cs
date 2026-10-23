using Celeste.Core.Audio;
using Celeste.Core.Mathematics.Easing;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Effects.Liquids;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Gameplay.Environment.Lava
{
    public interface IOriginalLavaProcess : ISourceLavaRectangleEnvironment,
        ISourceSpatialAudioEnvironment, IOriginalGameplayProcess, ISourceEasingEnvironment
    {
        ISourceSoundSourceFactory SoundSources { get; }
    }
}
