using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Tiles;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Presentation.Walls.Breakable
{
    public static class BreakableTileBlockVisuals
    {
        public static void AddTiles(SourceSolidEntityState block, ISourceSolidWorld world, ref char tileType,
            bool blendIn,
            ref float boxWidth, ref float boxHeight)
        {
            TileGrid tiles;
            if (!blendIn)
            {
                tiles = ((ISourceAutotilingResources)world.EngineContext).ForegroundAutotiler
                    .GenerateBox(tileType, (int)boxWidth / 8, (int)boxHeight / 8).TileGrid;
                block.OwnedComponents.Add(new LightOccludeState());
            }
            else
            {
                var level = (OriginalLevelSceneRoot)block.Scene;
                var bounds = ((OriginalChapterMapData)level.Session.MapData).TileBounds;
                var solids = level.SolidsData;
                var x = (int)(block.X / 8f) - bounds.Left;
                var y = (int)(block.Y / 8f) - bounds.Top;
                var w = (int)block.Width / 8;
                var h = (int)block.Height / 8;
                tiles = ((ISourceAutotilingResources)world.EngineContext).ForegroundAutotiler
                    .GenerateOverlay(tileType, x, y, w, h, solids).TileGrid;
                block.OwnedComponents.Add(new EffectCutoutState());
                block.Depth = -10501;
            }

            block.OwnedComponents.Add(tiles);
            block.OwnedComponents.Add(new TileInterceptorState(tiles, true));
        }
    }
}
