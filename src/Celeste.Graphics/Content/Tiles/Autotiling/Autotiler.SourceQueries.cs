using Celeste.Core.Collections;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public partial class Autotiler
    {
        public ISourceEngineContext EngineContext => engine;
        public virtual int TileWidth => tileWidth;
        public virtual int TileHeight => tileHeight;

        public virtual AnimatedTileBank AnimatedTilesBank =>
            bankEnvironment != null ? bankEnvironment.AnimatedTilesBank : bank;

        public virtual AutotileCandidateView QueryTile(VirtualMap<char> map, int x, int y, IntRect forceFill,
            char forceId, AutotileBehavior behavior)
        {
            var result = VanillaTileHandler(map, x, y, forceFill, forceId, behavior);
            return result == null
                ? default
                : new AutotileCandidateView(result.Textures, result.OverlapSprites, result.HasOverlays);
        }
    }
}
