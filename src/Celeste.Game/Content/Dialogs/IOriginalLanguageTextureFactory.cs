using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Content.Dialogs
{
    public interface IOriginalLanguageTextureFactory
    {
        AtlasEntry CreateTexture(string contentRelativePath);
    }
}
