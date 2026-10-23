using System;
using System.Numerics;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    /// <summary>Original SpotlightWipe.DrawSpotlight geometry, independent of the renderer.</summary>
    public static class SpotlightMesh
    {
        public const int VertexCount = 768;

        public static void Fill(global::Celeste.Graphics.Display.ColoredVertex[] vertices, Vector2 at, float radius,
            Vector4 color)
        {
            if (vertices == null || vertices.Length != VertexCount)
                throw new ArgumentException("Expected 768 spotlight vertices.", nameof(vertices));

            Vector2 previous = Vector2.UnitX;
            for (int i = 0; i < VertexCount; i += 12)
            {
                float angle = (i + 12f) / VertexCount * ((float)Math.PI * 2);
                Vector2 next = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                vertices[i] = new global::Celeste.Graphics.Display.ColoredVertex(at + previous * 5000, color);
                vertices[i + 1] = new global::Celeste.Graphics.Display.ColoredVertex(at + previous * radius, color);
                vertices[i + 2] = new global::Celeste.Graphics.Display.ColoredVertex(at + next * radius, color);
                vertices[i + 3] = vertices[i];
                vertices[i + 4] = new global::Celeste.Graphics.Display.ColoredVertex(at + next * 5000, color);
                vertices[i + 5] = vertices[i + 2];
                vertices[i + 6] = vertices[i + 1];
                vertices[i + 7] =
                    new global::Celeste.Graphics.Display.ColoredVertex(at + previous * (radius - 2), Vector4.Zero);
                vertices[i + 8] =
                    new global::Celeste.Graphics.Display.ColoredVertex(at + next * (radius - 2), Vector4.Zero);
                vertices[i + 9] = vertices[i + 1];
                vertices[i + 10] = vertices[i + 2];
                vertices[i + 11] = vertices[i + 8];
                previous = next;
            }
        }
    }
}
