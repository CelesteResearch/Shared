using Celeste.Everest.Runtime.Assemblies;

namespace Celeste.Everest.Runtime.Compatibility
{
    // A physical runtime factory, called after the canonical module reader is born.
    public interface ISourceLegacyAssemblyMetadataRuntimeFactory
    {
        IEverestLegacyAssemblyMetadataRuntime
            CreateAssemblyMetadataRuntime(SourceRuntimeModuleMetadata physicalModules);
    }
}
