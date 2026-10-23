using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public partial class TiledLightningRendererState<TBlock>
    {
        public static void DrawSimpleLightning(ref int index,
            ref SourceVertexPositionColor[] verts, uint seed,
            Vector2 pos,
            Vector2 a, Vector2 b, PackedColor color,
            ISourceVectorArithmetic arithmetic, float thickness = 1f)
        {
            seed += (uint)(OriginalHash(a) + OriginalHash(b));
            a += pos;
            b += pos;
            var num = arithmetic.Length(b - a);
            var vector = (b - a) * (1f / num);
            var vector2 = Vector2Geometry.Perpendicular(vector);
            a += vector2;
            b += vector2;
            var vector3 = a;
            var num2 = PseudoRand(ref seed) % 2 != 0 ? 1 : -1;
            var num3 = PseudoRandRange(ref seed, 0f, (float)Math.PI * 2f);
            var num4 = 0f;
            var num5 = index + (arithmetic.Length(b - a) / 4f + 1f) * 6f;
            while (num5 >= verts.Length) Array.Resize(ref verts, verts.Length * 2);

            for (var i = index; i < num5; i++) verts[i].Color = color;

            do
            {
                var num6 = PseudoRandRange(ref seed, 0f, 4f);
                num3 += 0.1f;
                num4 += 4f + num6;
                var vector4 = a + vector * num4;
                if (num4 < num)
                    vector4 += num2 * vector2 * num6 - vector2;
                else
                    vector4 = b;

                verts[index++].Position = new(vector3 - vector2 * thickness, 0f);
                verts[index++].Position = new(vector4 - vector2 * thickness, 0f);
                verts[index++].Position = new(vector4 + vector2 * thickness, 0f);
                verts[index++].Position = new(vector3 - vector2 * thickness, 0f);
                verts[index++].Position = new(vector4 + vector2 * thickness, 0f);
                verts[index++].Position = new(vector3, 0f);
                vector3 = vector4;
                num2 = -num2;
            } while (num4 < num);
        }

        public static void DrawBezierLightning(ref int index,
            ref SourceVertexPositionColor[] verts, uint seed,
            Vector2 pos,
            Vector2 a, Vector2 b, float anchor, int steps, PackedColor color,
            ISourceCurveArithmetic curveArithmetic, ISourceVectorArithmetic arithmetic)
        {
            seed += (uint)(OriginalHash(a) + OriginalHash(b));
            a += pos;
            b += pos;
            var vector = Vector2Geometry.Perpendicular(arithmetic.SafeNormalize(b - a));
            var simpleCurve = new SimpleCurve(a, b, (b + a) / 2f + vector * anchor);
            var num = index + (steps + 2) * 6;
            while (num >= verts.Length) Array.Resize(ref verts, verts.Length * 2);

            var vector2 = simpleCurve.GetPoint(0f, curveArithmetic);
            for (var i = 0; i <= steps; i++)
            {
                var point = simpleCurve.GetPoint(i / (float)steps, curveArithmetic);
                if (i != steps)
                    point += new Vector2(PseudoRandRange(ref seed, -2f, 2f), PseudoRandRange(ref seed, -2f, 2f));

                verts[index].Position = new(vector2 - vector, 0f);
                verts[index++].Color = color;
                verts[index].Position = new(point - vector, 0f);
                verts[index++].Color = color;
                verts[index].Position = new(point, 0f);
                verts[index++].Color = color;
                verts[index].Position = new(vector2 - vector, 0f);
                verts[index++].Color = color;
                verts[index].Position = new(point, 0f);
                verts[index++].Color = color;
                verts[index].Position = new(vector2, 0f);
                verts[index++].Color = color;
                vector2 = point;
            }
        }

        public static void DrawFatLightning(ISourceRenderContext context, object entity,
            uint seed, Vector2 a, Vector2 b,
            float size, float gap, PackedColor color,
            ISourceVectorArithmetic arithmetic)
        {
            seed += (uint)(OriginalHash(a) + OriginalHash(b));
            var num = arithmetic.Length(b - a);
            var vector = (b - a) * (1f / num);
            var vector2 = Vector2Geometry.Perpendicular(vector);
            var vector3 = a;
            var num2 = 1;
            PseudoRandRange(ref seed, 0f, (float)Math.PI * 2f);
            var num3 = 0f;
            do
            {
                num3 += PseudoRandRange(ref seed, 10f, 14f);
                var vector4 = a + vector * num3;
                if (num3 < num)
                    vector4 += num2 * vector2 * PseudoRandRange(ref seed, 0f, 6f);
                else
                    vector4 = b;

                var vector5 = vector4;
                if (gap > 0f)
                {
                    vector5 = vector3 + (vector4 - vector3) * (1f - gap);
                    SourcePrimitiveDrawing.Line(context, entity, vector3,
                        vector4 + vector, color, size * 0.5f, arithmetic);
                }

                SourcePrimitiveDrawing.Line(context, entity, vector3, vector5 + vector,
                    color, size, arithmetic);
                vector3 = vector4;
                num2 = -num2;
            } while (num3 < num);
        }

        public static uint PseudoRand(ref uint seed)
        {
            seed ^= seed << 13;
            seed ^= seed >> 17;
            return seed;
        }

        public static float PseudoRandRange(ref uint seed, float min, float max)
        {
            return min + (PseudoRand(ref seed) & 0x3FF) / 1024f * (max - min);
        }
    }
}
