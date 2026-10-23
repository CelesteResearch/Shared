using Celeste.Core.Display;
using System;
using Celeste.Graphics.Display;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Display.Colors
{
    public static class ColorMath
    {
        public static PackedColor HsvToPackedColor(float hue, float saturation, float value)
        {
            int degrees = (int)(hue * 360f);
            float chroma = saturation * value;
            float second = chroma * (1f - Math.Abs(degrees / 60f % 2f - 1f));
            float offset = value - chroma;
            if (degrees < 60) return new PackedColor(offset + chroma, offset + second, offset, 1f);
            if (degrees < 120) return new PackedColor(offset + second, offset + chroma, offset, 1f);
            if (degrees < 180) return new PackedColor(offset, offset + chroma, offset + second, 1f);
            if (degrees < 240) return new PackedColor(offset, offset + second, offset + chroma, 1f);
            if (degrees < 300) return new PackedColor(offset + second, offset, offset + chroma, 1f);
            return new PackedColor(offset + chroma, offset, offset + second, 1f);
        }


        public static Vector4 Scale(Vector4 color, float scale)
        {
            uint factor = (uint)Math.Min(Math.Max(scale * 65536f, 0), 16777215);
            float C(float value) => Math.Min(255u, ((uint)Math.Round(value * 255) * factor) >> 16) / 255f;
            return new Vector4(C(color.X), C(color.Y), C(color.Z), C(color.W));
        }

        public static Vector4 Lerp(Vector4 first, Vector4 second, float amount)
        {
            // XNA Color.Lerp quantizes amount through PackUNorm(65536), then
            // uses a signed fixed-point shift (including descending channels).
            int factor = (int)Math.Round(Math.Min(Math.Max(amount * 65536f, 0), 65536));

            float C(float a, float b)
            {
                int x = (int)Math.Round(a * 255), y = (int)Math.Round(b * 255);
                return (x + ((y - x) * factor >> 16)) / 255f;
            }

            return new Vector4(C(first.X, second.X), C(first.Y, second.Y), C(first.Z, second.Z), C(first.W, second.W));
        }
    }
}
