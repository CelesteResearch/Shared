using System;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityCatalog
    {
        public IDisposable RegisterScopedLogicalActualType(Type actualType, string logicalIdentity)
        {
            if (actualType == null) throw new ArgumentNullException(nameof(actualType));
            if (logicalIdentity == null) throw new ArgumentNullException(nameof(logicalIdentity));
            var logicalMetadata = FindLogicalMetadata(logicalIdentity)
                                  ?? throw new ArgumentException("Logical type facts are not registered.",
                                      nameof(logicalIdentity));
            var definition = types[logicalMetadata.RegistryKey];
            var previousActual = RequireActualTypeForLogicalIdentity(logicalIdentity);
            if (actualType.FullName == null || actualType.ContainsGenericParameters ||
                actualType == previousActual || !previousActual.IsAssignableFrom(actualType))
                throw new ArgumentException("A closed derived actual type is required.", nameof(actualType));
            runtimeTypes.TryGetValue(actualType.FullName, out var previousRuntime);
            ownedRuntimeTypes.TryGetValue(actualType, out var previousOwned);
            if (previousRuntime?.ActualType != null && previousRuntime.ActualType != actualType)
                throw new InvalidOperationException("The runtime full name belongs to another actual type.");
            var lease = new LogicalActualTypeLease(this, definition, actualType, definition.SelectedActualType,
                previousRuntime, previousOwned);
            ownedRuntimeTypes.Remove(actualType);
            runtimeTypes[actualType.FullName] =
                new SceneRuntimeTypeRegistration(actualType.FullName, definition.RegistryKey, actualType);
            definition.SelectActualType(actualType);
            actualSourceBindingsRevision++;
            try
            {
                RebuildActualTrackedTypeCounts();
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

        private sealed class LogicalActualTypeLease : IDisposable
        {
            private SceneEntityCatalog catalog;
            private readonly SceneEntityType definition;
            private readonly Type actualType;
            private readonly Type previousSelected;
            private readonly SceneRuntimeTypeRegistration previousRuntime;
            private readonly SceneEntityType previousOwned;

            public LogicalActualTypeLease(SceneEntityCatalog catalog, SceneEntityType definition,
                Type actualType, Type previousSelected, SceneRuntimeTypeRegistration previousRuntime,
                SceneEntityType previousOwned)
            {
                this.catalog = catalog;
                this.definition = definition;
                this.actualType = actualType;
                this.previousSelected = previousSelected;
                this.previousRuntime = previousRuntime;
                this.previousOwned = previousOwned;
            }

            public void Dispose()
            {
                if (catalog == null) return;
                if (definition.SelectedActualType != actualType)
                    throw new InvalidOperationException(
                        "Dispose logical actual type scopes in reverse registration order.");
                var owner = catalog;
                definition.SelectActualType(previousSelected);
                if (previousRuntime == null) owner.runtimeTypes.Remove(actualType.FullName);
                else owner.runtimeTypes[actualType.FullName] = previousRuntime;
                if (previousOwned != null) owner.ownedRuntimeTypes.Add(actualType, previousOwned);
                owner.actualSourceBindingsRevision++;
                catalog = null;
                owner.RebuildActualTrackedTypeCounts();
                owner.RepublishTrackingSnapshot();
            }
        }
    }
}
