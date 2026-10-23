using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Numerics;


namespace Celeste.Core.Display
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    [DebuggerDisplay("{DebugDisplayString,nq}")]
    public struct PackedColor : IEquatable<global::Celeste.Core.Display.PackedColor>
    {
        private uint packedValue;

        public byte B
        {
            get { return (byte)(packedValue >> 16); }
            set { packedValue = (packedValue & 0xFF00FFFFu) | (uint)(value << 16); }
        }

        public byte G
        {
            get { return (byte)(packedValue >> 8); }
            set { packedValue = (packedValue & 0xFFFF00FFu) | (uint)(value << 8); }
        }

        public byte R
        {
            get { return (byte)packedValue; }
            set { packedValue = (packedValue & 0xFFFFFF00u) | value; }
        }

        public byte A
        {
            get { return (byte)(packedValue >> 24); }
            set { packedValue = (packedValue & 0xFFFFFF) | (uint)(value << 24); }
        }

        public uint PackedValue
        {
            get { return packedValue; }
            set { packedValue = value; }
        }

        public static global::Celeste.Core.Display.PackedColor Transparent { get; private set; }
        public static global::Celeste.Core.Display.PackedColor AliceBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor AntiqueWhite { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Aqua { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Aquamarine { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Azure { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Beige { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Bisque { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Black { get; private set; }
        public static global::Celeste.Core.Display.PackedColor BlanchedAlmond { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Blue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor BlueViolet { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Brown { get; private set; }
        public static global::Celeste.Core.Display.PackedColor BurlyWood { get; private set; }
        public static global::Celeste.Core.Display.PackedColor CadetBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Chartreuse { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Chocolate { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Coral { get; private set; }
        public static global::Celeste.Core.Display.PackedColor CornflowerBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Cornsilk { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Crimson { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Cyan { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkCyan { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkGoldenrod { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkGray { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkGreen { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkKhaki { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkMagenta { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkOliveGreen { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkOrange { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkOrchid { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkRed { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkSalmon { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkSeaGreen { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkSlateBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkSlateGray { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkTurquoise { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DarkViolet { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DeepPink { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DeepSkyBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DimGray { get; private set; }
        public static global::Celeste.Core.Display.PackedColor DodgerBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Firebrick { get; private set; }
        public static global::Celeste.Core.Display.PackedColor FloralWhite { get; private set; }
        public static global::Celeste.Core.Display.PackedColor ForestGreen { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Fuchsia { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Gainsboro { get; private set; }
        public static global::Celeste.Core.Display.PackedColor GhostWhite { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Gold { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Goldenrod { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Gray { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Green { get; private set; }
        public static global::Celeste.Core.Display.PackedColor GreenYellow { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Honeydew { get; private set; }
        public static global::Celeste.Core.Display.PackedColor HotPink { get; private set; }
        public static global::Celeste.Core.Display.PackedColor IndianRed { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Indigo { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Ivory { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Khaki { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Lavender { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LavenderBlush { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LawnGreen { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LemonChiffon { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LightBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LightCoral { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LightCyan { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LightGoldenrodYellow { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LightGray { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LightGreen { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LightPink { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LightSalmon { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LightSeaGreen { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LightSkyBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LightSlateGray { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LightSteelBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LightYellow { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Lime { get; private set; }
        public static global::Celeste.Core.Display.PackedColor LimeGreen { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Linen { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Magenta { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Maroon { get; private set; }
        public static global::Celeste.Core.Display.PackedColor MediumAquamarine { get; private set; }
        public static global::Celeste.Core.Display.PackedColor MediumBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor MediumOrchid { get; private set; }
        public static global::Celeste.Core.Display.PackedColor MediumPurple { get; private set; }
        public static global::Celeste.Core.Display.PackedColor MediumSeaGreen { get; private set; }
        public static global::Celeste.Core.Display.PackedColor MediumSlateBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor MediumSpringGreen { get; private set; }
        public static global::Celeste.Core.Display.PackedColor MediumTurquoise { get; private set; }
        public static global::Celeste.Core.Display.PackedColor MediumVioletRed { get; private set; }
        public static global::Celeste.Core.Display.PackedColor MidnightBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor MintCream { get; private set; }
        public static global::Celeste.Core.Display.PackedColor MistyRose { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Moccasin { get; private set; }
        public static global::Celeste.Core.Display.PackedColor NavajoWhite { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Navy { get; private set; }
        public static global::Celeste.Core.Display.PackedColor OldLace { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Olive { get; private set; }
        public static global::Celeste.Core.Display.PackedColor OliveDrab { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Orange { get; private set; }
        public static global::Celeste.Core.Display.PackedColor OrangeRed { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Orchid { get; private set; }
        public static global::Celeste.Core.Display.PackedColor PaleGoldenrod { get; private set; }
        public static global::Celeste.Core.Display.PackedColor PaleGreen { get; private set; }
        public static global::Celeste.Core.Display.PackedColor PaleTurquoise { get; private set; }
        public static global::Celeste.Core.Display.PackedColor PaleVioletRed { get; private set; }
        public static global::Celeste.Core.Display.PackedColor PapayaWhip { get; private set; }
        public static global::Celeste.Core.Display.PackedColor PeachPuff { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Peru { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Pink { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Plum { get; private set; }
        public static global::Celeste.Core.Display.PackedColor PowderBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Purple { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Red { get; private set; }
        public static global::Celeste.Core.Display.PackedColor RosyBrown { get; private set; }
        public static global::Celeste.Core.Display.PackedColor RoyalBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor SaddleBrown { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Salmon { get; private set; }
        public static global::Celeste.Core.Display.PackedColor SandyBrown { get; private set; }
        public static global::Celeste.Core.Display.PackedColor SeaGreen { get; private set; }
        public static global::Celeste.Core.Display.PackedColor SeaShell { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Sienna { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Silver { get; private set; }
        public static global::Celeste.Core.Display.PackedColor SkyBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor SlateBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor SlateGray { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Snow { get; private set; }
        public static global::Celeste.Core.Display.PackedColor SpringGreen { get; private set; }
        public static global::Celeste.Core.Display.PackedColor SteelBlue { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Tan { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Teal { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Thistle { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Tomato { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Turquoise { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Violet { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Wheat { get; private set; }
        public static global::Celeste.Core.Display.PackedColor White { get; private set; }
        public static global::Celeste.Core.Display.PackedColor WhiteSmoke { get; private set; }
        public static global::Celeste.Core.Display.PackedColor Yellow { get; private set; }
        public static global::Celeste.Core.Display.PackedColor YellowGreen { get; private set; }

        internal string DebugDisplayString => R + " " + G + " " + B + " " + A;

        static PackedColor()
        {
            Transparent = new global::Celeste.Core.Display.PackedColor(0u);
            AliceBlue = new global::Celeste.Core.Display.PackedColor(4294965488u);
            AntiqueWhite = new global::Celeste.Core.Display.PackedColor(4292340730u);
            Aqua = new global::Celeste.Core.Display.PackedColor(4294967040u);
            Aquamarine = new global::Celeste.Core.Display.PackedColor(4292149119u);
            Azure = new global::Celeste.Core.Display.PackedColor(4294967280u);
            Beige = new global::Celeste.Core.Display.PackedColor(4292670965u);
            Bisque = new global::Celeste.Core.Display.PackedColor(4291093759u);
            Black = new global::Celeste.Core.Display.PackedColor(4278190080u);
            BlanchedAlmond = new global::Celeste.Core.Display.PackedColor(4291685375u);
            Blue = new global::Celeste.Core.Display.PackedColor(4294901760u);
            BlueViolet = new global::Celeste.Core.Display.PackedColor(4293012362u);
            Brown = new global::Celeste.Core.Display.PackedColor(4280953509u);
            BurlyWood = new global::Celeste.Core.Display.PackedColor(4287084766u);
            CadetBlue = new global::Celeste.Core.Display.PackedColor(4288716383u);
            Chartreuse = new global::Celeste.Core.Display.PackedColor(4278255487u);
            Chocolate = new global::Celeste.Core.Display.PackedColor(4280183250u);
            Coral = new global::Celeste.Core.Display.PackedColor(4283465727u);
            CornflowerBlue = new global::Celeste.Core.Display.PackedColor(4293760356u);
            Cornsilk = new global::Celeste.Core.Display.PackedColor(4292671743u);
            Crimson = new global::Celeste.Core.Display.PackedColor(4282127580u);
            Cyan = new global::Celeste.Core.Display.PackedColor(4294967040u);
            DarkBlue = new global::Celeste.Core.Display.PackedColor(4287299584u);
            DarkCyan = new global::Celeste.Core.Display.PackedColor(4287335168u);
            DarkGoldenrod = new global::Celeste.Core.Display.PackedColor(4278945464u);
            DarkGray = new global::Celeste.Core.Display.PackedColor(4289309097u);
            DarkGreen = new global::Celeste.Core.Display.PackedColor(4278215680u);
            DarkKhaki = new global::Celeste.Core.Display.PackedColor(4285249469u);
            DarkMagenta = new global::Celeste.Core.Display.PackedColor(4287299723u);
            DarkOliveGreen = new global::Celeste.Core.Display.PackedColor(4281297749u);
            DarkOrange = new global::Celeste.Core.Display.PackedColor(4278226175u);
            DarkOrchid = new global::Celeste.Core.Display.PackedColor(4291572377u);
            DarkRed = new global::Celeste.Core.Display.PackedColor(4278190219u);
            DarkSalmon = new global::Celeste.Core.Display.PackedColor(4286224105u);
            DarkSeaGreen = new global::Celeste.Core.Display.PackedColor(4287347855u);
            DarkSlateBlue = new global::Celeste.Core.Display.PackedColor(4287315272u);
            DarkSlateGray = new global::Celeste.Core.Display.PackedColor(4283387695u);
            DarkTurquoise = new global::Celeste.Core.Display.PackedColor(4291939840u);
            DarkViolet = new global::Celeste.Core.Display.PackedColor(4292018324u);
            DeepPink = new global::Celeste.Core.Display.PackedColor(4287829247u);
            DeepSkyBlue = new global::Celeste.Core.Display.PackedColor(4294950656u);
            DimGray = new global::Celeste.Core.Display.PackedColor(4285098345u);
            DodgerBlue = new global::Celeste.Core.Display.PackedColor(4294938654u);
            Firebrick = new global::Celeste.Core.Display.PackedColor(4280427186u);
            FloralWhite = new global::Celeste.Core.Display.PackedColor(4293982975u);
            ForestGreen = new global::Celeste.Core.Display.PackedColor(4280453922u);
            Fuchsia = new global::Celeste.Core.Display.PackedColor(4294902015u);
            Gainsboro = new global::Celeste.Core.Display.PackedColor(4292664540u);
            GhostWhite = new global::Celeste.Core.Display.PackedColor(4294965496u);
            Gold = new global::Celeste.Core.Display.PackedColor(4278245375u);
            Goldenrod = new global::Celeste.Core.Display.PackedColor(4280329690u);
            Gray = new global::Celeste.Core.Display.PackedColor(4286611584u);
            Green = new global::Celeste.Core.Display.PackedColor(4278222848u);
            GreenYellow = new global::Celeste.Core.Display.PackedColor(4281335725u);
            Honeydew = new global::Celeste.Core.Display.PackedColor(4293984240u);
            HotPink = new global::Celeste.Core.Display.PackedColor(4290013695u);
            IndianRed = new global::Celeste.Core.Display.PackedColor(4284243149u);
            Indigo = new global::Celeste.Core.Display.PackedColor(4286709835u);
            Ivory = new global::Celeste.Core.Display.PackedColor(4293984255u);
            Khaki = new global::Celeste.Core.Display.PackedColor(4287424240u);
            Lavender = new global::Celeste.Core.Display.PackedColor(4294633190u);
            LavenderBlush = new global::Celeste.Core.Display.PackedColor(4294308095u);
            LawnGreen = new global::Celeste.Core.Display.PackedColor(4278254716u);
            LemonChiffon = new global::Celeste.Core.Display.PackedColor(4291689215u);
            LightBlue = new global::Celeste.Core.Display.PackedColor(4293318829u);
            LightCoral = new global::Celeste.Core.Display.PackedColor(4286611696u);
            LightCyan = new global::Celeste.Core.Display.PackedColor(4294967264u);
            LightGoldenrodYellow = new global::Celeste.Core.Display.PackedColor(4292016890u);
            LightGray = new global::Celeste.Core.Display.PackedColor(4292072403u);
            LightGreen = new global::Celeste.Core.Display.PackedColor(4287688336u);
            LightPink = new global::Celeste.Core.Display.PackedColor(4290885375u);
            LightSalmon = new global::Celeste.Core.Display.PackedColor(4286226687u);
            LightSeaGreen = new global::Celeste.Core.Display.PackedColor(4289376800u);
            LightSkyBlue = new global::Celeste.Core.Display.PackedColor(4294626951u);
            LightSlateGray = new global::Celeste.Core.Display.PackedColor(4288252023u);
            LightSteelBlue = new global::Celeste.Core.Display.PackedColor(4292789424u);
            LightYellow = new global::Celeste.Core.Display.PackedColor(4292935679u);
            Lime = new global::Celeste.Core.Display.PackedColor(4278255360u);
            LimeGreen = new global::Celeste.Core.Display.PackedColor(4281519410u);
            Linen = new global::Celeste.Core.Display.PackedColor(4293325050u);
            Magenta = new global::Celeste.Core.Display.PackedColor(4294902015u);
            Maroon = new global::Celeste.Core.Display.PackedColor(4278190208u);
            MediumAquamarine = new global::Celeste.Core.Display.PackedColor(4289383782u);
            MediumBlue = new global::Celeste.Core.Display.PackedColor(4291624960u);
            MediumOrchid = new global::Celeste.Core.Display.PackedColor(4292040122u);
            MediumPurple = new global::Celeste.Core.Display.PackedColor(4292571283u);
            MediumSeaGreen = new global::Celeste.Core.Display.PackedColor(4285641532u);
            MediumSlateBlue = new global::Celeste.Core.Display.PackedColor(4293814395u);
            MediumSpringGreen = new global::Celeste.Core.Display.PackedColor(4288346624u);
            MediumTurquoise = new global::Celeste.Core.Display.PackedColor(4291613000u);
            MediumVioletRed = new global::Celeste.Core.Display.PackedColor(4286911943u);
            MidnightBlue = new global::Celeste.Core.Display.PackedColor(4285536537u);
            MintCream = new global::Celeste.Core.Display.PackedColor(4294639605u);
            MistyRose = new global::Celeste.Core.Display.PackedColor(4292994303u);
            Moccasin = new global::Celeste.Core.Display.PackedColor(4290110719u);
            NavajoWhite = new global::Celeste.Core.Display.PackedColor(4289584895u);
            Navy = new global::Celeste.Core.Display.PackedColor(4286578688u);
            OldLace = new global::Celeste.Core.Display.PackedColor(4293326333u);
            Olive = new global::Celeste.Core.Display.PackedColor(4278222976u);
            OliveDrab = new global::Celeste.Core.Display.PackedColor(4280520299u);
            Orange = new global::Celeste.Core.Display.PackedColor(4278232575u);
            OrangeRed = new global::Celeste.Core.Display.PackedColor(4278207999u);
            Orchid = new global::Celeste.Core.Display.PackedColor(4292243674u);
            PaleGoldenrod = new global::Celeste.Core.Display.PackedColor(4289390830u);
            PaleGreen = new global::Celeste.Core.Display.PackedColor(4288215960u);
            PaleTurquoise = new global::Celeste.Core.Display.PackedColor(4293848751u);
            PaleVioletRed = new global::Celeste.Core.Display.PackedColor(4287852763u);
            PapayaWhip = new global::Celeste.Core.Display.PackedColor(4292210687u);
            PeachPuff = new global::Celeste.Core.Display.PackedColor(4290370303u);
            Peru = new global::Celeste.Core.Display.PackedColor(4282353101u);
            Pink = new global::Celeste.Core.Display.PackedColor(4291543295u);
            Plum = new global::Celeste.Core.Display.PackedColor(4292714717u);
            PowderBlue = new global::Celeste.Core.Display.PackedColor(4293320880u);
            Purple = new global::Celeste.Core.Display.PackedColor(4286578816u);
            Red = new global::Celeste.Core.Display.PackedColor(4278190335u);
            RosyBrown = new global::Celeste.Core.Display.PackedColor(4287598524u);
            RoyalBlue = new global::Celeste.Core.Display.PackedColor(4292962625u);
            SaddleBrown = new global::Celeste.Core.Display.PackedColor(4279453067u);
            Salmon = new global::Celeste.Core.Display.PackedColor(4285694202u);
            SandyBrown = new global::Celeste.Core.Display.PackedColor(4284523764u);
            SeaGreen = new global::Celeste.Core.Display.PackedColor(4283927342u);
            SeaShell = new global::Celeste.Core.Display.PackedColor(4293850623u);
            Sienna = new global::Celeste.Core.Display.PackedColor(4281160352u);
            Silver = new global::Celeste.Core.Display.PackedColor(4290822336u);
            SkyBlue = new global::Celeste.Core.Display.PackedColor(4293643911u);
            SlateBlue = new global::Celeste.Core.Display.PackedColor(4291648106u);
            SlateGray = new global::Celeste.Core.Display.PackedColor(4287660144u);
            Snow = new global::Celeste.Core.Display.PackedColor(4294638335u);
            SpringGreen = new global::Celeste.Core.Display.PackedColor(4286578432u);
            SteelBlue = new global::Celeste.Core.Display.PackedColor(4290019910u);
            Tan = new global::Celeste.Core.Display.PackedColor(4287411410u);
            Teal = new global::Celeste.Core.Display.PackedColor(4286611456u);
            Thistle = new global::Celeste.Core.Display.PackedColor(4292394968u);
            Tomato = new global::Celeste.Core.Display.PackedColor(4282868735u);
            Turquoise = new global::Celeste.Core.Display.PackedColor(4291878976u);
            Violet = new global::Celeste.Core.Display.PackedColor(4293821166u);
            Wheat = new global::Celeste.Core.Display.PackedColor(4289978101u);
            White = new global::Celeste.Core.Display.PackedColor(uint.MaxValue);
            WhiteSmoke = new global::Celeste.Core.Display.PackedColor(4294309365u);
            Yellow = new global::Celeste.Core.Display.PackedColor(4278255615u);
            YellowGreen = new global::Celeste.Core.Display.PackedColor(4281519514u);
        }

        public PackedColor(Vector4 color)
        {
            packedValue = 0u;
            R = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(color.X * 255f, 0f, 255f);
            G = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(color.Y * 255f, 0f, 255f);
            B = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(color.Z * 255f, 0f, 255f);
            A = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(color.W * 255f, 0f, 255f);
        }

        public PackedColor(Vector3 color)
        {
            packedValue = 0u;
            R = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(color.X * 255f, 0f, 255f);
            G = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(color.Y * 255f, 0f, 255f);
            B = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(color.Z * 255f, 0f, 255f);
            A = byte.MaxValue;
        }

        public PackedColor(float r, float g, float b)
        {
            packedValue = 0u;
            R = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(r * 255f, 0f, 255f);
            G = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(g * 255f, 0f, 255f);
            B = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(b * 255f, 0f, 255f);
            A = byte.MaxValue;
        }

        public PackedColor(int r, int g, int b)
        {
            packedValue = 0u;
            R = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(r, 0, 255);
            G = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(g, 0, 255);
            B = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(b, 0, 255);
            A = byte.MaxValue;
        }

        public PackedColor(int r, int g, int b, int alpha)
        {
            packedValue = 0u;
            R = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(r, 0, 255);
            G = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(g, 0, 255);
            B = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(b, 0, 255);
            A = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(alpha, 0, 255);
        }

        public PackedColor(float r, float g, float b, float alpha)
        {
            packedValue = 0u;
            R = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(r * 255f, 0f, 255f);
            G = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(g * 255f, 0f, 255f);
            B = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(b * 255f, 0f, 255f);
            A = (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(alpha * 255f, 0f, 255f);
        }

        private PackedColor(uint packedValue)
        {
            this.packedValue = packedValue;
        }

        public bool Equals(global::Celeste.Core.Display.PackedColor other)
        {
            return PackedValue == other.PackedValue;
        }

        public static PackedColor FromHex(string hex)
            => new PackedColor(Convert.ToByte(hex.Substring(0, 2), 16),
                Convert.ToByte(hex.Substring(2, 2), 16), Convert.ToByte(hex.Substring(4, 2), 16));

        public Vector3 ToVector3()
        {
            return new Vector3((float)(int)R / 255f, (float)(int)G / 255f, (float)(int)B / 255f);
        }

        public Vector4 ToVector4()
        {
            return new Vector4((float)(int)R / 255f, (float)(int)G / 255f, (float)(int)B / 255f, (float)(int)A / 255f);
        }

        public static global::Celeste.Core.Display.PackedColor Lerp(
            global::Celeste.Core.Display.PackedColor value1,
            global::Celeste.Core.Display.PackedColor value2, float amount)
        {
            amount = global::Celeste.Core.Display.PackedColorMath.Clamp(amount, 0f, 1f);
            return new global::Celeste.Core.Display.PackedColor(
                (int)global::Celeste.Core.Display.PackedColorMath.Lerp((int)value1.R, (int)value2.R, amount),
                (int)global::Celeste.Core.Display.PackedColorMath.Lerp((int)value1.G, (int)value2.G, amount),
                (int)global::Celeste.Core.Display.PackedColorMath.Lerp((int)value1.B, (int)value2.B, amount),
                (int)global::Celeste.Core.Display.PackedColorMath.Lerp((int)value1.A, (int)value2.A, amount));
        }

        public static global::Celeste.Core.Display.PackedColor FromNonPremultiplied(Vector4 vector)
        {
            return new global::Celeste.Core.Display.PackedColor(vector.X * vector.W, vector.Y * vector.W,
                vector.Z * vector.W, vector.W);
        }

        public static global::Celeste.Core.Display.PackedColor FromNonPremultiplied(int r, int g, int b, int a)
        {
            return new global::Celeste.Core.Display.PackedColor(r * a / 255, g * a / 255, b * a / 255, a);
        }

        public static bool operator ==(global::Celeste.Core.Display.PackedColor a,
            global::Celeste.Core.Display.PackedColor b)
        {
            if (a.A == b.A && a.R == b.R && a.G == b.G)
            {
                return a.B == b.B;
            }

            return false;
        }

        public static bool operator !=(global::Celeste.Core.Display.PackedColor a,
            global::Celeste.Core.Display.PackedColor b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return packedValue.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is global::Celeste.Core.Display.PackedColor)
            {
                return Equals((global::Celeste.Core.Display.PackedColor)obj);
            }

            return false;
        }

        public static global::Celeste.Core.Display.PackedColor Multiply(
            global::Celeste.Core.Display.PackedColor value, float scale)
        {
            return new global::Celeste.Core.Display.PackedColor((int)((float)(int)value.R * scale),
                (int)((float)(int)value.G * scale),
                (int)((float)(int)value.B * scale), (int)((float)(int)value.A * scale));
        }

        public static global::Celeste.Core.Display.PackedColor operator *(
            global::Celeste.Core.Display.PackedColor value, float scale)
        {
            return new global::Celeste.Core.Display.PackedColor((int)((float)(int)value.R * scale),
                (int)((float)(int)value.G * scale),
                (int)((float)(int)value.B * scale), (int)((float)(int)value.A * scale));
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(25);
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

        public PackedColor(global::Celeste.Core.Display.PackedColor color, int alpha)
        {
            this = new global::Celeste.Core.Display.PackedColor(color.R, color.G, color.B,
                (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(alpha, 0, 255));
        }

        public PackedColor(global::Celeste.Core.Display.PackedColor color, float alpha)
        {
            this = new global::Celeste.Core.Display.PackedColor(color.R, color.G, color.B,
                (byte)global::Celeste.Core.Display.PackedColorMath.Clamp(alpha * 255f, 0f, 255f));
        }
    }
}
