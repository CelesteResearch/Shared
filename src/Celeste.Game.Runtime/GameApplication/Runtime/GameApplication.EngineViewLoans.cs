using Celeste.Core.Rendering;
using Celeste.Game.Execution;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceEngineViewEnvironment
    {
        int ISourceEngineViewEnvironment.ViewWidth => EngineRuntime.ViewWidth;
        int ISourceEngineViewEnvironment.ViewHeight => EngineRuntime.ViewHeight;
    }
}
