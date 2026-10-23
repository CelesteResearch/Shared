using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content;

namespace Celeste.Game.Gameplay.Checkpoints
{
    public interface IOriginalCheckpointProcess : ISourceEngineContext, ISourceGameGraphicsEnvironment,
        ISourceExtremaEnvironment, ISourceEasingEnvironment, IOriginalGameplayProcess, IOriginalAreaKeyEnvironment;
}
