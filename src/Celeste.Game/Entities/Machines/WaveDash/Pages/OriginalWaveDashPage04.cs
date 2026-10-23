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
using Celeste.Game.Entities.Machines.WaveDash.Playback;

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
            List<AtlasEntry> textures = Presentation.Gfx.GetAtlasSubtextures("playback/platforms");
            tutorial = new OriginalWaveDashPlaybackTutorial(engine, "wavedashppt", new Vector2(-126f, 0f),
                new Vector2(1f, 1f), new Vector2(1f, -1f));
            tutorial.OnRender = delegate(ISourceRenderContext context)
            {
                SourceAtlasDrawing.DrawCentered(context, null, textures[(int)(time % (float)textures.Count)],
                    Vector2.Zero, PackedColor.White);
            };
        }

        public override IEnumerator Routine()
        {
            yield return 0.5f;
            list = OriginalFancyTextParser.Parse(
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("WAVEDASH_PAGE4_LIST"), base.Width, 32, 1f,
                PackedColor.Black * 0.7f, OriginalFancyTextContext.Create((IOriginalFancyTextProcess)engine));
            float delay = 0f;
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
                new Vector2(128f, 100f),
                Vector2.Zero, Vector2.One * 1.5f, PackedColor.White, 2f, PackedColor.Black);
            tutorial.Render(context, new Vector2((float)base.Width / 2f, (float)base.Height / 2f - 100f), 4f);
            if (list != null)
            {
                list.Draw(context, null, (ISourceRichTextDrawProcess)engine, new Vector2(160f, base.Height - 400),
                    new Vector2(0f, 0f), Vector2.One, 1f, 0, listIndex);
            }
        }
    }
}
