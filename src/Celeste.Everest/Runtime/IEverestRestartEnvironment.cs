using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Everest.Runtime.Events;

namespace Celeste.Everest.Runtime
{
    public interface IEverestRestartEnvironment
    {
        EverestRestartProcess Restart { get; }
    }
}
