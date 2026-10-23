using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content;

namespace Celeste.Game.Gameplay.Environment.Debris
{
    public interface IOriginalFloatingDebrisProcess : ISourceEngineContext,
        ISourceEntitySourceDataEnvironment, ISourceVectorEnvironment, ISourceSineWaveEnvironment,
        ISourceRandomEnvironment, ISourceGameGraphicsEnvironment
    {
    }
}
