using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Gameplay.Checkpoints
{
    public interface IOriginalCheckpointProcess : ISourceEngineContext, ISourceGameGraphicsEnvironment,
        ISourceExtremaEnvironment, ISourceEasingEnvironment, IOriginalGameplayProcess, IOriginalAreaKeyEnvironment
    {
    }
}
