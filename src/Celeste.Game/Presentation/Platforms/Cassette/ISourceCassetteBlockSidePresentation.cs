using Celeste.Core.Display;
using Celeste.Core.Rendering;

namespace Celeste.Game.Presentation.Platforms.Cassette
{
    public interface ISourceCassetteBlockSidePresentation
    {
        void RenderBoxSide(ISourceRenderContext context, object actualSide, PackedColor disabledColor);
    }
}
