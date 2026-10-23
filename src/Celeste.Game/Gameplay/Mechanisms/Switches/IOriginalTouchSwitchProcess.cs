using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Gameplay.Mechanisms.Switches
{
    public interface IOriginalTouchSwitchProcess : ISourceEngineContext, ISourceGameGraphicsEnvironment,
        ISourceScalarEnvironment, ISourceRandomEnvironment, ISourceWigglerPoolScope,
        IOriginalGameplayProcess,
        ISourceExtremaEnvironment
    {
        ISourceSoundSourceFactory SoundSources { get; }
    }
}
