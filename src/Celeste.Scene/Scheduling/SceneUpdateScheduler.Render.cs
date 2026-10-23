using Celeste.Scene.Tracking;

namespace Celeste.Scene.Scheduling
{
    public sealed partial class SceneUpdateScheduler
    {
        // Original EntityList render passes enumerate the committed live list without sorting or snapshots.
        public bool HasVisibleEntities(SceneTagSet matchTags)
        {
            foreach (var entity in Entities.CommittedRenderEntities)
                if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible
                    && ((((ISceneEntityTags)entity).Tags & matchTags).Bits != 0))
                    return true;
            return false;
        }

        public void RenderEntities(global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            var observer = (context as global::Celeste.Core.Rendering.Observation.ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in Entities.CommittedRenderEntities)
                    if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible)
                        global::Celeste.Scene.Diagnostics.Presentation.SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            int entityIndex = 0;
            foreach (var entity in Entities.CommittedRenderEntities)
            {
                if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible)
                {
                    var owner =
                        global::Celeste.Scene.Diagnostics.Presentation.SceneRenderObservationMetadata.Read(entity);
                    var previous = observer.EnterEntity(entityIndex, in owner);
                    try
                    {
                        global::Celeste.Scene.Diagnostics.Presentation.SceneEntityRenderObservation.RenderBody(entity,
                            context);
                    }
                    finally
                    {
                        observer.Exit(in previous);
                    }
                }

                entityIndex++;
            }
        }

        public void RenderEntitiesOnly(global::Celeste.Core.Rendering.ISourceRenderContext context,
            SceneTagSet matchTags)
        {
            var observer = (context as global::Celeste.Core.Rendering.Observation.ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in Entities.CommittedRenderEntities)
                    if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible
                        && ((((ISceneEntityTags)entity).Tags & matchTags).Bits != 0))
                        global::Celeste.Scene.Diagnostics.Presentation.SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            int entityIndex = 0;
            foreach (var entity in Entities.CommittedRenderEntities)
            {
                if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible
                    && ((((ISceneEntityTags)entity).Tags & matchTags).Bits != 0))
                {
                    var owner =
                        global::Celeste.Scene.Diagnostics.Presentation.SceneRenderObservationMetadata.Read(entity);
                    var previous = observer.EnterEntity(entityIndex, in owner);
                    try
                    {
                        global::Celeste.Scene.Diagnostics.Presentation.SceneEntityRenderObservation.RenderBody(entity,
                            context);
                    }
                    finally
                    {
                        observer.Exit(in previous);
                    }
                }

                entityIndex++;
            }
        }

        public void RenderEntitiesOnlyFullMatch(global::Celeste.Core.Rendering.ISourceRenderContext context,
            SceneTagSet matchTags)
        {
            var observer = (context as global::Celeste.Core.Rendering.Observation.ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in Entities.CommittedRenderEntities)
                    if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible
                        && ((((ISceneEntityTags)entity).Tags & matchTags) == matchTags))
                        global::Celeste.Scene.Diagnostics.Presentation.SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            int entityIndex = 0;
            foreach (var entity in Entities.CommittedRenderEntities)
            {
                if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible
                    && ((((ISceneEntityTags)entity).Tags & matchTags) == matchTags))
                {
                    var owner =
                        global::Celeste.Scene.Diagnostics.Presentation.SceneRenderObservationMetadata.Read(entity);
                    var previous = observer.EnterEntity(entityIndex, in owner);
                    try
                    {
                        global::Celeste.Scene.Diagnostics.Presentation.SceneEntityRenderObservation.RenderBody(entity,
                            context);
                    }
                    finally
                    {
                        observer.Exit(in previous);
                    }
                }

                entityIndex++;
            }
        }

        public void RenderEntitiesExcept(global::Celeste.Core.Rendering.ISourceRenderContext context,
            SceneTagSet excludeTags)
        {
            var observer = (context as global::Celeste.Core.Rendering.Observation.ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in Entities.CommittedRenderEntities)
                    if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible
                        && ((((ISceneEntityTags)entity).Tags & excludeTags).Bits == 0))
                        global::Celeste.Scene.Diagnostics.Presentation.SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            int entityIndex = 0;
            foreach (var entity in Entities.CommittedRenderEntities)
            {
                if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible
                    && ((((ISceneEntityTags)entity).Tags & excludeTags).Bits == 0))
                {
                    var owner =
                        global::Celeste.Scene.Diagnostics.Presentation.SceneRenderObservationMetadata.Read(entity);
                    var previous = observer.EnterEntity(entityIndex, in owner);
                    try
                    {
                        global::Celeste.Scene.Diagnostics.Presentation.SceneEntityRenderObservation.RenderBody(entity,
                            context);
                    }
                    finally
                    {
                        observer.Exit(in previous);
                    }
                }

                entityIndex++;
            }
        }

        public void DebugRenderEntities(global::Celeste.Core.Rendering.ISourceRenderContext context,
            object actualCamera)
        {
            Entities.DebugRender(context, actualCamera, actualSceneIdentity);
        }
    }
}
