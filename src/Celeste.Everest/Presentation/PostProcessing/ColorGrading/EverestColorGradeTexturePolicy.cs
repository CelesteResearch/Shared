using Celeste.Game.Presentation.PostProcessing.ColorGrading;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Everest.Presentation.PostProcessing.ColorGrading
{
    public sealed class EverestColorGradeTexturePolicy : IOriginalColorGradeTexturePolicy
    {
        public SourceTexture2DResource Read(AtlasEntry grade)
        {
            return grade.Texture.TextureSafe;
        }
    }
}
