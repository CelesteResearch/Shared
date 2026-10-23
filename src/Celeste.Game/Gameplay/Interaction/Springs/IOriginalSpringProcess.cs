using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Game.Gameplay.Interaction.Springs
{
    public interface IOriginalSpringProcess : ISourceEngineContext, ISourceGameGraphicsEnvironment,
        ISourceRandomEnvironment, ISourceWigglerPoolScope, IOriginalGameplayProcess;
}
