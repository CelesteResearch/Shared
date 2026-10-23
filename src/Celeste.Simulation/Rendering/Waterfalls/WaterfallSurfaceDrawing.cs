using System;
using System.Collections.Generic;
using Celeste.Core.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Simulation.Rendering.Waterfalls
{
    public static class WaterfallSurfaceDrawing
    {
        public static void Straight(ISourceDrawScope scope, float x, float leftEdgeX, float rightEdgeX,
            float y, float height, IReadOnlyList<float> lines, PackedColor color)
        {
            SourcePrimitiveDrawing.Rect(scope, leftEdgeX, y, 3f, height, color);
            SourcePrimitiveDrawing.Rect(scope, rightEdgeX, y, 3f, height, color);
            for (var index = 0; index < lines.Count; index++)
                SourcePrimitiveDrawing.Rect(scope, x + lines[index], y, 1f, height, color);
        }

        public static void Wavy(ISourceDrawScope scope, float x, float width, float startY, float endY,
            int segmentLength, float sine, IReadOnlyList<float> lines, PackedColor color)
        {
            for (var y = startY; y < endY; y += segmentLength)
            {
                var distort = (int)(Math.Sin(y / 6f - sine * 8f) * 2.0);
                SourcePrimitiveDrawing.Rect(scope, x, y, 4 + distort, segmentLength, color);
                SourcePrimitiveDrawing.Rect(scope, x + width - 4f + distort, y, 4 - distort, segmentLength, color);
                for (var index = 0; index < lines.Count; index++)
                    SourcePrimitiveDrawing.Rect(scope, x + distort + lines[index], y, 1f, segmentLength, color);
            }
        }

        public static void WavyDisplacement(ISourceDrawScope scope, float x, float width, float startY, float endY,
            int segmentLength, float sine)
        {
            for (var y = startY; y < endY; y += segmentLength)
            {
                var distort = (int)(Math.Sin(y / 6f - sine * 8f) * 2.0);
                SourcePrimitiveDrawing.Rect(scope, x + 1f, y, width - 2f, segmentLength,
                    new(0.5f + distort / 32f, 0.5f, 0f, 1f));
            }
        }
    }
}
