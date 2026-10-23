using System.Numerics;
using Celeste.Core.Maps.Grids;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Graphics.Content.Tiles;
using Celeste.Simulation.Gameplay.Tiles;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private void InterceptSourceObjectTiles(OriginalLevelRoomData room)
        {
            if (!string.IsNullOrEmpty(room.ObjTiles))
            {
                var tileset = new Tileset(graphicsResources.GameAtlas.Entries["tilesets/scenery"], 8, 8);
                var tiles = CsvIntegerGrid.Read(room.ObjTiles, Bounds.Width / 8, Bounds.Height / 8);
                for (var x = 0; x < tiles.GetLength(0); x++)
                for (var y = 0; y < tiles.GetLength(1); y++)
                    if (tiles[x, y] != -1)
                        TileInterceptorState.TileCheck(Scheduler.Components, tileset[tiles[x, y]],
                            new Vector2(x * 8, y * 8) + new Vector2(Bounds.Left, Bounds.Top));
            }
        }
    }
}
