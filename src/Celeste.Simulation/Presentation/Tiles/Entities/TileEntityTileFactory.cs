using Celeste.Core.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Tiles.Entities
{
    public sealed class TileEntityTileFactory
    {
        public global::Celeste.Simulation.Content.Tiles.Chapters.ChapterTiles Chapter { get; }
        private readonly global::Celeste.Simulation.Runtime.Randomness.SpriteRandomContext random;
        private readonly global::Celeste.Graphics.Content.Tiles.Autotiling.ISourceAutotilingResources resources;

        private global::Celeste.Graphics.Content.Tiles.Autotiling.Autotiler foreground =>
            resources.ForegroundAutotiler;

        public TileEntityTileFactory(global::Celeste.Simulation.Content.Tiles.Chapters.ChapterTiles chapter,
            global::Celeste.Simulation.Runtime.Randomness.SpriteRandomContext random,
            global::Celeste.Graphics.Content.Tiles.Autotiling.ISourceAutotilingResources resources)
        {
            Chapter = chapter ?? throw new ArgumentNullException(nameof(chapter));
            this.random = random ?? throw new ArgumentNullException(nameof(random));
            this.resources = resources ?? throw new ArgumentNullException(nameof(resources));
        }

        internal global::Celeste.Graphics.Content.Tiles.TileGrid GenerateFloatyGroup(VirtualMap<char> map) =>
            foreground.GenerateMap(map,
                new global::Celeste.Graphics.Content.Tiles.Autotiling.AutotileBehavior
                    { EdgesExtend = false, EdgesIgnoreOutOfLevel = false, PaddingIgnoreOutOfLevel = false }).TileGrid;

        internal global::Celeste.Graphics.Content.Tiles.TileGrid GenerateRequest(
            global::Celeste.Simulation.Gameplay.Walls.Breakable.DashBlockTileRequest r) => r.Overlay
            ? foreground.GenerateOverlay(r.TileType, r.X, r.Y, r.Columns, r.Rows, Chapter.Solids).TileGrid
            : foreground.GenerateBox(r.TileType, r.Columns, r.Rows).TileGrid;

        internal global::Celeste.Graphics.Content.Tiles.TileGrid Generate(
            global::Celeste.Simulation.Presentation.Tiles.Entities.TileEntityKind kind, Vector2 position, float width,
            float height, char tile,
            bool finalBoss, out global::Celeste.Graphics.Content.Tiles.TileGrid highlight, out int? seed,
            bool blendIn = false)
        {
            int columns = (int)width / 8, rows = (int)height / 8;
            highlight = null;
            seed = null;
            if (kind == global::Celeste.Simulation.Presentation.Tiles.Entities.TileEntityKind.FallingBlock)
            {
                int generatedSeed = random.Current.Next();
                seed = generatedSeed;
                var tileScope = random.Push(new Random(generatedSeed));
                var tiles = foreground.GenerateBox(tile, columns, rows).TileGrid;
                tileScope.Dispose();
                if (finalBoss)
                {
                    var highlightScope = random.Push(new Random(generatedSeed));
                    highlight = foreground.GenerateBox('G', columns, rows).TileGrid;
                    highlightScope.Dispose();
                }

                return tiles;
            }

            if (kind == global::Celeste.Simulation.Presentation.Tiles.Entities.TileEntityKind.FakeBlock ||
                kind == global::Celeste.Simulation.Presentation.Tiles.Entities.TileEntityKind.DashBlock && !blendIn)
                return foreground.GenerateBox(tile, columns, rows).TileGrid;
            int x = (kind == global::Celeste.Simulation.Presentation.Tiles.Entities.TileEntityKind.ExitBlock ||
                     kind == global::Celeste.Simulation.Presentation.Tiles.Entities.TileEntityKind.DashBlock
                ? (int)(position.X / 8f)
                : (int)position.X / 8) - Chapter.Bounds.Left;
            int y = (kind == global::Celeste.Simulation.Presentation.Tiles.Entities.TileEntityKind.ExitBlock ||
                     kind == global::Celeste.Simulation.Presentation.Tiles.Entities.TileEntityKind.DashBlock
                ? (int)(position.Y / 8f)
                : (int)position.Y / 8) - Chapter.Bounds.Top;
            return foreground.GenerateOverlay(tile, x, y, columns, rows, Chapter.Solids).TileGrid;
        }
    }
}
