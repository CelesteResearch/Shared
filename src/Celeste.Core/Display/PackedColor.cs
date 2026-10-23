using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace Celeste.Core.Display
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    [DebuggerDisplay("{DebugDisplayString,nq}")]
    public struct PackedColor : IEquatable<PackedColor>
    {
        private uint packedValue;

        public byte B
        {
            get => (byte)(packedValue >> 16);
            set => packedValue = (packedValue & 0xFF00FFFFu) | (uint)(value << 16);
        }

        public byte G
        {
            get => (byte)(packedValue >> 8);
            set => packedValue = (packedValue & 0xFFFF00FFu) | (uint)(value << 8);
        }

        public byte R
        {
            get => (byte)packedValue;
            set => packedValue = (packedValue & 0xFFFFFF00u) | value;
        }

        public byte A
        {
            get => (byte)(packedValue >> 24);
            set => packedValue = (packedValue & 0xFFFFFF) | (uint)(value << 24);
        }

        public uint PackedValue
        {
            get => packedValue;
            set => packedValue = value;
        }

        public static PackedColor Transparent { get; private set; }
        public static PackedColor AliceBlue { get; private set; }
        public static PackedColor AntiqueWhite { get; private set; }
        public static PackedColor Aqua { get; private set; }
        public static PackedColor Aquamarine { get; private set; }
        public static PackedColor Azure { get; private set; }
        public static PackedColor Beige { get; private set; }
        public static PackedColor Bisque { get; private set; }
        public static PackedColor Black { get; private set; }
        public static PackedColor BlanchedAlmond { get; private set; }
        public static PackedColor Blue { get; private set; }
        public static PackedColor BlueViolet { get; private set; }
        public static PackedColor Brown { get; private set; }
        public static PackedColor BurlyWood { get; private set; }
        public static PackedColor CadetBlue { get; private set; }
        public static PackedColor Chartreuse { get; private set; }
        public static PackedColor Chocolate { get; private set; }
        public static PackedColor Coral { get; private set; }
        public static PackedColor CornflowerBlue { get; private set; }
        public static PackedColor Cornsilk { get; private set; }
        public static PackedColor Crimson { get; private set; }
        public static PackedColor Cyan { get; private set; }
        public static PackedColor DarkBlue { get; private set; }
        public static PackedColor DarkCyan { get; private set; }
        public static PackedColor DarkGoldenrod { get; private set; }
        public static PackedColor DarkGray { get; private set; }
        public static PackedColor DarkGreen { get; private set; }
        public static PackedColor DarkKhaki { get; private set; }
        public static PackedColor DarkMagenta { get; private set; }
        public static PackedColor DarkOliveGreen { get; private set; }
        public static PackedColor DarkOrange { get; private set; }
        public static PackedColor DarkOrchid { get; private set; }
        public static PackedColor DarkRed { get; private set; }
        public static PackedColor DarkSalmon { get; private set; }
        public static PackedColor DarkSeaGreen { get; private set; }
        public static PackedColor DarkSlateBlue { get; private set; }
        public static PackedColor DarkSlateGray { get; private set; }
        public static PackedColor DarkTurquoise { get; private set; }
        public static PackedColor DarkViolet { get; private set; }
        public static PackedColor DeepPink { get; private set; }
        public static PackedColor DeepSkyBlue { get; private set; }
        public static PackedColor DimGray { get; private set; }
        public static PackedColor DodgerBlue { get; private set; }
        public static PackedColor Firebrick { get; private set; }
        public static PackedColor FloralWhite { get; private set; }
        public static PackedColor ForestGreen { get; private set; }
        public static PackedColor Fuchsia { get; private set; }
        public static PackedColor Gainsboro { get; private set; }
        public static PackedColor GhostWhite { get; private set; }
        public static PackedColor Gold { get; private set; }
        public static PackedColor Goldenrod { get; private set; }
        public static PackedColor Gray { get; private set; }
        public static PackedColor Green { get; private set; }
        public static PackedColor GreenYellow { get; private set; }
        public static PackedColor Honeydew { get; private set; }
        public static PackedColor HotPink { get; private set; }
        public static PackedColor IndianRed { get; private set; }
        public static PackedColor Indigo { get; private set; }
        public static PackedColor Ivory { get; private set; }
        public static PackedColor Khaki { get; private set; }
        public static PackedColor Lavender { get; private set; }
        public static PackedColor LavenderBlush { get; private set; }
        public static PackedColor LawnGreen { get; private set; }
        public static PackedColor LemonChiffon { get; private set; }
        public static PackedColor LightBlue { get; private set; }
        public static PackedColor LightCoral { get; private set; }
        public static PackedColor LightCyan { get; private set; }
        public static PackedColor LightGoldenrodYellow { get; private set; }
        public static PackedColor LightGray { get; private set; }
        public static PackedColor LightGreen { get; private set; }
        public static PackedColor LightPink { get; private set; }
        public static PackedColor LightSalmon { get; private set; }
        public static PackedColor LightSeaGreen { get; private set; }
        public static PackedColor LightSkyBlue { get; private set; }
        public static PackedColor LightSlateGray { get; private set; }
        public static PackedColor LightSteelBlue { get; private set; }
        public static PackedColor LightYellow { get; private set; }
        public static PackedColor Lime { get; private set; }
        public static PackedColor LimeGreen { get; private set; }
        public static PackedColor Linen { get; private set; }
        public static PackedColor Magenta { get; private set; }
        public static PackedColor Maroon { get; private set; }
        public static PackedColor MediumAquamarine { get; private set; }
        public static PackedColor MediumBlue { get; private set; }
        public static PackedColor MediumOrchid { get; private set; }
        public static PackedColor MediumPurple { get; private set; }
        public static PackedColor MediumSeaGreen { get; private set; }
        public static PackedColor MediumSlateBlue { get; private set; }
        public static PackedColor MediumSpringGreen { get; private set; }
        public static PackedColor MediumTurquoise { get; private set; }
        public static PackedColor MediumVioletRed { get; private set; }
        public static PackedColor MidnightBlue { get; private set; }
        public static PackedColor MintCream { get; private set; }
        public static PackedColor MistyRose { get; private set; }
        public static PackedColor Moccasin { get; private set; }
        public static PackedColor NavajoWhite { get; private set; }
        public static PackedColor Navy { get; private set; }
        public static PackedColor OldLace { get; private set; }
        public static PackedColor Olive { get; private set; }
        public static PackedColor OliveDrab { get; private set; }
        public static PackedColor Orange { get; private set; }
        public static PackedColor OrangeRed { get; private set; }
        public static PackedColor Orchid { get; private set; }
        public static PackedColor PaleGoldenrod { get; private set; }
        public static PackedColor PaleGreen { get; private set; }
        public static PackedColor PaleTurquoise { get; private set; }
        public static PackedColor PaleVioletRed { get; private set; }
        public static PackedColor PapayaWhip { get; private set; }
        public static PackedColor PeachPuff { get; private set; }
        public static PackedColor Peru { get; private set; }
        public static PackedColor Pink { get; private set; }
        public static PackedColor Plum { get; private set; }
        public static PackedColor PowderBlue { get; private set; }
        public static PackedColor Purple { get; private set; }
        public static PackedColor Red { get; private set; }
        public static PackedColor RosyBrown { get; private set; }
        public static PackedColor RoyalBlue { get; private set; }
        public static PackedColor SaddleBrown { get; private set; }
        public static PackedColor Salmon { get; private set; }
        public static PackedColor SandyBrown { get; private set; }
        public static PackedColor SeaGreen { get; private set; }
        public static PackedColor SeaShell { get; private set; }
        public static PackedColor Sienna { get; private set; }
        public static PackedColor Silver { get; private set; }
        public static PackedColor SkyBlue { get; private set; }
        public static PackedColor SlateBlue { get; private set; }
        public static PackedColor SlateGray { get; private set; }
        public static PackedColor Snow { get; private set; }
        public static PackedColor SpringGreen { get; private set; }
        public static PackedColor SteelBlue { get; private set; }
        public static PackedColor Tan { get; private set; }
        public static PackedColor Teal { get; private set; }
        public static PackedColor Thistle { get; private set; }
        public static PackedColor Tomato { get; private set; }
        public static PackedColor Turquoise { get; private set; }
        public static PackedColor Violet { get; private set; }
        public static PackedColor Wheat { get; private set; }
        public static PackedColor White { get; private set; }
        public static PackedColor WhiteSmoke { get; private set; }
        public static PackedColor Yellow { get; private set; }
        public static PackedColor YellowGreen { get; private set; }

        internal string DebugDisplayString => R + " " + G + " " + B + " " + A;

        static PackedColor()
        {
            Transparent = new(0u);
            AliceBlue = new(4294965488u);
            AntiqueWhite = new(4292340730u);
            Aqua = new(4294967040u);
            Aquamarine = new(4292149119u);
            Azure = new(4294967280u);
            Beige = new(4292670965u);
            Bisque = new(4291093759u);
            Black = new(4278190080u);
            BlanchedAlmond = new(4291685375u);
            Blue = new(4294901760u);
            BlueViolet = new(4293012362u);
            Brown = new(4280953509u);
            BurlyWood = new(4287084766u);
            CadetBlue = new(4288716383u);
            Chartreuse = new(4278255487u);
            Chocolate = new(4280183250u);
            Coral = new(4283465727u);
            CornflowerBlue = new(4293760356u);
            Cornsilk = new(4292671743u);
            Crimson = new(4282127580u);
            Cyan = new(4294967040u);
            DarkBlue = new(4287299584u);
            DarkCyan = new(4287335168u);
            DarkGoldenrod = new(4278945464u);
            DarkGray = new(4289309097u);
            DarkGreen = new(4278215680u);
            DarkKhaki = new(4285249469u);
            DarkMagenta = new(4287299723u);
            DarkOliveGreen = new(4281297749u);
            DarkOrange = new(4278226175u);
            DarkOrchid = new(4291572377u);
            DarkRed = new(4278190219u);
            DarkSalmon = new(4286224105u);
            DarkSeaGreen = new(4287347855u);
            DarkSlateBlue = new(4287315272u);
            DarkSlateGray = new(4283387695u);
            DarkTurquoise = new(4291939840u);
            DarkViolet = new(4292018324u);
            DeepPink = new(4287829247u);
            DeepSkyBlue = new(4294950656u);
            DimGray = new(4285098345u);
            DodgerBlue = new(4294938654u);
            Firebrick = new(4280427186u);
            FloralWhite = new(4293982975u);
            ForestGreen = new(4280453922u);
            Fuchsia = new(4294902015u);
            Gainsboro = new(4292664540u);
            GhostWhite = new(4294965496u);
            Gold = new(4278245375u);
            Goldenrod = new(4280329690u);
            Gray = new(4286611584u);
            Green = new(4278222848u);
            GreenYellow = new(4281335725u);
            Honeydew = new(4293984240u);
            HotPink = new(4290013695u);
            IndianRed = new(4284243149u);
            Indigo = new(4286709835u);
            Ivory = new(4293984255u);
            Khaki = new(4287424240u);
            Lavender = new(4294633190u);
            LavenderBlush = new(4294308095u);
            LawnGreen = new(4278254716u);
            LemonChiffon = new(4291689215u);
            LightBlue = new(4293318829u);
            LightCoral = new(4286611696u);
            LightCyan = new(4294967264u);
            LightGoldenrodYellow = new(4292016890u);
            LightGray = new(4292072403u);
            LightGreen = new(4287688336u);
            LightPink = new(4290885375u);
            LightSalmon = new(4286226687u);
            LightSeaGreen = new(4289376800u);
            LightSkyBlue = new(4294626951u);
            LightSlateGray = new(4288252023u);
            LightSteelBlue = new(4292789424u);
            LightYellow = new(4292935679u);
            Lime = new(4278255360u);
            LimeGreen = new(4281519410u);
            Linen = new(4293325050u);
            Magenta = new(4294902015u);
            Maroon = new(4278190208u);
            MediumAquamarine = new(4289383782u);
            MediumBlue = new(4291624960u);
            MediumOrchid = new(4292040122u);
            MediumPurple = new(4292571283u);
            MediumSeaGreen = new(4285641532u);
            MediumSlateBlue = new(4293814395u);
            MediumSpringGreen = new(4288346624u);
            MediumTurquoise = new(4291613000u);
            MediumVioletRed = new(4286911943u);
            MidnightBlue = new(4285536537u);
            MintCream = new(4294639605u);
            MistyRose = new(4292994303u);
            Moccasin = new(4290110719u);
            NavajoWhite = new(4289584895u);
            Navy = new(4286578688u);
            OldLace = new(4293326333u);
            Olive = new(4278222976u);
            OliveDrab = new(4280520299u);
            Orange = new(4278232575u);
            OrangeRed = new(4278207999u);
            Orchid = new(4292243674u);
            PaleGoldenrod = new(4289390830u);
            PaleGreen = new(4288215960u);
            PaleTurquoise = new(4293848751u);
            PaleVioletRed = new(4287852763u);
            PapayaWhip = new(4292210687u);
            PeachPuff = new(4290370303u);
            Peru = new(4282353101u);
            Pink = new(4291543295u);
            Plum = new(4292714717u);
            PowderBlue = new(4293320880u);
            Purple = new(4286578816u);
            Red = new(4278190335u);
            RosyBrown = new(4287598524u);
            RoyalBlue = new(4292962625u);
            SaddleBrown = new(4279453067u);
            Salmon = new(4285694202u);
            SandyBrown = new(4284523764u);
            SeaGreen = new(4283927342u);
            SeaShell = new(4293850623u);
            Sienna = new(4281160352u);
            Silver = new(4290822336u);
            SkyBlue = new(4293643911u);
            SlateBlue = new(4291648106u);
            SlateGray = new(4287660144u);
            Snow = new(4294638335u);
            SpringGreen = new(4286578432u);
            SteelBlue = new(4290019910u);
            Tan = new(4287411410u);
            Teal = new(4286611456u);
            Thistle = new(4292394968u);
            Tomato = new(4282868735u);
            Turquoise = new(4291878976u);
            Violet = new(4293821166u);
            Wheat = new(4289978101u);
            White = new(uint.MaxValue);
            WhiteSmoke = new(4294309365u);
            Yellow = new(4278255615u);
            YellowGreen = new(4281519514u);
        }

        public PackedColor(Vector4 color)
        {
            packedValue = 0u;
            R = (byte)PackedColorMath.Clamp(color.X * 255f, 0f, 255f);
            G = (byte)PackedColorMath.Clamp(color.Y * 255f, 0f, 255f);
            B = (byte)PackedColorMath.Clamp(color.Z * 255f, 0f, 255f);
            A = (byte)PackedColorMath.Clamp(color.W * 255f, 0f, 255f);
        }

        public PackedColor(Vector3 color)
        {
            packedValue = 0u;
            R = (byte)PackedColorMath.Clamp(color.X * 255f, 0f, 255f);
            G = (byte)PackedColorMath.Clamp(color.Y * 255f, 0f, 255f);
            B = (byte)PackedColorMath.Clamp(color.Z * 255f, 0f, 255f);
            A = byte.MaxValue;
        }

        public PackedColor(float r, float g, float b)
        {
            packedValue = 0u;
            R = (byte)PackedColorMath.Clamp(r * 255f, 0f, 255f);
            G = (byte)PackedColorMath.Clamp(g * 255f, 0f, 255f);
            B = (byte)PackedColorMath.Clamp(b * 255f, 0f, 255f);
            A = byte.MaxValue;
        }

        public PackedColor(int r, int g, int b)
        {
            packedValue = 0u;
            R = (byte)PackedColorMath.Clamp(r, 0, 255);
            G = (byte)PackedColorMath.Clamp(g, 0, 255);
            B = (byte)PackedColorMath.Clamp(b, 0, 255);
            A = byte.MaxValue;
        }

        public PackedColor(int r, int g, int b, int alpha)
        {
            packedValue = 0u;
            R = (byte)PackedColorMath.Clamp(r, 0, 255);
            G = (byte)PackedColorMath.Clamp(g, 0, 255);
            B = (byte)PackedColorMath.Clamp(b, 0, 255);
            A = (byte)PackedColorMath.Clamp(alpha, 0, 255);
        }

        public PackedColor(float r, float g, float b, float alpha)
        {
            packedValue = 0u;
            R = (byte)PackedColorMath.Clamp(r * 255f, 0f, 255f);
            G = (byte)PackedColorMath.Clamp(g * 255f, 0f, 255f);
            B = (byte)PackedColorMath.Clamp(b * 255f, 0f, 255f);
            A = (byte)PackedColorMath.Clamp(alpha * 255f, 0f, 255f);
        }

        private PackedColor(uint packedValue)
        {
            this.packedValue = packedValue;
        }

        public bool Equals(PackedColor other)
        {
            return PackedValue == other.PackedValue;
        }

        public static PackedColor FromHex(string hex)
        {
            return new(Convert.ToByte(hex.Substring(0, 2), 16),
                Convert.ToByte(hex.Substring(2, 2), 16), Convert.ToByte(hex.Substring(4, 2), 16));
        }

        public Vector3 ToVector3()
        {
            return new(R / 255f, G / 255f, B / 255f);
        }

        public Vector4 ToVector4()
        {
            return new(R / 255f, G / 255f, B / 255f, A / 255f);
        }

        public static PackedColor Lerp(
            PackedColor value1,
            PackedColor value2, float amount)
        {
            amount = PackedColorMath.Clamp(amount, 0f, 1f);
            return new(
                (int)PackedColorMath.Lerp(value1.R, value2.R, amount),
                (int)PackedColorMath.Lerp(value1.G, value2.G, amount),
                (int)PackedColorMath.Lerp(value1.B, value2.B, amount),
                (int)PackedColorMath.Lerp(value1.A, value2.A, amount));
        }

        public static PackedColor FromNonPremultiplied(Vector4 vector)
        {
            return new(vector.X * vector.W, vector.Y * vector.W,
                vector.Z * vector.W, vector.W);
        }

        public static PackedColor FromNonPremultiplied(int r, int g, int b, int a)
        {
            return new(r * a / 255, g * a / 255, b * a / 255, a);
        }

        public static bool operator ==(PackedColor a,
            PackedColor b)
        {
            if (a.A == b.A && a.R == b.R && a.G == b.G) return a.B == b.B;

            return false;
        }

        public static bool operator !=(PackedColor a,
            PackedColor b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return packedValue.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is PackedColor) return Equals((PackedColor)obj);

            return false;
        }

        public static PackedColor Multiply(
            PackedColor value, float scale)
        {
            return new((int)(value.R * scale),
                (int)(value.G * scale),
                (int)(value.B * scale), (int)(value.A * scale));
        }

        public static PackedColor operator *(
            PackedColor value, float scale)
        {
            return new((int)(value.R * scale),
                (int)(value.G * scale),
                (int)(value.B * scale), (int)(value.A * scale));
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder(25);
            stringBuilder.Append("{R:");
            stringBuilder.Append(R);
            stringBuilder.Append(" G:");
            stringBuilder.Append(G);
            stringBuilder.Append(" B:");
            stringBuilder.Append(B);
            stringBuilder.Append(" A:");
            stringBuilder.Append(A);
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        private void PackFromVector4(Vector4 vector)
        {
            R = (byte)(vector.X * 255f);
            G = (byte)(vector.Y * 255f);
            B = (byte)(vector.Z * 255f);
            A = (byte)(vector.W * 255f);
        }

        public PackedColor(PackedColor color, int alpha)
        {
            this = new(color.R, color.G, color.B,
                (byte)PackedColorMath.Clamp(alpha, 0, 255));
        }

        public PackedColor(PackedColor color, float alpha)
        {
            this = new(color.R, color.G, color.B,
                (byte)PackedColorMath.Clamp(alpha * 255f, 0f, 255f));
        }
    }
}
