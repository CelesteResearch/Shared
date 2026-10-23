using System.Numerics;
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

namespace Celeste.Game.Entities.Triggers.Respawning
{
    public class OriginalRespawnTargetTrigger : SceneEntityState
    {
        public Vector2 Target;

        public OriginalRespawnTargetTrigger(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            Collider = new HitboxColliderGeometry(data.Width, data.Height);
            Target = data.Nodes[0] + offset;
            Visible = Active = false;
        }
    }
}
