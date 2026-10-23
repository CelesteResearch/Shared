using Celeste.Scene.Scheduling;

namespace Celeste.Scene.Tracking
{
    public interface ISceneEntityTagScene
    {
        void SetEntityTags(object identity, SceneTagSet value);
    }
}
