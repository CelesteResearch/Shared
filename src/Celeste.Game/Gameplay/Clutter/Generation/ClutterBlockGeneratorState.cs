using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Clutter.Blocks;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Simulation.Gameplay.Clutter;

namespace Celeste.Game.Gameplay.Clutter.Generation
{
    public sealed class ClutterBlockGeneratorState
    {
        private readonly ISourceEngineContext engine;
        private readonly ClutterGeneratorInitializationProfile initializationProfile;

        public ClutterBlockGeneratorState(ISourceEngineContext engine,
            ClutterGeneratorInitializationProfile initializationProfile)
        {
            this.engine = engine;
            this.initializationProfile = initializationProfile;
        }

        public void Init(OriginalLevelSceneRoot lvl)
        {
            switch (initializationProfile)
            {
                case ClutterGeneratorInitializationProfile.Original:
                    InitCore(lvl);
                    return;
                case ClutterGeneratorInitializationProfile.Installed:
                    if (!initialized)
                    {
                        if (tiles == null) tiles = new Tile[200, 200];
                        var width = lvl.Bounds.Width / 8;
                        var height = lvl.Bounds.Height / 8 + 1;
                        if (tiles.GetLength(0) < width || tiles.GetLength(1) < height)
                        {
                            var columns = Math.Max(tiles.GetLength(0), width);
                            var rows = Math.Max(tiles.GetLength(1), height);
                            tiles = new Tile[columns, rows];
                        }

                        InitCore(lvl);
                    }

                    return;
                default:
                    throw new InvalidOperationException("The Clutter generator source profile is not selected.");
            }
        }

        private static void Shuffle<T>(List<T> list, ISourceRandom random)
        {
            var count = list.Count;
            while (--count > 0)
            {
                var value = list[count];
                int index;
                list[count] = list[index = random.Next(count + 1)];
                list[index] = value;
            }
        }

        private struct Tile
        {
            public int Color;

            public bool Wall;

            public OriginalClutterBlockState Block;

            public bool Empty
            {
                get
                {
                    if (!Wall) return Color == -1;

                    return false;
                }
            }
        }

        private class TextureSet
        {
            public int Columns;

            public int Rows;

            public readonly List<AtlasEntry> textures = [];
        }

        private OriginalLevelSceneRoot level;

        private Tile[,] tiles;

        private readonly List<IntPoint> active = [];

        private List<List<TextureSet>> textures;

        private int columns;

        private int rows;

        private readonly bool[] enabled = new bool[3];

        private bool initialized;

        private void InitCore(OriginalLevelSceneRoot lvl)
        {
            if (initialized) return;

            initialized = true;
            level = lvl;
            columns = level.Bounds.Width / 8;
            rows = level.Bounds.Height / 8 + 1;
            if (tiles == null) tiles = new Tile[200, 200];

            for (var i = 0; i < columns; i++)
            for (var j = 0; j < rows; j++)
            {
                tiles[i, j].Color = -1;
                tiles[i, j].Block = null;
            }

            for (var k = 0; k < enabled.Length; k++) enabled[k] = !level.Session.GetFlag("oshiro_clutter_cleared_" + k);

            if (textures == null)
            {
                textures = [];
                for (var l = 0; l < 3; l++)
                {
                    var list = new List<TextureSet>();
                    var game = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;
                    var colors = (ClutterColor)l;
                    foreach (var atlasSubtexture in game.Frames("objects/resortclutter/" + colors +
                                                                "_"))
                    {
                        var num = atlasSubtexture.FrameWidth / 8;
                        var num2 = atlasSubtexture.FrameHeight / 8;
                        TextureSet textureSet = null;
                        foreach (var item in list)
                            if (item.Columns == num && item.Rows == num2)
                            {
                                textureSet = item;
                                break;
                            }

                        if (textureSet == null)
                        {
                            var obj = new TextureSet
                            {
                                Columns = num,
                                Rows = num2,
                            };
                            textureSet = obj;
                            list.Add(obj);
                        }

                        textureSet.textures.Add(atlasSubtexture);
                    }

                    list.Sort((a, b) => -Math.Sign(a.Columns * a.Rows - b.Columns * b.Rows));
                    textures.Add(list);
                }
            }

            var levelSolidOffset = level.LevelSolidOffset;
            for (var num3 = 0; num3 < columns; num3++)
            for (var num4 = 0; num4 < rows; num4++)
                tiles[num3, num4].Wall =
                    level.SolidsData[levelSolidOffset.X + num3, levelSolidOffset.Y + num4] != '0';
        }

