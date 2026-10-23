using System;
using System.Collections.Generic;
using System.Threading;

namespace Celeste.Core.Reflection.Members
{
    public sealed partial class SourceMemberCatalog
    {
        private ISourceActualTypeBindingSource actualTypeBindingSource;

        private long explicitActualTypeBindingsRevision;

        private long cachedActualTypeBindingsRevision = -1;

        private int cachedActualTypeBindingCount;

        private RuntimeAssemblyTypeGroups runtimeAssemblyTypeGroups;

        private sealed class RuntimeAssemblyTypeGroups
        {
            internal readonly long Revision;
            internal readonly Dictionary<string, SourceTypeDefinition[]> Groups;

            internal RuntimeAssemblyTypeGroups(long revision, Dictionary<string, SourceTypeDefinition[]> groups)
            {
                Revision = revision;
                Groups = groups;
            }
        }

        public void BindActualTypeBindingSource(ISourceActualTypeBindingSource source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (actualTypeBindingSource != null)
                throw new InvalidOperationException("The actual source type registry is already borrowed.");
            foreach (var binding in actualTypes)
                ValidateBorrowedSourceIdentity(source, binding.Key, binding.Value);
            actualTypeBindingSource = source;
            explicitActualTypeBindingsRevision++;
        }

        private void ValidateBorrowedSourceIdentity(ISourceActualTypeBindingSource source, Type actualType, string key)
        {
            if (source == null) return;
            var definition = typeDefinitions[key];
            if (source.TryGetOriginalSourceType(actualType, out var assembly, out var identity)
                && !MatchesCanonicalTypeIdentity(assembly, identity, definition))
                throw new InvalidOperationException(
                    "The explicit actual type and borrowed runtime registry disagree on original identity: " +
                    actualType.FullName);
            if (!source.TryGetActualSourceType(definition.AssemblyIdentity, definition.Identity, out var forwardType)
                || forwardType == actualType) return;
            if (!source.TryGetSelectedActualSourceType(definition.AssemblyIdentity, definition.Identity,
                    out var selectedType)
                || selectedType != forwardType || !actualType.IsAssignableFrom(selectedType)
                || !source.TryGetOriginalSourceType(selectedType, out var selectedAssembly, out var selectedIdentity)
                || !MatchesCanonicalTypeIdentity(selectedAssembly, selectedIdentity, definition))
                throw new InvalidOperationException(
                    "The borrowed forward type is not a qualified selected derivative of the explicit source declaration: " +
                    actualType.FullName);
        }

        private bool MatchesCanonicalTypeIdentity(string assembly, string identity, SourceTypeDefinition definition)
        {
            if (!SourceTypeForwarders.ContainsForwarder(assembly, identity))
                return assembly == definition.AssemblyIdentity && identity == definition.Identity;
            return CanonicalTypeKey(assembly, identity) == definition.CanonicalKey;
        }

        private bool TryGetBorrowedTypeDefinition(Type actualType, out SourceTypeDefinition definition)
        {
            definition = null;
            if (actualTypeBindingSource == null || actualType == null
                                                || !actualTypeBindingSource.TryGetOriginalSourceType(actualType,
                                                    out var assembly, out var identity)) return false;
            var found = SourceTypeForwarders.ContainsForwarder(assembly, identity)
                ? typeDefinitions.TryGetValue(CanonicalTypeKey(assembly, identity), out definition)
                : typeDefinitionsByIdentity.TryGetValue((assembly, identity), out definition);
            if (!found)
                throw new InvalidOperationException("The borrowed actual type has no qualified original TypeDef: " +
                                                    identity);
            ValidateBorrowedSourceIdentity(actualTypeBindingSource, actualType, definition.CanonicalKey);
            return true;
        }

        private SourceTypeDefinition RequireActualTypeDefinition(Type actualType)
        {
            if (actualType == null) throw new ArgumentNullException(nameof(actualType));
            if (actualTypes.TryGetValue(actualType, out var key))
            {
                ValidateBorrowedSourceIdentity(actualTypeBindingSource, actualType, key);
                return typeDefinitions[key];
            }

            if (TryGetBorrowedTypeDefinition(actualType, out var definition)) return definition;
            throw new InvalidOperationException("The actual type has no qualified original source binding: " +
                                                actualType.FullName);
        }

