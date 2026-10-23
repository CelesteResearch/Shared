using Celeste.Core.Rendering;
using Celeste.Core.Rendering.Observation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Diagnostics.Presentation
{
    public static class SceneEntityRenderObservation
    {
        internal static void RenderBody(object entity, ISourceRenderContext context)
        {
            var diagnostics = global::Celeste.Core.Framework.Timing.SourceFrameDiagnostics.Current;
            if (diagnostics?.EntityRenderTypePassActive != true)
            {
                ((global::Celeste.Core.Components.ISourceEntityRender)entity).Render(context);
                return;
            }

            int token = diagnostics.BeginEntityRenderType(entity);
            try
            {
                ((global::Celeste.Core.Components.ISourceEntityRender)entity).Render(context);
            }
            finally
            {
                diagnostics.EndEntityRenderType(token);
            }
        }


        public static void Render(SceneEntityState entity, ISourceRenderContext context)
        {
            var observer = (context as ISourceRenderObservationContext)?.RenderObserver;
            if (observer == null)
            {
                RenderBody(entity, context);
                return;
            }

            int entityIndex = entity.Scene is ISourceScene scene
                ? scene.SourceScene.Entities.FindCommittedRenderIndex(entity)
                : -1;
            var owner = SceneRenderObservationMetadata.Read(entity);
            var previous = observer.EnterNestedEntity(entityIndex, in owner);
            try
            {
                RenderBody(entity, context);
            }
            finally
            {
                observer.Exit(in previous);
            }
        }
    }
}
