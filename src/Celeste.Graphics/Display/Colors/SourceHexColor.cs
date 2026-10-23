using Celeste.Core.Display;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Display.Colors
{
    public static class SourceHexColor
    {
        public static PackedColor HexToColor(string hex)
        {
            int num = 0;
            if (hex.Length >= 1 && hex[0] == '#')
            {
                num = 1;
            }

            if (hex.Length - num >= 6)
            {
                float r = (float)(HexToByte(hex[num]) * 16 + HexToByte(hex[num + 1])) / 255f;
                float g = (float)(HexToByte(hex[num + 2]) * 16 + HexToByte(hex[num + 3])) / 255f;
                float b = (float)(HexToByte(hex[num + 4]) * 16 + HexToByte(hex[num + 5])) / 255f;
                return new PackedColor(r, g, b);
            }

            if (int.TryParse(hex.Substring(num), out var result))
            {
                return HexToColor(result);
            }

            return PackedColor.White;
        }

        public static PackedColor HexToColor(int hex)
        {
            return new PackedColor
            {
                A = byte.MaxValue,
                R = (byte)(hex >> 16),
                G = (byte)(hex >> 8),
                B = (byte)hex
            };
        }

        public static byte HexToByte(char c)
        {
            return (byte)"0123456789ABCDEF".IndexOf(char.ToUpper(c));
        }
    }
}
