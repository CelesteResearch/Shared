using System;
using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Core.Components;
using Celeste.Game.Execution.Audio.Surfaces;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Tiles;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Execution.LevelLoader.Terrain
{
    public class OriginalSolidTiles : SourceSolidEntityState, ISourceSolidTilesEntity
    {
        public TileGrid Tiles;
        public AnimatedTiles AnimatedTiles;
        public GridColliderGeometry Grid;
        GridColliderGeometry ISourceSolidTilesEntity.Grid => Grid;
        private readonly VirtualMap<char> tileTypes;

        public OriginalSolidTiles(Vector2 position, VirtualMap<char> data,
            ISourceSolidWorld world)
            : base(position, 0f, 0f, true, world)
        {
            Tags = ((IOriginalGameTagsEnvironment)world.EngineContext).Tags.Global
                .Value;
            Depth = -10000;
            tileTypes = data;
            EnableAssistModeChecks = false;
            AllowStaticMovers = false;
            Collider = Grid = new(data.Columns, data.Rows, 8f, 8f);
            for (var i = 0; i < data.Columns; i += 50)
            for (var j = 0; j < data.Rows; j += 50)
            {
                if (!data.AnyInSegmentAtTile(i, j)) continue;
                var k = i;
                for (var num = Math.Min(k + 50, data.Columns); k < num; k++)
                {
                    var l = j;
                    for (var num2 = Math.Min(l + 50, data.Rows); l < num2; l++)
                        if (data[k, l] != '0')
                            Grid[k, l] = true;
                }
            }

            var generated =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)world
                    .EngineContext).GameGraphics).ForegroundAutotiler
                .GenerateMap(data, true);
            Tiles = generated.TileGrid;
            Tiles.VisualExtend = 1;
            Components.Add(Tiles);
            Components.Add(AnimatedTiles = generated.SpriteOverlay);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            Tiles.ClipCamera = (Scene as OriginalLevelSceneRoot).Camera;
            AnimatedTiles.ClipCamera = Tiles.ClipCamera;
        }

        private int CoreTileSurfaceIndex()
        {
            var level = Scene as OriginalLevelSceneRoot;
            if (level.CoreMode == RoomCoreMode.Hot) return 37;

            return level.CoreMode == RoomCoreMode.Cold ? 36 : 3;
        }

        private int SurfaceSoundIndexAt(Vector2 readPosition)
        {
            var num = (int)((readPosition.X - X) / 8f);
            var num2 = (int)((readPosition.Y - Y) / 8f);
            if (num >= 0 && num2 >= 0 && num < Grid.CellsX && num2 < Grid.CellsY)
            {
                var c = tileTypes[num, num2];
                switch (c)
                {
                    case 'k':
                        return CoreTileSurfaceIndex();
                    default:
                        if (((IOriginalSurfaceIndexEnvironment)SourceWorld.EngineContext).SurfaceIndex.TileToIndex
                            .ContainsKey(c))
                            return ((IOriginalSurfaceIndexEnvironment)SourceWorld.EngineContext).SurfaceIndex
                                .TileToIndex[c];

                        break;
                    case '0':
                        break;
                }
            }

            return -1;
        }

        public override int GetWallSoundIndex(ISourceEntityCollider player, int side)
        {
            var num = SurfaceSoundIndexAt(((ISourceEntitySurfaceAnchors)player).Center + Vector2.UnitX * side * 8f);
            if (num < 0)
                num = SurfaceSoundIndexAt(((ISourceEntitySurfaceAnchors)player).Center + new Vector2(side * 8, -6f));

            if (num < 0)
                num = SurfaceSoundIndexAt(((ISourceEntitySurfaceAnchors)player).Center + new Vector2(side * 8, 6f));

            return num;
        }

        public override int GetStepSoundIndex(ISourceEntityCollider entity)
        {
            var num = SurfaceSoundIndexAt(((ISourceEntitySurfaceAnchors)entity).BottomCenter + Vector2.UnitY * 4f);
            if (num == -1)
                num = SurfaceSoundIndexAt(((ISourceEntitySurfaceAnchors)entity).BottomLeft + Vector2.UnitY * 4f);

            if (num == -1)
                num = SurfaceSoundIndexAt(((ISourceEntitySurfaceAnchors)entity).BottomRight + Vector2.UnitY * 4f);

            return num;
        }

        public override int GetLandSoundIndex(ISourceEntityCollider entity)
        {
            var num = SurfaceSoundIndexAt(((ISourceEntitySurfaceAnchors)entity).BottomCenter + Vector2.UnitY * 4f);
            if (num == -1)
                num = SurfaceSoundIndexAt(((ISourceEntitySurfaceAnchors)entity).BottomLeft + Vector2.UnitY * 4f);

            if (num == -1)
                num = SurfaceSoundIndexAt(((ISourceEntitySurfaceAnchors)entity).BottomRight + Vector2.UnitY * 4f);

            return num;
        }
    }
}
