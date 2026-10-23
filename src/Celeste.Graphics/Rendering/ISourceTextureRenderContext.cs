using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Graphics.Rendering
{
    // Translate the actual current Engine GPU texture to the ordinary source Draw command.
    // No source state, ownership transfer, rendering or target selection occurs here.
    public interface ISourceTextureRenderContext : ISourceRenderContext
    {
        TileRegion TargetRegion(object target);
    }
}
