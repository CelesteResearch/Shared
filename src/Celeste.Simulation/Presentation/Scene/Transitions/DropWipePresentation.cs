using System;
using Celeste.Core.Display;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Rendering;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public class DropWipePresentation : ScreenWipePresentation
    {
        private const int columns = 10;

        private readonly float[] meetings;

        private readonly PackedColor color;

        public DropWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
            : base(scene, wipeIn, onComplete)
        {
            color = WipeColor;
            meetings = new float[10];
            for (var i = 0; i < 10; i++) meetings[i] = 0.05f + SourceRandomMath.NextFloat(Random) * 0.9f;
        }

        public override void Render(object scene)
        {
            var num = WipeIn ? 1f - Percent : Percent;
            var num2 = 192f;
            RenderContext.BeginBatch(new(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.PointClamp, null, null, null, RenderContext.Graphics.ScreenMatrix));
            if (num >= 0.995f)
                SourcePrimitiveDrawing.Rect(RenderContext, this, -10f, -10f, RenderContext.Graphics.Width + 20,
                    RenderContext.Graphics.Height + 20, color);
            else
                for (var i = 0; i < 10; i++)
                {
                    var num3 = i / 10f;
                    var num4 = (WipeIn ? 1f - num3 : num3) * 0.3f;
                    if (num > num4)
                    {
                        var num5 = Easing.CubeIn(Extrema.Min(1f, (num - num4) / 0.7f));
                        var num6 = 1080f * meetings[i] * num5;
                        var num7 = 1080f * (1f - meetings[i]) * num5;
                        SourcePrimitiveDrawing.Rect(RenderContext, this, i * num2 - 1f, -10f, num2 + 2f,
                            num6 + 10f,
                            color);
                        SourcePrimitiveDrawing.Rect(RenderContext, this, i * num2 - 1f, 1080f - num7, num2 + 2f,
                            num7 + 10f, color);
                    }
                }

            RenderContext.EndBatch();
        }
    }
}
