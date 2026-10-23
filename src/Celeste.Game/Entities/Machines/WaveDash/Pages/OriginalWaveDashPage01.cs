using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Display.Colors;
using Celeste.Simulation.UI.Menus.Completion;

namespace Celeste.Game.Entities.Machines.WaveDash.Pages
{
    public class OriginalWaveDashPage01 : OriginalWaveDashPage
    {
        private AreaCompleteTitlePresentation title;

        private float subtitleEase;

        public OriginalWaveDashPage01(ISourceEngineContext engine) : base(engine)
        {
            Transition = Transitions.ScaleIn;
            ClearColor = SourceHexColor.HexToColor("9fc5e8");
        }

        public override void Added(OriginalWaveDashPresentationState presentation)
        {
            base.Added(presentation);
        }

        public override IEnumerator Routine()
        {
            ((IOriginalGameplayProcess)engine).AudioSession.SetAltMusic(
                "event:/new_content/music/lvl10/intermission_powerpoint");
            yield return 1f;
            title = new(
                new(Width / 2f, Height / 2f - 100f),
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE1_TITLE"), 2f, engine,
                true);
            yield return 1f;
            while (subtitleEase < 1f)
            {
                subtitleEase = ScalarMath.Approach(subtitleEase, 1f, engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }

            yield return 0.1f;
        }

        public override void Update()
        {
            if (title != null) title.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (title != null) title.Render(context);

            if (!(subtitleEase > 0f))
                return;
            var position = new Vector2(Width / 2f, Height / 2f + 80f);
            var x = 1f + ((ISourceEasingEnvironment)engine).EasingArithmetic.BigBackIn(1f - subtitleEase) * 2f;
            var y = 0.25f + ((ISourceEasingEnvironment)engine).EasingArithmetic.BigBackIn(subtitleEase) * 0.75f;
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, null,
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE1_SUBTITLE"), position,
                new(0.5f, 0.5f), new(x, y), PackedColor.Black * 0.8f);
        }
    }
}
