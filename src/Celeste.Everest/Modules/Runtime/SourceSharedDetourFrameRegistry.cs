using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Celeste.Everest.Runtime.Assemblies;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed class SourceSharedDetourFrameRegistry
    {
        private readonly Assembly sharedAssembly;
        private readonly SourceRuntimeModuleMetadata metadata;
        private readonly Dictionary<Type, int> owners = new();

        public SourceSharedDetourFrameRegistry(Assembly sharedAssembly, SourceRuntimeModuleMetadata metadata)
        {
            this.sharedAssembly = sharedAssembly ?? throw new ArgumentNullException(nameof(sharedAssembly));
            this.metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
        }

        public IDisposable Register(Type actualHelperType)
        {
            if (actualHelperType == null) throw new ArgumentNullException(nameof(actualHelperType));
            if (!ReferenceEquals(actualHelperType.Assembly, sharedAssembly))
                throw new InvalidOperationException(
                    "Only this capability's actual shared assembly can register a helper frame.");
            metadata.ResolveDefinition(actualHelperType);
            owners.TryGetValue(actualHelperType, out var count);
            owners[actualHelperType] = checked(count + 1);
            return new Lease(this, actualHelperType);
        }

        public bool TryValidate(MethodBase method, out string actualAssemblyIdentity)
        {
            if (method == null) throw new ArgumentNullException(nameof(method));
            actualAssemblyIdentity = null;
            var type = method.DeclaringType;
            if (type == null || !ReferenceEquals(type.Assembly, sharedAssembly)) return false;
            while (!owners.ContainsKey(type))
            {
                var parent = type.DeclaringType;
                if (parent == null || !type.IsNested ||
                    !type.IsDefined(typeof(CompilerGeneratedAttribute), false) ||
                    type.Module != parent.Module || type.Assembly != parent.Assembly) return false;
                type = parent;
            }

            metadata.ResolveDefinition(method);
            actualAssemblyIdentity = method.Module.Assembly.FullName;
            return true;
        }

        private void Release(Type type)
        {
            var count = owners[type];
            if (count == 1) owners.Remove(type);
            else owners[type] = count - 1;
        }

        private sealed class Lease : IDisposable
        {
            private SourceSharedDetourFrameRegistry registry;
            private Type type;

            public Lease(SourceSharedDetourFrameRegistry registry, Type type)
            {
                this.registry = registry;
                this.type = type;
            }

            public void Dispose()
            {
                if (registry == null) return;
                registry.Release(type);
                registry = null;
                type = null;
            }
        }
    }
}
