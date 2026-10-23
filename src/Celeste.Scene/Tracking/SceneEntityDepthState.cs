using System;

namespace Celeste.Scene.Tracking
{
    // These are the actual source Entity fields. The owner retains this object
    // across scene memberships; registries and scheduler entries only reference it.
    public class SceneEntityDepthState
    {
        public int RawDepth;
        public double ActualDepth;

        public SceneEntityDepthState(int depth = 0)
        {
            RawDepth = depth;
            // Entity.actualDepth has its CLR default, including nonzero ctor Depth.
        }

        public void SetDepth(int value, object scene, object identity)
        {
            if (RawDepth == value) return;
            RawDepth = value;
            if (scene == null) return;
            if (!(scene is ISceneEntityDepthScene depthScene))
                throw new InvalidOperationException("The actual source scene has no depth capability.");
            depthScene.SetEntityActualDepth(identity, this);
        }
    }
}
