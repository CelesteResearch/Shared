using System;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Rendering;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public class AngledWipePresentation : ScreenWipePresentation
    {
        private const int rows = 6;

        private const float angleSize = 64f;

        private readonly SourceVertexPositionColor[] vertexBuffer = new SourceVertexPositionColor[36];

        public AngledWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
            : base(scene, wipeIn, onComplete)
        {
            for (var i = 0; i < vertexBuffer.Length; i++) vertexBuffer[i].Color = WipeColor;
        }

        public override void Render(object scene)
        {
            var num = 183.33333f;
            var num2 = -64f;
            var num3 = 1984f;
            for (var i = 0; i < 6; i++)
            {
                var num4 = i * 6;
                var num5 = num2;
                var num6 = -10f + i * num;
                var num7 = 0f;
                var num8 = i / 6f;
                var num9 = (WipeIn ? 1f - num8 : num8) * 0.3f;
                if (Percent > num9) num7 = Extrema.Min(1f, (Percent - num9) / 0.7f);

                if (WipeIn) num7 = 1f - num7;

                var num10 = num3 * num7;
                vertexBuffer[num4].Position = new(num5, num6, 0f);
                vertexBuffer[num4 + 1].Position = new(num5 + num10, num6, 0f);
                vertexBuffer[num4 + 2].Position = new(num5, num6 + num, 0f);
                vertexBuffer[num4 + 3].Position = new(num5 + num10, num6, 0f);
                vertexBuffer[num4 + 4].Position = new(num5 + num10 + 64f, num6 + num, 0f);
                vertexBuffer[num4 + 5].Position = new(num5, num6 + num, 0f);
            }

            if (WipeIn)
                for (var j = 0; j < vertexBuffer.Length; j++)
                {
                    vertexBuffer[j].Position.X = 1920f - vertexBuffer[j].Position.X;
                    vertexBuffer[j].Position.Y = 1080f - vertexBuffer[j].Position.Y;
                }

            DrawPrimitives(vertexBuffer);
        }
    }
}
