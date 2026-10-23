using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content;

namespace Celeste.Game.Gameplay.Decoration.PowerSources
{
    public interface IOriginalPowerSourceNumberProcess : ISourceEngineContext, ISourceEntitySourceDataEnvironment,
        ISourceGameGraphicsEnvironment, ISourceExtremaEnvironment;
}
