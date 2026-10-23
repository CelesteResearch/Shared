using System;
using System.Linq;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Atlases;
using Celeste.Everest.Content.Types.Graphics;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public sealed partial class EverestDecalRegistry
    {
        public void Load()
        {
            loaded = false;
            RegisterDefaultHandlers();
            foreach (var mod in content.Mods)
                if (mod.Map.TryGetValue("DecalRegistry", out var asset) && asset.Type == typeof(AssetTypeDecalRegistry))
                    LoadModRegistry(asset);
            loaded = true;
        }

        public void LoadModRegistry(EverestContentAsset asset)
        {
            logger.DecalLoadingRegistry(asset);
            var basePath = ((EverestAtlasData)graphics.GameGraphics.GameAtlas).RelativeDataPath + "decals/";
            var local = asset.Source.Map.Keys.Where(path => path.StartsWith(basePath, StringComparison.Ordinal))
                .Select(path => path.AsSpan(basePath.Length).TrimEnd("0123456789").ToString().ToLower())
                .Distinct().ToList();
            foreach (var definition in ReadRegistryXml(asset))
            {
                var key = definition.Key;
                var info = definition.Value;
                var matched = false;
                if (key.EndsWith("*", StringComparison.Ordinal) || key.EndsWith("/", StringComparison.Ordinal))
                {
                    var prefix = key.AsSpan().TrimEnd('*');
                    foreach (var path in local)
                    {
                        var span = path.AsSpan();
                        if (span.Length > prefix.Length && span.StartsWith(prefix) &&
                            span.LastIndexOf('/') <= prefix.Length - 1)
                        {
                            RegisterDecal(path, info);
                            matched = true;
                        }
                    }
                }
                else if (local.Contains(key))
                {
                    RegisterDecal(key, info);
                    matched = true;
                }

                if (!matched) logger.DecalNoMatch(asset, definition.Key);
            }
        }
    }
}
