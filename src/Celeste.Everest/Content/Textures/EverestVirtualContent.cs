using Celeste.Core.Display;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Graphics.Content.Textures;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Runtime.Threading;

namespace Celeste.Everest.Content.Textures
{
    public sealed class EverestVirtualContent : VirtualContent
    {
        internal readonly IEverestVirtualTextureEnvironment SourceEnvironment;

        public EverestVirtualContent(IEverestVirtualTextureEnvironment environment,
            ISourceVirtualRenderTargetFactory renderTargets) : base(environment, renderTargets)
            => SourceEnvironment = environment;

        public override VirtualTexture CreateTexture(string path)
        {
            string assetPath = EverestFileProxyPath.Modize(path, SourceEnvironment.Content);
            var texture = SourceEnvironment.Content
                .TryGet<global::Celeste.Everest.Content.Types.Graphics.AssetTypeTexture>(
                    assetPath, out var metadata)
                ? new EverestVirtualTexture(this, metadata)
                : new EverestVirtualTexture(this, path);
            Assets.Add(texture);
            return texture;
        }

        public override VirtualTexture CreateTexture(string name, int width, int height, PackedColor color)
        {
            var texture = new EverestVirtualTexture(this, name, width, height, color);
            Assets.Add(texture);
            return texture;
        }

        public EverestVirtualTexture CreateTexture(EverestContentAsset metadata)
        {
            var texture = new EverestVirtualTexture(this, metadata);
            Assets.Add(texture);
            return texture;
        }

        public void UnloadOverworld()
        {
            foreach (var asset in Assets)
            {
                var name = asset.Name.Replace('\\', '/');
                if (asset is VirtualTexture && name.StartsWith("Graphics/Atlases/"))
                {
                    name = name.Substring(17);
                    if (name.StartsWith("Opening") || name.StartsWith("Overworld") ||
                        name.StartsWith("Mountain") || name.StartsWith("Journal"))
                        asset.Unload();
                }
            }
        }
    }
}
