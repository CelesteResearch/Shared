using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;

namespace Celeste.Game.Entities.Machines.WaveDash.Pages
{
    public partial class OriginalWaveDashPage02
    {
        private class TitleText
        {
            public const float Scale = 1.5f;

            public readonly string Text;

            public readonly Vector2 Position;

            public readonly float Width;

            private float ease;
            private readonly ISourceEngineContext engine;

            public TitleText(ISourceEngineContext engine, Vector2 pos, string text)
            {
                this.engine = engine;
                Position = pos;
                Text = text;
                Width = ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Measure(text).X * 1.5f;
            }

            public IEnumerator Stamp()
            {
                while (ease < 1f)
                {
                    ease = ScalarMath.Approach(ease, 1f, engine.DeltaTime * 4f,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    yield return null;
                }

                yield return 0.2f;
            }

            public void Render(ISourceRenderContext context)
            {
                if (!!(ease <= 0f))
                    return;
                var scale = Vector2.One *
                            (1f + (1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(ease))) *
                            1.5f;
                ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.DrawOutline(context, null, Text,
                    Position + new Vector2(Width / 2f,
                        ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.LineHeight * 0.5f * 1.5f),
                    new(0.5f, 0.5f), scale, PackedColor.White, 2f, PackedColor.Black);
            }
        }
    }
}
