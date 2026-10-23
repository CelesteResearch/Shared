using System.Numerics;

namespace Celeste.Graphics.Display.Canvas
{
    public interface ICanvasOverlayRenderer
    {
        void RenderOverlay(Vector2 scroll);
    }
}
