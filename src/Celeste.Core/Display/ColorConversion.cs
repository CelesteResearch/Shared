using System;

namespace Celeste.Core.Display
{
    public static class ColorConversion
    {
        public static PackedColor HsvToColor(float hue, float s, float v)
        {
            int num = (int)(hue * 360f);
            float num2 = s * v;
            float num3 = num2 * (1f - Math.Abs((float)num / 60f % 2f - 1f));
            float num4 = v - num2;
            if (num < 60) return new PackedColor(num4 + num2, num4 + num3, num4);
            if (num < 120) return new PackedColor(num4 + num3, num4 + num2, num4);
            if (num < 180) return new PackedColor(num4, num4 + num2, num4 + num3);
            if (num < 240) return new PackedColor(num4, num4 + num3, num4 + num2);
            if (num < 300) return new PackedColor(num4 + num3, num4, num4 + num2);
            return new PackedColor(num4 + num2, num4, num4 + num3);
        }
    }
}
