using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Game.Presentation.PostProcessing.ColorGrading
{
    public interface IOriginalColorGradeTexturePolicy
    {
        SourceTexture2DResource Read(AtlasEntry grade);
    }
}
