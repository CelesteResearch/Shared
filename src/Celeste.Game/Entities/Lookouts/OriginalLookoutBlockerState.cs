using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;

namespace Celeste.Game.Entities.Lookouts
{
    public class OriginalLookoutBlockerState : SceneEntityState
    {
        public OriginalLookoutBlockerState(EntityData data, Vector2 offset,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset)
        {
            Collider = new HitboxColliderGeometry(data.Width, data.Height);
        }
    }
}
