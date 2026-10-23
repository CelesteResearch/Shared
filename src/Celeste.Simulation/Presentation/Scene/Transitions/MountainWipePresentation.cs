using System;
using System.Numerics;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Core.Mathematics;
using Celeste.Scene.Rendering;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public class MountainWipePresentation : ScreenWipePresentation
    {
        private SourceVertexPositionColor[] vertexBuffer = new SourceVertexPositionColor[9];

        public MountainWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
            : base(scene, wipeIn, onComplete)
        {
            for (int i = 0; i < vertexBuffer.Length; i++)
            {
                vertexBuffer[i].Color = WipeColor;
            }
        }

        public override void Render(object scene)
        {
            float percent = Percent;
            int num = 1080;
            Vector2 value = new Vector2(960f, (float)num - (float)(num * 2) * percent);
            Vector2 value2 = new Vector2(-10f, (float)(num * 2) * (1f - percent));
            Vector2 value3 = new Vector2(base.Right, (float)(num * 2) * (1f - percent));
            if (!WipeIn)
            {
                vertexBuffer[0].Position = new Vector3(value, 0f);
                vertexBuffer[1].Position = new Vector3(value2, 0f);
                vertexBuffer[2].Position = new Vector3(value3, 0f);
                vertexBuffer[3].Position = new Vector3(value2, 0f);
                vertexBuffer[4].Position = new Vector3(value3, 0f);
                vertexBuffer[5].Position = new Vector3(value2.X, value2.Y + (float)num + 10f, 0f);
                vertexBuffer[6].Position = new Vector3(value3, 0f);
                vertexBuffer[8].Position = new Vector3(value3.X, value3.Y + (float)num + 10f, 0f);
                vertexBuffer[7].Position = new Vector3(value2.X, value2.Y + (float)num + 10f, 0f);
            }
            else
            {
                vertexBuffer[0].Position = new Vector3(value2.X, value.Y - (float)num - 10f, 0f);
                vertexBuffer[1].Position = new Vector3(value3.X, value.Y - (float)num - 10f, 0f);
                vertexBuffer[2].Position = new Vector3(value, 0f);
                vertexBuffer[3].Position = new Vector3(value2.X, value.Y - (float)num - 10f, 0f);
                vertexBuffer[4].Position = new Vector3(value, 0f);
                vertexBuffer[5].Position = new Vector3(value2, 0f);
                vertexBuffer[6].Position = new Vector3(value3.X, value.Y - (float)num - 10f, 0f);
                vertexBuffer[7].Position = new Vector3(value3, 0f);
                vertexBuffer[8].Position = new Vector3(value, 0f);
            }

            DrawPrimitives(vertexBuffer);
        }
    }
}
