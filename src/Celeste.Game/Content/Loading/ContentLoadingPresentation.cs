using System;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Framework.Timing;
using Celeste.Core.IO.Content;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Game.Content.Dialogs;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Content.Loading
{
    // Draws only loading UI. It borrows the original context, fonts and pixel; no Scene or clock is advanced.
    public sealed class ContentLoadingPresentation
    {
        private readonly SourceDrawState draw;
        private readonly OriginalGameTextProcess text;
        private readonly ISourceRenderContext context;
        private readonly Func<AtlasData> readLoadingAtlas;
        private readonly ContentLoadingTransition transition;
        private readonly Func<double> readSeconds;
        private readonly ProgressRow content = new();
        private readonly ProgressRow audio = new();

        public bool HasPending => content.Pending || audio.Pending;
        public float Opacity => transition.Opacity;
        public bool HasPresentation => HasPending || Opacity > 0;

        public bool PreparePresentation(bool blocking)
        {
            var visible = transition.Prepare(blocking || HasPending);
            if (!visible && !blocking && !HasPending)
            {
                content.Shown = false;
                audio.Shown = false;
            }

            return visible;
        }

        public ContentLoadingPresentation(SourceDrawState draw, OriginalGameTextProcess text,
            ISourceRenderContext context, Func<AtlasData> readLoadingAtlas = null,
            Func<double> readPresentationSeconds = null)
        {
            this.readLoadingAtlas = readLoadingAtlas;
            readSeconds = readPresentationSeconds ?? (() => (double)Stopwatch.GetTimestamp() / Stopwatch.Frequency);
            transition = new(readSeconds);
            this.draw = draw ?? throw new ArgumentNullException(nameof(draw));
            this.text = text ?? throw new ArgumentNullException(nameof(text));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void SetProgress(ContentLoadProgress contentProgress, ContentLoadProgress audioProgress)
        {
            var now = readSeconds();
            content.SetProgress(contentProgress, now);
            audio.SetProgress(audioProgress, now);
        }

        public static bool PresentWithoutUpdate(ISourceGameTickFrame frame, Action drawLoadingUI)
        {
            if (frame == null) throw new ArgumentNullException(nameof(frame));
            if (drawLoadingUI == null) throw new ArgumentNullException(nameof(drawLoadingUI));
            frame.AssertNotDisposed();
            if (!frame.BeginDraw()) return false;
            drawLoadingUI();
            frame.EndDraw();
            return true;
        }

        public void Render(bool blocking)
        {
            if (Opacity <= 0) return;
            var language = text.Dialog?.Language;
            var font = language == null ? null : text.Fonts.Get(language.FontFace);
            var activeFontReady = font != null && font.Sizes.Count != 0;
            var batch = new SourceRenderBatchState(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend,
                SourceSamplerState.LinearClamp, SourceDepthStencilState.None, SourceRasterizerState.CullNone,
                null, context.Graphics.ScreenMatrix);
            context.BeginBatch(in batch);
            if (!activeFontReady)
            {
                const string label = "Loading...";
                var size = draw.DefaultFont.MeasureString(label) * 1.5f;
                draw.SpriteBatch.DrawString(draw.DefaultFont, label, new Vector2(960, 540) - size * .5f,
                    (PackedColor.White * Opacity).PackedValue, 0, Vector2.Zero, 1.5f, SourceSpriteEffects.None, 0);
                context.EndBatch();
                return;
            }

            var labels = ContentLoadingText.ForLanguage(language.Id);
            SourcePrimitiveDrawing.Rect(context, null, -10, -10, 1940, 1100, PackedColor.Black * (.8f * Opacity));
            text.ActiveFont.DrawEdgeOutline(context, null, labels.Title, new(960, 300 + (1 - Opacity) * 24),
                new(.5f), new(FitScale(labels.Title, 1.5f, 1400)), PackedColor.Gray * Opacity,
                4, PackedColor.DarkSlateBlue * Opacity, 2, PackedColor.Black * Opacity);
            if (blocking) DrawMenuText(labels.Continue, new(960, 378), .5f, PackedColor.Gray);
            DrawLoadingIcon();
            var rowY = (content.Shown && audio.Shown ? 450 : 510) + (1 - Opacity) * 16;
            if (blocking && !content.Shown && !audio.Shown)
                DrawMenuText(labels.Processing, new(960, 550), .55f, PackedColor.Gray);
            if (content.Shown)
            {
                RenderRow(content, labels.Content, labels, rowY, blocking);
                rowY += 200;
            }

            if (audio.Shown) RenderRow(audio, labels.Audio, labels, rowY, blocking);
            context.EndBatch();
        }

        private void DrawLoadingIcon()
        {
            var atlas = readLoadingAtlas?.Invoke();
            if (atlas == null || !atlas.HasAtlasSubtextures("loading/")) return;
            var frames = atlas.GetAtlasSubtextures("loading/");
            var icon = frames[transition.FrameIndex(frames.Count)];
            if (icon?.Texture?.TextureSafe == null || icon.Texture.TextureSafe.IsDisposed) return;
            // Original loader frames run at 10 fps; only presentation time selects the frame.
            SourceAtlasDrawing.DrawCentered(context, null, icon, new(960, 870 + (1 - Opacity) * 16),
                PackedColor.White * Opacity, .5f);
        }

        private void RenderRow(ProgressRow row, string name, ContentLoadingText labels, float y, bool blocking)
        {
            row.UpdateText(name, labels);
            DrawMenuText(row.Label, new(960, y), .8f, PackedColor.White);
            DrawMenuText(row.Size, new(960, y + 58), .55f, PackedColor.White);
            DrawMenuText(row.Files, new(960, y + 102), .5f, PackedColor.Gray);
            DrawMenuText(blocking && !row.Pending ? labels.Processing : row.EstimateText,
                new(960, y + 146), .45f, PackedColor.Gray);
            // Native LoggedProgress uses a thin white bar over a black track, without a framed card.
            SourcePrimitiveDrawing.Rect(context, null, 460, y + 170, 1000, 4, PackedColor.Black * (.8f * Opacity));
            SourcePrimitiveDrawing.Rect(context, null, 460, y + 168, 1000 * row.ReceivedFraction, 8,
                PackedColor.White * (.8f * Opacity));
        }

        private float FitScale(string value, float scale, float width)
        {
            var measured = text.ActiveFont.Measure(value).X;
            return measured > 0 ? Math.Min(scale, width / measured) : scale;
        }

        private void DrawMenuText(string value, Vector2 position, float scale, PackedColor color)
        {
            text.ActiveFont.DrawOutline(context, null, value, position, new(.5f),
                new(FitScale(value, scale, 1400)), color * Opacity, 2, PackedColor.Black * Opacity);
        }

        private sealed class ProgressRow
        {
            private long baselineBytes, total, received;
            private int baselineFiles, totalFiles, readyFiles;
            private ContentLoadingText currentLabels;
            private bool textChanged;
            private readonly ContentLoadingEstimate estimate = new();
            public bool Pending, Shown;
            public string Label = "", Size = "", Files = "", EstimateText = "";
            public float ReceivedFraction;

            public void SetProgress(ContentLoadProgress progress, double now)
            {
                var wasPending = Pending;
                Pending = progress.ReadyFiles < progress.TotalFiles;
                if (Pending || wasPending)
                {
                    total = Math.Max(0, progress.TotalBytes - baselineBytes);
                    received = Math.Clamp(progress.ReceivedBytes - baselineBytes, 0, total);
                    totalFiles = Math.Max(0, progress.TotalFiles - baselineFiles);
                    readyFiles = Math.Clamp(progress.ReadyFiles - baselineFiles, 0, totalFiles);
                    ReceivedFraction = total == 0 ? 1 : Math.Clamp((float)((double)received / total), 0, 1);
                    Shown = true;
                    textChanged = true;
                }

                estimate.Update(now, total, received, Pending);
                if (!!Pending)
                    return;
                baselineBytes = progress.ReadyBytes;
                baselineFiles = progress.ReadyFiles;
            }

            public void UpdateText(string name, ContentLoadingText labels)
            {
                if (!textChanged && ReferenceEquals(currentLabels, labels)) return;
                currentLabels = labels;
                textChanged = false;
                Label = name;
                Size = string.Format(CultureInfo.InvariantCulture, labels.Size,
                    ((int)(ReceivedFraction * 100)).ToString(CultureInfo.InvariantCulture),
                    Bytes(received), Bytes(total));
                Files = string.Format(CultureInfo.InvariantCulture, labels.Files, readyFiles, totalFiles);
                EstimateText = !Pending ? labels.Ready
                    : total > 0 && received >= total ? labels.Processing
                    : estimate.BytesPerSecond <= 0 ? labels.Estimating
                    : string.Format(CultureInfo.InvariantCulture, labels.Rate,
                        Rate(estimate.BytesPerSecond),
                        estimate.RemainingSeconds < 0 ? "..." : Duration(estimate.RemainingSeconds));
            }

            private static string Rate(double value)
            {
                return value >= 1048576
                    ? (value / 1048576).ToString("F1", CultureInfo.InvariantCulture) + " MiB"
                    : (value / 1024).ToString("F1", CultureInfo.InvariantCulture) + " KiB";
            }

            private static string Duration(double seconds)
            {
                var value = (long)Math.Min(359999, Math.Ceiling(seconds));
                return value >= 3600
                    ? string.Format(CultureInfo.InvariantCulture, "{0}:{1:00}:{2:00}", value / 3600, value / 60 % 60,
                        value % 60)
                    : string.Format(CultureInfo.InvariantCulture, "{0}:{1:00}", value / 60, value % 60);
            }

            private static string Bytes(long value)
            {
                return ((double)value / 1048576).ToString("F1", CultureInfo.InvariantCulture);
            }
        }
    }
}
