using Celeste.Everest.Runtime.Threading;

namespace Celeste.Everest.Modules.Runtime
{
    public interface IEverestModuleRuntimeEnvironment
    {
        string PathEverest { get; }
        EverestMainThreadProcess MainThread { get; }
    }
}
