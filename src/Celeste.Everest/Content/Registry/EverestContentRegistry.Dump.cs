using System.IO;
using Celeste.Everest.Content.Serialization;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Textures;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Everest.Content.Registry
{
    public sealed partial class EverestContentRegistry
    {
        public void Dump(string fullName, object asset)
        {
            var environment = processing.ContentDump;
            var path = fullName;
            if (path.StartsWith(PathContentOrig))
                path = path.Substring(PathContentOrig.Length + 1);
            else if (File.Exists(path))
                return;
            var outputPath = Path.Combine(PathDUMP, path);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            environment.Diagnostics.DumpAsset(fullName, asset);
            if (asset is IEverestMetadata)
            {
                if (File.Exists(outputPath + ".meta.yaml")) return;
                using Stream stream = File.OpenWrite(outputPath + ".meta.yaml");
                using var writer = new StreamWriter(stream);
                environment.Yaml.Serializer.Serialize(writer, asset, asset.GetType());
                return;
            }

            if (asset is ISourceDataTextureResource texture)
            {
                if (!File.Exists(outputPath + ".png"))
                {
                    using Stream stream = File.OpenWrite(outputPath + ".png");
                    environment.PngWriter.SaveAsPng(texture, stream, texture.Width, texture.Height);
                }

                return;
            }

            if (asset is VirtualTexture virtualTexture)
            {
                Dump(path, virtualTexture.TextureSafe);
                return;
            }

            if (asset is AtlasEntry input)
            {
                using var copy = SourceAtlasTextureCopies.Postdivide(
                    SourceAtlasTextureCopies.GetPaddedSubtextureCopy(input, environment.TextureFactory));
                Dump(path, copy);
                return;
            }

            if (!(asset is AtlasData atlas)) return;
            foreach (var pair in atlas.Entries)
                Dump(Path.Combine(path, pair.Key.Replace('/', Path.DirectorySeparatorChar)), pair.Value);
        }
    }
}
