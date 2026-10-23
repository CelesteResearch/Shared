using Celeste.Core.Display;
using System;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Content.Textures
{
    public static class SourceAtlasTextureCopies
    {
        public static unsafe ISourceDataTextureResource GetPaddedSubtextureCopy(AtlasEntry input,
            ISourceDataTextureFactory factory)
        {
            if (input == null) return null;
            byte[] source = new byte[input.Texture.TextureSafe.Width * input.Texture.TextureSafe.Height * 4];
            input.Texture.TextureSafe.GetData(source, 0, source.Length);
            byte[] output = new byte[input.FrameWidth * input.FrameHeight * 4];
            int x = input.ClipRect.X, y = input.ClipRect.Y;
            int width = input.ClipRect.Width, height = input.ClipRect.Height;
            int sourceWidth = input.Texture.TextureSafe.Width;
            int outputWidth = input.FrameWidth;
            int offset = (int)Math.Round(input.DrawOffset.X) + (int)Math.Round(input.DrawOffset.Y) * input.FrameWidth;
            fixed (byte* sourceBytes = source)
            fixed (byte* outputBytes = output)
            {
                uint* sourcePixels = (uint*)sourceBytes;
                uint* outputPixels = (uint*)outputBytes;
                for (int row = height - 1; row > -1; row--)
                for (int column = width - 1; column > -1; column--)
                    outputPixels[row * outputWidth + column + offset] =
                        sourcePixels[(y + row) * sourceWidth + x + column];
            }

            var texture = factory.CreateTexture(null, input.FrameWidth, input.FrameHeight);
            texture.SetData(output);
            return texture;
        }

        public static unsafe ISourceDataTextureResource Postdivide(ISourceDataTextureResource texture)
        {
            if (texture == null) return null;
            byte[] data = new byte[texture.Width * texture.Height * 4];
            texture.GetData(data, 0, data.Length);
            fixed (byte* pixels = data)
            {
                for (int offset = data.Length - 4; offset > -1; offset -= 4)
                {
                    byte alpha = pixels[offset + 3];
                    if (alpha != 0 && alpha != byte.MaxValue)
                    {
                        float divisor = alpha;
                        var color = new PackedColor((int)Math.Round(255.0 * pixels[offset] / divisor),
                            (int)Math.Round(255.0 * pixels[offset + 1] / divisor),
                            (int)Math.Round(255.0 * pixels[offset + 2] / divisor), alpha);
                        pixels[offset] = color.R;
                        pixels[offset + 1] = color.G;
                        pixels[offset + 2] = color.B;
                        pixels[offset + 3] = color.A;
                    }
                }
            }

            texture.SetData(data);
            return texture;
        }
    }
}
