using System.Reflection;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Runtime.Compatibility
{
// Actual runtime load-context identity, never inferred from a second module list.
    public interface IEverestLegacyAssemblyMetadataRuntime
    {
        EverestModuleMetadata GetContextModuleMetadata(Assembly assembly);
    }
}
