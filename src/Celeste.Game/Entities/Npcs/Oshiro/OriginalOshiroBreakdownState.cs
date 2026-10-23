using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Stories.CelestialResort.Cutscenes;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Oshiro
{
    public class OriginalOshiroBreakdownState : OriginalNpcState
    {
        private bool talked;

        public OriginalOshiroBreakdownState(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
        {
            OwnedComponents.Add(Sprite = new OshiroSpriteState(engine, 1));
            OwnedComponents.Add(Light =
                new(engine, -Vector2.UnitY * 16f, PackedColor.White, 1f, 32, 64));
            MoveAnim = "move";
            IdleAnim = "idle";
        }

        public OriginalOshiroBreakdownState(EntityData data, Vector2 offset, ISourceEngineContext engine) : this(
            engine, data.Position + offset)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (Session.GetFlag("oshiro_breakdown")) RemoveSelf();
        }

        public override void Update()
        {
            base.Update();
            var entity =
                Level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (!(!talked && entity != null &&
                  ((entity.X <= Level.Bounds.Left + 370 && entity.OnSafeGround && entity.Y < Level.Bounds.Center.Y) ||
                   entity.X <= Level.Bounds.Left + 320)))
                return;
            Level.Scheduler.QueueSourceEntity(new CS03OshiroBreakdownState(Engine, entity, this));
            talked = true;
        }
    }
}
