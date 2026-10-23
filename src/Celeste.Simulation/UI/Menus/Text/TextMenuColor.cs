using System;
using System.Numerics;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Simulation.UI.Menus.Text
{
    public readonly struct TextMenuColor : IEquatable<TextMenuColor>
    {
        public readonly Vector4 Value;

        public TextMenuColor(Vector4 value)
        {
            Value = value;
        }

        public static implicit operator TextMenuColor(Vector4 value)
        {
            return new(value);
        }

        public static implicit operator Vector4(TextMenuColor value)
        {
            return value.Value;
        }

        public static TextMenuColor operator *(
            TextMenuColor value, float alpha)
        {
            return ColorMath.Scale(value.Value, alpha);
        }

        public static bool operator ==(TextMenuColor a,
            TextMenuColor b)
        {
            return a.Value == b.Value;
        }

        public static bool operator !=(TextMenuColor a,
            TextMenuColor b)
        {
            return a.Value != b.Value;
        }

        public bool Equals(TextMenuColor other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is TextMenuColor other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static readonly TextMenuColor White = Vector4.One,
            Black = new Vector4(0, 0, 0, 1),
            Gray = new Vector4(128, 128, 128, 255) / 255,
            DarkSlateBlue = new Vector4(72, 61, 139, 255) / 255,
            DarkSlateGray = new Vector4(47, 79, 79, 255) / 255,
            LightGray = new Vector4(211, 211, 211, 255) / 255;

        public static TextMenuColor Hex(string value)
        {
            return new Vector4(
                Convert.ToInt32(value.Substring(0, 2), 16),
                Convert.ToInt32(value.Substring(2, 2), 16), Convert.ToInt32(value.Substring(4, 2), 16), 255) / 255;
        }
    }
}
