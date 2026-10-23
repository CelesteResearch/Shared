using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Stories.CelestialResort.Cutscenes;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Oshiro
{
    public class OriginalOshiroHallway1State : OriginalNpcState
    {
        private bool talked;

        public OriginalOshiroHallway1State(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
        {
            OwnedComponents.Add(Sprite = new OshiroSpriteState(engine, -1));
            OwnedComponents.Add(Light =
                new(engine, -Vector2.UnitY * 16f, PackedColor.White, 1f, 32, 64));
            MoveAnim = "move";
            IdleAnim = "idle";
        }

        public OriginalOshiroHallway1State(EntityData data, Vector2 offset, ISourceEngineContext engine) : this(
            engine, data.Position + offset)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (Session.GetFlag("oshiro_resort_talked_2")) RemoveSelf();
        }

        public override void Update()
        {
            base.Update();
            var entity =
                Level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (!(!talked && entity != null && entity.X > X - 60f))
                return;
            Level.Scheduler.QueueSourceEntity(new CS03OshiroHallway1State(Engine, entity, this));
            talked = true;
        }
    }
}
