using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Content;
using Celeste.Simulation.Audio.Sources;
using Celeste.Game.Execution.Processes;

namespace Celeste.Game.Gameplay.Mechanisms.SwitchGates
{
    public interface IOriginalSwitchGateProcess : ISourceEngineContext, ISourceGameGraphicsEnvironment,
        ISourceRandomEnvironment, ISourceWigglerPoolScope,
        ISourceScalarEnvironment, ISourceEasingEnvironment, IOriginalGameplayProcess
    {
        ISourceSoundSourceFactory SoundSources { get; }
    }
}
