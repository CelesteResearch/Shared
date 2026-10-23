using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Backdrops.Drawing
{
    internal static class WeatherBackdropArt
    {
        internal static readonly global::Celeste.Graphics.Content.Tiles.TileRegion Pixel =
            new global::Celeste.Graphics.Content.Tiles.TileRegion(
                new global::Celeste.Graphics.Content.Atlas.AtlasEntry
                {
                    Name = "__particle_pixel", Page = "__particle_pixel", Width = 1, Height = 1, FrameWidth = 1,
                    FrameHeight = 1
                }, 0, 0, 1, 1);

        internal static float Float(Random random, float max = 1) => (float)random.NextDouble() * max;
        internal static float Range(Random random, float min, float max) => min + Float(random, max - min);
        internal static float Mod(float value, float period) => (value % period + period) % period;

        internal static global::Celeste.Graphics.Display.ImagePlacement Centered(
            global::Celeste.Graphics.Content.Tiles.TileRegion region, Vector2 at, Vector4 color, Vector2 scale,
            float rotation = 0)
            => new global::Celeste.Graphics.Display.ImagePlacement(region, at.X, at.Y, 0, scale.X, scale.Y, rotation,
                region.Width / 2f,
                region.Height / 2f, color);
    }
}
