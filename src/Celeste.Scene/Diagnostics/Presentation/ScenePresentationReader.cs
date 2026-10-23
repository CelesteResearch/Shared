using System;
using Celeste.Core.Components;
using Celeste.Scene.Entities;

namespace Celeste.Scene.Diagnostics.Presentation
{
    public static class ScenePresentationReader
    {
        // A custom entity may still expose useful standard tiles/images. This only marks
        // whether those components alone cover its entity Render dispatch.
        // Call once per concrete CLR type, not once per entity/frame.
        public static bool UsesStandardComponentRender(Type entityType)
        {
            if (entityType == null) throw new ArgumentNullException(nameof(entityType));
            if (!typeof(ISourceEntityRender).IsAssignableFrom(entityType)) return false;
            var map = entityType.GetInterfaceMap(typeof(ISourceEntityRender));
            return map.TargetMethods[0].DeclaringType == typeof(SceneEntityState);
        }
    }
}
