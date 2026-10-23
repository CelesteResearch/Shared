using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Physics.Collision.Shapes;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Everest.Gameplay.Enemies.Badeline.Chasers
{
    public class EverestBadelineOldsiteEndState : SceneEntityState
    {
        public EverestBadelineOldsiteEndState(ISourceEngineContext engine, Vector2 position, int width, int height)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            Collider = new HitboxColliderGeometry(width, height);
        }

        public EverestBadelineOldsiteEndState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(engine, data.Position + offset, data.Width, data.Height)
        {
        }
    }
}
