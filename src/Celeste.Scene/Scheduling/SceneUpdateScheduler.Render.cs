using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.Observation;
using Celeste.Scene.Diagnostics.Presentation;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Scheduling
{
    public sealed partial class SceneUpdateScheduler
    {
        // Original EntityList render passes enumerate the committed live list without sorting or snapshots.
        public bool HasVisibleEntities(SceneTagSet matchTags)
        {
            foreach (var entity in Entities.CommittedRenderEntities)
                if (((ISourceEntityVisibility)entity).Visible
                    && (((ISceneEntityTags)entity).Tags & matchTags).Bits != 0)
                    return true;
            return false;
        }

        public void RenderEntities(ISourceRenderContext context)
        {
            var observer = (context as ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in Entities.CommittedRenderEntities)
                    if (((ISourceEntityVisibility)entity).Visible)
                        SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            var entityIndex = 0;
            foreach (var entity in Entities.CommittedRenderEntities)
            {
                if (((ISourceEntityVisibility)entity).Visible)
                {
                    var owner =
                        SceneRenderObservationMetadata.Read(entity);
                    var previous = observer.EnterEntity(entityIndex, in owner);
                    try
                    {
                        SceneEntityRenderObservation.RenderBody(entity,
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

        public void RenderEntitiesOnly(ISourceRenderContext context,
            SceneTagSet matchTags)
        {
            var observer = (context as ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in Entities.CommittedRenderEntities)
                    if (((ISourceEntityVisibility)entity).Visible
                        && (((ISceneEntityTags)entity).Tags & matchTags).Bits != 0)
                        SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            var entityIndex = 0;
            foreach (var entity in Entities.CommittedRenderEntities)
            {
                if (((ISourceEntityVisibility)entity).Visible
                    && (((ISceneEntityTags)entity).Tags & matchTags).Bits != 0)
                {
                    var owner =
                        SceneRenderObservationMetadata.Read(entity);
                    var previous = observer.EnterEntity(entityIndex, in owner);
                    try
                    {
                        SceneEntityRenderObservation.RenderBody(entity,
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

        public void RenderEntitiesOnlyFullMatch(ISourceRenderContext context,
            SceneTagSet matchTags)
        {
            var observer = (context as ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in Entities.CommittedRenderEntities)
                    if (((ISourceEntityVisibility)entity).Visible
                        && (((ISceneEntityTags)entity).Tags & matchTags) == matchTags)
                        SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            var entityIndex = 0;
            foreach (var entity in Entities.CommittedRenderEntities)
            {
                if (((ISourceEntityVisibility)entity).Visible
                    && (((ISceneEntityTags)entity).Tags & matchTags) == matchTags)
                {
                    var owner =
                        SceneRenderObservationMetadata.Read(entity);
                    var previous = observer.EnterEntity(entityIndex, in owner);
                    try
                    {
                        SceneEntityRenderObservation.RenderBody(entity,
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

        public void RenderEntitiesExcept(ISourceRenderContext context,
            SceneTagSet excludeTags)
        {
            var observer = (context as ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in Entities.CommittedRenderEntities)
                    if (((ISourceEntityVisibility)entity).Visible
                        && (((ISceneEntityTags)entity).Tags & excludeTags).Bits == 0)
                        SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            var entityIndex = 0;
            foreach (var entity in Entities.CommittedRenderEntities)
            {
                if (((ISourceEntityVisibility)entity).Visible
                    && (((ISceneEntityTags)entity).Tags & excludeTags).Bits == 0)
                {
                    var owner =
                        SceneRenderObservationMetadata.Read(entity);
                    var previous = observer.EnterEntity(entityIndex, in owner);
                    try
                    {
                        SceneEntityRenderObservation.RenderBody(entity,
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

        public void DebugRenderEntities(ISourceRenderContext context,
            object actualCamera)
        {
            Entities.DebugRender(context, actualCamera, ActualSceneIdentity);
        }
    }
}
