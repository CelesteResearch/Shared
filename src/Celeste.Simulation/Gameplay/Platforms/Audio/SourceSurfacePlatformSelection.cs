using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Platforms.Audio
{
    public static class SourceSurfacePlatformSelection
    {
        public static SourceSurfaceSoundSelection QueryAt(ISourceEntityCollider mover, List<object> tracked,
            List<object> temporaryCollisions, Vector2 at, RoomPlayerSession scenePlayer)
        {
            temporaryCollisions.Clear();
            var mutable = (ISourceMutableEntityPosition)mover;
            Vector2 previous = mutable.Position;
            mutable.Position = at;
            foreach (var entity in tracked)
                if (SourceEntityCollision.Check(mover, (ISourceEntityCollider)entity))
                    temporaryCollisions.Add(entity);
            mutable.Position = previous;
            return Select(temporaryCollisions, scenePlayer);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public static SourceSurfaceSoundSelection Select(List<object> platforms, RoomPlayerSession scenePlayer)
        {
            // A nonempty vanilla candidate list always owns selection. Equal priorities retain its first entry.
            if (platforms.Count != 0)
            {
                SourcePlatformEntityState selected = null;
                foreach (var entity in platforms)
                {
                    var candidate = (SourcePlatformEntityState)entity;
                    if (selected == null || candidate.SurfaceSoundPriority > selected.SurfaceSoundPriority)
                        selected = candidate;
                }

                return new SourceSurfaceSoundSelection(selected);
            }

            return default;
        }
    }
}
