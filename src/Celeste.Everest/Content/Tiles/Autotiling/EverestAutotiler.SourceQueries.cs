using Celeste.Core.Collections;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;

namespace Celeste.Everest.Content.Tiles.Autotiling
{
    public sealed partial class EverestAutotiler
    {
        public override int TileWidth => 8;
        public override int TileHeight => 8;
        public override AnimatedTileBank AnimatedTilesBank => Graphics.AnimatedTilesBank;

        public override AutotileCandidateView QueryTile(VirtualMap<char> map, int x, int y, IntRect forceFill,
            char forceId, AutotileBehavior behavior)
        {
            var result = TileHandler(map, x, y, forceFill, forceId, behavior);
            return result == null
                ? default
                : new AutotileCandidateView(result.Textures, result.OverlapSprites, result.HasOverlays);
        }
    }
}
