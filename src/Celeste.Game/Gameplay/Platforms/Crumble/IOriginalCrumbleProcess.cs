using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content;

namespace Celeste.Game.Gameplay.Platforms.Crumble
{
    public interface IOriginalCrumbleProcess : ISourceEngineContext, ISourceRandomEnvironment,
        ISourceGameGraphicsEnvironment, ISourceEasingEnvironment, IOriginalGameInputProcessEnvironment,
        IOriginalGameplayProcess;
}
