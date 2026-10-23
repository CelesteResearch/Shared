using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Nodes;

namespace Celeste.Game.Entities.Machines.WaveDash.Pages
{
    public partial class OriginalWaveDashPage02 : OriginalWaveDashPage
    {
        private readonly List<TitleText> title = [];

        private RichTextLayout list;

        private int listIndex;

        private float impossibleEase;

        public OriginalWaveDashPage02(ISourceEngineContext engine) : base(engine)
        {
            Transition = Transitions.Rotate3D;
            ClearColor = SourceHexColor.HexToColor("fff2cc");
        }

        public override void Added(OriginalWaveDashPresentationState presentation)
        {
            base.Added(presentation);
        }

        public override IEnumerator Routine()
        {
            var text = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE2_TITLE").Split('|');
            var pos = new Vector2(128f, 128f);
            for (var i = 0; i < text.Length; i++)
            {
                var item = new TitleText(engine, pos, text[i]);
                title.Add(item);
                yield return item.Stamp();
                pos.X += item.Width + ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Measure(' ').X * 1.5f;
            }

            yield return PressButton();
            list = OriginalFancyTextParser.Parse(
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("WAVEDASH_PAGE2_LIST"), Width, 32, 1f,
                PackedColor.Black * 0.7f, OriginalFancyTextContext.Create((IOriginalFancyTextProcess)engine));
            var delay = 0f;
            while (listIndex < list.Nodes.Count)
            {
                if (list.Nodes[listIndex] is RichTextLineBreak)
                {
                    yield return PressButton();
                }
                else
                {
                    delay += 0.008f;
                    if (delay >= 0.016f)
                    {
                        delay -= 0.016f;
                        yield return 0.016f;
                    }
                }

                listIndex++;
            }

            yield return PressButton();
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/new_content/game/10_farewell/ppt_impossible");
            while (impossibleEase < 1f)
            {
                impossibleEase = ScalarMath.Approach(impossibleEase, 1f, engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }
        }

        public override void Update()
        {
        }

        public override void Render(ISourceRenderContext context)
        {
            foreach (var item in title) item.Render(context);

            if (list != null)
                list.Draw(context, null, (ISourceRichTextDrawProcess)engine, new(160f, 260f),
                    new(0f, 0f),
                    Vector2.One, 1f, 0, listIndex);

            if (impossibleEase > 0f)
            {
                var mTexture = Presentation.Gfx["Guy Clip Art"];
                var num = 0.75f;
                SourceAtlasDrawing.Draw(context, null, mTexture,
                    new(Width - mTexture.FrameWidth * num,
                        Height - 640f * impossibleEase), Vector2.Zero, PackedColor.White, num);
                var transformMatrix = SourceMatrixMath.Multiply(
                    SourceMatrixMath.CreateRotationZ(-0.5f +
                                                     ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(
                                                         1f - impossibleEase) * 8f),
                    SourceMatrixMath.CreateTranslation(Width - 500, Height - 600, 0f));
                ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, null, null, null, transformMatrix);
                ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, null,
                    ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE2_IMPOSSIBLE"), Vector2.Zero,
                    new(0.5f, 0.5f), Vector2.One * (2f + (1f - impossibleEase) * 0.5f),
                    PackedColor.Black * impossibleEase);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
            }
        }
    }
}
