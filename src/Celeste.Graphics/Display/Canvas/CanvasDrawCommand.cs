using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Display.Canvas
{
    // Source rectangles intentionally retain out-of-texture coordinates for LinearWrap.
    public struct CanvasDrawCommand
    {
        public CanvasDrawKind Kind;
        public CanvasSampler Sampler;
        public string Page;
        public IntRect Source;
        public Vector2 Position, Size;
        public float Scale;
        public bool FlipHorizontally;
        public Vector4 Color;
    }
}
