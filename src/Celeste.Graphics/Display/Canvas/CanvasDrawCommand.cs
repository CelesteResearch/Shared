using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Display.Canvas
{
    // Source rectangles intentionally retain out-of-texture coordinates for LinearWrap.
    public struct CanvasDrawCommand
    {
        public CanvasDrawKind Kind;
        public CanvasSampler Sampler;
        public string Page;
        public global::Celeste.Core.Geometry.IntRect Source;
        public Vector2 Position, Size;
        public float Scale;
        public bool FlipHorizontally;
        public Vector4 Color;
    }
}
