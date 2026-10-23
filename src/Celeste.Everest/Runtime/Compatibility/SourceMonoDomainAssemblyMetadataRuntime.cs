using System;
using System.Reflection;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Runtime.Assemblies;

namespace Celeste.Everest.Runtime.Compatibility
{
    /// Qualifies the actual Mono current AppDomain, which has no CLR AssemblyLoadContext owner.
    public sealed class SourceMonoDomainAssemblyMetadataRuntime : IEverestLegacyAssemblyMetadataRuntime
    {
        private readonly SourceRuntimeModuleMetadata physicalModules;

        public static bool IsSupported
        {
            get
            {
                var core = typeof(object).Assembly;
                if (core.GetType("Mono.Runtime", throwOnError: false, ignoreCase: false) == null) return false;
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                    if (assembly.GetType("System.Runtime.Loader.AssemblyLoadContext", throwOnError: false,
                            ignoreCase: false) != null)
                        return false;
                return true;
            }
        }

        public SourceMonoDomainAssemblyMetadataRuntime(SourceRuntimeModuleMetadata physicalModules)
        {
            this.physicalModules = physicalModules ?? throw new ArgumentNullException(nameof(physicalModules));
            if (!IsSupported)
                throw new PlatformNotSupportedException(
                    "This backend requires the actual Mono current AppDomain without CLR AssemblyLoadContext support.");
            physicalModules.ResolveDefinition(typeof(object).Assembly.GetType("Mono.Runtime", throwOnError: true,
                ignoreCase: false));
        }

        public EverestModuleMetadata GetContextModuleMetadata(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            if (!IsSupported)
                throw new PlatformNotSupportedException(
                    "The actual CLR no longer qualifies as the Mono current AppDomain backend.");
            bool present = false;
            foreach (var loaded in AppDomain.CurrentDomain.GetAssemblies())
                if (ReferenceEquals(loaded, assembly))
                {
                    present = true;
                    break;
                }

            if (!present)
                throw new InvalidOperationException(
                    "The actual assembly is not loaded in this Mono current AppDomain.");
            foreach (var module in assembly.GetModules()) physicalModules.RequireModule(module);
            // A certified current-domain physical assembly has no collectible CLR context metadata.
            // MonoModPolice retains its existing no-context diagnostic path.
            return null;
        }
    }
}
