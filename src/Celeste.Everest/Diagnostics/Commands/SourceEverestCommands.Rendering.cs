using Celeste.Input.Devices.Mouse;
using Celeste.Core.Display;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Rendering;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Display;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Core.Rendering.Cameras;
using Celeste.Game.Execution.Levels.Diagnostics.Commands;
using Celeste.Game.Execution.Levels;

namespace Celeste.Everest.Diagnostics.Commands
{
    public partial class SourceEverestCommands
    {
        public override void Render()
        {
            int viewWidth = process.ViewWidth;
            int viewHeight = process.ViewHeight;
            SourceMouseState state = installed.FnaInput.Mouse.GetState();
            int num = state.ScrollWheelValue - mouseScroll;
            mouseScroll = state.ScrollWheelValue;
            Vector2 vector = new Vector2(state.X - installed.Viewport.X, state.Y - installed.Viewport.Y);
            Vector2? vector2 = null;
            int max = 1;
            string text = "";
            IOriginalLevelCommands level = installed.Scene as OriginalLevelSceneRoot;
            if (level != null)
            {
                text = string.Concat(text,
                    string.Format("Area: {0} @ {1}\n", (object)level.LevelName,
                        (object)installed.AreaKeys.Format(level.Area)));
            }

            text = string.Concat(text,
                string.Format("Cursor @\n screen: {0}, {1}", (object)(int)Math.Round(vector.X),
                    (object)(int)Math.Round(vector.Y)));
            if (level != null)
            {
                ISourceCommandsCamera camera = level.Camera;
                float num2 = (float)process.ViewWidth / (float)installed.Width;
                Vector2 vector3 =
                    Vector2Geometry.Floor(level.ScreenToWorld(installed.VectorArithmetic.Divide(vector, num2)));
                if (!installed.CelesteTASInstalled.Value)
                {
                    text = string.Concat(text,
                        string.Format("\n world:       {0}, {1}", (object)(int)Math.Round(vector3.X),
                            (object)(int)Math.Round(vector3.Y)));
                }

                vector3 -= level.LevelOffset;
                text = string.Concat(text,
                    FormatSourceLevelCursor("\n level:       {0}, {1}", (object)(int)Math.Round(vector3.X),
                        (object)(int)Math.Round(vector3.Y)));
                vector2 = Vector2Geometry.Floor(installed.VectorArithmetic.Divide(vector3, 8f));
                text = string.Concat(text,
                    string.Format("\n level, /8:   {0}, {1}", (object)(int)Math.Round(vector2.Value.X),
                        (object)(int)Math.Round(vector2.Value.Y)));
                float value = 8f;
                Vector2? vector4 = vector2;
                vector2 = value * vector4;
                text = string.Concat(text,
                    string.Format("\n level, snap: {0}, {1}", (object)(int)Math.Round(vector2.Value.X),
                        (object)(int)Math.Round(vector2.Value.Y)));
                vector2 = vector2 + new Vector2(4f, 4f) + level.LevelOffset;
                vector2 = Vector2Geometry.Floor(level.WorldToScreen(vector2.Value) * num2);
                max = process.ViewWidth / camera.Viewport.Width;
            }

            process.Draw.SpriteBatch.Begin();
            if (num < 0)
            {
                cursorScale--;
            }
            else if (num > 0)
            {
                cursorScale++;
            }

            cursorScale = ScalarMath.Clamp(cursorScale, 1, max);
            if (vector2.HasValue)
            {
                DrawCursor(vector2.Value, cursorScale, PackedColor.Red);
            }

            DrawCursor(vector, cursorScale, PackedColor.Yellow);
            Vector2 vector5 = process.Draw.DefaultFont.MeasureString(text);
            SourcePrimitiveDrawing.Rect(process, 10f, 10f, vector5.X + 20f, vector5.Y + 20f, PackedColor.Black * 0.8f);
            process.Draw.SpriteBatch.DrawString(process.Draw.DefaultFont, text, new Vector2(20f, 20f),
                PackedColor.White.PackedValue);
            SourcePrimitiveDrawing.Rect(process, 10f, (float)viewHeight - 50f, (float)viewWidth - 20f, 40f,
                PackedColor.Black * 0.8f);
            Vector2 vector6 = new Vector2(20f, (float)viewHeight - 42f);
            process.Draw.SpriteBatch.DrawString(process.Draw.DefaultFont, ">" + currentText, vector6,
                PackedColor.White.PackedValue);
            if (underscore)
            {
                Vector2 vector7 = process.Draw.DefaultFont.MeasureString(">" + currentText.Substring(0, charIndex));
                vector7.X += 1f;
                SourcePrimitiveDrawing.Line(process, vector6 + new Vector2(vector7.X, 0f), vector6 + vector7,
                    PackedColor.White, installed.VectorArithmetic);
            }

            if (drawCommands.Count > 0)
            {
                int num3 = Math.Min((viewHeight - 100) / 30, drawCommands.Count - firstLineIndexToDraw);
                float num4 = 10f + 30f * (float)num3;
                SourcePrimitiveDrawing.Rect(process, 10f, (float)viewHeight - num4 - 60f, (float)viewWidth - 20f, num4,
                    PackedColor.Black * 0.8f);
                for (int i = 0; i < num3 && firstLineIndexToDraw + i < drawCommands.Count; i++)
                {
                    process.Draw.SpriteBatch.DrawString(process.Draw.DefaultFont,
                        drawCommands[firstLineIndexToDraw + i].Text,
                        new Vector2(20f, (float)viewHeight - 92f - 30f * (float)i),
                        drawCommands[firstLineIndexToDraw + i].Color.PackedValue);
                }
            }

            process.Draw.SpriteBatch.End();
        }

        internal void DrawCursor(Vector2 position, int scale, PackedColor color)
        {
            for (int i = -scale / 2; i <= scale / 2; i++)
            {
                SourcePrimitiveDrawing.Line(process, position.X - 4f * (float)scale, position.Y + (float)i,
                    position.X - 2f * (float)scale, position.Y + (float)i, color, installed.VectorArithmetic);
                SourcePrimitiveDrawing.Line(process, position.X + 2f * (float)scale - 1f, position.Y + (float)i,
                    position.X + 4f * (float)scale - 1f, position.Y + (float)i, color, installed.VectorArithmetic);
                SourcePrimitiveDrawing.Line(process, position.X + (float)i, position.Y - 4f * (float)scale + 1f,
                    position.X + (float)i, position.Y - 2f * (float)scale + 1f, color, installed.VectorArithmetic);
                SourcePrimitiveDrawing.Line(process, position.X + (float)i, position.Y + 2f * (float)scale,
                    position.X + (float)i, position.Y + 4f * (float)scale, color, installed.VectorArithmetic);
            }

            SourcePrimitiveDrawing.Line(process, position.X - 3f, position.Y, position.X + 2f, position.Y, color,
                installed.VectorArithmetic);
            SourcePrimitiveDrawing.Line(process, position.X, position.Y - 2f, position.X, position.Y + 3f, color,
                installed.VectorArithmetic);
        }
    }
}
