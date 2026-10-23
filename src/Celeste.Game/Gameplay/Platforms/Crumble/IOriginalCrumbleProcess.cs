using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics.Easing;
using Celeste.Game.Controls.Source;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Processes;

namespace Celeste.Game.Gameplay.Platforms.Crumble
{
    public interface IOriginalCrumbleProcess : ISourceEngineContext, ISourceRandomEnvironment,
        ISourceGameGraphicsEnvironment, ISourceEasingEnvironment, IOriginalGameInputProcessEnvironment,
        IOriginalGameplayProcess
    {
    }
}
