using System.Collections.Generic;

namespace Celeste.Everest.Text.BitmapFonts
{
    internal abstract class SourceStringCacheHelper
    {
        private readonly string name;
        private readonly int maxSize;
        private readonly IEverestEmojiProcess process;

        private readonly Dictionary<string, SourceStringCacheValueNode> cache =
            new Dictionary<string, SourceStringCacheValueNode>();

        private readonly LinkedList<string> cacheOldestToNewest = new LinkedList<string>();

        protected SourceStringCacheHelper(string name, int maxSize, IEverestEmojiProcess process)
        {
            this.name = name;
            this.maxSize = maxSize;
            this.process = process;
        }

        internal string GetCached(string key)
        {
            lock (cache)
            {
                if (cache.TryGetValue(key, out var value))
                {
                    cacheOldestToNewest.Remove(value.Node);
                    cacheOldestToNewest.AddLast(value.Node);
                    return value.Value;
                }

                string val = Compute(key);
                while (cache.Count >= maxSize)
                {
                    string value2 = cacheOldestToNewest.First.Value;
                    cache.Remove(value2);
                    cacheOldestToNewest.RemoveFirst();
                }

                LinkedListNode<string> node = cacheOldestToNewest.AddLast(key);
                cache.Add(key, new SourceStringCacheValueNode(node, val));
                process.Logger.VerboseEmojiCache(name, key, val, cache);
                return val;
            }
        }

        protected abstract string Compute(string key);

        internal void Clear()
        {
            lock (cache)
            {
                cache.Clear();
                cacheOldestToNewest.Clear();
            }
        }
    }
}
