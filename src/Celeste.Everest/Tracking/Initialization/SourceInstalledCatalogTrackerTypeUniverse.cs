using System;
using System.Collections.Generic;
using Celeste.Core.Reflection;
using Celeste.Everest.Modules.Runtime;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Tracking.Initialization
{
    public sealed class SourceInstalledCatalogTrackerTypeUniverse : ISourceInstalledTrackerTypeUniverse
    {
        private readonly SceneEntityCatalog catalog;

        private readonly Dictionary<ISourceTypeMetadata, ISourceTypeMetadata> sourceAdapters =
            new Dictionary<ISourceTypeMetadata, ISourceTypeMetadata>();

        private Celeste.Everest.Reflection.Runtime.SourceRuntimeTypeDiscovery RuntimeTypes =>
            (modules as Celeste.Everest.Reflection.Runtime.ISourceRuntimeTypeDiscoveryEnvironment)
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
                adapter = new Celeste.Everest.Reflection.Runtime.RuntimeTrackerTypeMetadata(type);
                sourceAdapters.Add(type, adapter);
            }

            return adapter;
        }

        public ISourceTypeMetadata EntityType =>
            WrapSource(catalog.Find(typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName)) ??
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
                string assemblyIdentity = requireOriginalAssemblyIdentity(module.GetType());
                if (string.IsNullOrEmpty(assemblyIdentity))
                    throw new InvalidOperationException("The source module assembly scope is not published.");
                if (assemblies.Add(assemblyIdentity))
                    types.AddRange(Array.ConvertAll(requireOriginalAssemblyTypes(assemblyIdentity), WrapSource));
            }

            if (RuntimeTypes != null) types.AddRange(RuntimeTypes.GetTypes());
            return types.ToArray();
        }

        // This explicitly enumerates already published source metadata. CLR loader
        // ReflectionTypeLoadException/partial-Type[] handling remains in TypeSafety,
        // not a fabricated failure or a fallback inventory in this representation.
        public ISourceTypeMetadata[] GetTypesSafe() => GetTypes();

        public SourceTrackedAsMetadata[] ReadDeclaredTrackedAsAttributes(ISourceTypeMetadata type)
        {
            if (type is Celeste.Everest.Reflection.Runtime.RuntimeTypeMetadata runtimeType)
            {
                return Array.ConvertAll(runtimeType.TrackedAs, attribute =>
                {
                    var target = Array.Find(GetTypesSafe(), candidate =>
                        candidate.Identity == attribute.TrackedAs.AssemblyQualifiedName);
                    if (target == null)
                    {
                        var source = catalog.Find(attribute.TrackedAs);
                        if (source != null)
                            target = new Celeste.Everest.Reflection.Runtime.RuntimeTrackerTypeMetadata(
                                source, attribute.TrackedAs);
                    }

                    if (target == null)
                        throw new InvalidOperationException("The actual TrackedAs target is not registered.");
                    return new SourceTrackedAsMetadata(target, attribute.Inherited);
                });
            }

            var declared = type.ReadDeclaredTrackedAsAttributes();
            var result = new SourceTrackedAsMetadata[declared.Length];
            for (int index = 0; index < result.Length; index++)
            {
                var trackedAs = catalog.FindLogicalMetadata(declared[index].Identity) ??
                                throw new InvalidOperationException(
                                    "Declared TrackedAs target metadata is not published.");
                result[index] = new SourceTrackedAsMetadata(WrapSource(trackedAs), declared[index].Inherited);
            }

            return result;
        }
    }
}
