using Celeste.Game.Execution.Engine.Screen;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalEngineScreenEnvironment
    {
        public OriginalEngineScreenState EngineScreen => ActualGame.SourceScreen;
    }
}
