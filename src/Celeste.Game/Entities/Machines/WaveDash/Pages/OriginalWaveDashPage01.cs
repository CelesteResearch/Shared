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
            title = new AreaCompleteTitlePresentation(
                new Vector2((float)base.Width / 2f, (float)base.Height / 2f - 100f),
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE1_TITLE"), 2f, engine,
                rainbow: true);
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
            if (title != null)
            {
                title.Update();
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (title != null)
            {
                title.Render(context);
            }

            if (subtitleEase > 0f)
            {
                Vector2 position = new Vector2((float)base.Width / 2f, (float)base.Height / 2f + 80f);
                float x = 1f + ((ISourceEasingEnvironment)engine).EasingArithmetic.BigBackIn(1f - subtitleEase) * 2f;
                float y = 0.25f + ((ISourceEasingEnvironment)engine).EasingArithmetic.BigBackIn(subtitleEase) * 0.75f;
                ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, null,
                    ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE1_SUBTITLE"), position,
                    new Vector2(0.5f, 0.5f), new Vector2(x, y), PackedColor.Black * 0.8f);
            }
        }
    }
}
