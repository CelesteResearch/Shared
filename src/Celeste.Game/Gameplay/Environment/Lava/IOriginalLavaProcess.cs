using Celeste.Core.Audio;
using Celeste.Core.Mathematics.Easing;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Player.Configuration;
using Celeste.Graphics.Effects.Liquids;

namespace Celeste.Game.Gameplay.Environment.Lava
{
    public interface IOriginalLavaProcess : ISourceLavaRectangleEnvironment,
        ISourceSpatialAudioEnvironment, IOriginalGameplayProcess, ISourceEasingEnvironment
    {
        ISourceSoundSourceFactory SoundSources { get; }
    }
}
