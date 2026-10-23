using Celeste.Core.Display;
using System;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Input.Gameplay;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Text;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Nodes;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Simulation.UI.Menus.Completion;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Threading;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Audio.Fmod.Events;

namespace Celeste.Game.Entities.Machines.WaveDash.Pages
{
    public partial class OriginalWaveDashPage05 : OriginalWaveDashPage
    {
        private List<Display> displays = new List<Display>();

        public OriginalWaveDashPage05(ISourceEngineContext engine) : base(engine)
        {
            Transition = Transitions.Spiral;
            ClearColor = SourceHexColor.HexToColor("fff2cc");
        }

        public override void Added(OriginalWaveDashPresentationState presentation)
        {
            base.Added(presentation);
            displays.Add(new Display(engine, new Vector2((float)base.Width * 0.28f, base.Height - 600),
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("WAVEDASH_PAGE5_INFO1"), "too_close",
                new Vector2(-50f, 20f)));
            displays.Add(new Display(engine, new Vector2((float)base.Width * 0.72f, base.Height - 600),
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("WAVEDASH_PAGE5_INFO2"), "too_far",
                new Vector2(-50f, -35f)));
        }

        public override IEnumerator Routine()
        {
            yield return 0.5f;
        }

        public override void Update()
        {
            foreach (Display display in displays)
            {
                display.Update();
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.DrawOutline(context, null,
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE5_TITLE"),
                new Vector2(128f, 100f),
                Vector2.Zero, Vector2.One * 1.5f, PackedColor.White, 2f, PackedColor.Black);
            foreach (Display display in displays)
            {
                display.Render(context);
            }
        }
    }
}
