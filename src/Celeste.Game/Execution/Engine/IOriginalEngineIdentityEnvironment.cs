using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution.Engine
{
    public interface IOriginalEngineIdentityEnvironment
    {
        EngineRuntime EngineIdentity { get; }
    }
}
