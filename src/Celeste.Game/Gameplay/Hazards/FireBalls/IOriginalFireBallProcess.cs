using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Gameplay.Hazards.FireBalls
{
    public interface IOriginalFireBallProcess : ISourceEngineContext, IOriginalGameplayProcess,
        ISourceEntitySourceDataEnvironment, ISourceScalarEnvironment, ISourceVectorEnvironment,
        ISourceExtremaEnvironment, ISourceRandomEnvironment, ISourceWigglerPoolScope,
        ISourceGameGraphicsEnvironment, ISourceSoundSourceEnvironment, ISourceSpatialAudioEnvironment,
        IOriginalFireBallPathEnvironment;
}
