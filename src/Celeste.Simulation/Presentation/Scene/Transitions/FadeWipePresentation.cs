using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Rendering;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public class FadeWipePresentation : ScreenWipePresentation
    {
        private SourceVertexPositionColor[] vertexBuffer = new SourceVertexPositionColor[6];

        public Action<float> OnUpdate;

        public FadeWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
            : base(scene, wipeIn, onComplete)
        {
        }


        public override void Update(object scene)
        {
            base.Update(scene);
            if (OnUpdate != null)
            {
                OnUpdate(Percent);
            }
        }

        public override void Render(object scene)
        {
            PackedColor color = WipeColor * (WipeIn ? (1f - Easing.CubeIn(Percent)) : Easing.CubeOut(Percent));
            vertexBuffer[0].Color = color;
            vertexBuffer[0].Position = new Vector3(-10f, -10f, 0f);
            vertexBuffer[1].Color = color;
            vertexBuffer[1].Position = new Vector3(base.Right, -10f, 0f);
            vertexBuffer[2].Color = color;
            vertexBuffer[2].Position = new Vector3(-10f, base.Bottom, 0f);
            vertexBuffer[3].Color = color;
            vertexBuffer[3].Position = new Vector3(base.Right, -10f, 0f);
            vertexBuffer[4].Color = color;
            vertexBuffer[4].Position = new Vector3(base.Right, base.Bottom, 0f);
            vertexBuffer[5].Color = color;
            vertexBuffer[5].Position = new Vector3(-10f, base.Bottom, 0f);
            DrawPrimitives(vertexBuffer);
        }
    }
}
