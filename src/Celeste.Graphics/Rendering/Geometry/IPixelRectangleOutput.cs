using Celeste.Core.Display;

namespace Celeste.Graphics.Rendering.Geometry
{
    /// <summary>Receives source TAS pixel rectangles in their original draw order.</summary>
    public interface IPixelRectangleOutput
    {
        void Rectangle(float x, float y, float width, float height, PackedColor color);
    }
}
