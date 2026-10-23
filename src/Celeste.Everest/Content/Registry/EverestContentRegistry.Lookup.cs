using Celeste.Everest.Content.Assets;

namespace Celeste.Everest.Content.Registry
{
    public sealed partial class EverestContentRegistry
    {
        public bool TryGet(string path, out EverestContentAsset metadata, bool includeDirs = false)
        {
            path = path.Replace('\\', '/');
            lock (Map)
            {
                if (Map.TryGetValue(path, out metadata) && metadata != null) return true;
            }

            metadata = null;
            return false;
        }

        public EverestContentAsset Get(string path, bool includeDirs = false)
        {
            return TryGet(path, out var metadata, includeDirs) ? metadata : null;
        }

        public bool TryGet<T>(string path, out EverestContentAsset metadata, bool includeDirs = false)
        {
            path = EverestContentPath.ResolveTyped(path);
            lock (Map)
            {
                if (Map.TryGetValue(path, out metadata) && metadata != null && metadata.Type == typeof(T)) return true;
            }

            metadata = null;
            return false;
        }

        public EverestContentAsset Get<T>(string path, bool includeDirs = false)
        {
            return TryGet<T>(path, out var metadata, includeDirs) ? metadata : null;
        }

        internal bool TryGetResolved<T>(string path, out EverestContentAsset asset)
        {
            lock (Map)
            {
                if (Map.TryGetValue(path, out asset) && asset != null && asset.Type == typeof(T)) return true;
            }

            asset = null;
            return false;
        }
    }
}
