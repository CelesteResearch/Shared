using Celeste.Core.Display;

namespace Celeste.Graphics.Display.Colors
{
    public static class SourceHexColor
    {
        public static PackedColor HexToColor(string hex)
        {
            var num = 0;
            if (hex.Length >= 1 && hex[0] == '#') num = 1;

            if (hex.Length - num >= 6)
            {
                var r = (HexToByte(hex[num]) * 16 + HexToByte(hex[num + 1])) / 255f;
                var g = (HexToByte(hex[num + 2]) * 16 + HexToByte(hex[num + 3])) / 255f;
                var b = (HexToByte(hex[num + 4]) * 16 + HexToByte(hex[num + 5])) / 255f;
                return new(r, g, b);
            }

            if (int.TryParse(hex.Substring(num), out var result)) return HexToColor(result);

            return PackedColor.White;
        }

        public static PackedColor HexToColor(int hex)
        {
            return new()
            {
                A = byte.MaxValue,
                R = (byte)(hex >> 16),
                G = (byte)(hex >> 8),
                B = (byte)hex,
            };
        }

        public static byte HexToByte(char c)
        {
            return (byte)"0123456789ABCDEF".IndexOf(char.ToUpper(c));
        }
    }
}
