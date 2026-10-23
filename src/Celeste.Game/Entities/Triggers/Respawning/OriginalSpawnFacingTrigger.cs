using System.Numerics;
using Celeste.Simulation.Gameplay.Actors.Facing;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Gameplay.Triggers.Respawn;

namespace Celeste.Game.Entities.Triggers.Respawning
{
    public class OriginalSpawnFacingTrigger : SceneEntityState, ISourceSpawnFacingEntity
    {
        public FacingDirection Facing;
        int ISourceSpawnFacingEntity.Facing => (int)Facing;

        public OriginalSpawnFacingTrigger(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            Collider = new HitboxColliderGeometry(data.Width, data.Height);
            Facing = EntityAttributeReader.Enum(data.Values, "facing", (FacingDirection)0);
            Visible = Active = false;
        }
    }
}
