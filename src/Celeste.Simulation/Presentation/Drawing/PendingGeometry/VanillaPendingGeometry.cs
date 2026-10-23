using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Drawing.PendingGeometry
{
    public static class VanillaPendingGeometry
    {
        public static IEnumerable<global::Celeste.Graphics.Display.ColoredGeometry> Barrier(
            global::Celeste.Core.Geometry.Bounds bounds, int depth)
        {
            // XNA Color.Red * .3f scales and truncates each byte channel.
            float channel = (int)(255f * .3f) / 255f;
            var c = new Vector4(channel, 0, 0, channel);
            var a = new Vector2(bounds.X, bounds.Y);
            var b = new Vector2(bounds.Right, bounds.Y);
            var d = new Vector2(bounds.X, bounds.Bottom);
            var e = new Vector2(bounds.Right, bounds.Bottom);
            yield return new global::Celeste.Graphics.Display.ColoredGeometry(depth, new[]
            {
                new global::Celeste.Graphics.Display.ColoredVertex(a, c),
                new global::Celeste.Graphics.Display.ColoredVertex(b, c),
                new global::Celeste.Graphics.Display.ColoredVertex(d, c),
                new global::Celeste.Graphics.Display.ColoredVertex(b, c),
                new global::Celeste.Graphics.Display.ColoredVertex(e, c),
                new global::Celeste.Graphics.Display.ColoredVertex(d, c)
            });
        }

        // Monocle.Draw.Circle(position, 12, Red, 8): eight lines in each quadrant.
        public static IEnumerable<global::Celeste.Graphics.Display.ColoredGeometry> SliderCircle(Vector2 center,
            int depth)
        {
            var red = new Vector4(1, 0, 0, 1);
            var vertices = new List<global::Celeste.Graphics.Display.ColoredVertex>(8 * 4 * 6);
            var vector = new Vector2(12, 0);
            var perpendicular = new Vector2(0, 12);
            for (int i = 1; i <= 8; i++)
            {
                float angle = i * (float)Math.PI / 16f;
                var next = new Vector2((float)Math.Cos(angle) * 12, (float)Math.Sin(angle) * 12);
                var nextPerpendicular = new Vector2(-next.Y, next.X);
                Line(vertices, center + vector, center + next, red);
                Line(vertices, center - vector, center - next, red);
                Line(vertices, center + perpendicular, center + nextPerpendicular, red);
                Line(vertices, center - perpendicular, center - nextPerpendicular, red);
                vector = next;
                perpendicular = nextPerpendicular;
            }

            yield return new global::Celeste.Graphics.Display.ColoredGeometry(depth, vertices.ToArray());
        }

        static void Line(List<global::Celeste.Graphics.Display.ColoredVertex> vertices, Vector2 a, Vector2 b,
            Vector4 color)
        {
            var edge = b - a;
            float length = edge.Length();
            if (length <= 0) return;
            var normal = new Vector2(-edge.Y / length, edge.X / length) * .5f;
            var p0 = a - normal;
            var p1 = a + normal;
            var p2 = b - normal;
            var p3 = b + normal;
            vertices.Add(new global::Celeste.Graphics.Display.ColoredVertex(p0, color));
            vertices.Add(new global::Celeste.Graphics.Display.ColoredVertex(p1, color));
            vertices.Add(new global::Celeste.Graphics.Display.ColoredVertex(p2, color));
            vertices.Add(new global::Celeste.Graphics.Display.ColoredVertex(p1, color));
            vertices.Add(new global::Celeste.Graphics.Display.ColoredVertex(p3, color));
            vertices.Add(new global::Celeste.Graphics.Display.ColoredVertex(p2, color));
        }
    }
}
