using System;

namespace Celeste.Scene.Tracking
{
    public interface ISceneEntityDepthScene
    {
        // Scene.SetActualDepth may operate before/without EntityList membership.
        // Its writes still affect the actual fields and scene counter, not a slot.
        void SetEntityActualDepth(object identity, SceneEntityDepthState fields);
    }
}
