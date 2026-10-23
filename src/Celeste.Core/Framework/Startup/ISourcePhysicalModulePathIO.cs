using System.Reflection;

namespace Celeste.Core.Framework.Startup
{
    // Supplies the deployed PE selected by a host that stream-loads its own assemblies.
    // SourceRuntimeModuleMetadata still verifies its identity and MVID.
    public interface ISourcePhysicalModulePathIO
    {
        bool TryGetPhysicalModulePath(Module actualModule, out string physicalPath);
    }
}
