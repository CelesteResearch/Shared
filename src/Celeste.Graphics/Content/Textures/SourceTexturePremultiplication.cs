using System;

namespace Celeste.Graphics.Content.Textures
{
    public static class SourceTexturePremultiplication
    {
        public static unsafe void PremultiplyRgba(byte[] data, int pixelCount)
        {
            fixed (byte* pixels = data)
                PremultiplyRgba((IntPtr)pixels, pixelCount);
        }

        public static unsafe void PremultiplyRgba(IntPtr data, int pixelCount)
        {
            byte* pixels = (byte*)data;
            for (int i = 0; i < pixelCount; i++)
            {
                pixels[i * 4 + 0] = (byte)((float)(int)pixels[i * 4 + 0] * ((float)(int)pixels[i * 4 + 3] / 255f));
                pixels[i * 4 + 1] = (byte)((float)(int)pixels[i * 4 + 1] * ((float)(int)pixels[i * 4 + 3] / 255f));
                pixels[i * 4 + 2] = (byte)((float)(int)pixels[i * 4 + 2] * ((float)(int)pixels[i * 4 + 3] / 255f));
            }
        }

        public static unsafe void PremultiplyPreservingTransparentRgb(byte[] data, int byteCount)
        {
            fixed (byte* pixels = data)
                PremultiplyPreservingTransparentRgb((IntPtr)pixels, byteCount);
        }

        public static unsafe void PremultiplyPreservingTransparentRgb(IntPtr data, int byteCount)
        {
            byte* pixels = (byte*)data;
            for (int offset = byteCount - 1 - 3; offset > -1; offset -= 4)
            {
                byte alpha = pixels[offset + 3];
                if (alpha != 0 && alpha != byte.MaxValue)
                {
                    double factor = (double)(int)alpha / 255.0;
                    pixels[offset] = (byte)((double)(int)pixels[offset] * factor);
                    pixels[offset + 1] = (byte)((double)(int)pixels[offset + 1] * factor);
                    pixels[offset + 2] = (byte)((double)(int)pixels[offset + 2] * factor);
                }
            }
        }
    }
}
