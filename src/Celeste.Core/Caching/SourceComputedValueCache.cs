using System.Collections.Generic;

namespace Celeste.Core.Caching
{
    public abstract class SourceComputedValueCache<TKey, TValue>
    {
        private readonly struct ValueNode(LinkedListNode<TKey> node, TValue value)
        {
            public LinkedListNode<TKey> Node { get; } = node;
            public TValue Value { get; } = value;
        }

        private readonly string _name;
        private readonly int _maxSize;
        private readonly Dictionary<TKey, ValueNode> _cache = new();
        private readonly LinkedList<TKey> _cacheOldestToNewest = new();
        private readonly ISourceCacheDiagnostics _diagnostics;

        protected SourceComputedValueCache(string name, int maxSize, ISourceCacheDiagnostics diagnostics)
        {
            _name = name;
            _maxSize = maxSize;
            _diagnostics = diagnostics;
        }

        public TValue GetCached(TKey key)
        {
            lock (_cache)
            {
                if (_cache.TryGetValue(key, out var entry))
                {
                    _cacheOldestToNewest.Remove(entry.Node);
                    _cacheOldestToNewest.AddLast(entry.Node);
                    return entry.Value;
                }

                var value = Compute(key);
                while (_cache.Count >= _maxSize)
                {
                    var oldest = _cacheOldestToNewest.First.Value;
                    _cache.Remove(oldest);
                    _cacheOldestToNewest.RemoveFirst();
                }

                var node = _cacheOldestToNewest.AddLast(key);
                _cache.Add(key, new(node, value));
                _diagnostics.CachedValue(_name, key, value, _cache.Count);
                return value;
            }
        }

        protected abstract TValue Compute(TKey key);

        public void Clear()
        {
            lock (_cache)
            {
                _cache.Clear();
                _cacheOldestToNewest.Clear();
            }
        }
    }
}
