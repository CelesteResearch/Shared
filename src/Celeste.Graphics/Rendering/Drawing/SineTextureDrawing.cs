using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering.Batches;

namespace Celeste.Graphics.Rendering.Drawing
{
    public static class SineTextureDrawing
    {
        public static void DrawHorizontal(ISourceRenderContext context, AtlasEntry texture, Vector2 position,
            Vector2 origin, Vector2 scale, float rotation, PackedColor color, SourceSpriteEffects effects,
            float sineCounter, float amplitude = 2f, int sliceSize = 2, float sliceAdd = (float)Math.PI / 4f)
        {
            position = new((float)Math.Floor(position.X), (float)Math.Floor(position.Y));
            var clip = texture.ClipRect;
            clip.Width = sliceSize;
            var index = 0;
            var batch = ((ISourceDrawScope)context).Draw.SpriteBatch;
            if (sliceSize > 0 && clip.Height > 0)
            {
                var info = new SourceSpriteInfo
                {
                    DestinationX = position.X, DestinationY = position.Y,
                    Color = color.PackedValue,
                    RotationSin = rotation == 0f ? rotation : (float)Math.Sin(rotation),
                    RotationCos = rotation == 0f ? 1f : (float)Math.Cos(rotation),
                    Effects = (byte)(effects &
                                     (SourceSpriteEffects.FlipHorizontally | SourceSpriteEffects.FlipVertically)),
                };
                int previousWidth = -1, previousHeight = -1, previousSlice = -1;
                var previousFullTexture = false;
                while (clip.X < texture.ClipRect.X + texture.ClipRect.Width)
                {
                    var offset = new Vector2(sliceSize * index,
                        (float)Math.Round(Math.Sin(sineCounter + sliceAdd * index) * amplitude));
                    // Preserve the virtual texture read and batch validation for every slice.
                    var actual = texture.ReadTextureForSpriteBatch();
                    if (!batch.IsBatchOpen || clip.Width <= 0)
                    {
                        batch.Draw(actual, position, clip, color.PackedValue, rotation,
                            origin - offset, scale, effects, 0f);
                        index++;
                        clip.X += sliceSize;
                        clip.Width = Math.Min(sliceSize, texture.ClipRect.X + texture.ClipRect.Width - clip.X);
                        continue;
                    }

                    int width = actual.Width, height = actual.Height;
                    var fullTexture = clip is { X: 0, Y: 0 } &&
                                      clip.Width == width && clip.Height == height;
                    if (width != previousWidth || height != previousHeight ||
                        clip.Width != previousSlice || fullTexture != previousFullTexture)
                    {
                        // These positive dimensions retain Draw's exact division order.
                        info.SourceY = fullTexture ? 0f : clip.Y / (float)height;
                        info.SourceWidth = fullTexture ? 1f : clip.Width / (float)width;
                        info.SourceHeight = fullTexture ? 1f : clip.Height / (float)height;
                        info.DestinationWidth = scale.X * clip.Width;
                        info.DestinationHeight = scale.Y * clip.Height;
                        previousWidth = width;
                        previousHeight = height;
                        previousSlice = clip.Width;
                        previousFullTexture = fullTexture;
                    }

                    info.SourceX = fullTexture ? 0f : clip.X / (float)width;
                    var at = origin - offset;
                    info.OriginX = at.X / info.SourceWidth / width;
                    info.OriginY = at.Y / info.SourceHeight / height;
                    batch.Draw(actual, in info);
                    index++;
                    clip.X += sliceSize;
                    clip.Width = Math.Min(sliceSize, texture.ClipRect.X + texture.ClipRect.Width - clip.X);
                }

                return;
            }

            while (clip.X < texture.ClipRect.X + texture.ClipRect.Width)
            {
                var offset = new Vector2(sliceSize * index,
                    (float)Math.Round(Math.Sin(sineCounter + sliceAdd * index) * amplitude));
                batch.Draw(texture.ReadTextureForSpriteBatch(), position, clip, color.PackedValue, rotation,
                    origin - offset, scale, effects, 0f);
                index++;
                clip.X += sliceSize;
                clip.Width = Math.Min(sliceSize, texture.ClipRect.X + texture.ClipRect.Width - clip.X);
            }
        }
    }
}
