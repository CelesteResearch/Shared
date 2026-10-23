using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Scene.Entities;
using Celeste.Physics.Collision.Shapes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Animation;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Entities.Collectibles.Hearts;
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

        private SpriteImage sprite;

        private SceneEntityState bgSolidTiles;

        public OriginalWhiteBlock(EntityData data, Vector2 offset, IOriginalWhiteBlockProcess engine,
            ISourceSolidWorldFactory worlds)
            : base(data.Position + offset, 48, true, worlds.CreateJumpThru(data.Position + offset, true))
        {
            this.engine = engine;
            OwnedComponents.Add(sprite = new SpriteImage(engine.GameGraphics.GameAtlas["objects/whiteblock"]));
            base.Depth = 8990;
            SurfaceSoundIndex = 27;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if ((scene as OriginalLevelSceneRoot).Session.HeartGem)
            {
                Disable();
            }
        }

        private void Disable()
        {
            enabled = false;
            sprite.Color = Color.White * 0.25f;
            Collidable = false;
        }

        private void Activate(RoomPlayerSession player)
        {
            engine.PlaySound("event:/game/04_cliffside/whiteblock_fallthru", base.Center);
            activated = true;
            Collidable = false;
            player.Depth = 10001;
            base.Depth = -9000;
            OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
            IntRect rectangle = new IntRect(level.Bounds.Left / 8, level.Bounds.Y / 8, level.Bounds.Width / 8,
                level.Bounds.Height / 8);
            IntRect tileBounds = level.TileBounds;
            bool[,] array = new bool[rectangle.Width, rectangle.Height];
            for (int i = 0; i < rectangle.Width; i++)
            {
                for (int j = 0; j < rectangle.Height; j++)
                {
                    array[i, j] =
                        level.BgData[i + rectangle.Left - tileBounds.Left, j + rectangle.Top - tileBounds.Top] !=
                        '0';
                }
            }

            bgSolidTiles = new SourceSolidEntityState(new Vector2(level.Bounds.Left, level.Bounds.Top), 1f, 1f, true,
                level.SolidWorldFactory.Create(new Vector2(level.Bounds.Left, level.Bounds.Top), true));
            bgSolidTiles.Collider = new GridColliderGeometry(8f, 8f, array);
            ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(bgSolidTiles);
        }

        public override void Update()
        {
            base.Update();
            if (!enabled)
            {
                return;
            }

            if (!activated)
            {
                RoomPlayerSession entity =
                    ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                    .GetTrackedEntity<RoomPlayerSession>(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (HasPlayerRider() && entity != null && entity.Data.Motion.Ducking)
                {
                    playerDuckTimer += engine.DeltaTime;
                    if (playerDuckTimer >= 3f)
                    {
                        Activate(entity);
                    }
                }
                else
                {
                    playerDuckTimer = 0f;
                }

                if ((base.Scene as OriginalLevelSceneRoot).Session.HeartGem)
                {
                    Disable();
                }
            }
            else if (((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntity<OriginalHeartGemState>(
                         "Celeste.HeartGem") == null)
            {
                RoomPlayerSession entity2 =
                    ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                    .GetTrackedEntity<RoomPlayerSession>(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

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
