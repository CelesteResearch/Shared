using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;
using Celeste.Core.Scheduling;
using Celeste.Core.Audio;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Game.Audio.Surfaces;
using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Debris;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Tiles;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Game.Entities.Mechanisms.RumbleWalls
{
    public class OriginalCrumbleWallOnRumbleState : SourceSolidEntityState
    {
        private bool permanent;
        private MapEntityId id;
        private char tileType;
        private bool blendIn;
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
            Vector2 position = SourceVector2Math.Add(data.Position, offset);
            char tileType = EntityAttributeReader.Char(data.Values, "tiletype", 'm');
            int width = data.Width;
            int height = data.Height;
            bool blendIn = EntityAttributeReader.Bool(data.Values, "blendin");
            bool persistent = EntityAttributeReader.Bool(data.Values, "persistent");
            return new OriginalCrumbleWallOnRumbleState(position, tileType, width, height, blendIn, persistent,
                id, level.SolidWorldFactory.Create(position, true));
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            TileGrid tileGrid;
            if (!blendIn)
                tileGrid = ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                    .ForegroundAutotiler.GenerateBox(tileType, (int)Width / 8, (int)Height / 8).TileGrid;
            else
            {
                var level = (OriginalLevelSceneRoot)Scene;
                IntRect tileBounds = ((OriginalChapterMapData)level.Session.MapData).TileBounds;
                var solidsData = level.SolidsData;
                int x = (int)(X / 8f) - tileBounds.Left;
                int y = (int)(Y / 8f) - tileBounds.Top;
                int tilesX = (int)Width / 8;
                int tilesY = (int)Height / 8;
                tileGrid = ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                    .ForegroundAutotiler.GenerateOverlay(tileType, x, y, tilesX, tilesY, solidsData).TileGrid;
                Depth = -10501;
            }

            OwnedComponents.Add(tileGrid);
            OwnedComponents.Add(new TileInterceptorState(tileGrid, true));
            OwnedComponents.Add(new LightOccludeState());
            if (SourceTrackedEntityCollision.Check(((ISourceScene)Scene).SourceScene.Entities,
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName, this))

                RemoveSelf();
        }

        public void Break()
        {
            if (!Collidable || Scene == null) return;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                "event:/new_content/game/10_farewell/quake_rockbreak", Position);
            Collidable = false;
            for (int i = 0; i < Width / 8f; i++)
            for (int j = 0; j < Height / 8f; j++)
            {
                var sourceScene = ((ISourceScene)Scene).SourceScene;
                if (!SourceSceneCollision.CheckRect(sourceScene.Entities, "Celeste.Solid",
                        new IntRect((int)X + i * 8, (int)Y + j * 8, 8, 8)))
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(engine.EntityPools.Create<DebrisState>()
                        .Init(SourceVector2Math.Add(Position, new Vector2(4 + i * 8, 4 + j * 8)), tileType)
                        .BlastFrom(TopCenter));
            }

            if (permanent) ((OriginalLevelSceneRoot)Scene).Session.DoNotLoad.Add(id);
            RemoveSelf();
        }
    }
}
