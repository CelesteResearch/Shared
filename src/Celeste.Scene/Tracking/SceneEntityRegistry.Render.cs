using Celeste.Scene.Scheduling;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityRegistry
    {
        // Original EntityList render passes enumerate the committed live list without sorting or snapshots.
        public bool HasVisibleEntities(int matchTags)
        {
            foreach (var entity in entities)
                if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible
                    && ((((ISceneEntityTags)entity).Tags.Bits & matchTags) != 0))
                    return true;
            return false;
        }

        public void Render(global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            var observer = (context as global::Celeste.Core.Rendering.Observation.ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in entities)
                    if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible)
                        global::Celeste.Scene.Diagnostics.Presentation.SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            int entityIndex = 0;
            foreach (var entity in entities)
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

        public void RenderOnly(int matchTags, global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            var observer = (context as global::Celeste.Core.Rendering.Observation.ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in entities)
                    if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible
                        && ((((ISceneEntityTags)entity).Tags.Bits & matchTags) != 0))
                        global::Celeste.Scene.Diagnostics.Presentation.SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            int entityIndex = 0;
            foreach (var entity in entities)
            {
                if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible
                    && ((((ISceneEntityTags)entity).Tags.Bits & matchTags) != 0))
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

        public void RenderOnlyFullMatch(int matchTags, global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            var observer = (context as global::Celeste.Core.Rendering.Observation.ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in entities)
                    if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible
                        && ((((ISceneEntityTags)entity).Tags.Bits & matchTags) == matchTags))
                        global::Celeste.Scene.Diagnostics.Presentation.SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            int entityIndex = 0;
            foreach (var entity in entities)
            {
                if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible
                    && ((((ISceneEntityTags)entity).Tags.Bits & matchTags) == matchTags))
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

        public void RenderExcept(int excludeTags, global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            var observer = (context as global::Celeste.Core.Rendering.Observation.ISourceRenderObservationContext)
                ?.RenderObserver;
            if (observer == null)
            {
                foreach (var entity in entities)
                    if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible
                        && ((((ISceneEntityTags)entity).Tags.Bits & excludeTags) == 0))
                        global::Celeste.Scene.Diagnostics.Presentation.SceneEntityRenderObservation.RenderBody(entity,
                            context);
                return;
            }

            int entityIndex = 0;
            foreach (var entity in entities)
            {
                if (((global::Celeste.Core.Components.ISourceEntityVisibility)entity).Visible
                    && ((((ISceneEntityTags)entity).Tags.Bits & excludeTags) == 0))
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

        public void DebugRender(global::Celeste.Core.Rendering.ISourceRenderContext context, object actualCamera,
            object actualScene)
        {
            ((global::Celeste.Core.Rendering.Diagnostics.ISourceEntityListDebugRenderHooksEnvironment)
                    ((global::Celeste.Core.Scheduling.ISourceEngineContextScene)actualScene).EngineContext)
                .EntityListDebugRenderHooks.InvokeBeforeDebugRender(actualCamera);
            foreach (var entity in entities)
                ((global::Celeste.Core.Components.ISourceEntityDebugRender)entity).DebugRender(context, actualCamera);
            ((global::Celeste.Core.Rendering.Diagnostics.ISourceEntityListDebugRenderHooksEnvironment)
                    ((global::Celeste.Core.Scheduling.ISourceEngineContextScene)actualScene).EngineContext)
                .EntityListDebugRenderHooks.InvokeAfterDebugRender(this, actualCamera);
        }
    }
}
