using Celeste.Graphics.Content.VirtualAssets;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;
using System.Text;

namespace Celeste.Graphics.Content.Atlas
{
    public class AtlasData : global::Celeste.Graphics.Animation.IAnimationFrameSource
    {
        public virtual AtlasEntry this[string id]
        {
            get => Entries[id];
            set => Entries[id] = value;
        }

        public bool Has(string id) => Entries.ContainsKey(id);

        public AtlasEntry GetOrDefault(string id, AtlasEntry defaultTexture) =>
            string.IsNullOrEmpty(id) || !Has(id) ? defaultTexture : Entries[id];

        public bool HasAtlasSubtextures(string key) => HasAtlasSubtexturesAt(key, 0);

        public bool HasAtlasSubtexturesAt(string key, int index)
        {
            if (orderedTexturesCache.TryGetValue(key, out var value))
            {
                if (index >= 0) return index < value.Count;
                return false;
            }

            return GetAtlasSubtextureFromAtlasAt(key, index) != null;
        }

        public AtlasEntry Frame(string key, int index) => GetAtlasSubtexturesAt(key, index);
        public List<AtlasEntry> Frames(string key) => GetAtlasSubtextures(key);

        public List<VirtualTexture> Sources;

        public void Dispose()
        {
            foreach (VirtualTexture source in Sources) source.Dispose();
            Sources.Clear();
            Entries.Clear();
        }

        private Dictionary<string, List<AtlasEntry>> orderedTexturesCache = new Dictionary<string, List<AtlasEntry>>();

        public List<AtlasEntry> GetAtlasSubtextures(string key)
        {
            if (!orderedTexturesCache.TryGetValue(key, out var result))
            {
                result = new List<AtlasEntry>();
                for (int index = 0;; index++)
                {
                    var texture = GetAtlasSubtextureFromAtlasAt(key, index);
                    if (texture == null) break;
                    result.Add(texture);
                }

                orderedTexturesCache.Add(key, result);
            }

            // Everest's lookup returns a fresh fallback sequence without caching it.
            // Vanilla atlases have no configured fallback and keep the empty result.
            if (result.Count == 0)
            {
                var fallback = GetFallback();
                if (fallback != null) return new List<AtlasEntry> { fallback };
            }

            return result;
        }

        public AtlasEntry GetAtlasSubtexturesAt(string key, int index)
        {
            if (orderedTexturesCache.TryGetValue(key, out var result))
                return index < 0 || index >= result.Count ? GetFallback() : result[index];
            return GetAtlasSubtextureFromAtlasAt(key, index) ?? GetFallback();
        }

        private AtlasEntry GetAtlasSubtextureFromAtlasAt(string key, int index)
        {
            if (index == 0 && Entries.ContainsKey(key)) return Entries[key];
            string text = index.ToString();
            int length = text.Length;
            while (text.Length < length + 6)
            {
                if (Entries.TryGetValue(key + text, out var result)) return result;
                text = "0" + text;
            }

            return null;
        }


        private ConcurrentStack<AtlasEntry> FallbackStack;
        public AtlasEntry DefaultFallback;

        public void ResetCaches()
        {
            if (orderedTexturesCache.Count > 0)
                orderedTexturesCache = new Dictionary<string, List<AtlasEntry>>();
        }

        public AtlasEntry GetFallback()
        {
            var fallbackStack = FallbackStack;
            if (fallbackStack != null && fallbackStack.TryPeek(out var result)) return result;
            if (DefaultFallback != null || Entries.TryGetValue("__fallback", out DefaultFallback))
                return DefaultFallback;
            return null;
        }

        public void PushFallback(AtlasEntry fallback)
        {
            if (FallbackStack == null) FallbackStack = new ConcurrentStack<AtlasEntry>();
            FallbackStack.Push(fallback);
        }

        public AtlasEntry PopFallback()
        {
            var fallbackStack = FallbackStack;
            if (fallbackStack != null && fallbackStack.TryPop(out var result)) return result;
            throw new InvalidOperationException("Fallback stack is empty or has not been created.");
        }

        public Dictionary<string, global::Celeste.Graphics.Content.Atlas.AtlasEntry> Entries { get; } =
            new Dictionary<string, global::Celeste.Graphics.Content.Atlas.AtlasEntry>(StringComparer
                .OrdinalIgnoreCase);

        public AtlasEntry GetLinkedTexture(string key)
        {
            if (key != null && Links.TryGetValue(key, out var value) && Entries.TryGetValue(value, out var value2))
            {
                return value2;
            }

            return null;
        }

        public Dictionary<string, string> Links { get; } = new Dictionary<string, string>(StringComparer.Ordinal);
    }
}
