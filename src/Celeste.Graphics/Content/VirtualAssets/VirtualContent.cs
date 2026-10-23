using System;
using System.Collections.Generic;
using Celeste.Core.Display;
using JetBrains.Annotations;

namespace Celeste.Graphics.Content.VirtualAssets
{
    public class VirtualContent
    {
        internal readonly ISourceVirtualTextureEnvironment Environment;
        internal readonly ISourceVirtualRenderTargetFactory RenderTargets;
        private readonly Lazy<VirtualTextureDataBuffers> textureData = new(() => new());
        internal VirtualTextureDataBuffers TextureData => textureData.Value;
        public List<VirtualAsset> Assets => assets;

        internal virtual bool TryReloadTextureOnRead(VirtualTexture texture)
        {
            return false;
        }

        // ReSharper disable once ConvertToPrimaryConstructor
        public VirtualContent(ISourceVirtualTextureEnvironment environment,
            ISourceVirtualRenderTargetFactory renderTargets)
        {
            Environment = environment;
            RenderTargets = renderTargets;
        }

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly List<VirtualAsset> assets = [];

        private bool reloading;
        public int Count => assets.Count;

        public virtual VirtualTexture CreateTexture(string path)
        {
            var virtualTexture = new VirtualTexture(this, path);
            assets.Add(virtualTexture);
            return virtualTexture;
        }

        public virtual VirtualTexture RegisterTexture(string path, int width, int height)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("A texture path is required.", nameof(path));
            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width));
            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height));
            var texture = new VirtualTexture(this, path, width, height);
            assets.Add(texture);
            return texture;
        }

        public virtual VirtualTexture CreateTexture(string name, int width, int height, PackedColor color)
        {
            var virtualTexture = new VirtualTexture(this, name, width, height, color);
            assets.Add(virtualTexture);
            return virtualTexture;
        }

        public VirtualRenderTarget CreateRenderTarget(string name, int width, int height, bool depth = false,
            bool preserve = true, int multiSampleCount = 0)
        {
            var virtualRenderTarget =
                new VirtualRenderTarget(this, name, width, height, multiSampleCount, depth, preserve);
            assets.Add(virtualRenderTarget);
            return virtualRenderTarget;
        }

        public void BySize()
        {
            var dictionary = new Dictionary<int, Dictionary<int, int>>();
            foreach (var asset in assets)
            {
                if (!dictionary.ContainsKey(asset.Width))
                    dictionary.Add(asset.Width, new());
                if (!dictionary[asset.Width].ContainsKey(asset.Height))
                    dictionary[asset.Width].Add(asset.Height, 0);
                dictionary[asset.Width][asset.Height]++;
            }

            foreach (var item in dictionary)
            foreach (var item2 in item.Value)
                Console.WriteLine(item.Key + "x" + item2.Key + ": " + item2.Value);
        }

        public void ByName()
        {
            foreach (var asset in assets)
                Console.WriteLine(asset.Name + "[" + asset.Width + "x" + asset.Height + "]");
        }

        internal void Remove(VirtualAsset asset)
        {
            assets.Remove(asset);
        }

        public void Reload()
        {
            if (reloading)
                foreach (var asset in assets)
                {
                    if (asset is VirtualTexture texture && !texture.ReloadWithOwner)
                        continue;
                    asset.Reload();
                }

            reloading = false;
        }

        public void Unload()
        {
            foreach (var asset in assets)
                asset.Unload();
            reloading = true;
        }
    }
}
