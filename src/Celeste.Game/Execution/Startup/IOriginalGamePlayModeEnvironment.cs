using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution.Startup
{
    public interface IOriginalGamePlayModeEnvironment
    {
        GameRuntime.PlayModes PlayMode { get; }
    }
}
