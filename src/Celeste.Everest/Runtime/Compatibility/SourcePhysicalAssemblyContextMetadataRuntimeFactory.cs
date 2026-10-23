using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Everest.Runtime.Assemblies;

namespace Celeste.Everest.Runtime.Compatibility
{
    public sealed class
        SourcePhysicalAssemblyContextMetadataRuntimeFactory : ISourceLegacyAssemblyMetadataRuntimeFactory
    {
        private readonly Func<Assembly, object> getContext;

        private readonly Func<object, IEnumerable<Assembly>> getContextAssemblies;

        private readonly Assembly[] applicationAssemblies;

        // ReSharper disable once ConvertToPrimaryConstructor
        public SourcePhysicalAssemblyContextMetadataRuntimeFactory(Func<Assembly, object> getContext,
            Func<object, IEnumerable<Assembly>> getContextAssemblies, params Assembly[] applicationAssemblies)
        {
            this.getContext = getContext ?? throw new ArgumentNullException(nameof(getContext));
            this.getContextAssemblies =
                getContextAssemblies ?? throw new ArgumentNullException(nameof(getContextAssemblies));
            this.applicationAssemblies = (Assembly[])(applicationAssemblies ??
                                                      throw new ArgumentNullException(nameof(applicationAssemblies)))
                .Clone();
        }

        public IEverestLegacyAssemblyMetadataRuntime CreateAssemblyMetadataRuntime(
            SourceRuntimeModuleMetadata physicalModules)
        {
            return new SourcePhysicalAssemblyContextMetadataRuntime(physicalModules, getContext,
                getContextAssemblies, applicationAssemblies);
        }
    }
}
