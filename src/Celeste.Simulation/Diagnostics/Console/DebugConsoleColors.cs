using System.Numerics;

namespace Celeste.Simulation.Diagnostics.Console
{
    // The XNA colours Celeste/Commands.cs uses. Kept as Vector4 so the pure layer needs no XNA type;
    // values are the XNA/FNA Color constants (Color.White etc.) normalised to 0..1.
    public static class DebugConsoleColors
    {
        public static readonly Vector4 White = new(1f, 1f, 1f, 1f);
        public static readonly Vector4 Yellow = new(1f, 1f, 0f, 1f);
        public static readonly Vector4 Aqua = new(0f, 1f, 1f, 1f);
        public static readonly Vector4 Red = new(1f, 0f, 0f, 1f);
        public static readonly Vector4 Green = new(0f, 128f / 255f, 0f, 1f);
        public static readonly Vector4 Lime = new(0f, 1f, 0f, 1f);
        public static readonly Vector4 LawnGreen = new(124f / 255f, 252f / 255f, 0f, 1f);
        public static readonly Vector4 Gray = new(128f / 255f, 128f / 255f, 128f / 255f, 1f);
        public static readonly Vector4 Black = new(0f, 0f, 0f, 1f);
    }
}
