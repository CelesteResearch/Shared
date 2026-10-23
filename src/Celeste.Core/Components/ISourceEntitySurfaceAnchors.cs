using System.Numerics;

namespace Celeste.Core.Components
{
    public interface ISourceEntitySurfaceAnchors : ISourceEntityCenter
    {
        Vector2 BottomCenter { get; }
        Vector2 BottomLeft { get; }
        Vector2 BottomRight { get; }
    }
}
