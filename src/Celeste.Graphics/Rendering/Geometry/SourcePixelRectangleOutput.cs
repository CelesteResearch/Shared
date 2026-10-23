using Celeste.Core.Display;
using Celeste.Core.Rendering;

namespace Celeste.Graphics.Rendering.Geometry
{
    // Pixel rectangles emitted by the source exact-line algorithm enter the same actual Draw batch.
    public sealed class SourcePixelRectangleOutput(ISourceRenderContext context, object actualEntity)
        : IPixelRectangleOutput
    {
        private readonly ISourceRenderContext context = context;
        private readonly object actualEntity = actualEntity;

        public void Rectangle(float x, float y, float width, float height, PackedColor color)
        {
            SourcePrimitiveDrawing.Rect(context, actualEntity, x, y, width, height, color);
        }
    }
}
