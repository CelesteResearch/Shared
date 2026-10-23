using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Entities.Machines.WaveDash.Playback;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Nodes;

namespace Celeste.Game.Entities.Machines.WaveDash.Pages
{
    public class OriginalWaveDashPage04 : OriginalWaveDashPage
    {
        private OriginalWaveDashPlaybackTutorial tutorial;

        private RichTextLayout list;

        private int listIndex;

        private float time;

        public OriginalWaveDashPage04(ISourceEngineContext engine) : base(engine)
        {
            Transition = Transitions.FadeIn;
            ClearColor = SourceHexColor.HexToColor("f4cccc");
        }

        public override void Added(OriginalWaveDashPresentationState presentation)
        {
            base.Added(presentation);
            var textures = Presentation.Gfx.GetAtlasSubtextures("playback/platforms");
            tutorial = new(engine, "wavedashppt", new(-126f, 0f),
                new(1f, 1f), new(1f, -1f));
            tutorial.OnRender = delegate(ISourceRenderContext context)
            {
                SourceAtlasDrawing.DrawCentered(context, null, textures[(int)(time % textures.Count)],
                    Vector2.Zero, PackedColor.White);
            };
        }

        public override IEnumerator Routine()
        {
            yield return 0.5f;
            list = OriginalFancyTextParser.Parse(
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("WAVEDASH_PAGE4_LIST"), Width, 32, 1f,
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
        }

        public override void Update()
        {
            time += engine.DeltaTime * 4f;
            tutorial.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.DrawOutline(context, null,
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE4_TITLE"),
                new(128f, 100f),
                Vector2.Zero, Vector2.One * 1.5f, PackedColor.White, 2f, PackedColor.Black);
            tutorial.Render(context, new(Width / 2f, Height / 2f - 100f), 4f);
            if (list != null)
                list.Draw(context, null, (ISourceRichTextDrawProcess)engine, new(160f, Height - 400),
                    new(0f, 0f), Vector2.One, 1f, 0, listIndex);
        }
    }
}
