using Celeste.Simulation;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Minigames.CelesteClassic.Content
{
    public static class ClassicCartridgeData
    {
        // Restored cartridge room data.
        public static string MapData => global::Celeste.Game.Reflection.Metadata.Resources.SourcePico8MapData.Value;

        // Emulator.cs:52-67.
        public static readonly byte[] Mask = new byte[128]
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 4, 2, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 2, 0, 0,
            0, 0, 3, 3, 3, 3, 3, 3, 3, 3,
            4, 4, 4, 2, 2, 0, 0, 0, 3, 3,
            3, 3, 3, 3, 3, 3, 4, 4, 4, 2,
            2, 2, 2, 2, 0, 0, 19, 19, 19, 19,
            2, 2, 3, 2, 2, 2, 2, 2, 2, 2,
            0, 0, 19, 19, 19, 19, 2, 2, 4, 2,
            2, 2, 2, 2, 2, 2, 0, 0, 19, 19,
            19, 19, 0, 4, 4, 2, 2, 2, 2, 2,
            2, 2, 0, 0, 19, 19, 19, 19, 0, 0,
            0, 2, 2, 2, 2, 2, 2, 2,
        };

        // Emulator.cs:69-87 (Calc.HexToColor argument order preserved).
        public static readonly string[] PaletteHex =
        {
            "000000", "1d2b53", "7e2553", "008751", "ab5236", "5f574f", "c2c3c7", "fff1e8", "ff004d", "ffa300",
            "ffec27", "00e436", "29adff", "83769c", "ff77a8", "ffccaa"
        };

        // Emulator.cs:93.
        public const string FontMap = "abcdefghijklmnopqrstuvwxyz0123456789~!@#4%^&*()_+-=?:.";
    }
}
