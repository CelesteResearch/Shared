using System;
using System.Collections;
using System.Globalization;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.Machines.WaveDash.Pages
{
    public class OriginalWaveDashPage00 : OriginalWaveDashPage
    {
        private readonly PackedColor taskbarColor = SourceHexColor.HexToColor("d9d3b1");

        private readonly string time;

        private readonly Vector2 pptIcon;

        private Vector2 cursor;

        private bool selected;

        public OriginalWaveDashPage00(ISourceEngineContext engine) : base(engine)
        {
            AutoProgress = true;
            ClearColor = SourceHexColor.HexToColor("118475");
            time = DateTime.Now.ToString("h:mm tt", CultureInfo.CreateSpecificCulture("en-US"));
            pptIcon = new(600f, 500f);
            cursor = new(1000f, 700f);
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
            var from = cursor;
            for (var t = 0f; t < 1f; t += engine.DeltaTime / time)
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
            DrawIcon(context, new(160f, 120f), "desktop/mymountain_icon",
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_DESKTOP_MYPC"));
            DrawIcon(context, new(160f, 320f), "desktop/recyclebin_icon",
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_DESKTOP_RECYCLEBIN"));
            DrawIcon(context, pptIcon, "desktop/wavedashing_icon",
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_DESKTOP_POWERPOINT"));
            DrawTaskbar(context);
            SourceAtlasDrawing.DrawCentered(context, null, Presentation.Gfx["desktop/cursor"], cursor,
                PackedColor.White);
        }

        public void DrawTaskbar(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, null, 0f, Height - 80f, Width, 80f, taskbarColor);
            SourcePrimitiveDrawing.Rect(context, null, 0f, Height - 80f, Width, 4f,
                PackedColor.White * 0.5f);
            var mTexture = Presentation.Gfx["desktop/startberry"];
            var num = 64f;
            var num2 = num / mTexture.FrameHeight * 0.7f;
            var text = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("WAVEDASH_DESKTOP_STARTBUTTON");
            var num3 = 0.6f;
            var width = mTexture.FrameWidth * num2 +
                        ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Measure(text).X * num3 + 32f;
            var vector = new Vector2(8f, Height - 80f + 8f);
            SourcePrimitiveDrawing.Rect(context, null, vector.X, vector.Y, width, num, PackedColor.White * 0.5f);
            SourceAtlasDrawing.DrawJustified(context, null, mTexture, vector + new Vector2(8f, num / 2f),
                new(0f, 0.5f), PackedColor.White, Vector2.One * num2);
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, null, text,
                vector + new Vector2(mTexture.FrameWidth * num2 + 16f, num / 2f), new(0f, 0.5f),
                Vector2.One * num3, PackedColor.Black * 0.8f);
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, null, time,
                new(Width - 24f, Height - 40f), new(1f, 0.5f),
                Vector2.One * 0.6f,
                PackedColor.Black * 0.8f);
        }

        private void DrawIcon(ISourceRenderContext context, Vector2 position, string icon, string text)
        {
            var flag = cursor.X > position.X - 64f && cursor.Y > position.Y - 64f && cursor.X < position.X + 64f &&
                       cursor.Y < position.Y + 80f;
            if (selected && flag)
                SourcePrimitiveDrawing.Rect(context, null, position.X - 80f, position.Y - 80f, 160f, 200f,
                    PackedColor.White * 0.25f);

            if (flag) DrawDottedRect(context, position.X - 80f, position.Y - 80f, 160f, 200f);

            var mTexture = Presentation.Gfx[icon];
            var scale = 128f / mTexture.FrameHeight;
            SourceAtlasDrawing.DrawCentered(context, null, mTexture, position, PackedColor.White, scale);
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, null, text,
                position + new Vector2(0f, 80f), new(0.5f, 0f), Vector2.One * 0.6f,
                selected && flag ? PackedColor.Black : PackedColor.White);
        }

        private void DrawDottedRect(ISourceRenderContext context, float x, float y, float w, float h)
        {
            var num = 4f;
            SourcePrimitiveDrawing.Rect(context, null, x, y, w, num, PackedColor.White);
            SourcePrimitiveDrawing.Rect(context, null, x + w - num, y, num, h, PackedColor.White);
            SourcePrimitiveDrawing.Rect(context, null, x, y, num, h, PackedColor.White);
            SourcePrimitiveDrawing.Rect(context, null, x, y + h - num, w, num, PackedColor.White);
            if (!selected)
            {
                for (var num2 = 4f; num2 < w; num2 += num * 2f)
                {
                    SourcePrimitiveDrawing.Rect(context, null, x + num2, y, num, num, ClearColor);
                    SourcePrimitiveDrawing.Rect(context, null, x + w - num2, y + h - num, num, num, ClearColor);
                }

                for (var num3 = 4f; num3 < h; num3 += num * 2f)
                {
                    SourcePrimitiveDrawing.Rect(context, null, x, y + num3, num, num, ClearColor);
                    SourcePrimitiveDrawing.Rect(context, null, x + w - num, y + h - num3, num, num, ClearColor);
                }
            }
        }
    }
}
