using Celeste.Core.Components;
using Celeste.Core.Maps;
using Celeste.Core.Rendering.Observation;
using Celeste.Scene.Tracking;
using Celeste.Scene.Entities;

namespace Celeste.Scene.Diagnostics.Presentation
{
    internal static class SceneRenderObservationMetadata
    {
        public static SourceRenderEntityPresentation Read(object entity)
        {
            var depth = (entity as ISceneEntityDepth)?.DepthState;
            MapEntityId id = (entity as ISourceEntitySourceData)?.SourceId ?? default;
            return new SourceRenderEntityPresentation(depth != null, depth?.ActualDepth ?? 0,
                id.Level != null, id, id.Level ?? ReadRoom(entity as SceneEntityState));
        }

        private static string ReadRoom(SceneEntityState entity)
        {
            if (entity == null) return null;
            if (entity.PresentationRoom != null) return entity.PresentationRoom;
            var current = entity.PresentationOwner;
            if (current == null) return null;
            var fast = current;
            while (current != null)
            {
                string room = current.SourceId.Level ?? current.PresentationRoom;
                if (room != null) return room;
                current = current.PresentationOwner;
                fast = fast?.PresentationOwner?.PresentationOwner;
                if (current != null && ReferenceEquals(current, fast))
                {
                    var cycle = current;
                    do
                    {
                        room = current.SourceId.Level ?? current.PresentationRoom;
                        if (room != null) return room;
                        current = current.PresentationOwner;
                    } while (!ReferenceEquals(current, cycle));

                    return null;
                }
            }

            return null;
        }
    }
}
