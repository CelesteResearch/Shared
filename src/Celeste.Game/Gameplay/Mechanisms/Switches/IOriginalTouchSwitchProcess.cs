using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Content;
using Celeste.Simulation.Audio.Sources;
using Celeste.Game.Execution.Processes;

namespace Celeste.Game.Gameplay.Mechanisms.Switches
{
    public interface IOriginalTouchSwitchProcess : ISourceEngineContext, ISourceGameGraphicsEnvironment,
        global::Celeste.Core.Mathematics.ISourceScalarEnvironment, ISourceRandomEnvironment, ISourceWigglerPoolScope,
        IOriginalGameplayProcess,
        global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment
    {
        ISourceSoundSourceFactory SoundSources { get; }
    }
}
