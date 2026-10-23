using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Tiles;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Tiles;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Entities.Walls.Concealment
{
    public class OriginalCoverupWallState : SceneEntityState
    {
        private readonly char fillTile;
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
            OwnedComponents.Add(cutout = new());
        }

        public OriginalCoverupWallState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : this(engine, SourceVector2Math.Add(data.Position, offset),
                EntityAttributeReader.Char(data.Values, "tiletype", '3'), data.Width, data.Height)
        {
        }

        protected TileGrid SourceTiles { get; set; }

        protected void AddedEntity(object scene)
        {
            base.Added(scene);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            var tilesX = (int)Width / 8;
            var tilesY = (int)Height / 8;
            var level = (OriginalLevelSceneRoot)Scene;
            var tileBounds = ((OriginalChapterMapData)level.Session.MapData).TileBounds;
            var solidsData = level.SolidsData;
            var x = (int)X / 8 - tileBounds.Left;
            var y = (int)Y / 8 - tileBounds.Top;
            OwnedComponents.Add(SourceTiles =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                .ForegroundAutotiler.GenerateOverlay(fillTile, x, y, tilesX, tilesY, solidsData).TileGrid);
            OwnedComponents.Add(new TileInterceptorState(SourceTiles, false));
        }
    }
}
