using System.Numerics;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles;
using Celeste.Simulation.Presentation.Backdrops.NorthernLights;

namespace Celeste.Game.Content.Maps.Backdrops
{
    public static class OriginalNorthernLightsBackdropResources
    {
        private static readonly Vector4[] Colors =
        [
            new Vector4(45, 224, 121, 255) / 255f, new Vector4(98, 244, 246, 255) / 255f,
            new Vector4(69, 188, 46, 255) / 255f, new Vector4(56, 86, 240, 255) / 255f,
        ];

        private static readonly TileRegion Pixel = new(
            new()
            {
                Name = "pixel", Page = "__particle_pixel", Width = 1, Height = 1, FrameWidth = 1, FrameHeight = 1,
            }, 0, 0, 1, 1);

        public static NorthernLightsBackdropResources Create(AtlasData misc)
        {
            var texture = misc.Entries["northernlights"];
            var noise = new TileRegion(texture, 0, 0, texture.FrameWidth, texture.FrameHeight);
            return new(noise, Pixel, Colors,
                new Vector4(2, 8, 37, 255) / 255f,
                new Vector4(23, 12, 47, 255) / 255f,
                320, 180, 3, 50, 40);
        }
    }
}
