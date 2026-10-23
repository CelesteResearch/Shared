using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Rendering
{
    public static class SourceSimpleCurveDrawing
    {
        public static void Render(ISourceRenderContext context, object entity, SimpleCurve curve,
            Vector2 offset, PackedColor color, int resolution, ISourceCurveArithmetic curveArithmetic,
            ISourceVectorArithmetic vectorArithmetic)
        {
            Vector2 start = offset + curve.Begin;
            for (int i = 1; i <= resolution; i++)
            {
                Vector2 vector = offset + curve.GetPoint((float)i / (float)resolution, curveArithmetic);
                SourcePrimitiveDrawing.Line(context, entity, start, vector, color, vectorArithmetic);
                start = vector;
            }
        }
    }
}
