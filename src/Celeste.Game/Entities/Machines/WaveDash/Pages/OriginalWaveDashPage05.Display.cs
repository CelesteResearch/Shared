using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Entities.Machines.WaveDash.Playback;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Graphics.Text.RichText.Layout;

namespace Celeste.Game.Entities.Machines.WaveDash.Pages
{
    public partial class OriginalWaveDashPage05
    {
        private class Display
        {
            public readonly Vector2 Position;

            public readonly RichTextLayout Info;

            public readonly OriginalWaveDashPlaybackTutorial Tutorial;

            private readonly SimulationCoroutine routine;

            private float xEase;

            private float time;
            private readonly ISourceEngineContext engine;

            public Display(ISourceEngineContext engine, Vector2 position, string text, string tutorial,
                Vector2 tutorialOffset)
            {
                this.engine = engine;
                Position = position;
                Info = OriginalFancyTextParser.Parse(text, 896, 8, 1f, PackedColor.Black * 0.6f,
                    OriginalFancyTextContext.Create((IOriginalFancyTextProcess)engine));
                Tutorial = new(engine, tutorial, tutorialOffset, new(1f, 1f),
                    new(1f, 1f));
                Tutorial.OnRender = delegate(ISourceRenderContext context)
                {
                    SourcePrimitiveDrawing.Line((ISourceDrawScope)context, -64f, 20f, 64f, 20f, PackedColor.Black,
                        ((ISourceVectorEnvironment)engine).VectorArithmetic);
                };
                routine = new(engine, Routine());
            }

            private IEnumerator Routine()
            {
                var playback = Tutorial.Playback;
                var step = 0;
                while (true)
                {
                    var frameIndex = playback.FrameIndex;
                    if (step % 2 == 0) Tutorial.Update();

                    if (frameIndex != playback.FrameIndex && playback.FrameIndex == playback.FrameCount - 1)
                    {
                        while (time < 3f) yield return null;

                        yield return 0.1f;
                        while (xEase < 1f)
                        {
                            xEase = ScalarMath.Approach(xEase, 1f, engine.DeltaTime * 4f,
                                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                            yield return null;
                        }

                        xEase = 1f;
                        yield return 0.5f;
                        xEase = 0f;
                        time = 0f;
                    }

                    step++;
                    yield return null;
                }
            }

            public void Update()
            {
                time += engine.DeltaTime;
                routine.Update();
            }

            public void Render(ISourceRenderContext context)
            {
                Tutorial.Render(context, Position, 4f);
                Info.DrawJustifyPerLine(context, null, (ISourceRichTextDrawProcess)engine,
                    Position + Vector2.UnitY * 200f,
                    new(0.5f, 0f), Vector2.One * 0.8f, 1f);
                if (!(xEase > 0f))
                    return;
                var vector = Vector2Geometry.AngleToVector((1f - xEase) * 0.1f + (float)Math.PI / 4f, 1f);
                var vector2 = new Vector2(-vector.Y, vector.X);
                var num = 0.5f + (1f - xEase) * 0.5f;
                var thickness = 64f * num;
                var num2 = 300f * num;
                var position = Position;
                SourcePrimitiveDrawing.Line((ISourceDrawScope)context, position - vector * num2,
                    position + vector * num2, PackedColor.Red, thickness,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                SourcePrimitiveDrawing.Line((ISourceDrawScope)context, position - vector2 * num2,
                    position + vector2 * num2, PackedColor.Red, thickness,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
            }
        }
    }
}
