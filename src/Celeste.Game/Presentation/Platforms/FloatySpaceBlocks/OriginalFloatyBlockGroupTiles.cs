using System.Collections.Generic;
using Celeste.Core.Collections;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Presentation.Platforms.FloatySpaceBlocks
{
    public static class OriginalFloatyBlockGroupTiles
    {
        public static TileGrid Generate<T>(List<T> group, IntPoint min, IntPoint max, ref char tileType,
            ISourceEngineContext engine) where T : SourceSolidEntityState
        {
            VirtualMap<char> map = CreateTileMap(group, min, max, tileType);
            return ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                .ForegroundAutotiler.GenerateMap(map, new AutotileBehavior
                {
                    EdgesExtend = false,
                    EdgesIgnoreOutOfLevel = false,
                    PaddingIgnoreOutOfLevel = false
                }).TileGrid;
        }

        internal static VirtualMap<char> CreateTileMap<T>(List<T> group, IntPoint min, IntPoint max, char tileType)
            where T : SourceSolidEntityState
        {
            IntRect bounds = new IntRect(min.X / 8, min.Y / 8, (max.X - min.X) / 8 + 1,
                (max.Y - min.Y) / 8 + 1);
            VirtualMap<char> map = new VirtualMap<char>(bounds.Width, bounds.Height, '0');
            foreach (T block in group)
            {
                int startX = (int)(block.X / 8f) - bounds.X;
                int startY = (int)(block.Y / 8f) - bounds.Y;
                int width = (int)(block.Width / 8f);
                int height = (int)(block.Height / 8f);
                for (int x = startX; x < startX + width; x++)
                {
                    for (int y = startY; y < startY + height; y++)
                    {
                        map[x, y] = tileType;
                    }
                }
            }

            return map;
        }
    }
}
