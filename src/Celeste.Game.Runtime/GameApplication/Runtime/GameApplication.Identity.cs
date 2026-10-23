using Celeste.Game.Execution;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Startup;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalEngineIdentityEnvironment, IOriginalGamePlayModeEnvironment
    {
        public EngineRuntime EngineIdentity => ActualGame;
        public GameRuntime.PlayModes PlayMode => GameRuntime.PlayMode;
    }
}
