using Celeste.Core.Display;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Physics.Collision;
using Celeste.Graphics.Display;

namespace Celeste.Scene.Entities
{
    public static class SourceEntityDebugRendering
    {
        public static void Render(object actualEntity, ISourceRenderContext context, object actualCamera)
        {
            var entity = (ISourceEntityCollider)actualEntity;
            if (entity.Collider != null)
                entity.Collider.Render(actualCamera, entity.Collidable ? PackedColor.Red : PackedColor.DarkRed,
                    context);
            ((ISourceOwnedComponentList)actualEntity).OwnedComponents.DebugRender(context, actualCamera);
        }
    }
}
