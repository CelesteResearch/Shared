using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Presentation.Platforms.ZipMovers
{
    public static partial class ZipMoverDrawing
    {
        // Callers retain their original phase expression and the cached geometry of their own path topology.
        public static void RopeLines(ISourceRenderContext context, object owner, ISourceVectorArithmetic vectors,
            Vector2 startA, Vector2 startB, Vector2 endA, Vector2 endB, Vector2 direction, Vector2 perpendicular,
            float length, float phase, Vector2? offset, PackedColor ropeColor, PackedColor lightColor,
            PackedColor? colorOverride = null)
        {
            SourcePrimitiveDrawing.Line(context, owner,
                offset.HasValue ? SourceVector2Math.Add(startA, offset.Value) : startA,
                offset.HasValue ? SourceVector2Math.Add(endA, offset.Value) : endA, colorOverride ?? ropeColor,
                vectors);
            SourcePrimitiveDrawing.Line(context, owner,
                offset.HasValue ? SourceVector2Math.Add(startB, offset.Value) : startB,
                offset.HasValue ? SourceVector2Math.Add(endB, offset.Value) : endB, colorOverride ?? ropeColor,
                vectors);
            for (float distance = 4f - phase % 4f; distance < length; distance += 4f)
            {
                var toothColor = colorOverride ?? lightColor;
                Vector2 first = SourceVector2Math.Add(SourceVector2Math.Add(startA, perpendicular),
                    SourceVector2Math.Multiply(direction, distance));
                Vector2 second = SourceVector2Math.Subtract(endB, SourceVector2Math.Multiply(direction, distance));
                SourcePrimitiveDrawing.Line(context, owner,
                    offset.HasValue ? SourceVector2Math.Add(first, offset.Value) : first,
                    offset.HasValue
                        ? SourceVector2Math.Add(SourceVector2Math.Add(first, SourceVector2Math.Multiply(direction, 2f)),
                            offset.Value)
                        : SourceVector2Math.Add(first, SourceVector2Math.Multiply(direction, 2f)),
                    toothColor, vectors);
                SourcePrimitiveDrawing.Line(context, owner,
                    offset.HasValue ? SourceVector2Math.Add(second, offset.Value) : second,
                    offset.HasValue
                        ? SourceVector2Math.Add(
                            SourceVector2Math.Subtract(second, SourceVector2Math.Multiply(direction, 2f)), offset.Value)
                        : SourceVector2Math.Subtract(second, SourceVector2Math.Multiply(direction, 2f)),
                    toothColor, vectors);
            }
        }
    }
}
