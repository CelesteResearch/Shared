using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsChapterSequence
    {
        public override void Render(ISourceRenderContext context)
        {
            var mirror = Process.SaveContext.CurrentSave != null
                         && Process.SaveContext.CurrentSave.Assists.MirrorMode;
            if (!Level.Paused)
            {
                if (mirror)
                    SourceAtlasDrawing.Draw(context, this, gradient, new(1720f, -10f),
                        Vector2.Zero, PackedColor.White * .6f, new Vector2(-1f, 1100f));
                else
                    SourceAtlasDrawing.Draw(context, this, gradient, new(200f, -10f),
                        Vector2.Zero, PackedColor.White * .6f, new Vector2(1f, 1100f));
            }

            if (fade > 0f)
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f,
                    PackedColor.Black * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(fade));
            if (credits != null && !Level.Paused)
                credits.Render(context, new(mirror ? 100 : 1820, 0f));
            base.Render(context);
        }
    }
}
