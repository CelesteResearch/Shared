using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Game.Gameplay.Collectibles.Keys
{
    public interface IOriginalKeyProcess : ISourceEngineContext, ISourceGameGraphicsEnvironment,
        ISourceCurveEnvironment, ISourceEasingEnvironment, ISourceRumbleEnvironment, ISourceWigglerPoolScope,
        IOriginalGameplayProcess;
}
