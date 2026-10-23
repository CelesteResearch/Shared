using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.Platforms.Dream
{
    public static class DreamBlockBorderDrawing
    {
        public static void DrawSegments(ISourceRenderContext context, object owner, ISourceEngineContext engine,
            Vector2 from, float num, Vector2 vector, Vector2 vector2, float offset,
            float wobbleFrom, float wobbleTo, float wobbleEase, PackedColor color, PackedColor color2)
            => DrawSegments(context, owner, engine, from, num, vector, vector2, offset,
                wobbleFrom, wobbleTo, wobbleEase, color, color2, null);

        public static void DrawSegments(ISourceRenderContext context, object owner, ISourceEngineContext engine,
            Vector2 from, float num, Vector2 vector, Vector2 vector2, float offset,
            float wobbleFrom, float wobbleTo, float wobbleEase, PackedColor color, PackedColor color2,
            Func<float, float, float, float> interpolate)
        {
            float num2 = 0f;
            int num3 = 16;
            for (int i = 2; (float)i < num - 2f; i += num3)
            {
                float fromAmplitude = LineAmplitude(wobbleFrom + offset, i);
                float toAmplitude = LineAmplitude(wobbleTo + offset, i);
                float num4 = interpolate == null
                    ? Lerp(fromAmplitude, toAmplitude, wobbleEase)
                    : interpolate(fromAmplitude, toAmplitude, wobbleEase);
                if ((float)(i + num3) >= num)
                {
                    num4 = 0f;
                }

                float num5 = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(num3, num - 2f - (float)i);
                Vector2 vector3 = from + vector * i + vector2 * num2;
                Vector2 vector4 = from + vector * ((float)i + num5) + vector2 * num4;
                SourcePrimitiveDrawing.Line(context, owner, vector3 - vector2, vector4 - vector2, color2,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                SourcePrimitiveDrawing.Line(context, owner, vector3 - vector2 * 2f, vector4 - vector2 * 2f, color2,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                SourcePrimitiveDrawing.Line(context, owner, vector3, vector4, color,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                num2 = num4;
            }
        }

        internal static float LineAmplitude(float seed, float index)
            => (float)(Math.Sin((double)(seed + index / 16f) + Math.Sin(seed * 2f + index / 32f) * 6.2831854820251465) +
                       1.0) * 1.5f;

        internal static float Lerp(float a, float b, float percent) => a + (b - a) * percent;
    }
}
