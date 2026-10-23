using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Simulation.UI.Menus.Completion;

namespace Celeste.Game.Entities.Machines.WaveDash.Pages
{
    public class OriginalWaveDashPage06 : OriginalWaveDashPage
    {
        private AreaCompleteTitlePresentation title;

        public OriginalWaveDashPage06(ISourceEngineContext engine) : base(engine)
        {
            Transition = Transitions.Rotate3D;
            ClearColor = SourceHexColor.HexToColor("d9d2e9");
        }

        public override IEnumerator Routine()
        {
            yield return 1f;
            ((IOriginalGameplayProcess)engine).AudioSession.Play(
                "event:/new_content/game/10_farewell/ppt_happy_wavedashing");
            title = new(new(Width / 2f, 150f),
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE6_TITLE"), 2f, engine,
                true);
            yield return 1.5f;
        }

        public override void Update()
        {
            if (title != null) title.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            SourceAtlasDrawing.DrawCentered(context, null, Presentation.Gfx["Bird Clip Art"],
                new Vector2(Width, Height) / 2f, PackedColor.White, 1.5f);
            if (title != null) title.Render(context);
        }
    }
}
