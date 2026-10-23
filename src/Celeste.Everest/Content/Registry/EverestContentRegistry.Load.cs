using System;
using System.Collections.Generic;
using Celeste.Everest.Content.Assets;

namespace Celeste.Everest.Content.Registry
{
    public sealed partial class EverestContentRegistry
    {
        private readonly List<string> LoadedAssetPaths = new();
        private readonly List<string> LoadedAssetFullPaths = new();
        private readonly List<WeakReference> LoadedAssets = new();
        public event Action<object, string> OnProcessLoad;
        public event Action<object, EverestContentAsset, bool> OnProcessUpdate;
        public event Action<EverestContentAsset, EverestContentAsset> OnUpdate;

        public void ProcessLoad(object asset, string assetNameFull)
        {
            if (DumpOnLoad)
                Dump(assetNameFull, asset);
            string path = assetNameFull;
            if (path.StartsWith(PathContentOrig))
                path = path.Substring(PathContentOrig.Length + 1);
            path = path.Replace('\\', '/');
            int index = LoadedAssetPaths.IndexOf(path);
            if (index == -1)
            {
                LoadedAssetPaths.Add(path);
                LoadedAssetFullPaths.Add(assetNameFull);
                LoadedAssets.Add(new WeakReference(asset));
            }
            else
                LoadedAssets[index] = new WeakReference(asset);

            OnProcessLoad?.Invoke(asset, path);
            ProcessUpdate(asset, Get(path, includeDirs: true), load: true);
        }
    }
}
