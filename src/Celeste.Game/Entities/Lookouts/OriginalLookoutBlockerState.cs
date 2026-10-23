using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;

namespace Celeste.Game.Entities.Lookouts
{
    public class OriginalLookoutBlockerState : SceneEntityState
    {
        public OriginalLookoutBlockerState(EntityData data, Vector2 offset,
            Celeste.Core.Scheduling.ISourceEngineContext engine)
            : base(((Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset)
        {
            Collider = new HitboxColliderGeometry(data.Width, data.Height);
        }
    }
}
