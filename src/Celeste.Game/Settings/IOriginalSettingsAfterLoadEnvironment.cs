using Celeste.Game.Execution.Engine;

namespace Celeste.Game.Settings
{
    public interface IOriginalSettingsAfterLoadEnvironment : ISettingsContext,
        IOriginalEngineIdentityEnvironment, ISettingsRuntimeContext
    {
        int CurrentDisplayWidth { get; }
        int CurrentDisplayHeight { get; }
    }
}
