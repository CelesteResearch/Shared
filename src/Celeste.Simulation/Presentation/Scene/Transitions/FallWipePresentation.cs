using System;
using System.Numerics;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Rendering;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public class FallWipePresentation : ScreenWipePresentation
    {
        private readonly SourceVertexPositionColor[] vertexBuffer = new SourceVertexPositionColor[9];

        public FallWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
            : base(scene, wipeIn, onComplete)
        {
            for (var i = 0; i < vertexBuffer.Length; i++) vertexBuffer[i].Color = WipeColor;
        }

        public override void Render(object scene)
        {
            var percent = Percent;
            var value = new Vector2(960f, 1080f - 2160f * percent);
            var value2 = new Vector2(-10f, 2160f * (1f - percent));
            var value3 = new Vector2(Right, 2160f * (1f - percent));
            if (!WipeIn)
            {
                vertexBuffer[0].Position = new(value, 0f);
                vertexBuffer[1].Position = new(value2, 0f);
                vertexBuffer[2].Position = new(value3, 0f);
                vertexBuffer[3].Position = new(value2, 0f);
                vertexBuffer[4].Position = new(value3, 0f);
                vertexBuffer[5].Position = new(value2.X, value2.Y + 1080f + 10f, 0f);
                vertexBuffer[6].Position = new(value3, 0f);
                vertexBuffer[8].Position = new(value3.X, value3.Y + 1080f + 10f, 0f);
                vertexBuffer[7].Position = new(value2.X, value2.Y + 1080f + 10f, 0f);
            }
            else
            {
                vertexBuffer[0].Position = new(value2.X, value.Y - 1080f - 10f, 0f);
                vertexBuffer[1].Position = new(value3.X, value.Y - 1080f - 10f, 0f);
                vertexBuffer[2].Position = new(value, 0f);
                vertexBuffer[3].Position = new(value2.X, value.Y - 1080f - 10f, 0f);
                vertexBuffer[4].Position = new(value, 0f);
                vertexBuffer[5].Position = new(value2, 0f);
                vertexBuffer[6].Position = new(value3.X, value.Y - 1080f - 10f, 0f);
                vertexBuffer[7].Position = new(value3, 0f);
                vertexBuffer[8].Position = new(value, 0f);
            }

            for (var i = 0; i < vertexBuffer.Length; i++)
                vertexBuffer[i].Position.Y = 1080f - vertexBuffer[i].Position.Y;

            DrawPrimitives(vertexBuffer);
        }
    }
}
