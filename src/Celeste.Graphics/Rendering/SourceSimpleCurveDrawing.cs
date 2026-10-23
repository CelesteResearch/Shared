using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;

namespace Celeste.Graphics.Rendering
{
    public static class SourceSimpleCurveDrawing
    {
        public static void Render(ISourceRenderContext context, object entity, SimpleCurve curve,
            Vector2 offset, PackedColor color, int resolution, ISourceCurveArithmetic curveArithmetic,
            ISourceVectorArithmetic vectorArithmetic)
        {
            var start = offset + curve.Begin;
            for (var i = 1; i <= resolution; i++)
            {
                var vector = offset + curve.GetPoint(i / (float)resolution, curveArithmetic);
                SourcePrimitiveDrawing.Line(context, entity, start, vector, color, vectorArithmetic);
                start = vector;
            }
        }
    }
}
