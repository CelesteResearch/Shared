using Celeste.Scene.Rendering;
using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Core.Framework.Timing;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Scenes;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Everest.UI.Shutdown
{
    public interface IEverestApplicationExitEnvironment
    {
        SourceGameLoopState ApplicationLoop { get; }
    }
}
