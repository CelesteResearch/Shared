using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public void BeforeDownTransition()
        {
            if (Machine.State != 5 && Machine.State != 18 && Machine.State != 19)
            {
                Machine.State = 0;
                Data.Motion.Normal.Speed.Y = ((ISourceExtremaEnvironment)EngineContext)
                    .ExtremaArithmetic.Max(0f, Data.Motion.Normal.Speed.Y);
                Data.Motion.AutoJump = false;
                Data.Motion.Normal.VariableJumpTimer = 0f;
            }

            foreach (var entry in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.Platform"))
            {
                var entity = (ISourceEntityCollider)entry;
                if (entity is ISourceSolidTilesEntity) continue;
                var at = Position + Vector2.UnitY * Height;
                if (!SourceEntityCollision.Check(this, entity)
                    && SourceEntityCollision.CheckAt(this, entity, at))
                    ((ISourceMutableEntityState)entity).Collidable = false;
            }
        }
    }
}
