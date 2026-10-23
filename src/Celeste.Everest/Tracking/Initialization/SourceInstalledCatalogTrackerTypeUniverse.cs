using System;
using System.Collections.Generic;
using Celeste.Core.Reflection;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Reflection.Runtime;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Tracking.Initialization
{
    public sealed class SourceInstalledCatalogTrackerTypeUniverse : ISourceInstalledTrackerTypeUniverse
    {
        private readonly SceneEntityCatalog catalog;

        private readonly Dictionary<ISourceTypeMetadata, ISourceTypeMetadata> sourceAdapters = new();

        private SourceRuntimeTypeDiscovery RuntimeTypes =>
            (modules as ISourceRuntimeTypeDiscoveryEnvironment)
            ?.RuntimeTypeDiscovery;

        private readonly ISourceEverestModulesEnvironment modules;
        private readonly Func<Type, string> requireOriginalAssemblyIdentity;
        private readonly Func<string, ISourceTypeMetadata[]> requireOriginalAssemblyTypes;

        public SourceInstalledCatalogTrackerTypeUniverse(SceneEntityCatalog catalog,
            ISourceEverestModulesEnvironment modules,
            Func<Type, string> requireOriginalAssemblyIdentity,
            Func<string, ISourceTypeMetadata[]> requireOriginalAssemblyTypes)
        {
            this.catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
            this.modules = modules ?? throw new ArgumentNullException(nameof(modules));
            this.requireOriginalAssemblyIdentity = requireOriginalAssemblyIdentity ??
                                                   throw new ArgumentNullException(
                                                       nameof(requireOriginalAssemblyIdentity));
            this.requireOriginalAssemblyTypes = requireOriginalAssemblyTypes ??
                                                throw new ArgumentNullException(nameof(requireOriginalAssemblyTypes));
        }

        private ISourceTypeMetadata WrapSource(ISourceTypeMetadata type)
        {
            if (type == null) return null;
            if (!sourceAdapters.TryGetValue(type, out var adapter))
            {
                adapter = new RuntimeTrackerTypeMetadata(type);
                sourceAdapters.Add(type, adapter);
            }

            return adapter;
        }

        public ISourceTypeMetadata EntityType =>
            WrapSource(catalog.Find(typeof(SceneEntityState).FullName)) ??
            throw new InvalidOperationException(
                "Entity source metadata is not published.");

        public ISourceTypeMetadata ComponentType => WrapSource(catalog.Find("Monocle.Component")) ??
                                                    throw new InvalidOperationException(
                                                        "Component source metadata is not published.");

        public ISourceTypeMetadata[] GetTypes()
        {
            var assemblies = new HashSet<string>(StringComparer.Ordinal);
            var types = new List<ISourceTypeMetadata>();
            foreach (var module in modules.Modules)
            {
                if (RuntimeTypes?.ContainsAssembly(module.GetType().Assembly) == true) continue;
                // Module assembly identity is source member metadata, not scene-entity qualification.
                var assemblyIdentity = requireOriginalAssemblyIdentity(module.GetType());
                if (string.IsNullOrEmpty(assemblyIdentity))
                    throw new InvalidOperationException("The source module assembly scope is not published.");
                if (assemblies.Add(assemblyIdentity))
                    types.AddRange(Array.ConvertAll(requireOriginalAssemblyTypes(assemblyIdentity), WrapSource));
            }

            if (RuntimeTypes != null) types.AddRange(RuntimeTypes.GetTypes());
            return [.. types];
        }

        // This explicitly enumerates already published source metadata. CLR loader
        // ReflectionTypeLoadException/partial-Type[] handling remains in TypeSafety,
        // not a fabricated failure or a fallback inventory in this representation.
        public ISourceTypeMetadata[] GetTypesSafe()
        {
            return GetTypes();
        }

        public SourceTrackedAsMetadata[] ReadDeclaredTrackedAsAttributes(ISourceTypeMetadata type)
        {
            if (type is RuntimeTypeMetadata runtimeType)
                return Array.ConvertAll(runtimeType.TrackedAs, attribute =>
                {
                    var target = Array.Find(GetTypesSafe(), candidate =>
                        candidate.Identity == attribute.TrackedAs.AssemblyQualifiedName);
                    if (target == null)
                    {
                        var source = catalog.Find(attribute.TrackedAs);
                        if (source != null)
                            target = new RuntimeTrackerTypeMetadata(
                                source, attribute.TrackedAs);
                    }

                    if (target == null)
                        throw new InvalidOperationException("The actual TrackedAs target is not registered.");
                    return new SourceTrackedAsMetadata(target, attribute.Inherited);
                });

            var declared = type.ReadDeclaredTrackedAsAttributes();
            var result = new SourceTrackedAsMetadata[declared.Length];
            for (var index = 0; index < result.Length; index++)
            {
                var trackedAs = catalog.FindLogicalMetadata(declared[index].Identity) ??
                                throw new InvalidOperationException(
                                    "Declared TrackedAs target metadata is not published.");
                result[index] = new(WrapSource(trackedAs), declared[index].Inherited);
            }

            return result;
        }
    }
}
