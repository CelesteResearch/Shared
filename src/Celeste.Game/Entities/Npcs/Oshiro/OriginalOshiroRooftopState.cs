using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Stories.CelestialResort.Cutscenes;

namespace Celeste.Game.Entities.Npcs.Oshiro
{
    public class OriginalOshiroRooftopState : OriginalNpcState
    {
        public OriginalOshiroRooftopState(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
        {
            OwnedComponents.Add(Sprite = new OshiroSpriteState(engine, 1));
            (Sprite as OshiroSpriteState).AllowTurnInvisible = false;
            MoveAnim = "move";
            IdleAnim = "idle";
            OwnedComponents.Add(Light =
                new(engine, -Vector2.UnitY * 16f, PackedColor.White, 1f, 32, 64));
        }

        public OriginalOshiroRooftopState(EntityData data, Vector2 offset, ISourceEngineContext engine) : this(
            engine, data.Position + offset)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (Session.GetFlag("oshiro_resort_roof"))
            {
                RemoveSelf();
                return;
            }

            Visible = false;
            Level.Scheduler.QueueSourceEntity(new CS03OshiroRooftopState(Engine, this));
        }
    }
}
