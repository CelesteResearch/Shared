using System.Reflection;
using Celeste.Core.Scheduling;

namespace Celeste.Everest.Modules.Runtime
{
    public interface ISourceModuleMetadataProvider
    {
        void Publish(ISourceEngineContext engine, Assembly assembly);
    }
}
