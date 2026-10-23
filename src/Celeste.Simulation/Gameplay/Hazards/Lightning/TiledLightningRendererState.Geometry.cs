using Celeste.Core.Display;
using System;
using Celeste.Core.Mathematics;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public partial class TiledLightningRendererState<TBlock>
    {
        public static void DrawSimpleLightning(ref int index,
            ref global::Celeste.Graphics.Rendering.Vertices.SourceVertexPositionColor[] verts, uint seed,
            Vector2 pos,
            Vector2 a, Vector2 b, global::Celeste.Core.Display.PackedColor color,
            ISourceVectorArithmetic arithmetic, float thickness = 1f)
        {
            seed += (uint)(OriginalHash(a) + OriginalHash(b));
            a += pos;
            b += pos;
            float num = arithmetic.Length(b - a);
            Vector2 vector = (b - a) * (1f / num);
            Vector2 vector2 = Vector2Geometry.Perpendicular(vector);
            a += vector2;
            b += vector2;
            Vector2 vector3 = a;
            int num2 = ((PseudoRand(ref seed) % 2 != 0) ? 1 : (-1));
            float num3 = PseudoRandRange(ref seed, 0f, (float)Math.PI * 2f);
            float num4 = 0f;
            float num5 = (float)index + (arithmetic.Length(b - a) / 4f + 1f) * 6f;
            while (num5 >= (float)verts.Length)
            {
                Array.Resize(ref verts, verts.Length * 2);
            }

            for (int i = index; (float)i < num5; i++)
            {
                verts[i].Color = color;
            }

            do
            {
                float num6 = PseudoRandRange(ref seed, 0f, 4f);
                num3 += 0.1f;
                num4 += 4f + num6;
                Vector2 vector4 = a + vector * num4;
                if (num4 < num)
                {
                    vector4 += num2 * vector2 * num6 - vector2;
                }
                else
                {
                    vector4 = b;
                }

                verts[index++].Position = new Vector3(vector3 - vector2 * thickness, 0f);
                verts[index++].Position = new Vector3(vector4 - vector2 * thickness, 0f);
                verts[index++].Position = new Vector3(vector4 + vector2 * thickness, 0f);
                verts[index++].Position = new Vector3(vector3 - vector2 * thickness, 0f);
                verts[index++].Position = new Vector3(vector4 + vector2 * thickness, 0f);
                verts[index++].Position = new Vector3(vector3, 0f);
                vector3 = vector4;
                num2 = -num2;
            } while (num4 < num);
        }

        public static void DrawBezierLightning(ref int index,
            ref global::Celeste.Graphics.Rendering.Vertices.SourceVertexPositionColor[] verts, uint seed,
            Vector2 pos,
            Vector2 a, Vector2 b, float anchor, int steps, global::Celeste.Core.Display.PackedColor color,
            ISourceCurveArithmetic curveArithmetic, ISourceVectorArithmetic arithmetic)
        {
            seed += (uint)(OriginalHash(a) + OriginalHash(b));
            a += pos;
            b += pos;
            Vector2 vector = Vector2Geometry.Perpendicular(arithmetic.SafeNormalize(b - a));
            SimpleCurve simpleCurve = new SimpleCurve(a, b, (b + a) / 2f + vector * anchor);
            int num = index + (steps + 2) * 6;
            while (num >= verts.Length)
            {
                Array.Resize(ref verts, verts.Length * 2);
            }

            Vector2 vector2 = simpleCurve.GetPoint(0f, curveArithmetic);
            for (int i = 0; i <= steps; i++)
            {
                Vector2 point = simpleCurve.GetPoint((float)i / (float)steps, curveArithmetic);
                if (i != steps)
                {
                    point += new Vector2(PseudoRandRange(ref seed, -2f, 2f), PseudoRandRange(ref seed, -2f, 2f));
                }

                verts[index].Position = new Vector3(vector2 - vector, 0f);
                verts[index++].Color = color;
                verts[index].Position = new Vector3(point - vector, 0f);
                verts[index++].Color = color;
                verts[index].Position = new Vector3(point, 0f);
                verts[index++].Color = color;
                verts[index].Position = new Vector3(vector2 - vector, 0f);
                verts[index++].Color = color;
                verts[index].Position = new Vector3(point, 0f);
                verts[index++].Color = color;
                verts[index].Position = new Vector3(vector2, 0f);
                verts[index++].Color = color;
                vector2 = point;
            }
        }

        public static void DrawFatLightning(Celeste.Core.Rendering.ISourceRenderContext context, object entity,
            uint seed, Vector2 a, Vector2 b,
            float size, float gap, global::Celeste.Core.Display.PackedColor color,
            ISourceVectorArithmetic arithmetic)
        {
            seed += (uint)(OriginalHash(a) + OriginalHash(b));
            float num = arithmetic.Length(b - a);
            Vector2 vector = (b - a) * (1f / num);
            Vector2 vector2 = Vector2Geometry.Perpendicular(vector);
            Vector2 vector3 = a;
            int num2 = 1;
            PseudoRandRange(ref seed, 0f, (float)Math.PI * 2f);
            float num3 = 0f;
            do
            {
                num3 += PseudoRandRange(ref seed, 10f, 14f);
                Vector2 vector4 = a + vector * num3;
                if (num3 < num)
                {
                    vector4 += num2 * vector2 * PseudoRandRange(ref seed, 0f, 6f);
                }
                else
                {
                    vector4 = b;
                }

                Vector2 vector5 = vector4;
                if (gap > 0f)
                {
                    vector5 = vector3 + (vector4 - vector3) * (1f - gap);
                    Celeste.Graphics.Rendering.SourcePrimitiveDrawing.Line(context, entity, vector3,
                        vector4 + vector, color, size * 0.5f, arithmetic);
                }

                Celeste.Graphics.Rendering.SourcePrimitiveDrawing.Line(context, entity, vector3, vector5 + vector,
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
            return min + (float)(PseudoRand(ref seed) & 0x3FF) / 1024f * (max - min);
        }
    }
}
