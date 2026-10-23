using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Collectibles.Hearts;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Animation;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Color = Celeste.Core.Display.PackedColor;

namespace Celeste.Game.Gameplay.Decoration.WhiteBlocks
{
    public class OriginalWhiteBlock : SourceJumpThruEntityState
    {
        private readonly IOriginalWhiteBlockProcess engine;

        private const float duckDuration = 3f;

        private float playerDuckTimer;

        private bool enabled = true;

        private bool activated;

        private readonly SpriteImage sprite;

        private SceneEntityState bgSolidTiles;

        public OriginalWhiteBlock(EntityData data, Vector2 offset, IOriginalWhiteBlockProcess engine,
            ISourceSolidWorldFactory worlds)
            : base(data.Position + offset, 48, true, worlds.CreateJumpThru(data.Position + offset, true))
        {
            this.engine = engine;
            OwnedComponents.Add(sprite = new(engine.GameGraphics.GameAtlas["objects/whiteblock"]));
            Depth = 8990;
            SurfaceSoundIndex = 27;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if ((scene as OriginalLevelSceneRoot).Session.HeartGem) Disable();
        }

        private void Disable()
        {
            enabled = false;
            sprite.Color = Color.White * 0.25f;
            Collidable = false;
        }

        private void Activate(RoomPlayerSession player)
        {
            engine.PlaySound("event:/game/04_cliffside/whiteblock_fallthru", Center);
            activated = true;
            Collidable = false;
            player.Depth = 10001;
            Depth = -9000;
            var level = Scene as OriginalLevelSceneRoot;
            var rectangle = new IntRect(level.Bounds.Left / 8, level.Bounds.Y / 8, level.Bounds.Width / 8,
                level.Bounds.Height / 8);
            var tileBounds = level.TileBounds;
            var array = new bool[rectangle.Width, rectangle.Height];
            for (var i = 0; i < rectangle.Width; i++)
            for (var j = 0; j < rectangle.Height; j++)
                array[i, j] =
                    level.BgData[i + rectangle.Left - tileBounds.Left, j + rectangle.Top - tileBounds.Top] !=
                    '0';

            bgSolidTiles = new SourceSolidEntityState(new(level.Bounds.Left, level.Bounds.Top), 1f, 1f, true,
                level.SolidWorldFactory.Create(new(level.Bounds.Left, level.Bounds.Top), true));
            bgSolidTiles.Collider = new GridColliderGeometry(8f, 8f, array);
            ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(bgSolidTiles);
        }

        public override void Update()
        {
            base.Update();
            if (!enabled) return;

            if (!activated)
            {
                var entity =
                    ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                    .GetTrackedEntity<RoomPlayerSession>(typeof(RoomPlayerSession).FullName);

                if (HasPlayerRider() && entity != null && entity.Data.Motion.Ducking)
                {
                    playerDuckTimer += engine.DeltaTime;
                    if (playerDuckTimer >= 3f) Activate(entity);
                }
                else
                {
                    playerDuckTimer = 0f;
                }

                if ((Scene as OriginalLevelSceneRoot).Session.HeartGem) Disable();
            }
            else if (((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntity<OriginalHeartGemState>(
                         "Celeste.HeartGem") == null)
            {
                var entity2 =
                    ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                    .GetTrackedEntity<RoomPlayerSession>(typeof(RoomPlayerSession).FullName);

                if (entity2 != null)
                {
                    Disable();
                    entity2.Depth = 0;
                    ((OriginalLevelSceneRoot)Scene).Scheduler.RemoveEntity(bgSolidTiles);
                }
            }
        }
    }
}
