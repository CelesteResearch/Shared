using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Game.Execution.Levels;
using Celeste.Physics.Collision;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Audio;

namespace Celeste.Game.Entities.Npcs
{
    public static class OriginalNpcFootstepPolicy
    {
        public static int? GetStepSoundIndex(OriginalLevelSceneRoot level,
            ISourceMutableEntityState actualNpc, List<object> temporaryCollisions)
        {
            var entities = level.Scheduler.Entities;
            var selected = SourceSurfacePlatformSelection.QueryAt(
                (ISourceEntityCollider)actualNpc, entities.GetTrackedEntities("Celeste.Platform"), temporaryCollisions,
                actualNpc.Position + Vector2.UnitY, entities.GetTrackedEntity<RoomPlayerSession>());
            return selected.HasValue ? selected.GetStepSoundIndex((ISourceEntityCollider)actualNpc) : null;
        }
    }
}
