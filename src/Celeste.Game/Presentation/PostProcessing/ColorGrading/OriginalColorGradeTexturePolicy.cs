using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Game.Presentation.PostProcessing.ColorGrading
{
    public sealed class OriginalColorGradeTexturePolicy : IOriginalColorGradeTexturePolicy
    {
        public SourceTexture2DResource Read(AtlasEntry grade) => grade.Texture.TextureSafe;
    }
}
