using System;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Rendering;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public class WindWipePresentation : ScreenWipePresentation
    {
        private readonly int t;

        private readonly int columns;

        private readonly int rows;

        private readonly SourceVertexPositionColor[] vertexBuffer;

        public WindWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
            : base(scene, wipeIn, onComplete)
        {
            t = 40;
            columns = 1920 / t + 1;
            rows = 1080 / t + 1;
            vertexBuffer = new SourceVertexPositionColor[columns * rows * 6];
            for (var i = 0; i < vertexBuffer.Length; i++) vertexBuffer[i].Color = WipeColor;
        }

        public override void Render(object scene)
        {
            float num = columns * rows;
            var num2 = 0;
            for (var i = 0; i < columns; i++)
            for (var j = 0; j < rows; j++)
            {
                var num3 = WipeIn ? columns - i - 1 : i;
                var num4 =
                    ((j + num3 % 2) % 2 * (rows + j / 2) + (j + num3 % 2 + 1) % 2 * (j / 2) + num3 * rows) /
                    num * 0.5f;
                var num5 = num4 + 300f / num;
                var num6 = (Extrema.Max(num4, Extrema.Min(num5, WipeIn ? 1f - Percent : Percent)) - num4) /
                           (num5 - num4);
                var num7 = (i - 0.5f) * t;
                var num8 = (j - 0.5f) * t - t * 0.5f * num6;
                var x = num7 + t;
                var y = num8 + t * num6;
                vertexBuffer[num2].Position = new(num7, num8, 0f);
                vertexBuffer[num2 + 1].Position = new(x, num8, 0f);
                vertexBuffer[num2 + 2].Position = new(num7, y, 0f);
                vertexBuffer[num2 + 3].Position = new(x, num8, 0f);
                vertexBuffer[num2 + 4].Position = new(x, y, 0f);
                vertexBuffer[num2 + 5].Position = new(num7, y, 0f);
                num2 += 6;
            }

            DrawPrimitives(vertexBuffer);
        }
    }
}
