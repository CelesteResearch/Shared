using Celeste.Everest.Content.Assets;

namespace Celeste.Everest.Content.Atlases
{
    public interface IEverestAtlasIngestDiagnostics
    {
        void TextureOverridden(EverestAtlasData atlas, EverestContentAsset asset, string path);
        void TextureLoadFailed(EverestAtlasData atlas, EverestContentAsset asset, string path);
    }
}
