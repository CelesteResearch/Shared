using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Rendering
{
    public interface ISourceDrawingTextureRenderContext : ISourceRenderContext
    {
        AtlasEntry Pixel { get; }
        AtlasEntry Particle { get; }
    }
}
