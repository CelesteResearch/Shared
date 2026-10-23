using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.UI.Menus.Text
{
    public readonly struct TextMenuColor : IEquatable<global::Celeste.Simulation.UI.Menus.Text.TextMenuColor>
    {
        public readonly Vector4 Value;

        public TextMenuColor(Vector4 value)
        {
            Value = value;
        }

        public static implicit operator global::Celeste.Simulation.UI.Menus.Text.TextMenuColor(Vector4 value) =>
            new global::Celeste.Simulation.UI.Menus.Text.TextMenuColor(value);

        public static implicit operator Vector4(global::Celeste.Simulation.UI.Menus.Text.TextMenuColor value) =>
            value.Value;

        public static global::Celeste.Simulation.UI.Menus.Text.TextMenuColor operator *(
            global::Celeste.Simulation.UI.Menus.Text.TextMenuColor value, float alpha) =>
            global::Celeste.Graphics.Display.Colors.ColorMath.Scale(value.Value, alpha);

        public static bool operator ==(global::Celeste.Simulation.UI.Menus.Text.TextMenuColor a,
            global::Celeste.Simulation.UI.Menus.Text.TextMenuColor b) => a.Value == b.Value;

        public static bool operator !=(global::Celeste.Simulation.UI.Menus.Text.TextMenuColor a,
            global::Celeste.Simulation.UI.Menus.Text.TextMenuColor b) => a.Value != b.Value;

        public bool Equals(global::Celeste.Simulation.UI.Menus.Text.TextMenuColor other) => Value == other.Value;

        public override bool Equals(object obj) =>
            obj is global::Celeste.Simulation.UI.Menus.Text.TextMenuColor other && Equals(other);

        public override int GetHashCode() => Value.GetHashCode();

        public static readonly global::Celeste.Simulation.UI.Menus.Text.TextMenuColor White = Vector4.One,
            Black = new Vector4(0, 0, 0, 1),
            Gray = new Vector4(128, 128, 128, 255) / 255,
            DarkSlateBlue = new Vector4(72, 61, 139, 255) / 255,
            DarkSlateGray = new Vector4(47, 79, 79, 255) / 255,
            LightGray = new Vector4(211, 211, 211, 255) / 255;

        public static global::Celeste.Simulation.UI.Menus.Text.TextMenuColor Hex(string value) => new Vector4(
            Convert.ToInt32(value.Substring(0, 2), 16),
            Convert.ToInt32(value.Substring(2, 2), 16), Convert.ToInt32(value.Substring(4, 2), 16), 255) / 255;
    }
}
