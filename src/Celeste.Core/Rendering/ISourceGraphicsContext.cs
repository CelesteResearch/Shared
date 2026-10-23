using System.Numerics;

namespace Celeste.Core.Rendering
{
    public interface ISourceGraphicsContext
    {
        int Width { get; }
        int Height { get; }
        int ViewWidth { get; }
        int ViewHeight { get; }
        object HudTarget { get; }
        Matrix4x4 ScreenMatrix { get; }
    }
}
