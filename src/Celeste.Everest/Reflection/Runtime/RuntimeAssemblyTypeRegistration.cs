using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Celeste.Core.Reflection;

namespace Celeste.Everest.Reflection.Runtime
{
    public sealed class RuntimeAssemblyTypeRegistration : IDisposable
    {
        private IDisposable discoveryRegistration;
        private IDisposable catalogRegistration;
        private Action rebuildTracker;
        private Action refreshConsumers;

        private RuntimeAssemblyTypeRegistration(Action rebuildTracker, Action refreshConsumers)
        {
            this.rebuildTracker = rebuildTracker;
            this.refreshConsumers = refreshConsumers;
        }

        public static IDisposable Register(SourceRuntimeTypeDiscovery discovery, Assembly assembly, Type[] types,
            Func<IEnumerable<ISourceTypeMetadata>, IDisposable> registerCatalog, Action rebuildTracker,
            Action refreshConsumers)
        {
            if (discovery == null) throw new ArgumentNullException(nameof(discovery));
            if (registerCatalog == null) throw new ArgumentNullException(nameof(registerCatalog));
            if (rebuildTracker == null) throw new ArgumentNullException(nameof(rebuildTracker));
            if (refreshConsumers == null) throw new ArgumentNullException(nameof(refreshConsumers));
            var registration = new RuntimeAssemblyTypeRegistration(rebuildTracker, refreshConsumers);
            try
            {
                registration.discoveryRegistration = discovery.Register(assembly, types);
                registration.catalogRegistration = registerCatalog(discovery.GetTypes().Where(type =>
                    type.RequireActualType().Assembly == assembly));
                rebuildTracker();
                refreshConsumers();
                return registration;
            }
            catch (Exception registrationFailure)
            {
                try
                {
                    registration.Dispose();
                }
                catch (Exception cleanupFailure)
                {
                    throw new AggregateException("Runtime assembly type registration and rollback failed.",
                        registrationFailure, cleanupFailure);
                }

                throw;
            }
        }

        public void Dispose()
        {
            var discovery = discoveryRegistration;
            var catalog = catalogRegistration;
            var rebuild = rebuildTracker;
            var refresh = refreshConsumers;
            discoveryRegistration = null;
            catalogRegistration = null;
            rebuildTracker = null;
            refreshConsumers = null;
            if (discovery == null && catalog == null) return;
            var failures = new List<Exception>();
            TryCleanup(() => discovery?.Dispose(), failures);
            TryCleanup(rebuild, failures);
            TryCleanup(() => catalog?.Dispose(), failures);
            TryCleanup(refresh, failures);
            if (failures.Count != 0)
                throw new AggregateException("Runtime assembly type release failed.", failures);
        }

        private static void TryCleanup(Action cleanup, List<Exception> failures)
        {
            try
            {
                cleanup?.Invoke();
            }
            catch (Exception failure)
            {
                failures.Add(failure);
            }
        }
    }
}
