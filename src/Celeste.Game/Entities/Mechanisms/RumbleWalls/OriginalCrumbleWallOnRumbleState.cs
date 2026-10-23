using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Audio.Surfaces;
using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Tiles;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Actors.Debris;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Tiles;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Entities.Mechanisms.RumbleWalls
{
    public class OriginalCrumbleWallOnRumbleState : SourceSolidEntityState
    {
        private readonly bool permanent;
        private readonly MapEntityId id;
        private readonly char tileType;
        private readonly bool blendIn;
        private readonly ISourceEngineContext engine;

        public OriginalCrumbleWallOnRumbleState(Vector2 position, char tileType, float width, float height,
            bool blendIn, bool persistent, MapEntityId id, ISourceSolidWorld world)
            : base(position, width, height, true, world)
        {
            engine = world.EngineContext;
            Depth = -12999;
            this.id = id;
            this.tileType = tileType;
            this.blendIn = blendIn;
            permanent = persistent;
            SurfaceSoundIndex = ((IOriginalTileSurfaceEnvironment)engine).SurfaceIndices.TileToIndex[this.tileType];
        }

        public static OriginalCrumbleWallOnRumbleState CreateFromMapData(EntityData data,
            Vector2 offset, MapEntityId id, OriginalLevelSceneRoot level)
        {
            var position = SourceVector2Math.Add(data.Position, offset);
            var tileType = EntityAttributeReader.Char(data.Values, "tiletype", 'm');
            var width = data.Width;
            var height = data.Height;
            var blendIn = EntityAttributeReader.Bool(data.Values, "blendin");
            var persistent = EntityAttributeReader.Bool(data.Values, "persistent");
            return new(position, tileType, width, height, blendIn, persistent,
                id, level.SolidWorldFactory.Create(position, true));
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            TileGrid tileGrid;
            if (!blendIn)
            {
                tileGrid = ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                    .ForegroundAutotiler.GenerateBox(tileType, (int)Width / 8, (int)Height / 8).TileGrid;
            }
            else
            {
                var level = (OriginalLevelSceneRoot)Scene;
                var tileBounds = ((OriginalChapterMapData)level.Session.MapData).TileBounds;
                var solidsData = level.SolidsData;
                var x = (int)(X / 8f) - tileBounds.Left;
                var y = (int)(Y / 8f) - tileBounds.Top;
                var tilesX = (int)Width / 8;
                var tilesY = (int)Height / 8;
                tileGrid = ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                    .ForegroundAutotiler.GenerateOverlay(tileType, x, y, tilesX, tilesY, solidsData).TileGrid;
                Depth = -10501;
            }

            OwnedComponents.Add(tileGrid);
            OwnedComponents.Add(new TileInterceptorState(tileGrid, true));
            OwnedComponents.Add(new LightOccludeState());
            if (SourceTrackedEntityCollision.Check(((ISourceScene)Scene).SourceScene.Entities,
                    typeof(RoomPlayerSession).FullName, this))

                RemoveSelf();
        }

        public void Break()
        {
            if (!Collidable || Scene == null) return;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                "event:/new_content/game/10_farewell/quake_rockbreak", Position);
            Collidable = false;
            for (var i = 0; i < Width / 8f; i++)
            for (var j = 0; j < Height / 8f; j++)
            {
                var sourceScene = ((ISourceScene)Scene).SourceScene;
                if (!SourceSceneCollision.CheckRect(sourceScene.Entities, "Celeste.Solid",
                        new((int)X + i * 8, (int)Y + j * 8, 8, 8)))
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(engine.EntityPools.Create<DebrisState>()
                        .Init(SourceVector2Math.Add(Position, new(4 + i * 8, 4 + j * 8)), tileType)
                        .BlastFrom(TopCenter));
            }

            if (permanent) ((OriginalLevelSceneRoot)Scene).Session.DoNotLoad.Add(id);
            RemoveSelf();
        }
    }
}
