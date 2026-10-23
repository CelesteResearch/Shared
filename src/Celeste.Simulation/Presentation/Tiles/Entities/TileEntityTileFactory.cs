using System;
using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Simulation.Content.Tiles.Chapters;
using Celeste.Simulation.Gameplay.Walls.Breakable;
using Celeste.Simulation.Runtime.Randomness;

namespace Celeste.Simulation.Presentation.Tiles.Entities
{
    public sealed class TileEntityTileFactory
    {
        public ChapterTiles Chapter { get; }
        private readonly SpriteRandomContext random;
        private readonly ISourceAutotilingResources resources;

        private Autotiler foreground =>
            resources.ForegroundAutotiler;

        public TileEntityTileFactory(ChapterTiles chapter,
            SpriteRandomContext random,
            ISourceAutotilingResources resources)
        {
            Chapter = chapter ?? throw new ArgumentNullException(nameof(chapter));
            this.random = random ?? throw new ArgumentNullException(nameof(random));
            this.resources = resources ?? throw new ArgumentNullException(nameof(resources));
        }

        internal TileGrid GenerateFloatyGroup(VirtualMap<char> map)
        {
            return foreground.GenerateMap(map,
                new AutotileBehavior
                    { EdgesExtend = false, EdgesIgnoreOutOfLevel = false, PaddingIgnoreOutOfLevel = false }).TileGrid;
        }

        internal TileGrid GenerateRequest(
            DashBlockTileRequest r)
        {
            return r.Overlay
                ? foreground.GenerateOverlay(r.TileType, r.X, r.Y, r.Columns, r.Rows, Chapter.Solids).TileGrid
                : foreground.GenerateBox(r.TileType, r.Columns, r.Rows).TileGrid;
        }

        internal TileGrid Generate(
            TileEntityKind kind, Vector2 position, float width,
            float height, char tile,
            bool finalBoss, out TileGrid highlight, out int? seed,
            bool blendIn = false)
        {
            int columns = (int)width / 8, rows = (int)height / 8;
            highlight = null;
            seed = null;
            if (kind == TileEntityKind.FallingBlock)
            {
                var generatedSeed = random.Current.Next();
                seed = generatedSeed;
                var tileScope = random.Push(new(generatedSeed));
                var tiles = foreground.GenerateBox(tile, columns, rows).TileGrid;
                tileScope.Dispose();
                if (finalBoss)
                {
                    var highlightScope = random.Push(new(generatedSeed));
                    highlight = foreground.GenerateBox('G', columns, rows).TileGrid;
                    highlightScope.Dispose();
                }

                return tiles;
            }

            if (kind == TileEntityKind.FakeBlock ||
                (kind == TileEntityKind.DashBlock && !blendIn))
                return foreground.GenerateBox(tile, columns, rows).TileGrid;
            var x = (kind == TileEntityKind.ExitBlock ||
                     kind == TileEntityKind.DashBlock
                ? (int)(position.X / 8f)
                : (int)position.X / 8) - Chapter.Bounds.Left;
            var y = (kind == TileEntityKind.ExitBlock ||
                     kind == TileEntityKind.DashBlock
                ? (int)(position.Y / 8f)
                : (int)position.Y / 8) - Chapter.Bounds.Top;
            return foreground.GenerateOverlay(tile, x, y, columns, rows, Chapter.Solids).TileGrid;
        }
    }
}
