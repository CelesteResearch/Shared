using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Content;

namespace Celeste.Game.Gameplay.Decoration.SummitClouds
{
    public interface IOriginalSummitCloudProcess : ISourceEngineContext, ISourceEntitySourceDataEnvironment,
        ISourceRandomEnvironment, ISourceSineWaveEnvironment, ISourceGameGraphicsEnvironment
    {
    }
}
