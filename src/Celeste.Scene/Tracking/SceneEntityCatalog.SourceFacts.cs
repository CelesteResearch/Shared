using System;
using System.Collections.Generic;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityCatalog
    {
        // Imported PE names are lookup inputs, separate from the runtime registry key.
        private readonly Dictionary<(string AssemblyIdentity, string TypeIdentity), string>
            importedTypeMetadata = new();

        private SceneEntityType FindImportedTypeMetadata(string assemblyIdentity, string typeIdentity)
        {
            if (!importedTypeMetadata.TryGetValue((assemblyIdentity, typeIdentity), out var registryKey)) return null;
            return (trackingSnapshot?.Types ?? types).TryGetValue(registryKey, out var current) &&
                   current.Identity == typeIdentity
                   && current.LogicalAssemblyIdentity == assemblyIdentity
                ? current
                : null;
        }

        public void RegisterLogicalTypeFacts(string identity, string registryKey, string name, string assemblyIdentity,
            string assemblySimpleName, int metadataToken, bool isAbstract,
            string[] sourceBaseTypes, bool[] declaredTrackedInherited,
            Celeste.Core.Reflection.ISourceAssemblyMetadata assembly)
        {
            types.TryGetValue(registryKey, out var previous);
            var definition = new SceneEntityType(registryKey, sourceBaseTypes,
                previous == null ? Array.Empty<string>() : previous.TrackedAs);
            definition.ConfigureDeclaredSourceFacts(identity, name, assemblyIdentity, assemblySimpleName,
                metadataToken, isAbstract, declaredTrackedInherited, this, assembly);
            types[registryKey] = definition;
            importedTypeMetadata[(assemblyIdentity, identity)] = registryKey;
            actualSourceBindingsRevision++;
            RepublishTrackingSnapshot();
        }

        public SceneEntityType FindLogicalMetadata(string identity)
        {
            foreach (var definition in (trackingSnapshot?.Types ?? types).Values)
                if (definition.Identity == identity)
                    return definition;
            return null;
        }

        public void PublishDeclaredPoolFacts(string identity, int pooledAttributeCount,
            bool hasPublicParameterlessConstructor)
        {
            types[identity].ConfigureDeclaredPoolFacts(pooledAttributeCount, hasPublicParameterlessConstructor);
            RepublishTrackingSnapshot();
        }

        public void PublishDeclaredTrackedAliases(string identity,
            Celeste.Core.Reflection.SourceTrackedAliasMetadata[] aliases)
        {
            types[identity].ConfigureDeclaredTrackedAliases(aliases);
            RepublishTrackingSnapshot();
        }

        public void BindRegisteredActualType(Type actualType, string identity)
        {
            if (actualType == null) throw new ArgumentNullException(nameof(actualType));
            if (!runtimeTypes.TryGetValue(actualType.FullName, out var existing) || existing.SourceType != identity)
                throw new InvalidOperationException("The exact source runtime mapping is not published: " + identity);
            RegisterRuntimeType(actualType, identity);
        }

        public void SelectLogicalActualType(Type actualType, string logicalIdentity)
        {
            if (actualType == null) throw new ArgumentNullException(nameof(actualType));
            SceneEntityType definition = null;
            foreach (var candidate in types.Values)
                if (candidate.Identity == logicalIdentity)
                {
                    definition = candidate;
                    break;
                }

            if (definition == null)
                throw new InvalidOperationException("Logical type facts are not registered: " + logicalIdentity);
            if (!runtimeTypes.TryGetValue(actualType.FullName, out var registration) ||
                registration.ActualType != actualType || registration.SourceType != definition.RegistryKey)
                throw new InvalidOperationException(
                    "Actual CLR type is not registered for logical type: " + logicalIdentity);
            definition.SelectActualType(actualType);
            actualSourceBindingsRevision++;
            RepublishTrackingSnapshot();
        }

        public Type RequireActualTypeForLogicalIdentity(string identity)
        {
            var definition = FindLogicalMetadata(identity) ?? Find(identity);
            string registryKey = definition?.RegistryKey ?? identity;
            if (definition is { HasRuntimeTypeFacts: true }) return definition.RequireActualType();
            if (definition != null && definition.SelectedActualType != null)
            {
                Type selectedType = definition.SelectedActualType;
                if (!runtimeTypes.TryGetValue(selectedType.FullName, out var selectedRegistration) ||
                    selectedRegistration.ActualType != selectedType || selectedRegistration.SourceType != registryKey)
                    throw new InvalidOperationException(
                        "The selected actual type has no matching runtime registration: " +
                        identity);
                return selectedType;
            }

            Type result = null;
            foreach (var registration in runtimeTypes.Values)
            {
                if (registration.SourceType != registryKey || registration.ActualType == null) continue;
                if (result != null && result != registration.ActualType)
                    throw new InvalidOperationException("Multiple actual CLR bindings for logical type: " + identity);
                result = registration.ActualType;
            }

            return result ?? throw new InvalidOperationException("Actual CLR type is not qualified: " + identity);
        }

        public Celeste.Core.Reflection.ISourceTypeMetadata[] GetLogicalAssemblyTypeMetadata(string assemblyIdentity)
        {
            var definitions = new List<SceneEntityType>();
            foreach (var definition in (trackingSnapshot?.Types ?? types).Values)
                if (definition.LogicalAssemblyIdentity == assemblyIdentity && definition.LogicalMetadataToken != 0)
                    definitions.Add(definition);
            definitions.Sort((left, right) => left.LogicalMetadataToken.CompareTo(right.LogicalMetadataToken));
            var result = new Celeste.Core.Reflection.ISourceTypeMetadata[definitions.Count];
            for (int index = 0; index < result.Length; index++) result[index] = definitions[index];
            return result;
        }

        public Celeste.Core.Reflection.ISourceTypeMetadata[] GetRuntimeAssemblyTypeMetadata(string assemblyIdentity)
        {
            var result = new List<Celeste.Core.Reflection.ISourceTypeMetadata>();
            foreach (var definition in GetLogicalAssemblyTypeMetadata(assemblyIdentity))
                if (TryGetActualSourceType(assemblyIdentity, definition.Identity, out _))
                    result.Add(definition);
            return result.ToArray();
        }

        public Type[] GetLogicalAssemblyTypes(string assemblyIdentity)
        {
            var definitions = new List<SceneEntityType>();
            foreach (var definition in (trackingSnapshot?.Types ?? types).Values)
                if (definition.LogicalAssemblyIdentity == assemblyIdentity && definition.LogicalMetadataToken != 0)
                    definitions.Add(definition);
            definitions.Sort((left, right) => left.LogicalMetadataToken.CompareTo(right.LogicalMetadataToken));
            var result = new Type[definitions.Count];
            for (int index = 0; index < result.Length; index++)
            {
                var definition = definitions[index];
                result[index] = RequireActualTypeForLogicalIdentity(definition.Name);
                if (result[index].IsAbstract != definition.LogicalIsAbstract)
                    throw new InvalidOperationException("Actual CLR abstract flag differs from logical source: " +
                                                        definition.Name);
            }

            return result;
        }

        public bool[] ReadDeclaredTrackedAttributes(Type actualType)
        {
            var definition = Find(actualType) ?? throw new InvalidOperationException("Actual type is not registered.");
            if ((!definition.HasManagedTypeFacts && definition.LogicalMetadataToken == 0) ||
                definition.DeclaredTrackedInherited == null)
                throw new InvalidOperationException("Declared source attribute metadata is not published.");
            return (bool[])definition.DeclaredTrackedInherited.Clone();
        }
    }
}
