using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Celeste.Core.Diagnostics;
using Celeste.Core.Reflection;

namespace Celeste.Core.Pooling
{
    // One original Engine.Pooler lifetime. Scene EntityRemoved publishes into these exact queues.
    public sealed class SourceEntityPoolRegistry
    {
        public sealed class Pool
        {
            public readonly string SourceType;
            public readonly Type RuntimeType;
            public readonly Queue<object> Entities = new();
            internal Func<object> Create;
            internal ConditionalWeakTable<object, Pool> ScopedOwners;

            internal Pool(string sourceType, Type runtimeType, Func<object> create)
            {
                SourceType = sourceType;
                RuntimeType = runtimeType;
                Create = create;
            }
        }

        private readonly Dictionary<Type, Pool> _pools = new();

        // Explicit qualified generic requests index the same selected physical pool.
        // Only profile publication fills this index; removal never consults it.
        private readonly Dictionary<Type, Pool> _requestPools = new();

        public IEnumerable<KeyValuePair<Type, Pool>> EnumeratePools()
        {
            return _pools;
        }

        public int Count => _pools.Count;

        public void Log(ISourceObjectLog output, ISourceLogicalTypeNameMetadata metadata)
        {
            if (_pools.Count == 0)
                output.Log("No Entity types are marked as Pooled!");
            foreach (var pool in _pools)
            {
                var obj = string.Concat(metadata.GetLogicalTypeName(pool.Value.SourceType), " : ",
                    pool.Value.Entities.Count);
                output.Log(obj);
            }
        }

        public void InitializeFromUniverse(ISourceTrackerTypeUniverse universe)
        {
            var types = universe.GetTypes();
            foreach (var type in types)
                if (type.DeclaredPooledAttributeCount != 0)
                {
                    if (!universe.EntityType.IsAssignableFrom(type))
                        throw new("Type '" + type.TypeName +
                                  "' cannot be Pooled because it doesn't derive from Entity");
                    if (!type.HasPublicParameterlessConstructor)
                        throw new("Type '" + type.TypeName +
                                  "' cannot be Pooled because it doesn't have a parameterless constructor");
                    var actualType = type.RequireActualType();
                    _pools.Add(actualType, new(type.RegistryKey, actualType, null));
                }
        }

        public void ConfigureConstructor<T>(Func<T> create)
            where T : class
        {
            if (create == null)
                throw new ArgumentNullException(nameof(create));
            var pool = _pools[typeof(T)];
            if (pool.Create != null)
                throw new InvalidOperationException("The source pool constructor is already configured.");
            pool.Create = () => create();
        }

        public void ConfigureConstructor<TRequest, TActual>(string sourceType, Func<TActual> create)
            where TRequest : class where TActual : TRequest
        {
            if (create == null)
                throw new ArgumentNullException(nameof(create));
            var pool = _pools[typeof(TActual)];
            if (!string.Equals(pool.SourceType, sourceType, StringComparison.Ordinal))
                throw new InvalidOperationException("The selected actual pool has a different source identity.");
            if (typeof(TRequest) == typeof(TActual) || _pools.ContainsKey(typeof(TRequest)))
                throw new InvalidOperationException("The generic request must refer to the selected profile pool.");
            if (pool.Create != null)
                throw new InvalidOperationException("The source pool constructor is already configured.");
            _requestPools.Add(typeof(TRequest), pool);
            pool.Create = () => create();
        }

        private bool TryGetRequestPool(Type requestType, out Pool pool)
        {
            return _pools.TryGetValue(requestType, out pool) || _requestPools.TryGetValue(requestType, out pool);
        }

        private static object Construct(Pool pool)
        {
            var create = pool.Create ??
                         throw new InvalidOperationException("The actual source pool constructor is not qualified.");
            return create();
        }

        public void ClearAllQueues()
        {
            foreach (var pool in _pools)
                pool.Value.Entities.Clear();
        }

        public void Register<T>(string sourceType, Func<T> create)
            where T : class
        {
            if (sourceType == null)
                throw new ArgumentNullException(nameof(sourceType));
            if (create == null)
                throw new ArgumentNullException(nameof(create));
            _pools.Add(typeof(T), new(sourceType, typeof(T), () => create()));
        }

        public IDisposable RegisterScoped<T>(Func<T> create)
            where T : class
        {
            Register(typeof(T).FullName, create);
            var pool = _pools[typeof(T)];
            pool.ScopedOwners = new();
            var construct = pool.Create;
            pool.Create = () =>
            {
                var entity = construct();
                pool.ScopedOwners.Add(entity, pool);
                return entity;
            };
            return new PoolRegistration(this, pool);
        }

        private sealed class PoolRegistration(SourceEntityPoolRegistry owner, Pool pool) : IDisposable
        {
            private SourceEntityPoolRegistry _owner = owner;

            // ReSharper disable once ReplaceWithPrimaryConstructorParameter
            private readonly Pool _pool = pool;

            public void Dispose()
            {
                if (_owner == null)
                    return;
                if (_owner._pools.TryGetValue(_pool.RuntimeType, out var current) && ReferenceEquals(current, _pool))
                    _owner._pools.Remove(_pool.RuntimeType);
                _owner = null;
            }
        }

        // Required pooled source types have no unregistered construction path.
        public T Create<T>()
            where T : class
        {
            var pool = _pools.TryGetValue(typeof(T), out var direct) ? direct : _requestPools[typeof(T)];
            return pool.Entities.Count == 0 ? (T)Construct(pool) : (T)pool.Entities.Dequeue();
        }

        public T Create<T>(Func<T> createUnpooled)
            where T : class
        {
            if (TryGetRequestPool(typeof(T), out var pool))
                return pool.Entities.Count == 0 ? (T)Construct(pool) : (T)pool.Entities.Dequeue();
            if (createUnpooled == null)
                throw new ArgumentNullException(nameof(createUnpooled));
            return createUnpooled();
        }

        public void EntityRemoved(object entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (_pools.TryGetValue(entity.GetType(), out var pool) && (pool.ScopedOwners == null ||
                                                                       (pool.ScopedOwners.TryGetValue(entity,
                                                                            out var generation) &&
                                                                        ReferenceEquals(generation, pool))))
                pool.Entities.Enqueue(entity);
        }
    }
}
