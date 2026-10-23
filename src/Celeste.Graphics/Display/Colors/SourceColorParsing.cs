using Celeste.Core.Display;
using System;
using System.Numerics;

namespace Celeste.Graphics.Display.Colors
{
    public static class SourceColorParsing
    {
        public static byte HexToByte(char value)
            => unchecked((byte)"0123456789ABCDEF".IndexOf(char.ToUpper(value)));

        public static Vector4 HexToColor(string hex)
        {
            int offset = 0;
            if (hex.Length >= 1 && hex[0] == '#') offset = 1;
            if (hex.Length - offset >= 6)
            {
                float red = (HexToByte(hex[offset]) * 16 + HexToByte(hex[offset + 1])) / 255f;
                float green = (HexToByte(hex[offset + 2]) * 16 + HexToByte(hex[offset + 3])) / 255f;
                float blue = (HexToByte(hex[offset + 4]) * 16 + HexToByte(hex[offset + 5])) / 255f;
                return new Vector4(Math.Min(1f, Math.Max(0f, red)), Math.Min(1f, Math.Max(0f, green)),
                    Math.Min(1f, Math.Max(0f, blue)), 1f);
            }

            if (int.TryParse(hex.Substring(offset), out int result)) return HexToColor(result);
            return Vector4.One;
        }

        public static Vector4 HexToColorWithAlpha(string hex)
            => HexToPackedColorWithAlpha(hex).ToVector4();

        public static PackedColor HexToPackedColorWithAlpha(string hex)
        {
            int offset = hex.Length >= 1 && hex[0] == '#' ? 1 : 0;
            int length = hex.Length - offset;
            if (length != 2 && length != 6 && length != 8) return PackedColor.White;

            int ReadChannel()
            {
                return HexToByte(hex[offset++]) * 16 + HexToByte(hex[offset++]);
            }

            if (length == 2) return new PackedColor(255, 255, 255, ReadChannel());
            int red = ReadChannel(), green = ReadChannel(), blue = ReadChannel();
            int alpha = length == 8 ? ReadChannel() : 255;
            return new PackedColor(red, green, blue, alpha);
        }

        public static Vector4 HexToColor(int hex)
            => new Vector4(unchecked((byte)(hex >> 16)), unchecked((byte)(hex >> 8)),
                unchecked((byte)hex), byte.MaxValue) / 255f;
    }
}
