using System;
using System.Collections.Generic;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Simulation.Rendering
{
    public sealed class ReflectionTentaclesResources
    {
        public readonly AtlasData Atlas;

        public readonly List<TileRegion[]> Arms = [];

        public readonly List<TileRegion> Fillers = [];

        public readonly Func<string, (int Width, int Height)> PageSize;

        public ReflectionTentaclesResources(AtlasData atlas,
            Func<string, (int Width, int Height)> pageSize)
        {
            Atlas = atlas;
            PageSize = pageSize;
            foreach (var texture in atlas.Frames("scenery/tentacles/arms"))
            {
                var slices = new TileRegion[10];
                var size = texture.FrameWidth / 10;
                for (var i = 0; i < 10; i++)
                    slices[i] = new(texture, size * (10 - i - 1),
                        0, size, texture.FrameHeight);
                Arms.Add(slices);
            }

            foreach (var texture in atlas.Frames("scenery/tentacles/filler"))
                Fillers.Add(new(texture, 0, 0, texture.FrameWidth,
                    texture.FrameHeight));
        }
    }
}
