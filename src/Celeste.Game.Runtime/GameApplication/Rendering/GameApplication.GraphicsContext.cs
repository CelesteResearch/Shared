using Celeste.Game.Execution.Engine;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalEngineGraphicsEnvironment
    {
        public IOriginalEngineGraphicsState EngineGraphics => ActualGame;
    }
}
