using System;
using System.Numerics;
using Celeste.Simulation.Presentation.Backdrops.HeatWave;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Content.Maps.Backdrops
{
    public static class OriginalHeatWaveBackdropResources
    {
        private static readonly Vector4[] HotColors =
            { new Vector4(1, 0, 0, 1), new Vector4(255, 165, 0, 255) / 255f };

        private static readonly Vector4[] ColdColors =
            { new Vector4(135, 206, 250, 255) / 255f, new Vector4(0, 128, 128, 255) / 255f };

        public static HeatWaveBackdropResources Create(AtlasData misc)
        {
            Vector4 Hex(int value) =>
                new Vector4((value >> 16) & 255, (value >> 8) & 255, value & 255, 255) / 255f;

            return new HeatWaveBackdropResources(() => misc.Entries["mist"], HotColors, ColdColors,
                Hex(0x639bff), Hex(0xf1b22b), Hex(0x5fcde4), Hex(0xf12b3a),
                new Vector4(128, 128, 26, 255) / 255f,
                320, 180, 50, 5, 370, 190, "hot", "cold", "none");
        }
    }
}
