using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Tiles;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Game.Entities.Walls.Concealment
{
    public class OriginalCoverupWallState : SceneEntityState
    {
        private char fillTile;
        private TileGrid tiles;
        private EffectCutoutState cutout;
        private readonly ISourceEngineContext engine;

        public OriginalCoverupWallState(ISourceEngineContext engine, Vector2 position, char tile, float width,
            float height)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            fillTile = tile;
            Depth = -13000;
            Collider = new HitboxColliderGeometry(width, height);
            OwnedComponents.Add(cutout = new EffectCutoutState());
        }

        public OriginalCoverupWallState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : this(engine, SourceVector2Math.Add(data.Position, offset),
                EntityAttributeReader.Char(data.Values, "tiletype", '3'), data.Width, data.Height)
        {
        }

        protected TileGrid SourceTiles
        {
            get => tiles;
            set => tiles = value;
        }

        protected void AddedEntity(object scene) => base.Added(scene);

        public override void Added(object scene)
        {
            base.Added(scene);
            int tilesX = (int)Width / 8;
            int tilesY = (int)Height / 8;
            OriginalLevelSceneRoot level = (OriginalLevelSceneRoot)Scene;
            IntRect tileBounds = ((OriginalChapterMapData)level.Session.MapData).TileBounds;
            var solidsData = level.SolidsData;
            int x = (int)X / 8 - tileBounds.Left;
            int y = (int)Y / 8 - tileBounds.Top;
            OwnedComponents.Add(tiles =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                .ForegroundAutotiler.GenerateOverlay(fillTile, x, y, tilesX, tilesY, solidsData).TileGrid);
            OwnedComponents.Add(new TileInterceptorState(tiles, false));
        }
    }
}
