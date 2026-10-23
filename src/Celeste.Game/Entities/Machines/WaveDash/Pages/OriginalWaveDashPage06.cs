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
            title = new AreaCompleteTitlePresentation(new Vector2((float)base.Width / 2f, 150f),
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE6_TITLE"), 2f, engine,
                rainbow: true);
            yield return 1.5f;
        }

        public override void Update()
        {
            if (title != null)
            {
                title.Update();
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            SourceAtlasDrawing.DrawCentered(context, null, Presentation.Gfx["Bird Clip Art"],
                new Vector2(base.Width, base.Height) / 2f, PackedColor.White, 1.5f);
            if (title != null)
            {
                title.Render(context);
            }
        }
    }
}
