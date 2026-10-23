using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Threading;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    // A registration lease admits only assemblies loaded by its actual mod context.
    // The context resolver must use the loader's authenticated physical PE registry.
    public sealed class EverestModAssemblyFrameOwnership
    {
        private readonly Func<Assembly, EverestModuleMetadata> resolveContextOwner;
        private readonly ConcurrentDictionary<Assembly, EverestModuleMetadata> registrations = new();

        public EverestModAssemblyFrameOwnership(Func<Assembly, EverestModuleMetadata> resolveContextOwner)
        {
            this.resolveContextOwner = resolveContextOwner ??
                                       throw new ArgumentNullException(nameof(resolveContextOwner));
        }

        public IDisposable Register(EverestModuleMetadata owner, Assembly assembly)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            if (!registrations.TryAdd(assembly, owner))
                throw new InvalidOperationException("The mod assembly already owns frame admission: " +
                                                    assembly.FullName);
            return new Registration(this, assembly);
        }

        public bool TryGetAssemblyIdentity(Assembly assembly, out string identity)
        {
            identity = null;
            if (assembly == null || assembly.IsDynamic) return false;
            var contextOwner = resolveContextOwner(assembly);
            if (contextOwner == null) return false;
            // Dependencies retain their own context identity. A helper DLL from this
            // context shares the live primary registration, never its assembly name.
            foreach (var registration in registrations)
            {
                if (!ReferenceEquals(registration.Value, contextOwner)) continue;
                if (!ReferenceEquals(resolveContextOwner(registration.Key), contextOwner)) continue;
                identity = assembly.FullName;
                return true;
            }

            return false;
        }

        private sealed class Registration : IDisposable
        {
            private EverestModAssemblyFrameOwnership owner;
            private readonly Assembly assembly;

            public Registration(EverestModAssemblyFrameOwnership owner, Assembly assembly)
            {
                this.owner = owner;
                this.assembly = assembly;
            }

            public void Dispose()
            {
                Interlocked.Exchange(ref owner, null)?.registrations.TryRemove(assembly, out _);
            }
        }
    }
}
