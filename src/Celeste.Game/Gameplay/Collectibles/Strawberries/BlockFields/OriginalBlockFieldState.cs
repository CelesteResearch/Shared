using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Collectibles.Strawberries.BlockFields
{
    public class OriginalBlockFieldState : SceneEntityState
    {
        public OriginalBlockFieldState(ISourceEngineContext engine, Vector2 position, int width, int height)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            Collider = new HitboxColliderGeometry(width, height);
        }

        public OriginalBlockFieldState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : this(engine, data.Position + offset, data.Width, data.Height)
        {
        }
    }
}
