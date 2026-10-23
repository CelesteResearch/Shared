using System;
using System.Numerics;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Display;

namespace Celeste.Simulation.Presentation.Backdrops.Drawing
{
    internal static class WeatherBackdropArt
    {
        internal static readonly TileRegion Pixel =
            new(
                new()
                {
                    Name = "__particle_pixel", Page = "__particle_pixel", Width = 1, Height = 1, FrameWidth = 1,
                    FrameHeight = 1,
                }, 0, 0, 1, 1);

        internal static float Float(Random random, float max = 1)
        {
            return (float)random.NextDouble() * max;
        }

        internal static float Range(Random random, float min, float max)
        {
            return min + Float(random, max - min);
        }

        internal static float Mod(float value, float period)
        {
            return (value % period + period) % period;
        }

        internal static ImagePlacement Centered(
            TileRegion region, Vector2 at, Vector4 color, Vector2 scale,
            float rotation = 0)
        {
            return new(region, at.X, at.Y, 0, scale.X, scale.Y,
                rotation,
                region.Width / 2f,
                region.Height / 2f, color);
        }
    }
}
