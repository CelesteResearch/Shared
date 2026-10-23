using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Diagnostics.Commands;
using Celeste.Graphics.Rendering;

namespace Celeste.Everest.Diagnostics.Commands
{
    public partial class SourceEverestCommands
    {
        public override void Render()
        {
            var viewWidth = process.ViewWidth;
            var viewHeight = process.ViewHeight;
            var state = installed.FnaInput.Mouse.GetState();
            var num = state.ScrollWheelValue - mouseScroll;
            mouseScroll = state.ScrollWheelValue;
            var vector = new Vector2(state.X - installed.Viewport.X, state.Y - installed.Viewport.Y);
            Vector2? vector2 = null;
            var max = 1;
            var text = "";
            IOriginalLevelCommands level = installed.Scene as OriginalLevelSceneRoot;
            if (level != null)
                text = string.Concat(text,
                    string.Format("Area: {0} @ {1}\n", level.LevelName,
                        installed.AreaKeys.Format(level.Area)));

            text = string.Concat(text,
                string.Format("Cursor @\n screen: {0}, {1}", (int)Math.Round(vector.X),
                    (int)Math.Round(vector.Y)));
            if (level != null)
            {
                var camera = level.Camera;
                var num2 = process.ViewWidth / (float)installed.Width;
                var vector3 =
                    Vector2Geometry.Floor(level.ScreenToWorld(installed.VectorArithmetic.Divide(vector, num2)));
                if (!installed.CelesteTASInstalled.Value)
                    text = string.Concat(text,
                        string.Format("\n world:       {0}, {1}", (int)Math.Round(vector3.X),
                            (int)Math.Round(vector3.Y)));

                vector3 -= level.LevelOffset;
                text = string.Concat(text,
                    FormatSourceLevelCursor("\n level:       {0}, {1}", (int)Math.Round(vector3.X),
                        (int)Math.Round(vector3.Y)));
                vector2 = Vector2Geometry.Floor(installed.VectorArithmetic.Divide(vector3, 8f));
                text = string.Concat(text,
                    string.Format("\n level, /8:   {0}, {1}", (int)Math.Round(vector2.Value.X),
                        (int)Math.Round(vector2.Value.Y)));
                var value = 8f;
                var vector4 = vector2;
                vector2 = value * vector4;
                text = string.Concat(text,
                    string.Format("\n level, snap: {0}, {1}", (int)Math.Round(vector2.Value.X),
                        (int)Math.Round(vector2.Value.Y)));
                vector2 = vector2 + new Vector2(4f, 4f) + level.LevelOffset;
                vector2 = Vector2Geometry.Floor(level.WorldToScreen(vector2.Value) * num2);
                max = process.ViewWidth / camera.Viewport.Width;
            }

            process.Draw.SpriteBatch.Begin();
            if (num < 0)
                cursorScale--;
            else if (num > 0) cursorScale++;

            cursorScale = ScalarMath.Clamp(cursorScale, 1, max);
            if (vector2.HasValue) DrawCursor(vector2.Value, cursorScale, PackedColor.Red);

            DrawCursor(vector, cursorScale, PackedColor.Yellow);
            var vector5 = process.Draw.DefaultFont.MeasureString(text);
            SourcePrimitiveDrawing.Rect(process, 10f, 10f, vector5.X + 20f, vector5.Y + 20f, PackedColor.Black * 0.8f);
            process.Draw.SpriteBatch.DrawString(process.Draw.DefaultFont, text, new(20f, 20f),
                PackedColor.White.PackedValue);
            SourcePrimitiveDrawing.Rect(process, 10f, viewHeight - 50f, viewWidth - 20f, 40f,
                PackedColor.Black * 0.8f);
            var vector6 = new Vector2(20f, viewHeight - 42f);
            process.Draw.SpriteBatch.DrawString(process.Draw.DefaultFont, ">" + currentText, vector6,
                PackedColor.White.PackedValue);
            if (underscore)
            {
                var vector7 = process.Draw.DefaultFont.MeasureString(">" + currentText.Substring(0, charIndex));
                vector7.X += 1f;
                SourcePrimitiveDrawing.Line(process, vector6 + new Vector2(vector7.X, 0f), vector6 + vector7,
                    PackedColor.White, installed.VectorArithmetic);
            }

            if (drawCommands.Count > 0)
            {
                var num3 = Math.Min((viewHeight - 100) / 30, drawCommands.Count - firstLineIndexToDraw);
                var num4 = 10f + 30f * num3;
                SourcePrimitiveDrawing.Rect(process, 10f, viewHeight - num4 - 60f, viewWidth - 20f, num4,
                    PackedColor.Black * 0.8f);
                for (var i = 0; i < num3 && firstLineIndexToDraw + i < drawCommands.Count; i++)
                    process.Draw.SpriteBatch.DrawString(process.Draw.DefaultFont,
                        drawCommands[firstLineIndexToDraw + i].Text,
                        new(20f, viewHeight - 92f - 30f * i),
                        drawCommands[firstLineIndexToDraw + i].Color.PackedValue);
            }

            process.Draw.SpriteBatch.End();
        }

        internal void DrawCursor(Vector2 position, int scale, PackedColor color)
        {
            for (var i = -scale / 2; i <= scale / 2; i++)
            {
                SourcePrimitiveDrawing.Line(process, position.X - 4f * scale, position.Y + i,
                    position.X - 2f * scale, position.Y + i, color, installed.VectorArithmetic);
                SourcePrimitiveDrawing.Line(process, position.X + 2f * scale - 1f, position.Y + i,
                    position.X + 4f * scale - 1f, position.Y + i, color, installed.VectorArithmetic);
                SourcePrimitiveDrawing.Line(process, position.X + i, position.Y - 4f * scale + 1f,
                    position.X + i, position.Y - 2f * scale + 1f, color, installed.VectorArithmetic);
                SourcePrimitiveDrawing.Line(process, position.X + i, position.Y + 2f * scale,
                    position.X + i, position.Y + 4f * scale, color, installed.VectorArithmetic);
            }

            SourcePrimitiveDrawing.Line(process, position.X - 3f, position.Y, position.X + 2f, position.Y, color,
                installed.VectorArithmetic);
            SourcePrimitiveDrawing.Line(process, position.X, position.Y - 2f, position.X, position.Y + 3f, color,
                installed.VectorArithmetic);
        }
    }
}
