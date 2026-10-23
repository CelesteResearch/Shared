using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Graphics.Rendering.Geometry
{
    // Pixel rectangles emitted by the source exact-line algorithm enter the same actual Draw batch.
    public sealed class SourcePixelRectangleOutput : IPixelRectangleOutput
    {
        private readonly ISourceRenderContext context;
        private readonly object actualEntity;

        public SourcePixelRectangleOutput(ISourceRenderContext context, object actualEntity)
        {
            this.context = context;
            this.actualEntity = actualEntity;
        }

        public void Rectangle(float x, float y, float width, float height, PackedColor color)
            => SourcePrimitiveDrawing.Rect(context, actualEntity, x, y, width, height, color);
    }
}
