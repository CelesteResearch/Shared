using System.Collections.Generic;
using Celeste.Core.Collections;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public static class GroupedOverlayTileGeneration
    {
        public static void Generate<T>(IReadOnlyList<T> regions, VirtualMap<char> map, IntRect tileBounds,
            Autotiler autotiler) where T : IGroupedOverlayTileRegion
        {
            var backup = new VirtualMap<char>(map.Columns, map.Rows);
            var overwritten = new VirtualMap<bool>(map.Columns, map.Rows);
            foreach (var item in regions)
            {
                var x = (int)(item.Position.X / 8f) - tileBounds.X;
                var y = (int)(item.Position.Y / 8f - tileBounds.Y);
                int width = (int)(item.Width / 8f), height = (int)(item.Height / 8f);
                for (var i = x; i < x + width; i++)
                for (var j = y; j < y + height; j++)
                {
                    if (!overwritten[i, j])
                    {
                        backup[i, j] = map[i, j];
                        overwritten[i, j] = true;
                    }

                    map[i, j] = item.FillTile;
                }
            }

            foreach (var item in regions)
            {
                var x = (int)item.Position.X / 8 - tileBounds.Left;
                var y = (int)item.Position.Y / 8 - tileBounds.Top;
                item.SetGeneratedOverlay(autotiler.GenerateOverlay(item.FillTile, x, y, (int)item.Width / 8,
                    (int)item.Height / 8, map));
            }

            foreach (var item in regions)
            {
                var x = (int)(item.Position.X / 8f) - tileBounds.X;
                var y = (int)(item.Position.Y / 8f - tileBounds.Y);
                int width = (int)(item.Width / 8f), height = (int)(item.Height / 8f);
                for (var i = x; i < x + width; i++)
                for (var j = y; j < y + height; j++)
                    if (overwritten[i, j])
                        map[i, j] = backup[i, j];
            }
        }
    }
}
