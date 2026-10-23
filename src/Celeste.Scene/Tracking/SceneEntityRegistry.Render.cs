using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.Diagnostics;
using Celeste.Core.Rendering.Observation;
using Celeste.Core.Scheduling;
using Celeste.Scene.Diagnostics.Presentation;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityRegistry
    {
        // Original EntityList render passes enumerate the committed live list without sorting or snapshots.
        public bool HasVisibleEntities(int matchTags)
        {
            foreach (var entity in entities)
                if (((ISourceEntityVisibility)entity).Visible
                    && (((ISceneEntityTags)entity).Tags.Bits & matchTags) != 0)
                    return true;
            return false;
        }

        public void Render(ISourceRenderContext context)
        {
            var observer = (context as ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in entities)
                    if (((ISourceEntityVisibility)entity).Visible)
                        SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            var entityIndex = 0;
            foreach (var entity in entities)
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

        public void RenderOnly(int matchTags, ISourceRenderContext context)
        {
            var observer = (context as ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in entities)
                    if (((ISourceEntityVisibility)entity).Visible
                        && (((ISceneEntityTags)entity).Tags.Bits & matchTags) != 0)
                        SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            var entityIndex = 0;
            foreach (var entity in entities)
            {
                if (((ISourceEntityVisibility)entity).Visible
                    && (((ISceneEntityTags)entity).Tags.Bits & matchTags) != 0)
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

        public void RenderOnlyFullMatch(int matchTags, ISourceRenderContext context)
        {
            var observer = (context as ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in entities)
                    if (((ISourceEntityVisibility)entity).Visible
                        && (((ISceneEntityTags)entity).Tags.Bits & matchTags) == matchTags)
                        SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            var entityIndex = 0;
            foreach (var entity in entities)
            {
                if (((ISourceEntityVisibility)entity).Visible
                    && (((ISceneEntityTags)entity).Tags.Bits & matchTags) == matchTags)
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

        public void RenderExcept(int excludeTags, ISourceRenderContext context)
        {
            var observer = (context as ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in entities)
                    if (((ISourceEntityVisibility)entity).Visible
                        && (((ISceneEntityTags)entity).Tags.Bits & excludeTags) == 0)
                        SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            var entityIndex = 0;
            foreach (var entity in entities)
            {
                if (((ISourceEntityVisibility)entity).Visible
                    && (((ISceneEntityTags)entity).Tags.Bits & excludeTags) == 0)
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

        public void DebugRender(ISourceRenderContext context, object actualCamera,
            object actualScene)
        {
            ((ISourceEntityListDebugRenderHooksEnvironment)
                    ((ISourceEngineContextScene)actualScene).EngineContext)
                .EntityListDebugRenderHooks.InvokeBeforeDebugRender(actualCamera);
            foreach (var entity in entities)
                ((ISourceEntityDebugRender)entity).DebugRender(context, actualCamera);
            ((ISourceEntityListDebugRenderHooksEnvironment)
                    ((ISourceEngineContextScene)actualScene).EngineContext)
                .EntityListDebugRenderHooks.InvokeAfterDebugRender(this, actualCamera);
        }
    }
}