        public bool UsesOriginalDeclarationMetadata(Type actualType)
        {
            if (actualType == null) return false;
            if (actualTypes.ContainsKey(actualType)) return true;
            if (!TryGetBorrowedTypeDefinition(actualType, out var definition)) return false;
            return !sourceTypes.TryGetValue(definition.CanonicalKey, out var declaration)
                   || declaration == actualType || !declaration.IsAssignableFrom(actualType);
        }

        private string RequireActualTypeKey(Type actualType)
        {
            if (actualType == null) throw new ArgumentNullException(nameof(actualType));
            if (actualTypes.TryGetValue(actualType, out var key))
            {
                ValidateBorrowedSourceIdentity(actualTypeBindingSource, actualType, key);
                return key;
            }

            var definition = RequireActualTypeDefinition(actualType);
            return definition.CanonicalKey;
        }

        public long ActualTypeBindingsRevision => explicitActualTypeBindingsRevision
                                                  + (actualTypeBindingSource?.ActualSourceBindingsRevision ?? 0);

        private IEnumerable<KeyValuePair<Type, string>> EnumerateOriginalTypeNames()
        {
            foreach (var binding in originalTypeNames)
            {
                ValidateBorrowedSourceIdentity(actualTypeBindingSource, binding.Key, actualTypes[binding.Key]);
                yield return binding;
            }

            if (actualTypeBindingSource == null) yield break;
            foreach (var actualType in actualTypeBindingSource.ActualSourceTypes)
            {
                if (actualTypes.ContainsKey(actualType)) continue;
                var definition = RequireActualTypeDefinition(actualType);
                yield return new(actualType, definition.Identity);
            }
        }

        public IEnumerable<Type> GetRuntimeAssemblyTypes(string assemblyIdentity)
        {
            if (assemblyIdentity == null) throw new ArgumentNullException(nameof(assemblyIdentity));
            var groups = GetRuntimeAssemblyTypeGroups();
            if (!groups.TryGetValue(assemblyIdentity, out var definitions)) yield break;
            foreach (var definition in definitions)
                yield return GetActualSourceType(definition.AssemblyIdentity, definition.Identity);
        }

        private Dictionary<string, SourceTypeDefinition[]> GetRuntimeAssemblyTypeGroups()
        {
            var revision = ActualTypeBindingsRevision;
            var cached = Volatile.Read(ref runtimeAssemblyTypeGroups);
            if (cached != null && cached.Revision == revision) return cached.Groups;

            var pending = new Dictionary<string, SortedDictionary<int, SourceTypeDefinition>>(StringComparer.Ordinal);
            foreach (var binding in EnumerateOriginalTypeNames())
            {
                var definition = RequireActualTypeDefinition(binding.Key);
                if (definition.AssemblyIdentity == null) continue;
                if (!pending.TryGetValue(definition.AssemblyIdentity, out var definitions))
                    pending.Add(definition.AssemblyIdentity,
                        definitions = new());
                definitions[definition.MetadataToken] = definition;
            }

            var groups = new Dictionary<string, SourceTypeDefinition[]>(pending.Count, StringComparer.Ordinal);
            foreach (var pair in pending)
            {
                var definitions = new SourceTypeDefinition[pair.Value.Count];
                pair.Value.Values.CopyTo(definitions, 0);
                groups.Add(pair.Key, definitions);
            }

            // A registration changed while the snapshot was built: use this result once,
            // then rebuild from the new revision rather than publishing stale groups.
            if (revision == ActualTypeBindingsRevision)
                Volatile.Write(ref runtimeAssemblyTypeGroups, new(revision, groups));
            return groups;
        }

        private int CountActualTypeBindings()
        {
            var revision = ActualTypeBindingsRevision;
            if (revision == cachedActualTypeBindingsRevision) return cachedActualTypeBindingCount;
            var count = actualTypes.Count;
            if (actualTypeBindingSource != null)
                foreach (var actualType in actualTypeBindingSource.ActualSourceTypes)
                    if (actualTypes.TryGetValue(actualType, out var key))
                    {
                        ValidateBorrowedSourceIdentity(actualTypeBindingSource, actualType, key);
                    }
                    else
                    {
                        RequireActualTypeDefinition(actualType);
                        count++;
                    }

            cachedActualTypeBindingCount = count;
            cachedActualTypeBindingsRevision = revision;
            return count;
        }
    }
}
