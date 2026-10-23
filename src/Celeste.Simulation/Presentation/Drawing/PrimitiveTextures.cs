using Celeste.Graphics.Content.Tiles;

namespace Celeste.Simulation.Presentation.Drawing
{
    public static class PrimitiveTextures
    {
        public static readonly TileRegion Pixel =
            new(
                new()
                {
                    Name = "pixel", Page = "__particle_pixel", Width = 1, Height = 1, FrameWidth = 1, FrameHeight = 1,
                },
                0, 0,
                1, 1);
    }
}
