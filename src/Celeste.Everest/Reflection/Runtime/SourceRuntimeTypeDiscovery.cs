using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Celeste.Core.Reflection;
using Celeste.Core.Reflection.Runtime;
using Celeste.Everest.Tracking.Attributes;

namespace Celeste.Everest.Reflection.Runtime
{
    public sealed class SourceRuntimeTypeDiscovery : ISourceRuntimeTypeAliasResolver
    {
        private readonly Dictionary<Assembly, RuntimeAssemblyMetadata> assemblies = new();

        private readonly Dictionary<Assembly, Type[]> physicalAssemblyTypes = new();

        private readonly List<Assembly> order = [];

        public long Revision { get; private set; }

        public RuntimeTypeAliasRegistry TypeAliases { get; } = new();

        public Type ResolveRuntimeTypeAlias(string name, bool ignoreCase = false)
        {
            return TypeAliases.ResolveRuntimeTypeAlias(name, ignoreCase);
        }

        public bool RuntimeTypeNameMatches(Type type, string name, bool allowShortName = false,
            bool ignoreCase = false)
        {
            return TypeAliases.RuntimeTypeNameMatches(type, name, allowShortName, ignoreCase);
        }

        public bool ContainsAssembly(Assembly assembly)
        {
            return assemblies.ContainsKey(assembly);
        }

        public IDisposable Register(Assembly assembly, Type[] types)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            if (types == null) throw new ArgumentNullException(nameof(types));
            if (assemblies.ContainsKey(assembly))
                throw new InvalidOperationException("The runtime assembly is already registered.");
            if (types.Any(type => type == null || type.Assembly != assembly))
                throw new ArgumentException("Every discovered type must belong to the registered assembly.",
                    nameof(types));
            // A loaded physical image has a fixed declared-type list. Keep its full
            // list, including open generics, separate from registered closed types.
            // Dynamic/custom assemblies and partially loadable images keep GetTypes.
            Type[] physicalTypes = null;
            if (!assembly.IsDynamic && assembly.GetType() == typeof(SourceRuntimeTypeDiscovery).Assembly.GetType())
                try
                {
                    physicalTypes = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException)
                {
                    // Discovery can register a supplied partial list. Aggregate
                    // reflection must retain its original GetTypes failure path.
                }

            var metadata = new RuntimeAssemblyMetadata(assembly);
            metadata.PublishTypes([
                .. CollectOwnedClosedTypes(assembly, types)
                    .Select(type => (ISourceTypeMetadata)new RuntimeTypeMetadata(type, metadata)),
            ]);
            var aliasRegistration =
                TypeAliases.Register(assembly, metadata.GetTypes().Select(type => type.RequireActualType()));
            assemblies.Add(assembly, metadata);
            if (physicalTypes != null) physicalAssemblyTypes.Add(assembly, physicalTypes);
            order.Add(assembly);
            Revision++;
            return new Registration(this, assembly, aliasRegistration);
        }

        private static IEnumerable<Type> CollectOwnedClosedTypes(Assembly assembly, Type[] types)
        {
            var seen = new HashSet<Type>();
            var pending = new List<Type>();
            foreach (var type in types)
                if (!type.ContainsGenericParameters && seen.Add(type))
                    pending.Add(type);
            for (var index = 0; index < pending.Count; index++)
            {
                var type = pending[index];
                AddOwned(type.BaseType);
                foreach (var attribute in type.GetCustomAttributes<EverestTrackedAsAttribute>(false))
                    AddOwned(attribute.TrackedAs);
            }

            return pending;

            void AddOwned(Type type)
            {
                // An external target keeps its real provider's registration and lifetime.
                if (type != null && type.Assembly == assembly && !type.ContainsGenericParameters && seen.Add(type))
                    pending.Add(type);
            }
        }

        public ISourceTypeMetadata[] GetTypes()
        {
            return
            [
                .. order.SelectMany(assembly => assemblies[assembly].GetTypes()),
            ];
        }

        public IEnumerable<Type> GetAssemblyTypes(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            var types = physicalAssemblyTypes.TryGetValue(assembly, out var snapshot)
                ? snapshot
                : assembly.GetTypes();
            foreach (var type in types) yield return type;
        }

        private sealed class Registration : IDisposable
        {
            private SourceRuntimeTypeDiscovery owner;
            private Assembly assembly;
            private IDisposable aliasRegistration;

            public Registration(SourceRuntimeTypeDiscovery owner, Assembly assembly, IDisposable aliasRegistration)
            {
                this.owner = owner;
                this.assembly = assembly;
                this.aliasRegistration = aliasRegistration;
            }

            public void Dispose()
            {
                if (owner == null) return;
                aliasRegistration.Dispose();
                aliasRegistration = null;
                owner.assemblies.Remove(assembly);
                owner.physicalAssemblyTypes.Remove(assembly);
                owner.order.Remove(assembly);
                owner.Revision++;
                owner = null;
                assembly = null;
            }
        }
    }
}
