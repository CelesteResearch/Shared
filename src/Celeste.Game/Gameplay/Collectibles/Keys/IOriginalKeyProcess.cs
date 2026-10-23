using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Content;

namespace Celeste.Game.Gameplay.Collectibles.Keys
{
    public interface IOriginalKeyProcess : ISourceEngineContext, ISourceGameGraphicsEnvironment,
        ISourceCurveEnvironment, ISourceEasingEnvironment, ISourceRumbleEnvironment, ISourceWigglerPoolScope,
        global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess
    {
    }
}
