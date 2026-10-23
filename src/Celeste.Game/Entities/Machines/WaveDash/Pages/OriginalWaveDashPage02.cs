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
    public partial class OriginalWaveDashPage02 : OriginalWaveDashPage
    {
        private List<TitleText> title = new List<TitleText>();

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
            string[] text = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE2_TITLE").Split('|');
            Vector2 pos = new Vector2(128f, 128f);
            for (int i = 0; i < text.Length; i++)
            {
                TitleText item = new TitleText(engine, pos, text[i]);
                title.Add(item);
                yield return item.Stamp();
                pos.X += item.Width + ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Measure(' ').X * 1.5f;
            }

            yield return PressButton();
            list = OriginalFancyTextParser.Parse(
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("WAVEDASH_PAGE2_LIST"), base.Width, 32, 1f,
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
            foreach (TitleText item in title)
            {
                item.Render(context);
            }

            if (list != null)
            {
                list.Draw(context, null, (ISourceRichTextDrawProcess)engine, new Vector2(160f, 260f),
                    new Vector2(0f, 0f),
                    Vector2.One, 1f, 0, listIndex);
            }

            if (impossibleEase > 0f)
            {
                AtlasEntry mTexture = Presentation.Gfx["Guy Clip Art"];
                float num = 0.75f;
                SourceAtlasDrawing.Draw(context, null, mTexture,
                    new Vector2((float)base.Width - (float)mTexture.FrameWidth * num,
                        (float)base.Height - 640f * impossibleEase), Vector2.Zero, PackedColor.White, num);
                Matrix4x4 transformMatrix = SourceMatrixMath.Multiply(
                    SourceMatrixMath.CreateRotationZ(-0.5f +
                                                     ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(
                                                         1f - impossibleEase) * 8f),
                    SourceMatrixMath.CreateTranslation(base.Width - 500, base.Height - 600, 0f));
                ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, null, null, null, transformMatrix);
                ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, null,
                    ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_PAGE2_IMPOSSIBLE"), Vector2.Zero,
                    new Vector2(0.5f, 0.5f), Vector2.One * (2f + (1f - impossibleEase) * 0.5f),
                    PackedColor.Black * impossibleEase);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
            }
        }
    }
}
