using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Gameplay.Mechanisms.SwitchGates
{
    public interface IOriginalSwitchGateProcess : ISourceEngineContext, ISourceGameGraphicsEnvironment,
        ISourceRandomEnvironment, ISourceWigglerPoolScope,
        ISourceScalarEnvironment, ISourceEasingEnvironment, IOriginalGameplayProcess
    {
        ISourceSoundSourceFactory SoundSources { get; }
    }
}
