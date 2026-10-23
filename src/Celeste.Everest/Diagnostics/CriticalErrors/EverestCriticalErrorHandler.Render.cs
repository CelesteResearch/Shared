using Celeste.Core.Display;
using System;
using System.Linq;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Presentation.Hud;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;

namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public sealed partial class EverestCriticalErrorHandler
    {
        private ActiveBitmapFont ActiveFont => ((ISourceActiveFontScope)EngineContext).ActiveFont;

        public override void Render(ISourceRenderContext context)
        {
            switch (State)
            {
                case DisplayState.Overlay: RenderFade(context); break;
                case DisplayState.BlueScreen:
                    SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f,
                        new PackedColor(32, 64, 96));
                    break;
            }

            if (optMenu != null)
            {
                optMenu.Alpha = Fade;
                optMenu.Render(context);
                if (failedChoices.Count > 0)
                    ActiveFont.Draw(context, this, "Failed to execute user action",
                        optMenu.Position - Vector2.UnitY * (optMenu.Height * optMenu.Justify.Y + 5f),
                        new Vector2(.5f, 1f), new Vector2(.7f), (PackedColor.IndianRed * Fade));
            }

            if (UsePlayerSprite && playerRenderTarget != null)
            {
                OriginalHiresRendererBatch.EndRender(context);
                try
                {
                    OriginalHiresRendererBatch.BeginRender(context, sampler: SourceSamplerState.PointClamp);
                    try
                    {
                        Vector2 position = new(288f, 540f);
                        float size = 702f;
                        ((global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)context).Draw.SpriteBatch.Draw(
                            playerRenderTarget.Target,
                            new IntRect((int)(position.X - size / 2f), (int)(position.Y - size), (int)size, (int)size),
                            (PackedColor.White * Fade).PackedValue);
                    }
                    finally
                    {
                        OriginalHiresRendererBatch.EndRender(context);
                    }
                }
                catch (Exception exception)
                {
                    process.Logger.Log(EverestLogLevel.Error, "crit-error-handler",
                        "Error while rendering player sprite:");
                    process.Logger.LogDetailed(exception, "crit-error-handler");
                    process.AmendLogFile(LogFile, "Error while rendering player sprite", exception);
                    disablePlayerSprite = true;
                }
                finally
                {
                    OriginalHiresRendererBatch.BeginRender(context);
                }
            }

            Vector2 textPosition = new(576f, 378f);
            ActiveFont.Draw(context, this, "Oooops! :(", textPosition, new Vector2(0f, 1f), new Vector2(3f),
                (PackedColor.White * Fade));
            textPosition.X += 50f;
            DrawLineWrap("Celeste/Everest encountered a critical error.", .7f, PackedColor.LightGray);
            DrawLineWrap("Please report this in the Celeste discord!", .7f, PackedColor.LightGray);
            DrawLineWrap("discord.gg/celeste - channel #modding_help", .5f, PackedColor.Gray, Vector2.UnitX * 50f);
            DrawLineWrap("Your log file has been backed up; please attach it to your bug report.", .7f,
                PackedColor.LightGray);
            if (string.IsNullOrEmpty(LogFileError)) DrawLineWrap(LogFile, .4f, PackedColor.Gray, Vector2.UnitX * 50f);
            else DrawLineWrap(LogFileError, .5f, PackedColor.OrangeRed, Vector2.UnitX * 50f);
            if (EncounteredAdditionalErrors)
            {
                textPosition.Y += 20f;
                DrawLineWrap("Additional errors have occurred since the initial crash!", .7f, PackedColor.IndianRed);
            }

            textPosition.Y += 20f;
            DrawLineWrap("Error Details: " + errorType + ": " + errorMessage, .7f, PackedColor.LightGray);
            textPosition.X += 50f;
            string[] stackLines = (errorStackTrace ?? string.Empty).Split('\n').Select(line => line.Trim()).ToArray();
            for (int i = 0; i < stackLines.Length; i++)
            {
                if (i == 0 || !stackLines[i].StartsWith("at Hook<"))
                {
                    DrawLineWrap(stackLines[i], .4f, PackedColor.Gray);
                    if (textPosition.Y >= 972f && i + 1 < stackLines.Length)
                    {
                        DrawLineWrap("...", .5f, PackedColor.Gray);
                        break;
                    }
                }
            }

            void DrawLineWrap(string text, float scale, PackedColor color, Vector2 offset = default)
            {
                for (bool first = true; first || !string.IsNullOrWhiteSpace(text); first = false)
                {
                    float availableWidth = 1824f - (textPosition.X + offset.X);
                    int length;
                    if (ActiveFont.Measure(text).X * scale > availableWidth)
                    {
                        int lower = 0;
                        int upper = text.Length;
                        while (lower < upper - 1)
                        {
                            int middle = lower + (upper - lower) / 2;
                            if (ActiveFont.Measure(text.Substring(0, middle)).X * scale > availableWidth)
                                upper = middle;
                            else lower = middle;
                        }

                        length = lower;
                    }
                    else length = text.Length;

                    ActiveFont.Draw(context, this, text.Substring(0, length), textPosition + offset, Vector2.Zero,
                        new Vector2(scale), (color * Fade));
                    textPosition.Y += ActiveFont.LineHeight * 1.1f * scale;
                    text = text.Substring(length);
                    if (first) offset.X += ActiveFont.LineHeight * .8f * scale;
                }
            }
        }
    }
}
