using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Presentation.Doors;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Entities.Npcs.Oshiro
{
    public class OriginalDoorState : SourceActorEntityState, IDoorPresentationSource
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private readonly Sprite sprite;
        Sprite IDoorPresentationSource.Sprite => sprite;

        private readonly string openSfx;

        private readonly string closeSfx;

        private readonly LightOccludeState occlude;

        private bool disabled;

        public OriginalDoorState(EntityData data, Vector2 offset, OriginalLevelSceneRoot level)
            : base(new(level.PlatformWorld, data.Position + offset), level.EngineContext,
                ((ISourcePlatformTargetMotionEnvironment)level.EngineContext).TargetMotionPolicy)
        {
            engine = level.EngineContext;
            Depth = 8998;
            var text = EntityAttributeReader.Attr(data.Values, "type", "wood");
            if (text == "wood")
            {
                OwnedComponents.Add(sprite =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("door"));
                openSfx = "event:/game/03_resort/door_wood_open";
                closeSfx = "event:/game/03_resort/door_wood_close";
            }
            else
            {
                OwnedComponents.Add(sprite =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create(text + "door"));
                openSfx = "event:/game/03_resort/door_metal_open";
                closeSfx = "event:/game/03_resort/door_metal_close";
            }

            sprite.Play("idle");
            Collider = new HitboxColliderGeometry(12f, 22f, -6f, -23f);
            OwnedComponents.Add(occlude = new(new IntRect(-1, -24, 2, 24)));
            OwnedComponents.Add(new PlayerColliderComponentState(HitPlayer));
        }

        public override bool IsRiding(ISourceEntityCollider solid)
        {
            return ((ISourceMutableEntityState)solid).Collidable && solid.Collider != null &&
                   solid.Collider.Collide(new IntRect((int)X - 2, (int)Y - 2, 4, 4));
        }

        protected override void OnSquish(PixelCollision data)
        {
        }

        private void HitPlayer(RoomPlayerSession player)
        {
            if (!disabled) Open(player.X);
        }

        public void Open(float x)
        {
            DoorPresentation.Open(Process, this, x, openSfx);
        }

        public override void Update()
        {
            var currentAnimationId = sprite.CurrentAnimationID;
            base.Update();
            occlude.Visible = sprite.CurrentAnimationID == "idle";
            if (!disabled && CollideCheck("Celeste.Solid")) disabled = true;

            DoorPresentation.PlayCloseIfCompleted(Process, this,
                currentAnimationId, closeSfx);
        }
    }
}
