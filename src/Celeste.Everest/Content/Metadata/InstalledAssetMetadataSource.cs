using System.IO;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Text;

namespace Celeste.Everest.Content.Metadata
{
    public sealed class InstalledAssetMetadataSource
    {
        private readonly EverestContentRegistry content;

        // ReSharper disable once ConvertToPrimaryConstructor
        public InstalledAssetMetadataSource(EverestContentRegistry content)
        {
            this.content = content;
        }

        public bool TryDeserialize<T>(EverestContentAsset asset, out T result)
        {
            if (asset.Type == typeof(AssetTypeYaml))
            {
                try
                {
                    using var input = new StreamReader(asset.Stream);
                    result = InstalledYamlHelper.Deserializer.Deserialize<T>(input);
                }
                catch
                {
                    result = default;
                    return false;
                }

                return true;
            }

            result = default;
            return false;
        }

        public T Deserialize<T>(EverestContentAsset asset)
        {
            TryDeserialize<T>(asset, out var result);
            return result;
        }

        public bool TryGetMeta<T>(EverestContentAsset asset, out T meta)
        {
            if (content.TryGet(asset.PathVirtual + ".meta", out var metadata)
                && TryDeserialize(metadata, out meta)) return true;
            meta = default;
            return false;
        }

        public T GetMeta<T>(EverestContentAsset asset)
        {
            TryGetMeta<T>(asset, out var meta);
            return meta;
        }
    }
}
