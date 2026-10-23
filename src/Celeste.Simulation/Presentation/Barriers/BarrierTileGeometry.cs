using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Presentation.Barriers
{
    public static class BarrierTileGeometry
    {
        private static readonly IntPoint[] directions = [new(0, -1), new(0, 1), new(-1, 0), new(1, 0)];

        public static void WriteTiles(SourceSolidEntityState block, VirtualMap<bool> tiles, IntRect bounds, bool value)
        {
            for (var x = (int)block.Position.X / 8; x < block.Right / 8f; x++)
            for (var y = (int)block.Position.Y / 8; y < block.Bottom / 8f; y++)
                tiles[x - bounds.X, y - bounds.Y] = value;
        }

        public static void RebuildEdges<T>(IReadOnlyList<T> blocks, VirtualMap<bool> tiles, IntRect bounds,
            Action<T, Vector2, Vector2> addEdge) where T : SourceSolidEntityState
        {
            for (var blockIndex = 0; blockIndex < blocks.Count; blockIndex++)
            {
                var block = blocks[blockIndex];
                for (var x = (int)block.Position.X / 8; x < block.Right / 8f; x++)
                for (var y = (int)block.Position.Y / 8; y < block.Bottom / 8f; y++)
                    foreach (var direction in directions)
                    {
                        int px = -direction.Y, py = direction.X;
                        if (!Inside(tiles, bounds, x + direction.X, y + direction.Y)
                            && (!Inside(tiles, bounds, x - px, y - py)
                                || Inside(tiles, bounds, x + direction.X - px, y + direction.Y - py)))
                        {
                            int bx = x + px, by = y + py;
                            var offset = new Vector2(4f) + new Vector2(direction.X - px, direction.Y - py) * 4f;
                            while (Inside(tiles, bounds, bx, by)
                                   && !Inside(tiles, bounds, bx + direction.X, by + direction.Y))
                            {
                                bx += px;
                                by += py;
                            }

                            addEdge(block, new Vector2(x, y) * 8f + offset - block.Position,
                                new Vector2(bx, by) * 8f + offset - block.Position);
                        }
                    }
            }
        }

        private static bool Inside(VirtualMap<bool> tiles, IntRect bounds, int x, int y)
        {
            return tiles[x - bounds.X, y - bounds.Y];
        }

        public static float Wave(float offset, float along, float length, float solidify, ISourceEngineContext engine)
        {
            if (along <= 1f || along >= length - 1f) return 0f;
            if (solidify >= 1f) return 0f;
            var angle = offset + along * .25f;
            var sine = (float)(Math.Sin(angle) * 2.0 + Math.Sin(angle * .25f));
            var ease = ((ISourceEasingEnvironment)engine).EasingArithmetic.SineInOut(ScalarMath.YoYo(along / length));
            return (1f + sine * ease) * (1f - solidify);
        }
    }
}
