using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.IntroCar
{
    public class OriginalIntroCarState : SourceJumpThruEntityState
    {
        private SpriteImage bodySprite;
        private SceneEntityState wheels;
        private float startY;
        private bool didHaveRider;
        protected readonly ISourceSolidWorldFactory worlds;

        public OriginalIntroCarState(ISourceEngineContext engine, ISourceSolidWorldFactory worlds, Vector2 position)
            : base(position, 25, true, worlds.CreateJumpThru(position, true))
        {
            this.worlds = worlds;
            startY = position.Y;
            Depth = 1;
            Components.Add(bodySprite =
                new SpriteImage(((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["scenery/car/body"]));
            bodySprite.Origin = new Vector2(bodySprite.Width / 2f, bodySprite.Height);
            HitboxColliderGeometry hitbox = new HitboxColliderGeometry(25f, 4f, -15f, -17f);
            HitboxColliderGeometry hitbox2 = new HitboxColliderGeometry(19f, 4f, 8f, -11f);
            Collider = new ColliderListGeometry(hitbox, hitbox2);
            SurfaceSoundIndex = 2;
        }

        public OriginalIntroCarState(ISourceEngineContext engine, ISourceSolidWorldFactory worlds,
            EntityData data, Vector2 offset)
            : this(engine, worlds, data.Position + offset)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            SpriteImage image =
                new SpriteImage(
                    ((ISourceGameGraphicsEnvironment)SourceWorld.EngineContext).GameGraphics.GameAtlas
                        ["scenery/car/wheels"]);
            image.Origin = new Vector2(image.Width / 2f, image.Height);
            wheels = new SceneEntityState(
                ((ISourceEntitySourceDataEnvironment)SourceWorld.EngineContext).EntitySourceDataRegistration, Position);
            wheels.Components.Add(image);
            wheels.Depth = 3;
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(wheels);
            OriginalLevelSceneRoot level = scene as OriginalLevelSceneRoot;
            if (level.Session.AreaID == 0)
            {
                OriginalIntroPavementState pavement = new OriginalIntroPavementState(SourceWorld.EngineContext, worlds,
                    new Vector2(level.Bounds.Left, Y), (int)(X - (float)level.Bounds.Left - 48f));
                pavement.Depth = -10001;
                level.SourceScene.QueueSourceEntity(pavement);
                level.SourceScene.QueueSourceEntity(new OriginalIntroCarBarrierState(SourceWorld.EngineContext,
                    Position + new Vector2(32f, 0f), -10, PackedColor.White));
                level.SourceScene.QueueSourceEntity(new OriginalIntroCarBarrierState(SourceWorld.EngineContext,
                    Position + new Vector2(41f, 0f), 5, PackedColor.DarkGray));
            }
        }

        public override void Update()
        {
            bool flag = HasRider();
            if (Y > startY && (!flag || Y > startY + 1f))
            {
                float moveV = -10f * SourceWorld.EngineContext.DeltaTime;
                MoveV(moveV);
            }

            if (Y <= startY && !didHaveRider && flag) MoveV(2f);
            if (didHaveRider && !flag)
                ((ISourceSpatialAudioEnvironment)SourceWorld.EngineContext).SpatialAudio.Play(
                    "event:/game/00_prologue/car_up", Position);
            didHaveRider = flag;
            base.Update();
        }

        public override int GetLandSoundIndex(ISourceEntityCollider entity)
        {
            ((ISourceSpatialAudioEnvironment)SourceWorld.EngineContext).SpatialAudio.Play(
                "event:/game/00_prologue/car_down", Position);
            return -1;
        }
    }
}
