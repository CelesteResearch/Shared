using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Celeste.Core.Reflection;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityCatalog : ISourceActualTypeBindingSource
    {
        private long actualSourceBindingsRevision;
        private long forwardBindingsRevision = -1;

        private readonly Dictionary<string, SceneRuntimeTypeRegistration> forwardBindings =
            new Dictionary<string, SceneRuntimeTypeRegistration>(StringComparer.Ordinal);

        private readonly HashSet<string> ambiguousForwardBindings = new HashSet<string>(StringComparer.Ordinal);
        private static readonly Type ClrRuntimeTypeClass = typeof(object).GetType();
        private static readonly Func<Type, bool> IsFunctionPointer = CreateFunctionPointerPredicate();
        private RuntimeTypeReverseSnapshot runtimeTypesByActualType;

        private static Func<Type, bool> CreateFunctionPointerPredicate()
        {
            // Newer CLR versions can expose function pointer Types with a null FullName.
            // Bind the public virtual getter once; older Mono runtimes lack this property.
            var getter = typeof(Type).GetProperty("IsFunctionPointer")?.GetGetMethod();
            return getter == null ? null : (Func<Type, bool>)getter.CreateDelegate(typeof(Func<Type, bool>));
        }

        private sealed class RuntimeTypeReferenceComparer : IEqualityComparer<Type>
        {
            internal static readonly RuntimeTypeReferenceComparer Instance = new RuntimeTypeReferenceComparer();

            public bool Equals(Type left, Type right) => ReferenceEquals(left, right);
            public int GetHashCode(Type value) => RuntimeHelpers.GetHashCode(value);
        }

        private sealed class RuntimeTypeReverseSnapshot
        {
            internal readonly long Revision;
            internal readonly Dictionary<Type, SceneRuntimeTypeRegistration> Registrations;

            internal RuntimeTypeReverseSnapshot(long revision,
                Dictionary<Type, SceneRuntimeTypeRegistration> registrations)
            {
                Revision = revision;
                Registrations = registrations;
            }
        }

        private Dictionary<Type, SceneRuntimeTypeRegistration> GetRuntimeTypesByActualType()
        {
            var revision = actualSourceBindingsRevision;
            if (runtimeTypesByActualType?.Revision == revision)
                return runtimeTypesByActualType.Registrations;
            var registrations = new Dictionary<Type, SceneRuntimeTypeRegistration>(
                RuntimeTypeReferenceComparer.Instance);
            foreach (var pair in runtimeTypes)
            {
                var registration = pair.Value;
                var actualType = registration.ActualType;
                if (actualType != null && actualType.GetType() == ClrRuntimeTypeClass &&
                    string.Equals(pair.Key, actualType.FullName, StringComparison.Ordinal))
                    registrations.Add(actualType, registration);
            }

            if (revision == actualSourceBindingsRevision)
                runtimeTypesByActualType = new RuntimeTypeReverseSnapshot(revision, registrations);
            return registrations;
        }

        private void RefreshForwardBindings()
        {
            if (forwardBindingsRevision == actualSourceBindingsRevision) return;
            forwardBindings.Clear();
            ambiguousForwardBindings.Clear();
            foreach (var registration in runtimeTypes.Values)
            {
                if (registration.ActualType == null) continue;
                if (forwardBindings.TryGetValue(registration.SourceType, out var existing)
                    && existing.ActualType != registration.ActualType)
                    ambiguousForwardBindings.Add(registration.SourceType);
                else forwardBindings[registration.SourceType] = registration;
            }

            forwardBindingsRevision = actualSourceBindingsRevision;
        }

        public long ActualSourceBindingsRevision => actualSourceBindingsRevision;

        public IEnumerable<Type> ActualSourceTypes
        {
            get
            {
                foreach (var registration in runtimeTypes.Values)
                {
                    if (registration.ActualType == null) continue;
                    if (!types.TryGetValue(registration.SourceType, out var definition)
                        || definition.LogicalMetadataToken == 0) continue;
                    yield return registration.ActualType;
                }
            }
        }

        public bool TryGetSelectedActualSourceType(string assemblyIdentity, string originalIdentity,
            out Type actualType)
        {
            var definition = FindImportedTypeMetadata(assemblyIdentity, originalIdentity);
            actualType = null;
            if (definition == null || definition.LogicalMetadataToken == 0
                                   || definition.Identity != originalIdentity ||
                                   definition.LogicalAssemblyIdentity != assemblyIdentity
                                   || definition.SelectedActualType == null) return false;
            return TryGetActualSourceType(assemblyIdentity, originalIdentity, out actualType);
        }

        public bool TryGetActualSourceType(string assemblyIdentity, string originalIdentity, out Type actualType)
        {
            var definition = FindImportedTypeMetadata(assemblyIdentity, originalIdentity);
            actualType = null;
            if (definition == null || definition.LogicalMetadataToken == 0
                                   || definition.Identity != originalIdentity ||
                                   definition.LogicalAssemblyIdentity != assemblyIdentity) return false;
            if (definition.SelectedActualType != null)
            {
                actualType = definition.SelectedActualType;
                if (!runtimeTypes.TryGetValue(actualType.FullName, out var selected)
                    || selected.ActualType != actualType || selected.SourceType != definition.RegistryKey)
                    throw new InvalidOperationException(
                        "The selected actual type has no matching runtime registration: " +
                        originalIdentity);
                return true;
            }

            RefreshForwardBindings();
            if (ambiguousForwardBindings.Contains(definition.RegistryKey))
                throw new InvalidOperationException(
                    "Multiple actual types require an explicit selected source binding: " +
                    originalIdentity);
            if (forwardBindings.TryGetValue(definition.RegistryKey, out var registration))
                actualType = registration.ActualType;
            return actualType != null;
        }

        public bool TryGetOriginalSourceType(Type actualType, out string assemblyIdentity, out string originalIdentity)
        {
            assemblyIdentity = null;
            originalIdentity = null;
            if (actualType == null) return false;
            SceneRuntimeTypeRegistration registration;
            if (actualType.GetType() == ClrRuntimeTypeClass &&
                (!actualType.IsGenericType || actualType.IsGenericTypeDefinition)
                && !actualType.HasElementType &&
                !actualType.IsGenericParameter
                && (IsFunctionPointer == null ||
                    !IsFunctionPointer(actualType)))
            {
                if (!GetRuntimeTypesByActualType().TryGetValue(actualType, out registration)
                    || registration.ActualType != actualType) return false;
            }
            else if (!runtimeTypes.TryGetValue(actualType.FullName, out registration)
                     || registration.ActualType != actualType) return false;

            if (!types.TryGetValue(registration.SourceType, out var definition)
                || definition.LogicalMetadataToken == 0) return false;
            assemblyIdentity = definition.LogicalAssemblyIdentity;
            originalIdentity = definition.Identity;
            return true;
        }
    }
}
