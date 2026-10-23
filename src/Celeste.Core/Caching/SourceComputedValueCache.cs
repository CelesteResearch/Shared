using System.Collections.Generic;

namespace Celeste.Core.Caching
{
    public abstract class SourceComputedValueCache<TKey, TValue>
    {
        private readonly struct ValueNode
        {
            public LinkedListNode<TKey> Node { get; }
            public TValue Value { get; }

            public ValueNode(LinkedListNode<TKey> node, TValue value)
            {
                Node = node;
                Value = value;
            }
        }

        private readonly string name;
        private readonly int maxSize;
        private readonly Dictionary<TKey, ValueNode> cache = new();
        private readonly LinkedList<TKey> cacheOldestToNewest = new();
        private readonly ISourceCacheDiagnostics diagnostics;

        protected SourceComputedValueCache(string name, int maxSize, ISourceCacheDiagnostics diagnostics)
        {
            this.name = name;
            this.maxSize = maxSize;
            this.diagnostics = diagnostics;
        }

        public TValue GetCached(TKey key)
        {
            lock (cache)
            {
                if (cache.TryGetValue(key, out var entry))
                {
                    cacheOldestToNewest.Remove(entry.Node);
                    cacheOldestToNewest.AddLast(entry.Node);
                    return entry.Value;
                }

                TValue value = Compute(key);
                while (cache.Count >= maxSize)
                {
                    TKey oldest = cacheOldestToNewest.First.Value;
                    cache.Remove(oldest);
                    cacheOldestToNewest.RemoveFirst();
                }

                LinkedListNode<TKey> node = cacheOldestToNewest.AddLast(key);
                cache.Add(key, new ValueNode(node, value));
                diagnostics.CachedValue(name, key, value, cache.Count);
                return value;
            }
        }

        protected abstract TValue Compute(TKey key);

        public void Clear()
        {
            lock (cache)
            {
                cache.Clear();
                cacheOldestToNewest.Clear();
            }
        }
    }
}
