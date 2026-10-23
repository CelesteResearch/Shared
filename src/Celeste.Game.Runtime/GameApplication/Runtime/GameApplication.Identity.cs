using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Startup;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalEngineIdentityEnvironment, IOriginalGamePlayModeEnvironment
    {
        public EngineRuntime EngineIdentity => ActualGame;
        public GameRuntime.PlayModes PlayMode => GameRuntime.PlayMode;
    }
}