        public void Dispose()
        {
            textures = null;
            tiles = null;
            initialized = false;
        }

        public void Add(int x, int y, int w, int h, ClutterColor color)
        {
            var position = new Vector2(level.Bounds.X, level.Bounds.Y) + new Vector2(x, y) * 8f;
            level.Scheduler.QueueSourceEntity(new OriginalClutterBlockBaseState(position, w * 8, h * 8,
                enabled[(int)color],
                color, level.SolidWorldFactory.Create(position, true)));
            if (!enabled[(int)color]) return;

            var i = Math.Max(0, x);
            for (var num = Math.Min(columns, x + w); i < num; i++)
            {
                var j = Math.Max(0, y);
                for (var num2 = Math.Min(rows, y + h); j < num2; j++)
                {
                    var item = new IntPoint(i, j);
                    tiles[item.X, item.Y].Color = (int)color;
                    active.Add(item);
                }
            }
        }

        public void Generate()
        {
            if (!initialized) return;

            Shuffle(active, ((ISourceRandomEnvironment)engine).Random);
            var list = new List<OriginalClutterBlockState>();
            var bounds = level.Bounds;
            foreach (var item in active)
            {
                if (tiles[item.X, item.Y].Block != null) continue;

                var num = 0;
                int color;
                TextureSet textureSet;
                while (true)
                {
                    color = tiles[item.X, item.Y].Color;
                    textureSet = textures[color][num];
                    var flag = true;
                    if (item.X + textureSet.Columns <= columns && item.Y + textureSet.Rows <= rows)
                    {
                        var num2 = item.X;
                        var num3 = item.X + textureSet.Columns;
                        while (flag && num2 < num3)
                        {
                            var num4 = item.Y;
                            var num5 = item.Y + textureSet.Rows;
                            while (flag && num4 < num5)
                            {
                                var tile = tiles[num2, num4];
                                if (tile.Block != null || tile.Color != color) flag = false;

                                num4++;
                            }

                            num2++;
                        }

                        if (flag) break;
                    }

                    num++;
                }

                var clutterBlock = new OriginalClutterBlockState(
                    new Vector2(bounds.X, bounds.Y) + new Vector2(item.X, item.Y) * 8f,
                    textureSet.textures[((ISourceRandomEnvironment)engine).Random.Next(textureSet.textures.Count)],
                    (ClutterColor)color, engine);
                for (var i = item.X; i < item.X + textureSet.Columns; i++)
                for (var j = item.Y; j < item.Y + textureSet.Rows; j++)
                    tiles[i, j].Block = clutterBlock;

                list.Add(clutterBlock);
                level.Scheduler.QueueSourceEntity(clutterBlock);
            }

            for (var k = 0; k < columns; k++)
            for (var l = 0; l < rows; l++)
            {
                var tile2 = tiles[k, l];
                if (tile2.Block == null) continue;

                var block = tile2.Block;
                if (!block.TopSideOpen && (l == 0 || tiles[k, l - 1].Empty)) block.TopSideOpen = true;

                if (!block.LeftSideOpen && (k == 0 || tiles[k - 1, l].Empty)) block.LeftSideOpen = true;

                if (!block.RightSideOpen && (k == columns - 1 || tiles[k + 1, l].Empty)) block.RightSideOpen = true;

                if (!block.OnTheGround && l < rows - 1)
                {
                    var tile3 = tiles[k, l + 1];
                    if (tile3.Wall)
                    {
                        block.OnTheGround = true;
                    }
                    else if (tile3.Block != null && tile3.Block != block && !block.HasBelow.Contains(tile3.Block))
                    {
                        block.HasBelow.Add(tile3.Block);
                        block.Below.Add(tile3.Block);
                        tile3.Block.Above.Add(block);
                    }
                }
            }

            foreach (var item2 in list)
                if (item2.OnTheGround)
                    SetAboveToOnGround(item2);

            initialized = false;
            level = null;
            active.Clear();
        }

        private void SetAboveToOnGround(OriginalClutterBlockState block)
        {
            foreach (var item in block.Above)
                if (!item.OnTheGround)
                {
                    item.OnTheGround = true;
                    SetAboveToOnGround(item);
                }
        }
    }
}
