using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Processes;

namespace Celeste.Game.Gameplay.Interaction.Springs
{
    public interface IOriginalSpringProcess : ISourceEngineContext, ISourceGameGraphicsEnvironment,
        ISourceRandomEnvironment, ISourceWigglerPoolScope, IOriginalGameplayProcess
    {
    }
}
