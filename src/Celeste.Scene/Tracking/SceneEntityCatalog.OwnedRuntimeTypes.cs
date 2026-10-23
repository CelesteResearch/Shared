using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Celeste.Core.Reflection;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityCatalog
    {
        private readonly Dictionary<Type, SceneEntityType> ownedRuntimeTypes = new();
        private readonly HashSet<object> runtimeTypeOwners = new(new ReferenceOwnerComparer());

        public IDisposable RegisterOwnedRuntimeTypes(object owner, IEnumerable<ISourceTypeMetadata> definitions)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (definitions == null) throw new ArgumentNullException(nameof(definitions));
            if (runtimeTypeOwners.Contains(owner))
                throw new InvalidOperationException("Runtime type owner is already registered.");
            var pending = new Dictionary<Type, SceneEntityType>();
            var keys = new HashSet<string>(StringComparer.Ordinal);
            foreach (var metadata in definitions)
            {
                if (metadata == null)
                    throw new ArgumentException("A runtime type definition is null.", nameof(definitions));
                var actual = metadata.RequireActualType();
                if (actual == null || actual.FullName == null || actual.ContainsGenericParameters)
                    throw new ArgumentException("A closed actual CLR type is required.", nameof(definitions));
                if (ownedRuntimeTypes.ContainsKey(actual) || pending.ContainsKey(actual)
                                                          || types.ContainsKey(metadata.RegistryKey) ||
                                                          !keys.Add(metadata.RegistryKey)
                                                          || (runtimeTypes.TryGetValue(actual.FullName,
                                                              out var source) && source.ActualType == actual))
                    throw new InvalidOperationException("Runtime type is already registered: " + actual);
                var bases = new List<string>();
                for (var type = actual.BaseType; type != null; type = type.BaseType)
                    bases.Add(type.FullName);
                var definition = new SceneEntityType(metadata.RegistryKey, bases, (string[])[]);
                definition.ConfigureRuntimeTypeFacts(metadata, this);
                pending.Add(actual, definition);
            }

            foreach (var entry in pending)
            {
                types.Add(entry.Value.Name, entry.Value);
                ownedRuntimeTypes.Add(entry.Key, entry.Value);
            }

            runtimeTypeOwners.Add(owner);
            actualSourceBindingsRevision++;
            var lease = new RuntimeTypesLease(this, owner, pending);
            try
            {
                RepublishTrackingSnapshot();
                return lease;
            }
            catch (Exception registrationError)
            {
                try
                {
                    lease.Dispose();
                }
                catch (Exception cleanupError)
                {
                    throw new AggregateException(registrationError, cleanupError);
                }

                throw;
            }
        }

        private sealed class RuntimeTypesLease : IDisposable
        {
            private SceneEntityCatalog catalog;
            private object owner;
            private Dictionary<Type, SceneEntityType> registrations;

            internal RuntimeTypesLease(SceneEntityCatalog catalog, object owner,
                Dictionary<Type, SceneEntityType> registrations)
            {
                this.catalog = catalog;
                this.owner = owner;
                this.registrations = registrations;
            }

            public void Dispose()
            {
                if (catalog == null) return;
                // Remove owner types from the tracker universe before releasing this lease.
                foreach (var entry in registrations)
                {
                    catalog.ownedRuntimeTypes.Remove(entry.Key);
                    catalog.types.Remove(entry.Value.Name);
                    catalog.trackedTypes.Remove(entry.Value.Name);
                }

                catalog.runtimeTypeOwners.Remove(owner);
                catalog.actualSourceBindingsRevision++;
                try
                {
                    catalog.RepublishTrackingSnapshot();
                }
                finally
                {
                    registrations.Clear();
                    registrations = null;
                    owner = null;
                    catalog = null;
                }
            }
        }

        private sealed class ReferenceOwnerComparer : IEqualityComparer<object>
        {
            public new bool Equals(object left, object right)
            {
                return ReferenceEquals(left, right);
            }

            public int GetHashCode(object value)
            {
                return RuntimeHelpers.GetHashCode(value);
            }
        }
    }
}
