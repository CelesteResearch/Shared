using System;

namespace Celeste.Graphics.Content.Textures
{
    public static class SourceTexturePremultiplication
    {
        public static unsafe void PremultiplyRgba(byte[] data, int pixelCount)
        {
            fixed (byte* pixels = data)
            {
                PremultiplyRgba((IntPtr)pixels, pixelCount);
            }
        }

        public static unsafe void PremultiplyRgba(IntPtr data, int pixelCount)
        {
            var pixels = (byte*)data;
            for (var i = 0; i < pixelCount; i++)
            {
                pixels[i * 4 + 0] = (byte)(pixels[i * 4 + 0] * (pixels[i * 4 + 3] / 255f));
                pixels[i * 4 + 1] = (byte)(pixels[i * 4 + 1] * (pixels[i * 4 + 3] / 255f));
                pixels[i * 4 + 2] = (byte)(pixels[i * 4 + 2] * (pixels[i * 4 + 3] / 255f));
            }
        }

        public static unsafe void PremultiplyPreservingTransparentRgb(byte[] data, int byteCount)
        {
            fixed (byte* pixels = data)
            {
                PremultiplyPreservingTransparentRgb((IntPtr)pixels, byteCount);
            }
        }

        public static unsafe void PremultiplyPreservingTransparentRgb(IntPtr data, int byteCount)
        {
            var pixels = (byte*)data;
            for (var offset = byteCount - 1 - 3; offset > -1; offset -= 4)
            {
                var alpha = pixels[offset + 3];
                if (alpha != 0 && alpha != byte.MaxValue)
                {
                    var factor = alpha / 255.0;
                    pixels[offset] = (byte)(pixels[offset] * factor);
                    pixels[offset + 1] = (byte)(pixels[offset + 1] * factor);
                    pixels[offset + 2] = (byte)(pixels[offset + 2] * factor);
                }
            }
        }
    }
}
