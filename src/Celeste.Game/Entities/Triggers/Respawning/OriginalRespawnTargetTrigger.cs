using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;

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
