using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Simulation.UI.Menus.Completion;

namespace Celeste.Game.Entities.Machines.WaveDash.Pages
{
    public class OriginalWaveDashPage03 : OriginalWaveDashPage
    {
        private readonly string title;

        private string titleDisplayed;

        private AtlasEntry clipArt;

        private float clipArtEase;

        private RichTextLayout infoText;

        private AreaCompleteTitlePresentation easyText;

        public OriginalWaveDashPage03(ISourceEngineContext engine) : base(engine)
        {
            Transition = Transitions.Blocky;
            ClearColor = SourceHexColor.HexToColor("d9ead3");
            title = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE3_TITLE");
            titleDisplayed = "";
        }

        public override void Added(OriginalWaveDashPresentationState presentation)
        {
            base.Added(presentation);
            clipArt = presentation.Gfx["moveset"];
        }

        public override IEnumerator Routine()
        {
            while (titleDisplayed.Length < title.Length)
            {
                titleDisplayed += title[titleDisplayed.Length];
                yield return 0.05f;
            }

            yield return PressButton();
            ((IOriginalGameplayProcess)engine).AudioSession.Play(
                "event:/new_content/game/10_farewell/ppt_wavedash_whoosh");
            while (clipArtEase < 1f)
            {
                clipArtEase = ScalarMath.Approach(clipArtEase, 1f, engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }

            yield return 0.25f;
            infoText = OriginalFancyTextParser.Parse(
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("WAVEDASH_PAGE3_INFO"), Width - 240, 32, 1f,
                PackedColor.Black * 0.7f, OriginalFancyTextContext.Create((IOriginalFancyTextProcess)engine));
            yield return PressButton();
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/new_content/game/10_farewell/ppt_its_easy");
            easyText = new(new(Width / 2f, Height - 150),
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE3_EASY"), 2f, engine,
                true);
            yield return 1f;
        }

        public override void Update()
        {
            if (easyText != null) easyText.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.DrawOutline(context, null, titleDisplayed,
                new(128f, 100f), Vector2.Zero, Vector2.One * 1.5f, PackedColor.White, 2f, PackedColor.Black);
            if (clipArtEase > 0f)
            {
                var scale = Vector2.One * (1f + (1f - clipArtEase) * 3f) * 0.8f;
                var rotation = (1f - clipArtEase) * 8f;
                var color = PackedColor.White * clipArtEase;
                SourceAtlasDrawing.DrawCentered(context, null, clipArt,
                    new(Width / 2f, Height / 2f - 90f), color, scale, rotation);
            }

            if (infoText != null)
                infoText.Draw(context, null, (ISourceRichTextDrawProcess)engine,
                    new(Width / 2f, Height - 350), new(0.5f, 0f), Vector2.One, 1f);

            if (easyText != null) easyText.Render(context);
        }
    }
}
