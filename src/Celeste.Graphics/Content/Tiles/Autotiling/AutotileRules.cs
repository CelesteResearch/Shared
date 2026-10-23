using System;
using System.Collections.Generic;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public sealed class AutotileRules
    {
        public readonly Dictionary<char, AutotileTerrain> Terrains = new Dictionary<char, AutotileTerrain>();
        public char EmptyId, UnsetId;
        public int TileWidth, TileHeight;

        internal Dictionary<char, AutotileTerrain> CreateRuntimeLookup()
        {
            var regions = new Dictionary<TileRegion, TileRegion>();
            var output = new Dictionary<char, AutotileTerrain>();

            AutotileCandidates CopyCandidates(AutotileCandidates source)
            {
                var copy = new AutotileCandidates();
                copy.Textures.Capacity = source.Textures.Capacity;
                copy.Textures.AddRange(source.Textures);
                copy.OverlapSprites.Capacity = source.OverlapSprites.Capacity;
                copy.OverlapSprites.AddRange(source.OverlapSprites);
                copy.HasOverlays = source.HasOverlays;
                return copy;
            }

            foreach (var item in Terrains)
            {
                var source = item.Value;
                var copy = new AutotileTerrain(source.ID);
                foreach (char ignored in source.Ignores) copy.Ignores.Add(ignored);
                copy.IgnoreOtherTerrains = source.IgnoreOtherTerrains;
                copy.Masked.Capacity = source.Masked.Capacity;
                foreach (var mask in source.Masked)
                    copy.Masked.Add(new AutotileMaskRule
                        { Mask = (byte[])mask.Mask.Clone(), Tiles = CopyCandidates(mask.Tiles) });
                copy.Center = CopyCandidates(source.Center);
                copy.Padded = CopyCandidates(source.Padded);
                output.Add(item.Key, copy);
            }

            return output;
        }
    }
}
