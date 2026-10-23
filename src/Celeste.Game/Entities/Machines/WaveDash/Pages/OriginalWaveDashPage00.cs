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
    public class OriginalWaveDashPage00 : OriginalWaveDashPage
    {
        private PackedColor taskbarColor = SourceHexColor.HexToColor("d9d3b1");

        private string time;

        private Vector2 pptIcon;

        private Vector2 cursor;

        private bool selected;

        public OriginalWaveDashPage00(ISourceEngineContext engine) : base(engine)
        {
            AutoProgress = true;
            ClearColor = SourceHexColor.HexToColor("118475");
            time = DateTime.Now.ToString("h:mm tt", CultureInfo.CreateSpecificCulture("en-US"));
            pptIcon = new Vector2(600f, 500f);
            cursor = new Vector2(1000f, 700f);
        }

        public override IEnumerator Routine()
        {
            yield return 1f;
            yield return MoveCursor(cursor + new Vector2(0f, -80f), 0.3f);
            yield return 0.2f;
            yield return MoveCursor(pptIcon, 0.8f);
            yield return 0.7f;
            selected = true;
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/new_content/game/10_farewell/ppt_doubleclick");
            yield return 0.1f;
            selected = false;
            yield return 0.1f;
            selected = true;
            yield return 0.08f;
            selected = false;
            yield return 0.5f;
            Presentation.ScaleInPoint = pptIcon;
        }

        private IEnumerator MoveCursor(Vector2 to, float time)
        {
            Vector2 from = cursor;
            for (float t = 0f; t < 1f; t += engine.DeltaTime / time)
            {
                cursor = SourceVector2Math.Add(from,
                    SourceVector2Math.Multiply(SourceVector2Math.Subtract(to, from),
                        ((ISourceEasingEnvironment)engine).EasingArithmetic.SineOut(t)));
                yield return null;
            }
        }

        public override void Update()
        {
        }

        public override void Render(ISourceRenderContext context)
        {
            DrawIcon(context, new Vector2(160f, 120f), "desktop/mymountain_icon",
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_DESKTOP_MYPC"));
            DrawIcon(context, new Vector2(160f, 320f), "desktop/recyclebin_icon",
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_DESKTOP_RECYCLEBIN"));
            DrawIcon(context, pptIcon, "desktop/wavedashing_icon",
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_DESKTOP_POWERPOINT"));
            DrawTaskbar(context);
            SourceAtlasDrawing.DrawCentered(context, null, Presentation.Gfx["desktop/cursor"], cursor,
                PackedColor.White);
        }

        public void DrawTaskbar(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, null, 0f, (float)base.Height - 80f, base.Width, 80f, taskbarColor);
            SourcePrimitiveDrawing.Rect(context, null, 0f, (float)base.Height - 80f, base.Width, 4f,
                PackedColor.White * 0.5f);
            AtlasEntry mTexture = Presentation.Gfx["desktop/startberry"];
            float num = 64f;
            float num2 = num / (float)mTexture.FrameHeight * 0.7f;
            string text = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_DESKTOP_STARTBUTTON");
            float num3 = 0.6f;
            float width = (float)mTexture.FrameWidth * num2 +
                          ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Measure(text).X * num3 + 32f;
            Vector2 vector = new Vector2(8f, (float)base.Height - 80f + 8f);
            SourcePrimitiveDrawing.Rect(context, null, vector.X, vector.Y, width, num, PackedColor.White * 0.5f);
            SourceAtlasDrawing.DrawJustified(context, null, mTexture, vector + new Vector2(8f, num / 2f),
                new Vector2(0f, 0.5f), PackedColor.White, Vector2.One * num2);
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, null, text,
                vector + new Vector2((float)mTexture.FrameWidth * num2 + 16f, num / 2f), new Vector2(0f, 0.5f),
                Vector2.One * num3, PackedColor.Black * 0.8f);
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, null, time,
                new Vector2((float)base.Width - 24f, (float)base.Height - 40f), new Vector2(1f, 0.5f),
                Vector2.One * 0.6f,
                PackedColor.Black * 0.8f);
        }

        private void DrawIcon(ISourceRenderContext context, Vector2 position, string icon, string text)
        {
            bool flag = cursor.X > position.X - 64f && cursor.Y > position.Y - 64f && cursor.X < position.X + 64f &&
                        cursor.Y < position.Y + 80f;
            if (selected && flag)
            {
                SourcePrimitiveDrawing.Rect(context, null, position.X - 80f, position.Y - 80f, 160f, 200f,
                    PackedColor.White * 0.25f);
            }

            if (flag)
            {
                DrawDottedRect(context, position.X - 80f, position.Y - 80f, 160f, 200f);
            }

            AtlasEntry mTexture = Presentation.Gfx[icon];
            float scale = 128f / (float)mTexture.FrameHeight;
            SourceAtlasDrawing.DrawCentered(context, null, mTexture, position, PackedColor.White, scale);
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, null, text,
                position + new Vector2(0f, 80f), new Vector2(0.5f, 0f), Vector2.One * 0.6f,
                (selected && flag) ? PackedColor.Black : PackedColor.White);
        }

        private void DrawDottedRect(ISourceRenderContext context, float x, float y, float w, float h)
        {
            float num = 4f;
            SourcePrimitiveDrawing.Rect(context, null, x, y, w, num, PackedColor.White);
            SourcePrimitiveDrawing.Rect(context, null, x + w - num, y, num, h, PackedColor.White);
            SourcePrimitiveDrawing.Rect(context, null, x, y, num, h, PackedColor.White);
            SourcePrimitiveDrawing.Rect(context, null, x, y + h - num, w, num, PackedColor.White);
            if (!selected)
            {
                for (float num2 = 4f; num2 < w; num2 += num * 2f)
                {
                    SourcePrimitiveDrawing.Rect(context, null, x + num2, y, num, num, ClearColor);
                    SourcePrimitiveDrawing.Rect(context, null, x + w - num2, y + h - num, num, num, ClearColor);
                }

                for (float num3 = 4f; num3 < h; num3 += num * 2f)
                {
                    SourcePrimitiveDrawing.Rect(context, null, x, y + num3, num, num, ClearColor);
                    SourcePrimitiveDrawing.Rect(context, null, x + w - num, y + h - num3, num, num, ClearColor);
                }
            }
        }
    }
}
