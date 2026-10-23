using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Runtime.Assemblies;

namespace Celeste.Everest.Runtime.Compatibility
{
    // Physical application contexts do not carry an Everest module metadata owner.
    // The CLR-specific context APIs are supplied by the actual runtime endpoint.
    public sealed class SourcePhysicalAssemblyContextMetadataRuntime : IEverestLegacyAssemblyMetadataRuntime
    {
        private readonly SourceRuntimeModuleMetadata physicalModules;
        private readonly Func<Assembly, object> getContext;
        private readonly Func<object, IEnumerable<Assembly>> getContextAssemblies;
        private readonly List<object> applicationContexts = new();

        public SourcePhysicalAssemblyContextMetadataRuntime(SourceRuntimeModuleMetadata physicalModules,
            Func<Assembly, object> getContext, Func<object, IEnumerable<Assembly>> getContextAssemblies,
            IEnumerable<Assembly> applicationAssemblies)
        {
            this.physicalModules = physicalModules ?? throw new ArgumentNullException(nameof(physicalModules));
            this.getContext = getContext ?? throw new ArgumentNullException(nameof(getContext));
            this.getContextAssemblies =
                getContextAssemblies ?? throw new ArgumentNullException(nameof(getContextAssemblies));
            if (applicationAssemblies == null) throw new ArgumentNullException(nameof(applicationAssemblies));
            foreach (var assembly in applicationAssemblies)
            {
                if (assembly == null)
                    throw new ArgumentException("An actual application assembly is required.",
                        nameof(applicationAssemblies));
                var context = getContext(assembly)
                              ?? throw new InvalidOperationException(
                                  "The physical application assembly has no CLR load context.");
                if (!ContainsContext(context)) applicationContexts.Add(context);
                RequirePresent(context, assembly);
                foreach (var module in assembly.GetModules()) physicalModules.RequireModule(module);
            }

            if (applicationContexts.Count == 0)
                throw new ArgumentException("At least one actual application context is required.",
                    nameof(applicationAssemblies));
        }

        private bool ContainsContext(object context)
        {
            foreach (var known in applicationContexts)
                if (ReferenceEquals(known, context))
                    return true;
            return false;
        }

        private void RequirePresent(object context, Assembly assembly)
        {
            foreach (var loaded in getContextAssemblies(context))
                if (ReferenceEquals(loaded, assembly))
                    return;
            throw new InvalidOperationException("The actual assembly is not present in its CLR load context.");
        }

        public EverestModuleMetadata GetContextModuleMetadata(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            var context = getContext(assembly);
            if (context == null || !ContainsContext(context))
                throw new NotSupportedException(
                    "This actual load context has no registered application or Everest module owner.");
            RequirePresent(context, assembly);
            foreach (var module in assembly.GetModules()) physicalModules.RequireModule(module);
            // Ordinary host/framework assemblies have no original Everest mod owner.
            return null;
        }
    }
}
