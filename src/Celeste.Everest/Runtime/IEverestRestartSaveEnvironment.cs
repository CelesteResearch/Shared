using Celeste.Everest.Modules.Persistence.GameSaves;

namespace Celeste.Everest.Runtime
{
    public interface IEverestRestartSaveEnvironment
    {
        IEverestSaveModuleState SaveModuleState { get; }
    }
}
