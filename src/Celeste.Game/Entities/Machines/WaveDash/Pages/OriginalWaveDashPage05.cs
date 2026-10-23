using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Game.Entities.Machines.WaveDash.Pages
{
    public partial class OriginalWaveDashPage05 : OriginalWaveDashPage
    {
        private readonly List<Display> displays = [];

        public OriginalWaveDashPage05(ISourceEngineContext engine) : base(engine)
        {
            Transition = Transitions.Spiral;
            ClearColor = SourceHexColor.HexToColor("fff2cc");
        }

        public override void Added(OriginalWaveDashPresentationState presentation)
        {
            base.Added(presentation);
            displays.Add(new(engine, new(Width * 0.28f, Height - 600),
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("WAVEDASH_PAGE5_INFO1"), "too_close",
                new(-50f, 20f)));
            displays.Add(new(engine, new(Width * 0.72f, Height - 600),
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("WAVEDASH_PAGE5_INFO2"), "too_far",
                new(-50f, -35f)));
        }

        public override IEnumerator Routine()
        {
            yield return 0.5f;
        }

        public override void Update()
        {
            foreach (var display in displays) display.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.DrawOutline(context, null,
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE5_TITLE"),
                new(128f, 100f),
                Vector2.Zero, Vector2.One * 1.5f, PackedColor.White, 2f, PackedColor.Black);
            foreach (var display in displays) display.Render(context);
        }
    }
}
