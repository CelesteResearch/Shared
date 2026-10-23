using Celeste.Graphics.Content.Atlas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Celeste.Simulation.Rendering
{
    public sealed class ReflectionTentaclesResources
    {
        public readonly global::Celeste.Graphics.Content.Atlas.AtlasData Atlas;

        public readonly List<global::Celeste.Graphics.Content.Tiles.TileRegion[]> Arms =
            new List<global::Celeste.Graphics.Content.Tiles.TileRegion[]>();

        public readonly List<global::Celeste.Graphics.Content.Tiles.TileRegion> Fillers =
            new List<global::Celeste.Graphics.Content.Tiles.TileRegion>();

        public readonly Func<string, (int Width, int Height)> PageSize;

        public ReflectionTentaclesResources(global::Celeste.Graphics.Content.Atlas.AtlasData atlas,
            Func<string, (int Width, int Height)> pageSize)
        {
            Atlas = atlas;
            PageSize = pageSize;
            foreach (var texture in atlas.Frames("scenery/tentacles/arms"))
            {
                var slices = new global::Celeste.Graphics.Content.Tiles.TileRegion[10];
                int size = texture.FrameWidth / 10;
                for (int i = 0; i < 10; i++)
                    slices[i] = new global::Celeste.Graphics.Content.Tiles.TileRegion(texture, size * (10 - i - 1),
                        0, size, texture.FrameHeight);
                Arms.Add(slices);
            }

            foreach (var texture in atlas.Frames("scenery/tentacles/filler"))
                Fillers.Add(new global::Celeste.Graphics.Content.Tiles.TileRegion(texture, 0, 0, texture.FrameWidth,
                    texture.FrameHeight));
        }
    }
}
